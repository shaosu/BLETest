using BLETest1.Devices;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Windows.Devices.Bluetooth;
using Windows.Devices.Bluetooth.Advertisement;
using Windows.Devices.Bluetooth.GenericAttributeProfile;
using Windows.Devices.Enumeration;
using Windows.Foundation;
using Windows.Security.Cryptography;


namespace BLETest1.ViewModel
{

    public enum MsgType
    {
        NotifyTxt,
        BleDevice,
        BleSendData,
        BleRecData,
    }

    public class ReadResult
    {   /// <summary>
        /// 操作结果
        /// </summary>
        public bool State { get; set; }

        /// <summary>
        /// 消息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 读取字节数据
        /// </summary>
        public byte[] Content { get; set; }

        /// <summary>
        /// 读取大小
        /// </summary>
        public int ByteCount { get; set; }

        /// <summary>
        /// 获取十进制
        /// </summary>
        /// <returns></returns>
        public uint ToUint()
        {
            try
            {
                Array.Reverse(Content);
                return BitConverter.ToUInt32(Content, 0);
            }
            catch
            {
                return 0;
            }
        }

        public override string ToString()
        {
            if (Content == null) Content = Array.Empty<byte>();
            var sss = Content.Select(a => a.ToString("X2")).ToArray();
            string hex = string.Join(" ", sss);
            return $"{Message}:{hex}";
        }

    }

    public class BleCore
    {

        private bool asyncLock = false;

        /// <summary>
        /// 搜索蓝牙设备对象
        /// </summary>
        private DeviceWatcher deviceWatcher;

        /// <summary>
        /// 当前连接的服务
        /// </summary>
        public GattDeviceService CurrentService { get; set; }

        /// <summary>
        /// 当前连接的蓝牙设备
        /// </summary>
        public MyBluetoothLEDeviceEx CurrentDevice { get; set; }

        /// <summary>
        /// 写特征对象
        /// </summary>
        public GattCharacteristic CurrentWriteCharacteristic { get; set; }

        /// <summary>
        /// 写名称特征对象
        /// </summary>
        public GattCharacteristic CurrentNameCharacteristic { get; set; }

        /// <summary>
        /// 通知特征对象
        /// </summary>
        public GattCharacteristic CurrentNotifyCharacteristic { get; set; }

        /// <summary>
        /// 特性通知类型通知启用
        /// </summary>
        private const GattClientCharacteristicConfigurationDescriptorValue
            CHARACTERSITIC_NOTIFICATION_TYPE = GattClientCharacteristicConfigurationDescriptorValue.Notify;

        /// <summary>
        /// 存储检测到的设备
        /// </summary>
        private List<MyBluetoothLEDeviceEx> DevicesList = new List<MyBluetoothLEDeviceEx>();

        /// <summary>
        /// 定义搜索蓝牙设备委托
        /// </summary>
        /// <param name="type"></param>
        /// <param name="bluetoothLEDevice"></param>
        public delegate void DevicewatcherChangedEvent(MsgType type, MyBluetoothLEDeviceEx bluetoothLEDevice);

        public delegate void DeviceRSSIChangedChangedEvent(MyBluetoothLEDeviceEx bluetoothLEDevice, short rssi);

        /// <summary>
        /// 搜索蓝牙事件
        /// </summary>
        public event DevicewatcherChangedEvent DevicewatcherChanged;
        public event DeviceRSSIChangedChangedEvent DeviceRSSIChangedChanged;

        /// <summary>
        /// 获取服务委托
        /// </summary>
        /// <param name="gattDeviceService"></param>
        public delegate void GattDeviceServiceAddedEvent(GattDeviceService gattDeviceService);

        /// <summary>
        /// 获取服务事件
        /// </summary>
        public event GattDeviceServiceAddedEvent GattDeviceServiceAdded;

        /// <summary>
        /// 获取特征委托
        /// </summary>
        /// <param name="gattCharacteristic"></param>
        public delegate void CharacteristicAddedEvent(GattCharacteristic gattCharacteristic);

        /// <summary>
        /// 获取特征事件
        /// </summary>
        public event CharacteristicAddedEvent CharacteristicAdded;

        /// <summary>
        /// 提示信息委托
        /// </summary>
        /// <param name="type"></param>
        /// <param name="message"></param>
        /// <param name="data"></param>
        public delegate void MessageChangedEvent(MsgType type, string message, byte[] data = null);

        /// <summary>
        /// 提示信息事件
        /// </summary>
        public event MessageChangedEvent MessageChanged;

        /// <summary>
        /// 当前连接蓝牙的Mac
        /// </summary>
        private string CurrentDeviceMAC { get { return CurrentDevice.MAC; } }

        public BleCore()
        {

        }


        /// <summary>
        /// 搜索蓝牙设备 方法1
        /// </summary>
        public void StartBleDevicewatcher_1()
        {

            string[] requestedProperties = {
                "System.Devices.Aep.DeviceAddress",
                "System.Devices.Aep.IsConnected",
                "System.Devices.Aep.Bluetooth.Le.IsConnectable" ,
                "System.Devices.Aep.SignalStrength",
                "System.Devices.Aep.IsPresent"
           };
            string aqsAllBluetoothLEDevices = "(System.Devices.Aep.ProtocolId:=\"{bb7bb05e-5972-42b5-94fc-76eaa7084d49}\")";

            string Selector = "System.Devices.Aep.ProtocolId:=\"{bb7bb05e-5972-42b5-94fc-76eaa7084d49}\"";
            string selector = "(" + Selector + ")" + " AND (System.Devices.Aep.CanPair:=System.StructuredQueryType.Boolean#True OR System.Devices.Aep.IsPaired:=System.StructuredQueryType.Boolean#True)";


            this.deviceWatcher =
                DeviceInformation.CreateWatcher(
                 //  aqsAllBluetoothLEDevices,

                 //  BluetoothLEDevice.GetDeviceSelectorFromPairingState(false),
                 selector,
                    requestedProperties,
                    DeviceInformationKind.AssociationEndpoint);

            //在监控之前注册事件
            this.deviceWatcher.Added += DeviceWatcher_Added;
            this.deviceWatcher.Stopped += DeviceWatcher_Stopped;
            this.deviceWatcher.Updated += DeviceWatcher_Updated; ;
            this.deviceWatcher.Start();
            string msg = "自动发现设备中..";
            this.MessageChanged(MsgType.NotifyTxt, msg);
        }



        BluetoothLEAdvertisementWatcher watcher;
        /// <summary>
        /// 搜索蓝牙设备 方法2
        /// </summary>
        public void StartBleDevicewatcher(short minDB)
        {
            watcher = new BluetoothLEAdvertisementWatcher();

            watcher.ScanningMode = BluetoothLEScanningMode.Active;

            // only activate the watcher when we're recieving values >= -80
            watcher.SignalStrengthFilter.InRangeThresholdInDBm = minDB;

            // stop watching if the value drops below -90 (user walked away)
            watcher.SignalStrengthFilter.OutOfRangeThresholdInDBm = (short)(minDB - 20);

            // register callback for when we see an advertisements
            watcher.Received += OnAdvertisementReceived;
            watcher.Stopped += Watcher_Stopped;

            // wait 5 seconds to make sure the device is really out of range
            watcher.SignalStrengthFilter.OutOfRangeTimeout = TimeSpan.FromMilliseconds(5000);
            watcher.SignalStrengthFilter.SamplingInterval = TimeSpan.FromMilliseconds(2000);

            // starting watching for advertisements
            watcher.Start();
            string msg = "自动发现设备中..";

            this.MessageChanged(MsgType.NotifyTxt, msg);
        }

        private void Watcher_Stopped(BluetoothLEAdvertisementWatcher sender, BluetoothLEAdvertisementWatcherStoppedEventArgs args)
        {
            DevicesList.Clear();
            string msg = "自动发现设备停止";
            this.MessageChanged(MsgType.NotifyTxt, msg);
        }
        public string FilterName = string.Empty;

        private void OnAdvertisementReceived(BluetoothLEAdvertisementWatcher watcher, BluetoothLEAdvertisementReceivedEventArgs eventArgs)
        {
            if (eventArgs.RawSignalStrengthInDBm <= -100) return;



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

                            Boolean contain = false;
                            MyBluetoothLEDeviceEx curEx = null;

                            int c = DevicesList.Count;
                            for (int i = 0; i < c; i++) //过滤重复的设备
                            {
                                MyBluetoothLEDeviceEx device = DevicesList[i];
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
                                byte[] _Bytes1 = BitConverter.GetBytes(currentDevice.BluetoothAddress);
                                Array.Reverse(_Bytes1);
                                string mac = BitConverter.ToString(_Bytes1, 2, 6).Replace('-', ':').ToLower();
                                var rssi = eventArgs.RawSignalStrengthInDBm;
                                string blName = currentDevice.Name;
                                MyBluetoothLEDeviceEx bleEx = new MyBluetoothLEDeviceEx();
                                bleEx.BLE = currentDevice;
                                bleEx.MAC = mac;
                                bleEx.RSSI = rssi;
                                bleEx.Name = blName;

                                this.DevicesList.Add(bleEx);
                                this.MessageChanged(MsgType.NotifyTxt, "发现设备：" + currentDevice.Name + "  address:" + mac + " rssi:" + rssi);
                                this.DevicewatcherChanged(MsgType.BleDevice, bleEx);
                            }
                            else
                            {
                                if (curEx != null)
                                {
                                    if (curEx.RSSI != eventArgs.RawSignalStrengthInDBm)
                                    {
                                        curEx.RSSI = eventArgs.RawSignalStrengthInDBm;
                                        //DeviceRSSIChangedChanged?.Invoke(curEx, curEx.RSSI);
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



        /// <summary>
        /// 停止搜索
        /// </summary>
        public void StopBleDeviceWatcher()
        {
            if (deviceWatcher != null)
                this.deviceWatcher.Stop();

            if (watcher != null && watcher.Status == BluetoothLEAdvertisementWatcherStatus.Started)
                watcher.Stop();
        }

        /// <summary>
        /// 获取发现的蓝牙设备
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void DeviceWatcher_Added(DeviceWatcher sender, DeviceInformation args)
        {

            this.MessageChanged(MsgType.NotifyTxt, "发现设备：" + args.Id);
            this.Matching(args.Id, args);
        }

        private void DeviceWatcher_Updated(DeviceWatcher sender, DeviceInformationUpdate args)
        {

        }

        /// <summary>
        /// 停止搜索蓝牙设备
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void DeviceWatcher_Stopped(DeviceWatcher sender, object args)
        {
            string msg = "自动发现设备停止";
            this.MessageChanged(MsgType.NotifyTxt, msg);
        }


        /// <summary>
        /// 匹配
        /// </summary>
        /// <param name="device"></param>
        public void StartMatching(MyBluetoothLEDeviceEx device)
        {
            this.CurrentDevice = device;
        }

        /// <summary>
        /// 获取蓝牙服务
        /// </summary>
        public async void FindService()
        {
            if (CurrentDevice == null) return;
            /*var gattServices = this.CurrentDevice.GattServices;
            foreach(GattDeviceService ser in gattServices)
            {
                this.GattDeviceServiceAdded(ser);
            }*/

            this.CurrentDevice.BLE.GetGattServicesAsync().Completed = async (asyncInfo, asyncStatu) =>
            {
                if (asyncStatu == AsyncStatus.Completed)
                {
                    var sevices = asyncInfo.GetResults().Services;
                    foreach (GattDeviceService ser in sevices)
                    {
                        this.GattDeviceServiceAdded(ser);
                        //  FindCharacteristic(ser);
                    }
                }
            };
        }


        public async void FindCharacteristic(GattDeviceService gattDeviceService)
        {
            /* this.CurrentService = gattDeviceService;
             foreach(var c in gattDeviceService.GetAllCharacteristics())
             {
                 this.CharacteristicAdded(c);
             }*/


            gattDeviceService.GetCharacteristicsAsync().Completed = async (asyncInfo, asyncStatu) =>
            {
                if (asyncStatu == AsyncStatus.Completed)
                {
                    var chara = asyncInfo.GetResults().Characteristics;
                    foreach (GattCharacteristic c in chara)
                    {
                        this.CharacteristicAdded(c);
                    }
                }
            };
        }


        /// <summary>
        /// 获取操作,
        /// TODO:同时控制几个特征,然后连接
        /// </summary>
        /// <param name="gattCharacteristic"></param>
        /// <returns></returns>
        public async Task SetOpteron(GattCharacteristic gattCharacteristic)
        {
            if (gattCharacteristic.CharacteristicProperties == GattCharacteristicProperties.WriteWithoutResponse)
            {
                this.CurrentWriteCharacteristic = gattCharacteristic;
            }
            if (gattCharacteristic.CharacteristicProperties.HasFlag(GattCharacteristicProperties.Notify))
            {
                this.CurrentNotifyCharacteristic = gattCharacteristic;
                this.CurrentNotifyCharacteristic.ProtectionLevel = GattProtectionLevel.Plain;
                this.CurrentNotifyCharacteristic.ValueChanged += Characteristic_ValueChanged;
                await this.EnableNotifications(CurrentNotifyCharacteristic);
            }


            if (gattCharacteristic.CharacteristicProperties.HasFlag(GattCharacteristicProperties.Read)
                || gattCharacteristic.CharacteristicProperties.HasFlag(GattCharacteristicProperties.Write))
            {
                this.CurrentNameCharacteristic = gattCharacteristic;
            }

            if (gattCharacteristic.CharacteristicProperties.HasFlag(GattCharacteristicProperties.Write))
            {
                this.CurrentWriteCharacteristic = gattCharacteristic;
            }

            this.Connect();
        }

        public async Task SetOpteron(GattCharacteristic write, GattCharacteristic notify)
        {

            if (write.CharacteristicProperties.HasFlag(GattCharacteristicProperties.WriteWithoutResponse)
                || write.CharacteristicProperties.HasFlag(GattCharacteristicProperties.Write))
            {
                this.CurrentWriteCharacteristic = write;
            }

            if (notify.CharacteristicProperties.HasFlag(GattCharacteristicProperties.Notify))
            {
                this.CurrentNotifyCharacteristic = notify;
                try
                {
                    // 设置特征值的ValueChanged事件处理器
                    CurrentNotifyCharacteristic.ValueChanged += Characteristic_ValueChanged;

                    // 将特征的客户端特征配置设置为通知模式
                    var status = await CurrentNotifyCharacteristic.WriteClientCharacteristicConfigurationDescriptorAsync(GattClientCharacteristicConfigurationDescriptorValue.Notify);

                    if (status != GattCommunicationStatus.Success)
                    {
                        throw new Exception($"启用通知失败: {status}");
                    }

                    string msg = "通知已启用<" + this.CurrentDeviceMAC;
                    this.MessageChanged(MsgType.NotifyTxt, msg);
                }
                catch (Exception ex)
                {
                    CurrentNotifyCharacteristic.ValueChanged -= Characteristic_ValueChanged;
                    throw new Exception($"启用通知时出错: {ex.Message}", ex);
                }

                // this.CurrentNotifyCharacteristic.ProtectionLevel = GattProtectionLevel.Plain;
                // this.CurrentNotifyCharacteristic.ValueChanged += Characteristic_ValueChanged;
                //await this.EnableNotifications(CurrentNotifyCharacteristic);
            }
            this.Connect();
        }



        private async Task Connect()
        {
            string msg = "正在连接设备<" + this.CurrentDeviceMAC + "> ..";
            this.MessageChanged(MsgType.NotifyTxt, msg);
            this.CurrentDevice.BLE.ConnectionStatusChanged += CurrentDevice_ConnectionStatusChanged;
            this.IsConnect = true;
        }

        public bool IsConnect = false;
        /// <summary>
        /// 主动断开连接
        /// </summary>
        public void DisConnect()
        {
            IsConnect = false;

            //使用到的服务 （我这里仅仅使用了一个服务）
            CurrentService?.Dispose();
            //蓝牙
            if (CurrentDevice != null)
                CurrentDevice.BLE.ConnectionStatusChanged -= CurrentDevice_ConnectionStatusChanged;
            //关闭
            CurrentDevice?.BLE?.Dispose();

            CurrentDevice = null;
            CurrentService = null;

            //特征值
            CurrentNameCharacteristic = null;
            CurrentWriteCharacteristic = null;
            CurrentNotifyCharacteristic = null;
        }



        private void CurrentDevice_ConnectionStatusChanged(BluetoothLEDevice sender, object args)
        {
            if (sender.ConnectionStatus == BluetoothConnectionStatus.Disconnected &&
                  CurrentDeviceMAC != null)
            {
                string msg = "设备已断开，自动重连";
                MessageChanged(MsgType.NotifyTxt, msg);
                IsConnect = false;
                if (!asyncLock)
                {
                    asyncLock = true;
                    string mac = CurrentDeviceMAC;
                    this.CurrentDevice.BLE.Dispose();
                    this.CurrentDevice = null;

                    this.CurrentNotifyCharacteristic = null;
                    this.CurrentWriteCharacteristic = null;
                    SelectDeviceFromIdAsync(mac);
                }
            }
            else
            {
                string msg = "设备已连接";
                MessageChanged(MsgType.NotifyTxt, msg);
                IsConnect = true;
            }
        }

        /// <summary>
        /// 搜索到的蓝牙设备
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private async Task Matching(string id, DeviceInformation args = null)
        {

            try
            {
                BluetoothLEDevice.FromIdAsync(id).Completed = async (asyncInfo, asyncStatus) =>
                {
                    if (asyncStatus == AsyncStatus.Completed)
                    {
                        BluetoothLEDevice bleDevice = asyncInfo.GetResults();
                        if (bleDevice.Name.StartsWith("Bluetooth"))
                        {
                            return;
                        }

                        byte[] _Bytes1 = BitConverter.GetBytes(bleDevice.BluetoothAddress);
                        Array.Reverse(_Bytes1);
                        string macAddress = BitConverter.ToString(_Bytes1, 2, 6).Replace('-', ':').ToLower();



                        MyBluetoothLEDeviceEx tmp2 = new MyBluetoothLEDeviceEx();
                        tmp2.Name = bleDevice.Name;
                        tmp2.MAC = macAddress;

                        MyBluetoothLEDeviceEx tmp = this.DevicesList.Where(p => p.Name == bleDevice.Name).FirstOrDefault();
                        if (tmp == null)
                        {//没有添加过
                         //  bool state = IsConnectable(bleDevice.DeviceInformation);
                            this.DevicesList.Add(tmp2);

                            this.DevicewatcherChanged(MsgType.BleDevice, tmp2);
                        }
                    }
                };
            }
            catch (Exception e)
            {
                string msg = "没有发现设备" + e.ToString();
                this.MessageChanged(MsgType.NotifyTxt, msg);
                this.StopBleDeviceWatcher();
            }
        }


        /// <summary>
        /// 主动断开连接
        /// </summary>
        public void Dispose()
        {

            CurrentService?.Dispose();
            CurrentDevice?.BLE?.Dispose();

            CurrentDevice = null;
            CurrentService = null;
            CurrentWriteCharacteristic = null;
            CurrentNotifyCharacteristic = null;
            this.MessageChanged(MsgType.NotifyTxt, "主动断开连接");
        }

        /// <summary>
        /// 按MAC地址直接组装设备ID查找设备
        /// </summary>
        /// <param name="MAC"></param>
        /// <returns></returns>
        public async Task SelectDeviceFromIdAsync(string MAC)
        {
            CurrentDevice = null;

            BluetoothAdapter.GetDefaultAsync().Completed = async (asyncInfo, asyncStatus) =>
            {
                if (asyncStatus == AsyncStatus.Completed)
                {
                    BluetoothAdapter bluetoothAdapter = asyncInfo.GetResults();
                    // ulong 转为byte数组
                    byte[] _Bytes1 = BitConverter.GetBytes(bluetoothAdapter.BluetoothAddress);
                    Array.Reverse(_Bytes1);
                    string macAddress = BitConverter.ToString(_Bytes1, 2, 6).Replace('-', ':').ToLower();
                    string Id = "BluetoothLe#BluetoothLe" + macAddress + "-" + MAC;
                    await Matching(Id);
                }
            };
        }



        /// <summary>
        /// 设置特征对象为接收通知对象
        /// </summary>
        /// <param name="characteristic"></param>
        /// <returns></returns>
        public async Task EnableNotifications(GattCharacteristic characteristic)
        {
            string msg = "收通知对象=" + CurrentDevice.BLE.ConnectionStatus;
            this.MessageChanged(MsgType.NotifyTxt, msg);

            characteristic.WriteClientCharacteristicConfigurationDescriptorAsync(CHARACTERSITIC_NOTIFICATION_TYPE).Completed = async (asyncInfo, asyncStatus) =>
            {
                if (asyncStatus == AsyncStatus.Completed)
                {
                    GattCommunicationStatus status = asyncInfo.GetResults();
                    if (status == GattCommunicationStatus.Unreachable)
                    {
                        msg = "设备不可用";
                        this.MessageChanged(MsgType.NotifyTxt, msg);
                        if (CurrentNotifyCharacteristic != null && !asyncLock)
                        {
                            await this.EnableNotifications(CurrentNotifyCharacteristic);
                        }
                    }
                    asyncLock = false;
                    msg = "设备连接状态" + status;
                    this.MessageChanged(MsgType.NotifyTxt, msg);
                }
            };
        }

        /// <summary>
        /// 接受到蓝牙数据
        /// </summary>
        private void Characteristic_ValueChanged(GattCharacteristic sender, GattValueChangedEventArgs args)
        {
            byte[] data;
            CryptographicBuffer.CopyToByteArray(args.CharacteristicValue, out data);
            string str = ASCIIEncoding.UTF8.GetString(data).Replace("\0", string.Empty);
            string hex = string.Join(" ", data.Select(a => a.ToString("X2")).ToArray());
            string format = $"通知:{str}  =>Hex:{hex} ";
            // 解析
            if (sender.Uuid.ToString().ToLower() == MiTemperatureSensor.ChartUUID.ToLower())
            {
                var tmp = MiTemperatureSensor.ParseTemperatureData(data);
                format += tmp.ToString();
            }

            this.MessageChanged(MsgType.BleRecData, format, data);
        }

        /// <summary>
        /// 发送数据接口
        /// </summary>
        /// <returns></returns>
        public async Task Write(byte[] data)
        {
            if (CurrentWriteCharacteristic != null)
            {
                CurrentWriteCharacteristic.WriteValueAsync(CryptographicBuffer.CreateFromByteArray(data), GattWriteOption.WriteWithResponse);
                // string str = "发送数据:" + BitConverter.ToString(data);
                string hex = string.Join(" ", data.Select(a => a.ToString("X2")).ToArray());
                string str = "发送数据:" + hex;
                this.MessageChanged(MsgType.BleSendData, str, data);
            }

        }


        /// <summary>
        /// 异步读数据
        /// </summary>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public async Task<ReadResult> ReadAsync()
        {
            if (CurrentWriteCharacteristic == null) return new ReadResult();

            string Value;
            ReadResult result = new ReadResult();
            try
            {
                GattReadResult ReadResult = await CurrentWriteCharacteristic.ReadValueAsync(BluetoothCacheMode.Uncached);

                switch (ReadResult.Status)
                {
                    case GattCommunicationStatus.Success:
                        result.State = true;
                        CryptographicBuffer.CopyToByteArray(ReadResult.Value, out byte[] data);

                        string str = BitConverter.ToString(data);
                        Value = str.Replace("-", " ");

                        result.Content = data;
                        result.Message = "读取成功";
                        result.ByteCount = data.Length;
                        break;
                    case GattCommunicationStatus.Unreachable:
                        result.State = false;
                        result.Message = "读取失败 详情：此时无法与该设备进行通信。";
                        if (ReadResult.ProtocolError != null)
                        {
                            result.Content = new byte[] { (byte)ReadResult.ProtocolError };
                        }
                        break;
                    case GattCommunicationStatus.ProtocolError:
                        result.State = false;
                        result.Message = "读取失败 详情：出现了 GATT 通信协议错误。";
                        if (ReadResult.ProtocolError != null)
                        {
                            result.Content = new byte[] { (byte)ReadResult.ProtocolError };
                        }
                        break;
                    case GattCommunicationStatus.AccessDenied:
                        result.State = false;
                        result.Message = "读取失败 详情：拒绝访问。";
                        if (ReadResult.ProtocolError != null)
                        {
                            result.Content = new byte[] { (byte)ReadResult.ProtocolError };
                        }
                        break;
                    default:
                        break;
                }
                return result;
            }
            catch (Exception ex)
            {
                result.State = false;
                result.Message = "读取特征发生异常 详情：" + ex.Message;
                result.Content = new byte[0];
                return result;
            }

        }


        /// <summary>
        /// 发送数据接口
        /// </summary>
        /// <returns></returns>
        public async Task WriteName(byte[] data)
        {
            if (CurrentNameCharacteristic != null)
            {
                CurrentNameCharacteristic.WriteValueAsync(CryptographicBuffer.CreateFromByteArray(data), GattWriteOption.WriteWithResponse);
                string hex = string.Join(" ", data.Select(a => a.ToString("X2")).ToArray());
                //string str = "发送数据:" + BitConverter.ToString(data);
                string str = "发送数据:" + hex;
                this.MessageChanged(MsgType.BleSendData, str, data);
            }
        }

    }
}

