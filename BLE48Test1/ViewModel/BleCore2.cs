using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.Devices.Bluetooth;
using Windows.Devices.Bluetooth.Advertisement;
using Windows.Devices.Bluetooth.GenericAttributeProfile;
using Windows.Foundation;
using Windows.Security.Cryptography;

namespace BLETest1.ViewModel
{
    public delegate void ScanResultEventHandler(object sender, List<MyBluetoothLEDeviceEx> e);
    public delegate void ServiceResultEventHandler(object sender, MyBluetoothLEDeviceEx dev, List<GattDeviceService> e);
    public delegate void CharacterResultEventHandler(object sender, MyBluetoothLEDeviceEx dev, GattDeviceService service, List<GattCharacteristic> e);
    public delegate void DataRecvEventHandler(object sender, MyBluetoothLEDeviceEx dev, List<byte> e);
    public delegate void ConnectChangedEventHandler(object sender, MyBluetoothLEDeviceEx dev, bool conn);

    public interface IBleCore2
    {
        event ScanResultEventHandler ScanResultEvent;
        event ServiceResultEventHandler ServiceResultEvent;
        event CharacterResultEventHandler CharacterResultEvent;
        event DataRecvEventHandler DataRecvEvent;
        event ConnectChangedEventHandler ConnectChangedEvent;

        void StartScan(int scanSeconds, short minDb, string FilterName);

        void FindService(int tomeOutSec, MyBluetoothLEDeviceEx dev);

        void FindCharacteristic(int tomeOutSec, MyBluetoothLEDeviceEx dev, GattDeviceService service);

        Task<bool> ConnectDevice(ConnectedDeviceParam param);
        bool DisConnectDevice(ConnectedDeviceParam param);
    }

    public class ConnectedDeviceParam
    {
        public MyBluetoothLEDeviceEx dev;
        public GattDeviceService service;
        public GattCharacteristic write;
        public GattCharacteristic notify;
    }

    public class BleCore2 : IBleCore2
    {
        public event ScanResultEventHandler ScanResultEvent;
        public event ServiceResultEventHandler ServiceResultEvent;
        public event CharacterResultEventHandler CharacterResultEvent;
        public event DataRecvEventHandler DataRecvEvent;
        public event ConnectChangedEventHandler ConnectChangedEvent;

        public List<MyBluetoothLEDeviceEx> DeviceList = new List<MyBluetoothLEDeviceEx>();
        public ConnectedDeviceParam ConnectedDevice = new ConnectedDeviceParam();
        public bool IsConnect = false;

        public ConnectedDeviceParam BuildConnectedDevice(ConnectedDeviceParam param, string writeUUID, string notifyUUID)
        {
            try
            {
                ConnectedDevice.dev = param.dev;
                ConnectedDevice.service = param.service;
                string serviceUUID = param.service.Uuid.ToString().ToLower();
                var dev = param.dev;
                ConnectedDevice.write = dev.CharacterList[serviceUUID].Where(x => x.Uuid.ToString().ToLower() == writeUUID.ToLower()).First();
                ConnectedDevice.notify = dev.CharacterList[serviceUUID].Where(x => x.Uuid.ToString().ToLower() == notifyUUID.ToLower()).First();
                param.write = ConnectedDevice.write;
                param.notify = ConnectedDevice.notify;
                return ConnectedDevice;
            }
            catch (Exception ex)
            {

            }
            return param;
        }

        public void SendData(byte[] data)
        {
            if (ConnectedDevice.write == null) return;
            var writer = new Windows.Storage.Streams.DataWriter();
            writer.WriteBytes(data);
            var writeBuffer = writer.DetachBuffer();
            var status = ConnectedDevice.write.WriteValueAsync(writeBuffer, GattWriteOption.WriteWithResponse);
        }

        public async Task<bool> ConnectDevice(ConnectedDeviceParam param)
        {
            param.notify.ValueChanged -= NotifyCharacteristic_ValueChanged;
            param.notify.ValueChanged += NotifyCharacteristic_ValueChanged;

            var status = await param.notify.WriteClientCharacteristicConfigurationDescriptorAsync(GattClientCharacteristicConfigurationDescriptorValue.Notify);
            if (status != GattCommunicationStatus.Success)
            {
                IsConnect = false;
                return IsConnect;
            }

            param.dev.BLE.ConnectionStatusChanged -= BLE_ConnectionStatusChanged;
            param.dev.BLE.ConnectionStatusChanged += BLE_ConnectionStatusChanged;
            IsConnect = true;
            return IsConnect;
        }

        private bool asyncLock = false;
        private void BLE_ConnectionStatusChanged(BluetoothLEDevice sender, object args)
        {
            if (sender.ConnectionStatus == BluetoothConnectionStatus.Disconnected)
            {
                string msg = "设备已断开，自动重连";
                IsConnect = false;
                if (!asyncLock)
                {
                    asyncLock = true;
                }
                ConnectChangedEvent?.Invoke(this, ConnectedDevice.dev, IsConnect);
            }
            else
            {
                IsConnect = true;
                ConnectChangedEvent?.Invoke(this, ConnectedDevice.dev, IsConnect);
            }
        }

        private void NotifyCharacteristic_ValueChanged(GattCharacteristic sender, GattValueChangedEventArgs args)
        {
            byte[] data;
            CryptographicBuffer.CopyToByteArray(args.CharacteristicValue, out data);
            string str = ASCIIEncoding.UTF8.GetString(data).Replace("\0", string.Empty);
            string hex = string.Join(" ", data.Select(a => a.ToString("X2")).ToArray());
            string format = $"通知:{str}  =>Hex:{hex}";

            DataRecvEvent?.Invoke(this, ConnectedDevice.dev, data.ToList());
        }


        /// <summary>
        /// 关闭服务的所有特征
        /// </summary>
        private async Task CloseServiceCharacteristics(GattDeviceService service)
        {
            if (service == null) return;

            try
            {
                var characteristicsResult = await service.GetCharacteristicsAsync();

                if (characteristicsResult.Status == GattCommunicationStatus.Success)
                {
                    foreach (var characteristic in characteristicsResult.Characteristics)
                    {
                        // 如果是通知特征，先禁用通知
                        if (characteristic.CharacteristicProperties.HasFlag(GattCharacteristicProperties.Notify))
                        {
                            await characteristic.WriteClientCharacteristicConfigurationDescriptorAsync(GattClientCharacteristicConfigurationDescriptorValue.None);
                        }
                        characteristic.Service?.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"关闭特征时出错: {ex.Message}");
            }
        }

        public bool DisConnectDevice(ConnectedDeviceParam param)
        {
            try
            {
                IsConnect = false;
                var dev = param.dev;
                if (dev != null)
                {
                    foreach (var sev in dev.ServiceList)
                    {
                        CloseServiceCharacteristics(sev).Wait();
                        sev.Session?.Dispose();
                        sev.Dispose();
                    }
                }

                if (param.dev?.BLE != null)
                {
                    param.dev.BLE.ConnectionStatusChanged -= BLE_ConnectionStatusChanged;
                }

                if (ConnectedDevice != null)
                {
                    //关闭该蓝牙的所有服务
                    ConnectedDevice.service?.Session?.Dispose();
                    ConnectedDevice.service?.Dispose();
                    ConnectedDevice.dev?.BLE?.Dispose();
                    ConnectedDevice.write = null;
                    ConnectedDevice.notify = null;
                    ConnectedDevice.service = null;
                    ConnectedDevice.dev = null;
                }
                param.service?.Session?.Dispose();
                param.service?.Dispose();

                param.dev?.BLE.Dispose();
                if (param.dev != null)
                    param.dev.BLE = null;
                param.dev = null;
                param.service = null;
                param.write = null;
                param.notify = null;

                IsConnect = false;
                return IsConnect;
            }
            catch (Exception ex)
            {
                if (param.dev != null)
                {
                    // 强制释放
                    param.dev.BLE?.Dispose();
                    param.dev.BLE = null;
                }
            }
            IsConnect = false;
            return IsConnect;
        }

        public void FindCharacteristic(int tomeOutSec, MyBluetoothLEDeviceEx dev, GattDeviceService service)
        {
            Task.Run(() =>
            {
                DateTime start = DateTime.Now;
                FindCharacteristic(dev, service);
                while (true)
                {
                    Thread.Sleep(200);
                    if ((DateTime.Now - start).TotalSeconds > tomeOutSec)
                    {
                        break;
                    }
                }
                string uuid = service.Uuid.ToString();
                CharacterResultEvent?.Invoke(this, dev, service, dev.CharacterList[uuid]);
            });
        }

        private void FindCharacteristic(MyBluetoothLEDeviceEx dev, GattDeviceService service)
        {
            if (service == null) return;
            /* this.CurrentService = gattDeviceService;
             foreach(var c in gattDeviceService.GetAllCharacteristics())
             {
                 this.CharacteristicAdded(c);
             }*/

            service.GetCharacteristicsAsync().Completed = async (asyncInfo, asyncStatu) =>
            {
                if (asyncStatu == AsyncStatus.Completed)
                {
                    var chara = asyncInfo.GetResults().Characteristics;
                    foreach (GattCharacteristic c in chara)
                    {
                        string uuid = service.Uuid.ToString();
                        if (dev.CharacterList.ContainsKey(uuid) == false)
                        {
                            var list = new List<GattCharacteristic>();
                            list.Add(c);
                            dev.CharacterList[uuid] = list;
                        }
                        else
                        {
                            dev.CharacterList[uuid].Add(c);
                        }
                    }
                }
            };
        }

        public void FindService(int tomeOutSec, MyBluetoothLEDeviceEx dev)
        {
            Task.Run(() =>
            {
                DateTime start = DateTime.Now;
                FindService(dev);
                while (true)
                {
                    Thread.Sleep(200);
                    if ((DateTime.Now - start).TotalSeconds > tomeOutSec)
                    {
                        break;
                    }
                }
                ServiceResultEvent?.Invoke(this, dev, dev.ServiceList);
            });
        }

        /// <summary>
        /// 获取蓝牙服务
        /// </summary>
        private void FindService(MyBluetoothLEDeviceEx dev)
        {
            if (dev == null) return;

            dev.BLE.GetGattServicesAsync().Completed = async (asyncInfo, asyncStatu) =>
            {
                if (asyncStatu == AsyncStatus.Completed)
                {
                    var sevices = asyncInfo.GetResults().Services;
                    foreach (GattDeviceService ser in sevices)
                    {
                        dev.ServiceList.Add(ser);
                        //  FindCharacteristic(ser);
                    }
                }
            };
        }


        #region "  搜索蓝牙设备  "

        private short MinScanDb = -80;
        private string FilterName = string.Empty;
        public void StartScan(int scanSeconds, short minDb, string filterName)
        {
            MinScanDb = minDb;
            FilterName = filterName;
            Task.Run(() =>
            {
                StartBleDevicewatcher(minDb);
                Thread.Sleep(scanSeconds * 1000);
                watcher.Stop();
                Thread.Sleep(3 * 1000);
                ScanResultEvent?.Invoke(this, DeviceList);
            });
        }

        private BluetoothLEAdvertisementWatcher watcher;
        /// <summary>
        /// 搜索蓝牙设备方法2
        /// </summary>
        private void StartBleDevicewatcher(short minDb)
        {
            watcher = new BluetoothLEAdvertisementWatcher();
            watcher.ScanningMode = BluetoothLEScanningMode.Active;
            // only activate the watcher when we're recieving values >= -80
            watcher.SignalStrengthFilter.InRangeThresholdInDBm = minDb;
            // stop watching if the value drops below -90 (user walked away)
            watcher.SignalStrengthFilter.OutOfRangeThresholdInDBm = (short)(minDb - 20);
            // register callback for when we see an advertisements
            watcher.Received += OnAdvertisementReceived;
            watcher.Stopped += Watcher_Stopped;
            // wait 5 seconds to make sure the device is really out of range
            watcher.SignalStrengthFilter.OutOfRangeTimeout = TimeSpan.FromMilliseconds(5000);
            watcher.SignalStrengthFilter.SamplingInterval = TimeSpan.FromMilliseconds(2000);
            // starting watching for advertisements
            DeviceList = new List<MyBluetoothLEDeviceEx>();
            watcher.Start();
        }

        private void Watcher_Stopped(BluetoothLEAdvertisementWatcher sender, BluetoothLEAdvertisementWatcherStoppedEventArgs args)
        {
            string msg = "自动发现设备停止";
        }
        private void OnAdvertisementReceived(BluetoothLEAdvertisementWatcher watcher, BluetoothLEAdvertisementReceivedEventArgs eventArgs)
        {
            if (eventArgs.RawSignalStrengthInDBm < MinScanDb) return;

            BluetoothLEDevice.FromBluetoothAddressAsync(eventArgs.BluetoothAddress).Completed = async (asyncInfo, asyncStatus) =>
            {
                if (asyncStatus == AsyncStatus.Completed)
                {
                    if (asyncInfo.GetResults() == null)
                    {
                        //this.MessAgeChanged(MsgType.NotifyTxt, "没有得到结果集");
                    }
                    else
                    {
                        try
                        {
                            BluetoothLEDevice currentDevice = asyncInfo.GetResults();
                            if (currentDevice.Name.StartsWith("Bluetooth"))
                            {
                                return;
                            }
                            if (string.IsNullOrWhiteSpace(FilterName) == false
                                && currentDevice.Name.Contains(FilterName) == false)
                            {
                                return;
                            }

                            bool contain = false;
                            MyBluetoothLEDeviceEx curEx = null;
                            int c = DeviceList.Count;
                            for (int i = 0; i < c; i++) //过滤重复的设备
                            {
                                MyBluetoothLEDeviceEx device = DeviceList[i];
                                if (device.BLE != null)
                                {
                                    if (device.BLE.DeviceId == currentDevice.DeviceId)
                                    {
                                        contain = true;
                                        curEx = device;
                                    }
                                }
                            }

                            if (contain == false)
                            {
                                string mac = MyBluetoothLEDeviceEx.BuildMac(currentDevice.BluetoothAddress);
                                var rssi = eventArgs.RawSignalStrengthInDBm;
                                string blName = currentDevice.Name;
                                MyBluetoothLEDeviceEx bleEx = new MyBluetoothLEDeviceEx();
                                bleEx.BLE = currentDevice;
                                bleEx.MAC = mac;
                                bleEx.RSSI = rssi;
                                bleEx.Name = blName;
                                this.DeviceList.Add(bleEx);
                            }
                            else
                            {
                                if (curEx != null)
                                {
                                    if (curEx.RSSI != eventArgs.RawSignalStrengthInDBm)
                                    {
                                        curEx.RSSI = eventArgs.RawSignalStrengthInDBm;
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                }
            };
        }

        #endregion


    }
}
