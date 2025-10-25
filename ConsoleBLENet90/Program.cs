using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Bluetooth;
using Windows.Devices.Bluetooth.Advertisement;
using Windows.Devices.Bluetooth.GenericAttributeProfile;
using Windows.Storage.Streams;

namespace BleScannerExample
{
    internal class Program
    {
        // 存储检测到的设备，避免重复处理
        private static readonly Dictionary<ulong, BluetoothLEDevice> discoveredDevices = [];
        private static BluetoothLEAdvertisementWatcher? bleWatcher;
        private static BluetoothLEDevice? connectedDevice;
        private static GattCharacteristic? heartRateCharacteristic;

        static async Task Main(string[] args)
        {
            Console.WriteLine("BLE设备扫描与连接示例");
            Console.WriteLine("按下回车键开始扫描...");
            Console.ReadLine();

            await StartBleScanning();

            Console.WriteLine("扫描进行中，按下任意键停止扫描并退出...");
            Console.ReadKey();

            StopBleScanning();
            DisconnectDevice();

            Console.WriteLine("程序结束");
        }

        /// <summary>
        /// 启动BLE设备扫描
        /// </summary>
        static async Task StartBleScanning()
        {
            try
            {
                bleWatcher = new BluetoothLEAdvertisementWatcher
                {
                    ScanningMode = BluetoothLEScanningMode.Active // 主动扫描模式，可获取更多信息
                };

                // 可选：添加服务UUID过滤，只扫描特定设备（如心率设备）
                //bleWatcher.AdvertisementFilter.Advertisement.ServiceUuids.Add(BluetoothUuidHelper.FromShortId(0x180D));

                bleWatcher.Received += async (sender, args) =>
                {
                    // 根据设备地址去重
                    if (discoveredDevices.ContainsKey(args.BluetoothAddress))
                        return;

                    try
                    {
                        // 获取蓝牙设备对象
                        var device = await BluetoothLEDevice.FromBluetoothAddressAsync(args.BluetoothAddress);
                        if (device == null) return;

                        discoveredDevices.Add(device.BluetoothAddress, device);

                        Console.WriteLine($"发现设备: {device.Name ?? "未知"} | " +
                                        $"地址: {device.BluetoothAddress:X} | " +
                                        $"信号强度: {args.RawSignalStrengthInDBm} dBm");

                        // 如果是ESP32设备，尝试连接
                        if (device.Name?.Contains("ESP32") == true ||
                            args.Advertisement.ServiceUuids.Contains(BluetoothUuidHelper.FromShortId(0x180D)))
                        {
                            Console.WriteLine("检测ESP32设备，尝试连接...");
                            await ConnectToDevice(device);
                        }
                    }
                    catch (Exception ex)
                    {
                        //Console.WriteLine($"处理设备时出错: {ex.Message}");
                    }
                };

                bleWatcher.Stopped += (sender, args) =>
                {
                    Console.WriteLine("BLE扫描已停止");
                };

                discoveredDevices.Clear();
                bleWatcher.Start();
                Console.WriteLine("BLE扫描已启动...");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"启动扫描失败: {ex.Message}");
            }
        }

        /// <summary>
        /// 连接到指定的BLE设备
        /// </summary>
        static async Task ConnectToDevice(BluetoothLEDevice device)
        {
            try
            {
                connectedDevice = device;

                // 监听连接状态变化
                device.ConnectionStatusChanged += (sender, args) =>
                {
                    Console.WriteLine($"设备连接状态: {device.ConnectionStatus}");
                    if (device.ConnectionStatus == BluetoothConnectionStatus.Disconnected)
                    {
                        Console.WriteLine("设备已断开连接");
                    }
                };

                Console.WriteLine($"正在连接设备: {device.Name}...");

                // 等待设备服务枚举完成
                await Task.Delay(1000);

                // 获取心率服务 (UUID: 0x180D)
                var servicesResult = await device.GetGattServicesAsync();
                if (servicesResult.Status != GattCommunicationStatus.Success)
                {
                    Console.WriteLine("获取服务失败");
                    return;
                }

                Console.WriteLine($"发现 {servicesResult.Services.Count} 个服务");

                foreach (var service in servicesResult.Services)
                {
                    Console.WriteLine($"服务 UUID: {service.Uuid}");

                    // 查找心率服务
                    //if (service.Uuid.Equals(BluetoothUuidHelper.FromShortId(0x180D)))
                    {
                        await SetupHeartRateService(service);
                    }
                }

                if (heartRateCharacteristic == null)
                {
                    Console.WriteLine("未找到心率服务特征");
                    return;
                }

                Console.WriteLine("设备连接并配置成功！");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"连接设备失败: {ex.Message}");
            }
        }

        /// <summary>
        /// 设置心率服务并订阅通知
        /// </summary>
        static async Task SetupHeartRateService(GattDeviceService service)
        {
            try
            {
                // 获取心率测量特征值 (UUID: 0x2A37)
                var characteristicsResult = await service.GetCharacteristicsAsync();
                if (characteristicsResult.Status != GattCommunicationStatus.Success)
                    return;

                foreach (var characteristic in characteristicsResult.Characteristics)
                {
                    Console.WriteLine($"特征值 UUID: {characteristic.Uuid}, 属性: {characteristic.CharacteristicProperties}");

                    if (characteristic.CharacteristicProperties.HasFlag(GattCharacteristicProperties.Notify))
                    {
                        heartRateCharacteristic = characteristic;
                        break;
                    }
                }

                if (heartRateCharacteristic == null)
                {
                    Console.WriteLine("未找到ESP32特征值");
                    return;
                }

                // 订阅特征值通知
                heartRateCharacteristic.ValueChanged += HeartRateMeasurementChanged;

                var status = await heartRateCharacteristic.WriteClientCharacteristicConfigurationDescriptorAsync(GattClientCharacteristicConfigurationDescriptorValue.Notify);

                if (status == GattCommunicationStatus.Success)
                {
                    Console.WriteLine("已订阅ESP32数据通知");
                }
                else
                {
                    Console.WriteLine($"订阅通知失败: {status}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"设置ESP32服务失败: {ex.Message}");
            }
        }

        /// <summary>
        /// ESP32数据变化事件处理
        /// </summary>
        private static void HeartRateMeasurementChanged(GattCharacteristic sender, GattValueChangedEventArgs args)
        {
            try
            {
                using var reader = DataReader.FromBuffer(args.CharacteristicValue);
                reader.ByteOrder = ByteOrder.LittleEndian;
                // 解析ESP32数据（根据BLE规范）
                uint c = reader.UnconsumedBufferLength;
                byte[] buff = new byte[c];
                reader.ReadBytes(buff);
                string heartRateValue = ASCIIEncoding.UTF8.GetString(buff);
            
                Console.WriteLine($"[{DateTime.Now:T}] 数据: {heartRateValue}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"解析ESP32数据失败: {ex.Message}");
            }
        }

        /// <summary>
        /// 停止BLE扫描
        /// </summary>
        static void StopBleScanning()
        {
            bleWatcher?.Stop();
            Console.WriteLine("已停止BLE扫描");
        }

        /// <summary>
        /// 断开设备连接并清理资源
        /// </summary>
        static void DisconnectDevice()
        {
            if (heartRateCharacteristic != null)
            {
                heartRateCharacteristic.ValueChanged -= HeartRateMeasurementChanged;
            }

            connectedDevice?.Dispose();
            connectedDevice = null;
            heartRateCharacteristic = null;

            foreach (var device in discoveredDevices.Values)
            {
                device?.Dispose();
            }
            discoveredDevices.Clear();

            Console.WriteLine("已断开设备连接并清理资源");
        }
    }
}