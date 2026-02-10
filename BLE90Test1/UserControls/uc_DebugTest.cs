using BLETest1.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.Devices.Bluetooth.GenericAttributeProfile;
using Windows.Devices.Radios;
using Windows.Storage.Streams;
using Windows.Devices.Bluetooth;

namespace BLETest1.UserControls
{
    public partial class uc_DebugTest : UserControlBase
    {
        BleCore bleCore = new BleCore();
        /// <summary>
        /// 存储检测到的设备
        /// </summary>
        List<MyBluetoothLEDeviceEx> DeviceList = new List<MyBluetoothLEDeviceEx>();

        /// <summary>
        /// 当前蓝牙服务列表
        /// </summary>
        List<GattDeviceService> GattDeviceServices = new List<GattDeviceService>();

        /// <summary>
        /// 当前蓝牙服务特征列表
        /// </summary>
        List<GattCharacteristic> GattCharacteristics = new List<GattCharacteristic>();

        public uc_DebugTest()
        {
            InitializeComponent();
        }

        private void btn_WriteStr_Click(object sender, EventArgs e)
        {
            try
            {
                string str = tbCode.Text;
                byte[] buffer = Encoding.UTF8.GetBytes(str);
                this.bleCore.WriteName(buffer);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
                    bleCore = new BleCore();

                    this.bleCore.MessageChanged -= BleCore_MessAgeChanged;
                    this.bleCore.DevicewatcherChanged -= BleCore_DeviceWatcherChanged;
                    this.bleCore.GattDeviceServiceAdded -= BleCore_GattDeviceServiceAdded;
                    this.bleCore.CharacteristicAdded -= BleCore_CharacteristicAdded;
                    this.bleCore.DeviceRSSIChangedChanged -= BleCore_DeviceRSSIChangedChanged;

                    this.bleCore.MessageChanged += BleCore_MessAgeChanged;
                    this.bleCore.DevicewatcherChanged += BleCore_DeviceWatcherChanged;
                    this.bleCore.GattDeviceServiceAdded += BleCore_GattDeviceServiceAdded;
                    this.bleCore.CharacteristicAdded += BleCore_CharacteristicAdded;
                    this.bleCore.DeviceRSSIChangedChanged += BleCore_DeviceRSSIChangedChanged;

                    DeviceList.Clear();
                    GattDeviceServices.Clear();
                    GattCharacteristics.Clear();
                    this.listboxMessage.Items.Clear();
                    this.listboxBleDevice.Items.Clear();
                    this.bleCore.StartBleDevicewatcher((short)num_minDb.Value);
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
            try
            {
                UI_Invoke(() =>
                {
                    this.listboxMessage.Items.Add(message);
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 搜索蓝牙设备列表
        /// </summary>
        private void BleCore_DeviceWatcherChanged(MsgType type, MyBluetoothLEDeviceEx bluetoothLEDevice)
        {

            UI_Invoke(() =>
            {
                try
                {
                    lock (lock_list)
                    {
                        this.listboxBleDevice.Items.Add(bluetoothLEDevice);
                        this.DeviceList.Add(bluetoothLEDevice);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            });

        }
        private object lock_list = new object();

        private MyBluetoothLEDeviceEx FindFromListBox(ulong BluetoothAddress, short rssi, out int index)
        {
            index = -1;
            for (int i = 0; i < listboxBleDevice.Items.Count; i++)
            {
                MyBluetoothLEDeviceEx dev = listboxBleDevice.Items[i] as MyBluetoothLEDeviceEx;
                if (dev != null && dev.BLE.BluetoothAddress == BluetoothAddress)
                {
                    dev.RSSI = rssi;
                    index = i;
                    return dev;
                }
            }
            return null;
        }

        private void BleCore_DeviceRSSIChangedChanged(MyBluetoothLEDeviceEx ble, short rssi)
        {
            UI_Invoke(() =>
            {
                try
                {
                    lock (lock_list)
                    {
                        int index;
                        var dev = FindFromListBox(ble.BLE.BluetoothAddress, rssi, out index);
                        if (dev != null)
                        {
                            dev.RSSI = rssi;
                            listboxBleDevice.BeginUpdate();
                            listboxBleDevice.Items.Clear();
                            // 添加新项
                            int c = DeviceList.Count;
                            for (int i = 0; i < c; i++)
                            {
                                listboxBleDevice.Items.Add(DeviceList[i]);
                            }
                            listboxBleDevice.EndUpdate();
                            // 或者强制重绘
                            listboxBleDevice.Refresh();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            });
        }

        /// <summary>
        /// 获取服务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnServes_Click(object sender, EventArgs e)
        {
            try
            {
                this.cmb_Server.Items.Clear();
                this.bleCore.FindService();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 获取服务列表
        /// </summary>
        /// <param name="gattDeviceService"></param>
        private void BleCore_GattDeviceServiceAdded(GattDeviceService gattDeviceService)
        {
            UI_Invoke(() =>
            {
                try
                {
                    this.cmb_Server.Items.Add(gattDeviceService.Uuid.ToString());
                    this.GattDeviceServices.Add(gattDeviceService);
                    this.btn_Features.Enabled = true;
                    if (cmb_Server.Items.Count > 0)
                    {
                        cmb_Server.SelectedIndex = cmb_Server.Items.Count - 1;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            });

        }

        /// <summary>
        /// 获取特征
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Features_Click(object sender, EventArgs e)
        {
            try
            {
                this.cmb_WriteFeatures.Items.Clear();
                cmb_NotifyFeatures.Items.Clear();
                if (this.cmb_Server.SelectedItem == null)
                {
                    MessageBox.Show("选择蓝牙服务");
                    return;
                }
                else
                {
                    var item = this.GattDeviceServices.Where(u => u.Uuid ==
                    new Guid(this.cmb_Server.SelectedItem.ToString())).FirstOrDefault();
                    //获取蓝牙特征
                    this.bleCore.FindCharacteristic(item);
                }
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// 获取特征列表
        /// </summary>
        /// <param name="gattCharacteristic"></param>
        private void BleCore_CharacteristicAdded(GattCharacteristic gattCharacteristic)
        {
            UI_Invoke(() =>
            {
                try
                {
                    this.cmb_WriteFeatures.Items.Add(gattCharacteristic.Uuid);
                    this.GattCharacteristics.Add(gattCharacteristic);
                    this.btn_OptAndConn.Enabled = true;
                    if (cmb_WriteFeatures.Items.Count > 0)
                    {
                        cmb_WriteFeatures.SelectedIndex = cmb_WriteFeatures.Items.Count - 1;
                    }

                    this.cmb_NotifyFeatures.Items.Add(gattCharacteristic.Uuid);
                    if (cmb_NotifyFeatures.Items.Count > 0)
                    {
                        cmb_NotifyFeatures.SelectedIndex = cmb_WriteFeatures.Items.Count - 1;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            });
        }

        /// <summary>
        /// 获取操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_OptAndConn_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.cmb_WriteFeatures.SelectedItem == null)
                {
                    MessageBox.Show("请选择蓝牙服务");
                    return;
                }

                var item = this.GattCharacteristics.Where(u => u.Uuid == new Guid(this.cmb_WriteFeatures.SelectedItem.ToString())).FirstOrDefault();
                //获取操作
                this.bleCore.SetOpteron(item);

                if (item.CharacteristicProperties.HasFlag(GattCharacteristicProperties.Read) ||
                    item.CharacteristicProperties.HasFlag(GattCharacteristicProperties.Write))
                {
                    this.btn_Read.Enabled = true;
                    this.btn_WriteHex.Enabled = true;
                    this.btn_WriteStr.Enabled = true;
                }

                if (item.CharacteristicProperties.HasFlag(GattCharacteristicProperties.WriteWithoutResponse))
                {
                    this.btn_WriteHex.Enabled = true;
                    this.btn_WriteStr.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_OptAndConn2_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.cmb_WriteFeatures.SelectedItem == null)
                {
                    MessageBox.Show("请选择蓝牙服务");
                    return;
                }

                var write_Uuid = cmb_WriteFeatures.SelectedItem.ToString();
                var notify_Uuid = cmb_NotifyFeatures.SelectedItem.ToString();

                GattCharacteristic write = GattCharacteristics.Where(a => a.Uuid.ToString() == write_Uuid).FirstOrDefault();
                GattCharacteristic notify = GattCharacteristics.Where(a => a.Uuid.ToString() == notify_Uuid).FirstOrDefault();

                //获取操作
                this.bleCore.SetOpteron(write, notify);
                this.btn_WriteHex.Enabled = true;
                this.btn_WriteStr.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// 断开
        /// </summary>
        private void btn_DisConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.bleCore.IsConnect)
                {
                    //找到在蓝牙列表里面执行当前蓝牙的对象
                    MyBluetoothLEDeviceEx bleEx = this.bleCore.CurrentDevice;

                    //关闭该蓝牙的所有服务
                    foreach (var sev in GattDeviceServices)
                    {
                        sev.Dispose();
                    }
                    //并清空
                    //GattDeviceServices.Clear();
                    //GattCharacteristics.Clear();
                    //蓝牙类的关闭
                    this.bleCore.DisConnect();

                    if (bleEx != null)
                    {//关闭列表中的蓝牙
                        bleEx.BLE.Dispose();
                    }
                    bleEx = null;
                }

                //cmb_Server.Items.Clear();
                cmb_Server.SelectedIndex = -1;
                cmb_Server.SelectedItem = null;
                cmb_Server.Text = string.Empty;
                //cmb_WriteFeatures.Items.Clear();
                cmb_WriteFeatures.SelectedIndex = -1;
                cmb_NotifyFeatures.SelectedIndex = -1;
                cmb_WriteFeatures.Text = string.Empty;
                //释放内存
                GC.Collect();
                btn_WriteStr.Enabled = false;
                btn_WriteHex.Enabled = false;
                btn_Read.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 读取
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Read_Click(object sender, EventArgs e)
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
            if (listboxMessage.Items.Count > 5000)
            {
                listboxMessage.Items.Clear();
            }
            AppendToLogFile(msg);
        }

        internal override void AppendToLogFile(string timeMsg)
        {
            string file = $"Log\\{DateTime.Now.ToString("yyyMMdd")}.txt";
            if (Directory.Exists("Log") == false)
            {
                Directory.CreateDirectory("Log");
            }
            File.AppendAllText(file, timeMsg + Environment.NewLine);
        }

        private void AppendMessageOfData(string msg)
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
        private void btn_WriteHex_Click(object sender, EventArgs e)
        {
            string str = txt_ReadWriteInfo.Text;
            List<byte> buffer = Form1.StringToArray(str);
            this.bleCore.Write(buffer.ToArray());
        }


        private void listboxBleDevice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listboxBleDevice.SelectedIndex == -1) return;

            if (this.listboxBleDevice.SelectedItem == null)
            {
                listboxMessage.Items.Add("请选择连接的蓝牙");
                return;
            }
            if (bleCore.IsConnect) return;

            MyBluetoothLEDeviceEx ble = this.listboxBleDevice.SelectedItem as MyBluetoothLEDeviceEx;
            if (ble == null)
            {
                listboxMessage.Items.Add("没有发现此蓝牙，请重新搜索");
                txt_SelectedBL.Text = string.Empty;
                return;
            }
            //两个蓝牙进行匹配
            bleCore.StartMatching(ble);
            string nameWithMac = $"{ble.Name} (MAC:{ble.MAC})";
            txt_SelectedBL.Text = nameWithMac;
        }

        private void btnClearLog_Click(object sender, EventArgs e)
        {
            listboxMessage.Items.Clear();
        }
        private void btn_CRC16_Click(object sender, EventArgs e)
        {
            txt_ReadWriteInfo.Text = Form1.CRC16(false, txt_ReadWriteInfo.Text);
        }

        private void btn_CRC16HL_Click(object sender, EventArgs e)
        {
            txt_ReadWriteInfo.Text = Form1.CRC16(true, txt_ReadWriteInfo.Text);
        }

        private void btn_Sleep_Click(object sender, EventArgs e)
        {
            byte[] sleepCmd = new byte[] { 0x01, 0x10, 0x00, 0x3B, 0x00, 0x01, 0x02, 0x00, 0x20, 0xA3, 0x03 };
            string hex = string.Join(" ", sleepCmd.Select(a => a.ToString("X2")).ToArray());
            txt_ReadWriteInfo.Text = hex;
        }

        private void cmb_WriteFeatures_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmb_WriteFeatures.SelectedItem == null) return;
                string uuid = cmb_WriteFeatures.SelectedItem.ToString();
                var charact = GattCharacteristics.Where(u => u.Uuid.ToString() == uuid).FirstOrDefault();
                string pps = charact.CharacteristicProperties.ToString();
                lab_PropertieWrite.Text = pps;
            }
            catch (Exception ex)
            {


            }
        }

        private void cmb_NotifyFeatures_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmb_NotifyFeatures.SelectedItem == null) return;
                string uuid = cmb_NotifyFeatures.SelectedItem.ToString();
                var charact = GattCharacteristics.Where(u => u.Uuid.ToString() == uuid).FirstOrDefault();
                string pps = charact.CharacteristicProperties.ToString();
                lab_PropertieNotify.Text = pps;
            }
            catch (Exception ex)
            {

            }
        }

        private void txt_filterName_TextChanged(object sender, EventArgs e)
        {
            if (bleCore != null)
            {
                bleCore.FilterName = txt_filterName.Text;
            }
        }

        private void btn_ReStartBL_Click(object sender, EventArgs e)
        {
            try
            {
                Task.Run(async () =>
                {
                    BluetoothController controller = new BluetoothController();
                    await controller.RestartBLUseRadio();
                });

                if (false)
                {
                    ToggleBluetoothRadio(false);
                    System.Threading.Thread.Sleep(3000);
                    ToggleBluetoothRadio(true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"打开蓝牙设置失败: {ex.Message}");
            }
        }

        // 直接控制蓝牙无线电开关
        public static void ToggleBluetoothRadio(bool enable, bool showMsg = false)
        {
            try
            {
                // 使用 PowerShell 命令控制蓝牙
                string script = enable
                    ? @"Add-Type -AssemblyName System.Runtime.WindowsRuntime
                        $asTaskGeneric = ([System.WindowsRuntimeSystemExtensions].GetMethods() | Where-Object { $_.Name -eq 'AsTask' -and $_.GetParameters().Count -eq 1 -and $_.GetParameters()[0].ParameterType.Name -eq 'IAsyncOperation`1' })[0]
                        Function Await($WinRtTask, $ResultType) {
                            $asTask = $asTaskGeneric.MakeGenericMethod($ResultType)
                            $netTask = $asTask.Invoke($null, @($WinRtTask))
                            $netTask.Wait(-1) | Out-Null
                            $netTask.Result
                        }
                        [Windows.Devices.Radios.Radio,Windows.System.Devices,ContentType=WindowsRuntime] | Out-Null
                        [Windows.Devices.Radios.RadioState,Windows.System.Devices,ContentType=WindowsRuntime] | Out-Null
                        $radios = Await ([Windows.Devices.Radios.Radio]::RequestAccessAsync()) ([Windows.Devices.Radios.RadioAccessStatus])
                        $radios = Await ([Windows.Devices.Radios.Radio]::GetRadiosAsync()) ([System.Collections.Generic.IReadOnlyList[Windows.Devices.Radios.Radio]])
                        $bluetooth = $radios | Where-Object { $_.Kind -eq 'Bluetooth' }
                        if ($bluetooth) { Await ($bluetooth.SetStateAsync('On')) ([Windows.Devices.Radios.RadioAccessStatus]) }"
                    : @"Add-Type -AssemblyName System.Runtime.WindowsRuntime
                        $asTaskGeneric = ([System.WindowsRuntimeSystemExtensions].GetMethods() | Where-Object { $_.Name -eq 'AsTask' -and $_.GetParameters().Count -eq 1 -and $_.GetParameters()[0].ParameterType.Name -eq 'IAsyncOperation`1' })[0]
                        Function Await($WinRtTask, $ResultType) {
                            $asTask = $asTaskGeneric.MakeGenericMethod($ResultType)
                            $netTask = $asTask.Invoke($null, @($WinRtTask))
                            $netTask.Wait(-1) | Out-Null
                            $netTask.Result
                        }
                        [Windows.Devices.Radios.Radio,Windows.System.Devices,ContentType=WindowsRuntime] | Out-Null
                        [Windows.Devices.Radios.RadioState,Windows.System.Devices,ContentType=WindowsRuntime] | Out-Null
                        $radios = Await ([Windows.Devices.Radios.Radio]::RequestAccessAsync()) ([Windows.Devices.Radios.RadioAccessStatus])
                        $radios = Await ([Windows.Devices.Radios.Radio]::GetRadiosAsync()) ([System.Collections.Generic.IReadOnlyList[Windows.Devices.Radios.Radio]])
                        $bluetooth = $radios | Where-Object { $_.Kind -eq 'Bluetooth' }
                        if ($bluetooth) { Await ($bluetooth.SetStateAsync('Off')) ([Windows.Devices.Radios.RadioAccessStatus]) }";

                var psi = new ProcessStartInfo
                {
                    FileName = "powershell.exe",
                    Arguments = $"-NoProfile -ExecutionPolicy Bypass -Command \"{script.Replace("\"", "\\\"")}\"",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true
                };

                using (var process = Process.Start(psi))
                {
                    process.WaitForExit(10000);
                    string error = process.StandardError.ReadToEnd();

                    if (process.ExitCode == 0 && string.IsNullOrEmpty(error))
                    {
                        if (showMsg)
                            MessageBox.Show(enable ? "蓝牙已打开" : "蓝牙已关闭", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        if (showMsg)
                            MessageBox.Show($"操作可能未成功: {error}", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                if (showMsg)
                    MessageBox.Show($"操作失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
