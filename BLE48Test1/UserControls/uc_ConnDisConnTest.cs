using BLETest1.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.Devices.Bluetooth.GenericAttributeProfile;

namespace BLETest1.UserControls
{

    public partial class uc_ConnDisConnTest : UserControlBase
    {
        int ReadDelay_ms = 500;
        ushort ReadCount = 2;
        private long SendCount = 0;
        private long RecvCount = 0;

        bool FindCharacterEnd = false;
        bool FindServiceEnd = false;
        bool ScanResultEnd = false;

        public uc_ConnDisConnTest()
        {
            InitializeComponent();
        }

        public uc_ConnDisConnTest(ListBox lst)
        {
            InitializeComponent();
            listboxMessage = lst;
        }
        private void uc_ConnDisConnTest_Load(object sender, EventArgs e)
        {
            com_BLList.SelectedIndex = 1;
            com_LoopMode.SelectedIndex = 0;
            UseStartParam();
        }
        private void UseStartParam()
        {
            if (StartParam == null) return;
            com_LoopMode.SelectedIndex = (int)StartParam.LoopReadP.LoopType;
            com_BLList.SelectedIndex = StartParam.BLSelectIndex;
            txt_MAC.Text = StartParam.MAC;
            txt_tagService.Text = StartParam.ServiceUUID;
            txt_tagWriteChar.Text = StartParam.WriteChartUUID;
            txt_tagNotifyChar.Text = StartParam.NotifyChartUUID;
            txt_filterName.Text = StartParam.FilterName;
            num_minDb.Value = StartParam.MinDB;
            num_ReadCount.Value = StartParam.LoopReadP.ReadCount;
            num_ReadDelay.Value = StartParam.LoopReadP.ReadIntervalMs;

            SendCount = StartParam.SendCount;
            RecvCount = StartParam.RecvCount;
            StartTime = StartParam.StartTime;
            if (StartTime != DateTime.MinValue)
            {
                chk_DLLDebugLoop.Checked = true;
            }
        }

        private void BulidParamAndRestart()
        {
            if (this.InvokeRequired)
            {
                Action action = BulidParamAndRestart;
                this.Invoke(action);
                return;
            }
            StartParam param = new StartParam()
            {
                RunType = RunType.LoopRead,
                MAC = txt_MAC.Text,
                StartTime = StartTime,
                SendCount = SendCount,
                RecvCount = RecvCount,
            };
            param.ServiceUUID = txt_tagService.Text;
            param.WriteChartUUID = txt_tagWriteChar.Text;
            param.NotifyChartUUID = txt_tagNotifyChar.Text;
            param.BLSelectIndex = com_BLList.SelectedIndex;
            param.FilterName = txt_filterName.Text;
            param.MinDB = (short)num_minDb.Value;
            param.LoopReadP = new LoopReadParam();
            param.LoopReadP.LoopType = com_LoopMode.SelectedIndex;
            param.LoopReadP.ReadCount = (ushort)num_ReadCount.Value;
            param.LoopReadP.ReadIntervalMs = (int)num_ReadDelay.Value;
            AppendMessageWithTime("重启中");
            StartParam.AppExitAndRestart(param);
        }

        internal override void AppendToLogFile(string timeMsg)
        {
            string file = $"Log\\循环读测试{DateTime.Now.ToString("yyyyMMdd")}.txt";
            if (Directory.Exists("Log") == false)
            {
                Directory.CreateDirectory("Log");
            }
            File.AppendAllText(file, timeMsg + Environment.NewLine);
        }

        private void btnClearLog_Click(object sender, EventArgs e)
        {
            listboxMessage.Items.Clear();
        }

        private async Task DisConnAndClear(BleCore2 ble, ConnectedDeviceParam connParam)
        {
            if (ble != null)
            {
                ble.ScanResultEvent -= Ble_ScanResultEvent;
                ble.ServiceResultEvent -= Ble_ServiceResultEvent;
                ble.CharacterResultEvent -= Ble_CharacterResultEvent;
                ble.ConnectChangedEvent -= Ble_ConnectChangedEvent;
                ble.DataRecvEvent -= Ble_DataRecvEvent;
                if (connParam != null)
                {
                    await Task.Delay(500);
                    AppendMessageWithTime("断开连接");
                    ble.DisConnectDevice(connParam);
                }
                ble = null;
                connParam = null;
            }
            GC.Collect();
        }
        static int NotFindMACCounter = 0;

        private void btn_Test_Click(object sender, EventArgs e)
        {
            string tagMac = txt_MAC.Text.ToLower();// "30:83:98:fc:b4:3e"; ; "30:83:98:FC:B4:3E"
            string tagService = txt_tagService.Text.ToLower();// "0000fff0-0000-1000-8000-00805f9b34fb";
            string tagWriteChar = txt_tagWriteChar.Text.ToLower();// "0000fff1-0000-1000-8000-00805f9b34fb";
            string tagNotifyChar = txt_tagNotifyChar.Text.ToLower();// "0000fff2-0000-1000-8000-00805f9b34fb";
            string filterName = txt_filterName.Text.Trim();
            short mindb = (short)num_minDb.Value;
            Form1.SetControlEnable(btn_Test, false);
            Form1.SetControlEnable(btn_Scan, false);

            Task.Run(async () =>
            {
                ScanResultEnd = false;
                FindServiceEnd = false;
                FindCharacterEnd = false;
                BleCore2 ble = new BleCore2();
                ConnectedDeviceParam connParam = null;
                try
                {
                    AppendMessageWithTime("扫描");
                    ble.StartScan(10, mindb, filterName);

                    ble.ScanResultEvent += Ble_ScanResultEvent;
                    ble.ServiceResultEvent += Ble_ServiceResultEvent;
                    ble.CharacterResultEvent += Ble_CharacterResultEvent;
                    ble.ConnectChangedEvent += Ble_ConnectChangedEvent;
                    ble.DataRecvEvent += Ble_DataRecvEvent;
                    connParam = new ConnectedDeviceParam();

                    for (int i = 0; i < 10; i++)
                    {
                        await Task.Delay(1000);
                        if (ScanResultEnd)
                        {
                            break;
                        }
                    }
                    AppendMessageWithTime($"扫描结果:{ble.DeviceList.Count}个");
                    for (int i = 0; i < ble.DeviceList.Count; i++)
                    {
                        var dev = ble.DeviceList[i];
                        AppendMessageWithTime($"扫描结果:{i + 1} {dev}");
                    }
                    var devex = ble.DeviceList.Where(a => a.MAC == tagMac).FirstOrDefault();
                    connParam.dev = devex;
                    if (devex == null)
                    {
                        NotFindMACCounter++;
                        AppendMessageWithTime($"重启蓝牙!");
                        BluetoothController.RestartBL(3);
                        AppendMessageWithTime($"不到指定蓝牙:{tagMac} {NotFindMACCounter}次");
                        return;
                    }
                    else
                    {
                        NotFindMACCounter = 0;
                    }
                    AppendMessageWithTime("查找服务");
                    ble.FindService(10, devex);
                    for (int i = 0; i < 10; i++)
                    {
                        await Task.Delay(1000);
                        if (FindServiceEnd)
                        {
                            break;
                        }
                    }
                    var Service = devex.ServiceList.Where(a => a.Uuid.ToString().ToLower() == tagService).First();
                    connParam.service = Service;
                    if (true)
                    {
                        AppendMessageWithTime("查找特征");
                        ble.FindCharacteristic(10, devex, Service);
                        for (int i = 0; i < 10; i++)
                        {
                            await Task.Delay(1000);
                            if (FindCharacterEnd)
                            {
                                break;
                            }
                        }

                        connParam = ble.BuildConnectedDevice(connParam, tagWriteChar, tagNotifyChar);
                        AppendMessageWithTime($"连接:{connParam.dev}");
                        await ble.ConnectDevice(connParam);

                        long minLoopCount = long.MaxValue;
                        if (LMood == LoopMode.ForConnDisConn) minLoopCount = 1;
                        if (CheckLoop == false) minLoopCount = 1;
                        for (long i = 0; i < minLoopCount; i++)
                        {
                            await Task.Delay(ReadDelay_ms);
                            byte[] sendData = Form1.BuildSendFrame(0, ReadCount);
                            string hex = string.Join(" ", sendData.Select(a => a.ToString("X2")).ToArray());
                            AppendMessageWithTime($"发送数据:{hex} 发送次数:{SendCount++}");
                            ble.SendData(sendData);

                            await Task.Delay(ReadDelay_ms);
                            AppendMessageWithTime($"发送数据:{hex} 发送次数:{SendCount++}");
                            ble.SendData(sendData);
                            FlashTJ();
                            if (CheckLoop == false) minLoopCount = 0; // 测试过程中修改,这样才会退出
                        }
                    }
                    await Task.Delay(500);
                }
                catch (Exception ex)
                {
                    AppendMessageWithTime("执行异常:" + ex.Message);
                }
                finally
                {
                    await DisConnAndClear(ble, connParam);
                    BluetoothController.RestartBL(3);
                    ble = null;
                    connParam = null;
                    AppendMessageWithTime("===执行结束===");
                    GC.Collect();
                    await Task.Delay(2000);
                    GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced, blocking: true);
                    await Task.Delay(2000);
                    FlashTJ();
      
                    if (CheckLoop && NotFindMACCounter >= AutoRestartCount)
                    {
                        BulidParamAndRestart();
                    }
                    else
                    {
                        Form1.SetControlEnable(btn_Test, true);
                        Form1.SetControlEnable(btn_Scan, true);
                    }
                }
            });
        }

        private void Ble_ConnectChangedEvent(object sender, MyBluetoothLEDeviceEx dev, bool conn)
        {
            try
            {
                if (dev == null)
                {
                    string hex = $"连接状态:{conn}";
                    AppendMessageWithTime(hex);
                }
                else
                {
                    string hex = $"{dev.Name} MAC:{dev.MAC} 连接状态:{conn}";
                    AppendMessageWithTime(hex);
                }
            }
            catch (Exception ex)
            {
                string hex = $"连接状态:{conn}";
                AppendMessageWithTime(hex);
            }

        }

        private void Ble_CharacterResultEvent(object sender, MyBluetoothLEDeviceEx dev, GattDeviceService service, List<GattCharacteristic> e)
        {
            FindCharacterEnd = true;
        }

        private void Ble_ServiceResultEvent(object sender, MyBluetoothLEDeviceEx dev, List<GattDeviceService> e)
        {
            FindServiceEnd = true;
        }


        private void Ble_ScanResultEvent(object sender, List<MyBluetoothLEDeviceEx> e)
        {
            ScanResultEnd = true;
        }

        private void Ble_DataRecvEvent(object sender, MyBluetoothLEDeviceEx dev, List<byte> data)
        {
            string hex = string.Join(" ", data.Select(a => a.ToString("X2")).ToArray());
            if (data.Count >= 9 && data[1] == 3)
            {
                string mac = string.Empty;
                if (dev != null)
                    mac = dev.MAC;
                var args = new HexDataEventArgs(mac, data.ToArray());
                PubMod.ShortHL hl = 0;
                hl.HByte = args.Data[3];
                hl.LByte = args.Data[4];
                args.Value1 = new ItemValueDw("电流", hl.sdata * 0.01, "A");
                hl.HByte = args.Data[5];
                hl.LByte = args.Data[6];
                args.Value2 = new ItemValueDw("总电压", hl.data * 0.01, "V");
                AppendMessageWithTime("接收数据:" + args.ToString() + $" 接收次数:{RecvCount++}");
            }
            else
            {
                AppendMessageWithTime("接收数据:" + hex + $" 接收次数:{RecvCount++}");
            }
        }

        private void ChangeBLParam(IBLConnTagParam param)
        {
            txt_tagService.Text = param.tagService.ToUpper();
            txt_tagWriteChar.Text = param.tagWriteChar.ToUpper();
            txt_tagNotifyChar.Text = param.tagNotifyChar.ToUpper();
        }
        private void com_BLList_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (com_BLList.SelectedIndex)
            {
                case 0:
                    ChangeBLParam(new BLConnTagParamESP());
                    break;
                case 1:
                    ChangeBLParam(new BLConnTagParamGuoMing());
                    break;
                default:
                    break;
            }
        }

        private Timer dllTimer = null;
        private void chk_DLLDebugLoop_CheckedChanged(object sender, EventArgs e)
        {
            if (dllTimer == null)
            {
                dllTimer = new Timer();
                dllTimer.Interval = 5 * 1000;
                dllTimer.Tick += DllTimer_Tick;
            }

            dllTimer.Enabled = chk_DLLDebugLoop.Checked;// 停止时钟
            CheckLoop = chk_DLLDebugLoop.Checked;
            if (dllTimer.Enabled == true & StartParam == null)
            {
                StartTime = DateTime.Now;
                AppendMessageWithTime("开始时间:" + StartTime.ToString("yyyy-MM-dd HH:mm:ss"));
            }
            StartParam = null;
            DllTimer_Tick(sender, e);
        }

        private DateTime StartTime = DateTime.MinValue;
        private bool CheckLoop = false;
        private void DllTimer_Tick(object sender, EventArgs e)
        {
            if (btn_Test.Enabled)
            {
                btn_Test_Click(sender, e);
            }
            FlashTJ();
        }

        private void num_ReadDelay_ValueChanged(object sender, EventArgs e)
        {
            ReadDelay_ms = (int)num_ReadDelay.Value;
        }

        private void num_ReadCount_ValueChanged(object sender, EventArgs e)
        {
            ReadCount = (ushort)num_ReadCount.Value;
        }

        private void btn_ClearTJ_Click(object sender, EventArgs e)
        {
            var rt = MessageBox.Show("清零统计数据", "清空", MessageBoxButtons.YesNoCancel);
            if (rt == DialogResult.Yes)
            {
                SendCount = 0;
                RecvCount = 0;
                FlashTJ();
            }
        }

        private void FlashTJ()
        {
            if (txt_TJ.InvokeRequired)
            {
                Action action = FlashTJ;
                txt_TJ.Invoke(action);
                return;
            }

            if (CheckLoop)
            {
                var sp = DateTime.Now - StartTime;
                txt_TJ.Text = $"发送:{SendCount} 接收:{RecvCount}\r\n开始时间:{StartTime.ToString("yyyy-MM-dd HH:mm:ss")} 时长:{sp.TotalHours:F4}H";
            }
        }

        private void btn_FlashTJ_Click(object sender, EventArgs e)
        {
            FlashTJ();
        }
        private enum LoopMode
        {
            ForSendRecv,
            ForConnDisConn,
        }
        LoopMode LMood = LoopMode.ForConnDisConn;
        private void com_LoopMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (com_LoopMode.SelectedIndex >= 0 && com_LoopMode.SelectedIndex <= 1)
            {
                LMood = (LoopMode)com_LoopMode.SelectedIndex;
            }

        }

        private void num_minDb_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btn_Scan_Click(object sender, EventArgs e)
        {
            string filterName = txt_filterName.Text.Trim();
            short mindb = (short)num_minDb.Value;
            Form1.SetControlEnable(btn_Test, false);
            Form1.SetControlEnable(btn_Scan, false);

            Task.Run(async () =>
            {
                ScanResultEnd = false;
                BleCore2 ble = new BleCore2();
                ConnectedDeviceParam connParam = null;
                try
                {
                    AppendMessageWithTime("扫描");
                    ble.StartScan(10, mindb, filterName);

                    ble.ScanResultEvent += Ble_ScanResultEvent;
                    connParam = new ConnectedDeviceParam();

                    for (int i = 0; i < 10; i++)
                    {
                        await Task.Delay(1000);
                        if (ScanResultEnd)
                        {
                            break;
                        }
                    }
                    AppendMessageWithTime($"扫描结果:{ble.DeviceList.Count}个");
                    for (int i = 0; i < ble.DeviceList.Count; i++)
                    {
                        var dev = ble.DeviceList[i];
                        AppendMessageWithTime($"扫描结果:{i + 1} {dev}");
                    }
                    await Task.Delay(500);
                }
                catch (Exception ex)
                {
                    AppendMessageWithTime("执行异常:" + ex.Message);
                }
                finally
                {
                    if (ble != null)
                    {
                        ble.ScanResultEvent -= Ble_ScanResultEvent;
                    }
                    ble = null;
                    connParam = null;
                    AppendMessageWithTime("===执行结束===");
                    GC.Collect();
                    Form1.SetControlEnable(btn_Test, true);
                    Form1.SetControlEnable(btn_Scan, true);
                }
            });
        }

        int AutoRestartCount = 5;
        private void nmu_AutoRestartCount_ValueChanged(object sender, EventArgs e)
        {
            AutoRestartCount = (int)nmu_AutoRestartCount.Value;
        }
    }
}
