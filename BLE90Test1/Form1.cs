using BLETest1.ViewModel;
using System.Data;
using System.Text;
using Windows.Devices.Bluetooth.GenericAttributeProfile;

namespace BLETest1
{
    public partial class Form1 : Form
    {
        BleCore bleCore = new BleCore();
        /// <summary>
        /// 存储检测到的设备
        /// </summary>
        List<Windows.Devices.Bluetooth.BluetoothLEDevice> DeviceList = new List<Windows.Devices.Bluetooth.BluetoothLEDevice>();

        /// <summary>
        /// 当前蓝牙服务列表
        /// </summary>
        List<GattDeviceService> GattDeviceServices = new List<GattDeviceService>();

        /// <summary>
        /// 当前蓝牙服务特征列表
        /// </summary>  
        List<GattCharacteristic> GattCharacteristics = new List<GattCharacteristic>();

        public Form1()
        {
            InitializeComponent();
  
            CheckForIllegalCrossThreadCalls = false;
            this.bleCore.MessageChanged += BleCore_MessAgeChanged;
            this.bleCore.DevicewatcherChanged += BleCore_DeviceWatcherChanged;
            this.bleCore.GattDeviceServiceAdded += BleCore_GattDeviceServiceAdded;
            this.bleCore.CharacteristicAdded += BleCore_CharacteristicAdded;
            this.Init();
        }
        private void Init()
        {
            this.Load += BlueForm_Load;
            //开始
            // btnWriteStr.Click += btnWriteStr_Click;
            //搜索蓝牙
            //this.btnSearch.Click += btnSearch_Click;
            //获取服务
            //this.btnServes.Click += BtnServes_Click;
            //获取特征
            //this.btnFeatures.Click += BtnFeatures_Click;
            //获取操作及连接
            //this.btn_OptAndConn.Click += btn_OptAndConn_Click;

            this.FormClosing += BlueForm_FormClosing;
        }

        private void BlueForm_Load(object sender, EventArgs e)
        {

        }



        private void btnWriteStr_Click(object sender, EventArgs e)
        {
            string str = tbCode.Text;

            byte[] buffer = Encoding.UTF8.GetBytes(str);

            this.bleCore.WriteName(buffer);

        }


        bool Closing = false;
        private void BlueForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Closing = true;
            bleCore.Dispose();
        }
        private const string Search = "扫描";

        /// <summary>
        /// 搜索蓝牙
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.btnSearch.Text == Search)
                {
                    this.listboxMessage.Items.Clear();
                    this.listboxBleDevice.Items.Clear();
                    this.bleCore.StartBleDevicewatcher();
                    this.btnSearch.Text = "停止";
                }
                else
                {
                    this.bleCore.StopBleDeviceWatcher();
                    this.btnSearch.Text = Search;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        /// <summary>
        /// 提示消息
        /// </summary>
        private void BleCore_MessAgeChanged(MsgType type, string message, byte[] data)
        {
            if (Closing) return;
            //RunAsync(() =>
            //{
            this.listboxMessage.Items.Add(message);
            //});
        }

        /// <summary>
        /// 搜索蓝牙设备列表
        /// </summary>
        private void BleCore_DeviceWatcherChanged(MsgType type, Windows.Devices.Bluetooth.BluetoothLEDevice bluetoothLEDevice)
        {
            if (Closing) return;

            this.listboxBleDevice.Items.Add(bluetoothLEDevice.Name);
            this.DeviceList.Add(bluetoothLEDevice);
        }

        /// <summary>
        /// 获取服务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnServes_Click(object sender, EventArgs e)
        {
            this.cmbServer.Items.Clear();
            this.bleCore.FindService();
        }

        /// <summary>
        /// 获取服务列表
        /// </summary>
        /// <param name="gattDeviceService"></param>
        private void BleCore_GattDeviceServiceAdded(GattDeviceService gattDeviceService)
        {
            // RunAsync(() =>
            //  {
            this.cmbServer.Items.Add(gattDeviceService.Uuid.ToString());
            this.GattDeviceServices.Add(gattDeviceService);
            this.btnFeatures.Enabled = true;
            if (cmbServer.Items.Count > 0)
            {
                cmbServer.SelectedIndex = cmbServer.Items.Count - 1;
            }

            //   });
        }

        /// <summary>
        /// 获取特征
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnFeatures_Click(object sender, EventArgs e)
        {
            this.cmbFeatures.Items.Clear();
            if (this.cmbServer.SelectedItem == null)
            {
                MessageBox.Show("选择蓝牙服务");
                return;
            }
            else
            {
                var item = this.GattDeviceServices.Where(u => u.Uuid ==
                new Guid(this.cmbServer.SelectedItem.ToString())).FirstOrDefault();
                //获取蓝牙特征
                this.bleCore.FindCharacteristic(item);
            }
        }

        /// <summary>
        /// 获取特征列表
        /// </summary>
        /// <param name="gattCharacteristic"></param>
        private void BleCore_CharacteristicAdded(GattCharacteristic gattCharacteristic)
        {
            // RunAsync(() =>
            //  {
            this.cmbFeatures.Items.Add(gattCharacteristic.Uuid);
            this.GattCharacteristics.Add(gattCharacteristic);
            this.btn_OptAndConn.Enabled = true;
            if (cmbFeatures.Items.Count > 0)
            {
                cmbFeatures.SelectedIndex = cmbFeatures.Items.Count - 1;
            }

            //  });
        }


        /// <summary>
        /// 获取操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_OptAndConn_Click(object sender, EventArgs e)
        {
            if (this.cmbFeatures.SelectedItem == null)
            {
                MessageBox.Show("请选择蓝牙服务");
                return;
            }

            var item = this.GattCharacteristics.Where(u => u.Uuid == new Guid(this.cmbFeatures.SelectedItem.ToString())).FirstOrDefault();
            //获取操作
            this.bleCore.SetOpteron(item);

            if (item.CharacteristicProperties.HasFlag(GattCharacteristicProperties.Read) ||
                item.CharacteristicProperties.HasFlag(GattCharacteristicProperties.Write))
            {
                this.btnRead.Enabled = true;
                this.btnWriteHex.Enabled = true;
                this.btnWriteStr.Enabled = true;
            }
        }


        /// <summary>
        /// 读取
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnRead_Click(object sender, EventArgs e)
        {
            Task.Factory.StartNew(async () =>
            {
                ReadResult varrt = await this.bleCore.ReadAsync();
                AppendMessage(varrt.ToString());
                string Content = ASCIIEncoding.UTF8.GetString(varrt.Content);
                AppendMessageOfData(Content);
            });
        }

        void AppendMessage(string msg)
        {
            if (this.InvokeRequired)
            {
                Action<string> action = AppendMessage;
                this.Invoke(action, msg);
                return;
            }

            listboxMessage.Items.Add(msg);
        }
        void AppendMessageOfData(string msg)
        {
            if (this.InvokeRequired)
            {
                Action<string> action = AppendMessageOfData;
                this.Invoke(action, msg);
                return;
            }

            txt_Read.Text = msg;
        }

        /// <summary>
        /// 写入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnWriteHex_Click(object sender, EventArgs e)
        {
            string str = tbReadWriteInfo.Text;
            List<byte> buffer = StringToArray(str);
            this.bleCore.Write(buffer.ToArray());
        }

        //断开
        private void btn_DisConnect_Click(object sender, EventArgs e)
        {
            if (this.listboxBleDevice.SelectedItem != null)
            {
                //找到在蓝牙列表里面执行当前蓝牙的对象
                string deviceName = this.listboxBleDevice.SelectedItem.ToString();
                Windows.Devices.Bluetooth.BluetoothLEDevice bluetoothLEDevice =
                    this.DeviceList.Where(u => u.Name == deviceName).FirstOrDefault();

                if (bluetoothLEDevice != null)
                {//从列表中移除
                    this.DeviceList.Remove(bluetoothLEDevice);
                }

                //关闭该蓝牙的所有服务
                foreach (var sev in GattDeviceServices)
                {
                    sev.Dispose();
                }
                //并清空
                GattDeviceServices.Clear();
                GattCharacteristics.Clear();

                if (bluetoothLEDevice != null)
                {//关闭列表中的蓝牙
                    bluetoothLEDevice.Dispose();
                }
                bluetoothLEDevice = null;
                //蓝牙类的关闭
                this.bleCore.DisConnect();
            }

            cmbServer.Items.Clear();
            cmbServer.SelectedIndex = -1;
            cmbServer.SelectedItem = null;
            cmbServer.Text = string.Empty;
            cmbFeatures.Items.Clear();
            cmbFeatures.SelectedIndex = -1;
            cmbFeatures.Text = string.Empty;
            listboxBleDevice.Items.Clear();
            //释放内存
            GC.Collect();
        }

        private void listboxBleDevice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listboxBleDevice.SelectedItem == null)
            {
                listboxMessage.Items.Add("请选择连接的蓝牙");
                return;
            }

            string deviceName = this.listboxBleDevice.SelectedItem.ToString();
            Windows.Devices.Bluetooth.BluetoothLEDevice bluetoothLEDevice = this.DeviceList.Where(u => u.Name == deviceName).FirstOrDefault();

            if (bluetoothLEDevice == null)
            {
                listboxMessage.Items.Add("没有发现此蓝牙，请重新搜索");
                txt_SelectedBL.Text = string.Empty;
                return;
            }
            //两个蓝牙进行匹配
            bleCore.StartMatching(bluetoothLEDevice);
            byte[] _Bytes1 = BitConverter.GetBytes(bluetoothLEDevice.BluetoothAddress);
            Array.Reverse(_Bytes1);
            string address = BitConverter.ToString(_Bytes1, 2, 6).Replace('-', ':').ToLower();

            string nameWithMac = $"{bluetoothLEDevice.Name} (MAC:{address})";
            txt_SelectedBL.Text = nameWithMac;
        }

        private void btnClearLog_Click(object sender, EventArgs e)
        {
            listboxMessage.Items.Clear();
        }

        private List<byte> StringToArray(string str)
        {
            string[] arr = str.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            List<byte> buffer = new List<byte>();
            for (int i = 0; i < arr.Length; i++)
            {
                buffer.Add(Convert.ToByte(arr[i], 16));
            }
            return buffer;
        }

        private void CRC16(bool HL)
        {
            string str = tbReadWriteInfo.Text;
            List<byte> buffer = StringToArray(str);
            //CRC校验
            ushort crc = CRC(buffer.ToArray(), buffer.Count);

            if (HL)
            {
                buffer.Add((byte)((crc & 0xFF00) >> 8));
                buffer.Add((byte)((crc & 0x00FF)));
            }
            else
            {
                buffer.Add((byte)((crc & 0x00FF)));
                buffer.Add((byte)((crc & 0xFF00) >> 8));
            }
            string hex = string.Join(" ", buffer.Select(a => a.ToString("X2")).ToArray());
            tbReadWriteInfo.Text = hex;
        }

        private void btn_CRC16_Click(object sender, EventArgs e)
        {
            CRC16(false);
            //this.bleCore.Write(buffer);
        }

        private void btn_CRC16HL_Click(object sender, EventArgs e)
        {
            CRC16(true);
        }

        /// <summary>
        /// CRC校验
        /// </summary>
        /// <param name="data"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static ushort CRC(byte[] data, int length)
        {
            ushort tempCrcResult = 0xffff;
            for (int i = 0; i < length; i++)
            {
                tempCrcResult = (ushort)(tempCrcResult ^ data[i]);
                for (int j = 0; j < 8; j++)
                {
                    if ((tempCrcResult & 0x0001) == 1)
                        tempCrcResult = (ushort)((tempCrcResult >> 1) ^ 0xa001);
                    else tempCrcResult = (ushort)(tempCrcResult >> 1);
                }
            }
            return (tempCrcResult = (ushort)(((tempCrcResult & 0xff) << 8) | (tempCrcResult >> 8)));
        }
    }
}
