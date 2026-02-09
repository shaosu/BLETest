using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Bluetooth.GenericAttributeProfile;

namespace BLETest1.ViewModel
{
    public class MyBluetoothLEDeviceEx
    {
        public Windows.Devices.Bluetooth.BluetoothLEDevice BLE { get; set; }
        public List<GattDeviceService> ServiceList = new List<GattDeviceService>();
        public Dictionary<string, List<GattCharacteristic>> CharacterList = new Dictionary<string, List<GattCharacteristic>>();

        public short RSSI { get; set; }
        public string Name { get; set; }
        public string MAC { get; set; }

        public static string BuildMac(ulong BluetoothAddress)
        {
            byte[] _Bytes1 = BitConverter.GetBytes(BluetoothAddress);
            Array.Reverse(_Bytes1);
            string MAC = BitConverter.ToString(_Bytes1, 2, 6).Replace('-', ':').ToUpper();
            return MAC;
        }

        public MyBluetoothLEDeviceEx()
        {

        }
        public override string ToString()
        {
            return $"{Name} MAC:{MAC} RSSI:{RSSI}";
        }
    }
}
