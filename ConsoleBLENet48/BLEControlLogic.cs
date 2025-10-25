using BLETest1.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.Devices.Bluetooth;
using Windows.Devices.Bluetooth.GenericAttributeProfile;

namespace ConsoleBLENet48
{
    public class BLEControlLogic
    {
        public  void MainLoop(string[] args)
        {
            BleCore bleCore = new BleCore();
            bleCore.MessageChanged += BleCore_MessAgeChanged;
            bleCore.DevicewatcherChanged += BleCore_DeviceWatcherChanged;
            bleCore.GattDeviceServiceAdded += BleCore_GattDeviceServiceAdded;
            bleCore.CharacteristicAdded += BleCore_CharacteristicAdded;
            bleCore.StartBleDevicewatcher();
            Thread.Sleep(3000);

            Console.WriteLine("按回车开始选择ESP32设备");
            Console.ReadLine();
            // Select BLE
            string deviceName = SelectBLE("ESP32");
            if (string.IsNullOrEmpty(deviceName))
            {
                Console.WriteLine("未扫描到ESP32设备");
                return;
            }

            Windows.Devices.Bluetooth.BluetoothLEDevice bluetoothLEDevice = DeviceList.Where(u => u.Name == deviceName).FirstOrDefault();
            bleCore.StartMatching(bluetoothLEDevice);//两个蓝牙进行匹配

            bleCore.FindService();
            Thread.Sleep(1000);
            Console.WriteLine("按回车开始选择服务(默认最后一个)");
            Console.ReadLine();

            // 选择最后一个服务
            var item = GattDeviceServices.Where(u => u.Uuid == new Guid(cmbServer.Last().ToString())).FirstOrDefault();
            //获取蓝牙特征
            bleCore.FindCharacteristic(item);
            Thread.Sleep(1000);
            Console.WriteLine("按回车开始选择特征(默认最后一个)");
            Console.ReadLine();

            // 选择最后一个特征
            var itemFeatures = GattCharacteristics.Where(u => u.Uuid == new Guid(cmbFeatures.Last().ToString())).FirstOrDefault();
            //获取操作
            bleCore.SetOpteron(itemFeatures);

            Console.WriteLine("按回车开始主动读数据,按Esc退出读数据");
            for (int i = 0; i < int.MaxValue; i++)
            {
                var k = Console.ReadKey();
                if (k.Key == ConsoleKey.Escape)
                {
                    break;
                }
                Task.Factory.StartNew(async () =>
                {
                    ReadResult varrt = await bleCore.ReadAsync();
                    AppendMessage(varrt.ToString());
                    string Content = ASCIIEncoding.UTF8.GetString(varrt.Content);
                    AppendMessage(Content);
                });
                Thread.Sleep(1000);
            }

            Console.WriteLine("按任意键断开连接");
            Console.ReadKey();
            if (bluetoothLEDevice != null)
            {
                bluetoothLEDevice.Dispose();//关闭列表中的蓝牙
            }
            bluetoothLEDevice = null;
            bleCore.DisConnect();
            bleCore.Dispose();
        }

        private static List<BluetoothLEDevice> DeviceList = new List<BluetoothLEDevice>();
        /// <summary>
        /// 当前蓝牙服务列表
        /// </summary>
        private static List<GattDeviceService> GattDeviceServices = new List<GattDeviceService>();

        /// <summary>
        /// 当前蓝牙服务特征列表
        /// </summary>
        private static List<GattCharacteristic> GattCharacteristics = new List<GattCharacteristic>();

        private static List<string> listboxMessage = new List<string>();
        private static List<string> listboxBleDevice = new List<string>();
        private static List<string> cmbServer = new List<string>();
        private static List<string> cmbFeatures = new List<string>();

        private static string SelectBLE(string nameKey)
        {
            foreach (var device in listboxBleDevice)
            {
                if (device.Contains(nameKey))
                {
                    return device;
                }
            }
            return string.Empty;
        }

        static void AppendMessage(string msg)
        {
            listboxMessage.Add(msg);
            Console.WriteLine(msg);
        }

        private static void BleCore_CharacteristicAdded(GattCharacteristic gattCharacteristic)
        {
            cmbFeatures.Add(gattCharacteristic.Uuid.ToString());
            GattCharacteristics.Add(gattCharacteristic);
            Console.WriteLine("CharacteristicAdded:" + gattCharacteristic.Uuid.ToString());
        }

        private static void BleCore_GattDeviceServiceAdded(GattDeviceService gattDeviceService)
        {
            cmbServer.Add(gattDeviceService.Uuid.ToString());
            GattDeviceServices.Add(gattDeviceService);
            Console.WriteLine("GattDeviceServiceAdded:" + gattDeviceService.Uuid.ToString());
        }

        private static void BleCore_DeviceWatcherChanged(MsgType type, BluetoothLEDevice bluetoothLEDevice)
        {
            listboxBleDevice.Add(bluetoothLEDevice.Name);
            DeviceList.Add(bluetoothLEDevice);
            Console.WriteLine("DeviceWatcherChanged:" + bluetoothLEDevice.Name);
        }

        private static void BleCore_MessAgeChanged(MsgType type, string message, byte[] data)
        {
            listboxMessage.Add(message);
            Console.WriteLine("MessAgeChanged:" + message);
        }

    }

}
