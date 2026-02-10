using BLETest1.DataTypes;
using BLETest1.Devices;
using BLETest1.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.Devices.Bluetooth.GenericAttributeProfile;

namespace BLETest1.UserControls
{
    public partial class uc_SleepLoopTest : UserControlBase
    {
        double MaxSleepCurrent_mA = 5.0;
        int SleepUpLoopDelaySec = 30;
        private long SendCount = 0;
        private long RecvCount = 0;

        private long SleepCount = 0;
        private long SleepFaultCount = 0;

        private long WakeUpCount = 0;
        private long WakeUpFaultCount = 0;

        private long SleepUpLoopCount = 1;

        private bool HaveSleepFault = false;
        private bool SleepFailedStop = false;

        bool FindCharacterEnd = false;
        bool FindServiceEnd = false;
        bool ScanResultEnd = false;
        bool ConnedFlag = false;
        public uc_SleepLoopTest()
        {
            InitializeComponent();
        }

        public uc_SleepLoopTest(ListBox lst)
        {
            InitializeComponent();
            listboxMessage = lst;
        }

        private void uc_SleepLoopTest_Load(object sender, EventArgs e)
        {
            com_BLList.SelectedIndex = 1;
            com_SleepCurrentSrc.SelectedIndex = 0;
            com_VirPadPort_Click(sender, e);
            if (com_VirPadPort.Items.Count > 0) com_VirPadPort.SelectedIndex = 0;

            UseStartParam();
        }

        private void UseStartParam()
        {
            if (StartParam == null) return;

            com_BLList.SelectedIndex = StartParam.BLSelectIndex;
            txt_MAC.Text = StartParam.MAC;
            txt_tagService.Text = StartParam.ServiceUUID;
            txt_tagWriteChar.Text = StartParam.WriteChartUUID;
            txt_tagNotifyChar.Text = StartParam.NotifyChartUUID;
            txt_filterName.Text = StartParam.FilterName;
            num_minDb.Value = StartParam.MinDB;

            SendCount = StartParam.SendCount;
            RecvCount = StartParam.RecvCount;
            StartTime = StartParam.StartTime;

            SleepCount = StartParam.SleepP.SleepCount;
            SleepFaultCount = StartParam.SleepP.SleepFaultCount;
            WakeUpCount = StartParam.SleepP.WakeUpCount;
            WakeUpFaultCount = StartParam.SleepP.WakeUpFaultCount;
            SleepUpLoopCount = StartParam.SleepP.SleepUpLoopCount;

            com_VirPadPort.SelectedItem = StartParam.SleepP.VirPadCOM;
            num_SleepUpLoopDelay.Value = StartParam.SleepP.SleepUpLoopDelaySec;
            num_MaxSleepCurrent.Value = (Decimal)StartParam.SleepP.MaxSleepCurrent_mA;
            com_SleepCurrentSrc.SelectedIndex = StartParam.SleepP.SleepCurrentSrc;
            nmu_DelayForGetCurrent.Value = StartParam.SleepP.DelayForGetCurrent;

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
                RunType = RunType.LoopSleep,
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

            param.SleepP = new SleepParam()
            {
                SleepCount = SleepCount,
                SleepFaultCount = SleepFaultCount,
                WakeUpCount = WakeUpCount,
                WakeUpFaultCount = WakeUpFaultCount,
                SleepUpLoopCount = SleepUpLoopCount,
                VirPadCOM = com_VirPadPort.SelectedItem.ToString(),
                SleepUpLoopDelaySec = (int)num_SleepUpLoopDelay.Value,
                MaxSleepCurrent_mA = (double)num_MaxSleepCurrent.Value,
                SleepCurrentSrc = com_SleepCurrentSrc.SelectedIndex,
                DelayForGetCurrent = (int)nmu_DelayForGetCurrent.Value,
            };
            AppendMessageWithTime("重启中");
            StartParam.AppExitAndRestart(param);
        }


        internal override void AppendToLogFile(string timeMsg)
        {
            string file = $"Log\\循环休眠测试{DateTime.Now.ToString("yyyyMMdd")}.txt";
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
                    await Task.Delay(1);
                    AppendMessageWithTime("断开连接");
                    ble.DisConnectDevice(connParam);
                }
                ble = null;
                connParam = null;
            }
            GC.Collect();
        }
        static int NotFindMACCounter = 0;

        private byte[] sleepCmd = new byte[] { 0x01, 0x10, 0x00, 0x3B, 0x00, 0x01, 0x02, 0x00, 0x20, 0xA3, 0x03 };
        private void btn_Test_Click(object sender, EventArgs e)
        {
            string tagMac = txt_MAC.Text.ToLower();// "30:83:98:fc:b4:3e"; ; "30:83:98:FC:B4:3E"
            string tagService = txt_tagService.Text.ToLower();// "0000fff0-0000-1000-8000-00805f9b34fb";
            string tagWriteChar = txt_tagWriteChar.Text.ToLower();// "0000fff1-0000-1000-8000-00805f9b34fb";
            string tagNotifyChar = txt_tagNotifyChar.Text.ToLower();// "0000fff2-0000-1000-8000-00805f9b34fb";
            string filterName = txt_filterName.Text.Trim();
            short mindb = (short)num_minDb.Value;
            string virPadCom = com_VirPadPort.Text;

            Form1.SetControlEnable(btn_Test, false);

            Task TaskSleep = new Task(() =>
            {
                ScanResultEnd = false;
                FindServiceEnd = false;
                FindCharacterEnd = false;
                ConnedFlag = false;
                BleCore2 ble = new BleCore2();
                ConnectedDeviceParam connParam = null;
                try
                {
                    AppendMessageWithTime("扫描-休眠");
                    ble.StartScan(10, mindb, filterName);

                    ble.ScanResultEvent += Ble_ScanResultEvent;
                    ble.ServiceResultEvent += Ble_ServiceResultEvent;
                    ble.CharacterResultEvent += Ble_CharacterResultEvent;
                    ble.ConnectChangedEvent += Ble_ConnectChangedEvent;
                    ble.DataRecvEvent += Ble_DataRecvEvent;
                    connParam = new ConnectedDeviceParam();

                    for (int i = 0; i < 10; i++)
                    {
                        Thread.Sleep(1000);
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
                        AppendMessageWithTime($"不到指定蓝牙:{tagMac} {NotFindMACCounter}次");
                        NotFindMACCounter++;
                        AppendMessageWithTime($"重启蓝牙!");
                        BluetoothController.RestartBL(3);
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
                        Thread.Sleep(1000);
                        if (FindServiceEnd)
                        {
                            break;
                        }
                    }
                    var Service = devex.ServiceList.Where(a => a.Uuid.ToString().ToLower() == tagService).First();
                    connParam.service = Service;
                    if (Service != null)
                    {
                        ConnedFlag = true;
                    }
                    if (true)
                    {
                        AppendMessageWithTime("查找特征");
                        ble.FindCharacteristic(10, devex, Service);
                        for (int i = 0; i < 10; i++)
                        {
                            Thread.Sleep(1000);
                            if (FindCharacterEnd)
                            {
                                break;
                            }
                        }

                        connParam = ble.BuildConnectedDevice(connParam, tagWriteChar, tagNotifyChar);
                        AppendMessageWithTime($"连接:{connParam.dev}");
                        ble.ConnectDevice(connParam).Wait();

                        long minLoopCount = 3;
                        if (CheckLoop == false) minLoopCount = 3;
                        for (long i = 0; i < minLoopCount; i++)
                        {
                            Thread.Sleep(500);
                            byte[] sendData = Form1.BuildSendFrame(0, 2);
                            string hex = string.Join(" ", sendData.Select(a => a.ToString("X2")).ToArray());
                            AppendMessageWithTime($"发送数据:{hex} 发送次数:{SendCount++}");
                            ble.SendData(sendData);

                            Thread.Sleep(500);
                            AppendMessageWithTime($"发送数据:{hex} 发送次数:{SendCount++}");
                            ble.SendData(sendData);
                            FlashTJ();
                            if (CheckLoop == false) minLoopCount = 0; // 测试过程中修改,这样才会退出
                        }

                        // 连接成功后延迟多少秒发送休眠命令
                        Thread.Sleep(5 * 1000);
                        AppendMessageWithTime($"发送休眠命令前延迟:{5}秒");

                        RecvSleepCmdRT = false;
                        for (int i = 0; i < 30; i++) // 3次
                        {
                            if (RecvSleepCmdRT == false)
                            {
                                if (i % 10 == 0) // 1秒触发一次
                                {
                                    string hex = string.Join(" ", sleepCmd.Select(a => a.ToString("X2")).ToArray());
                                    AppendMessageWithTime($"发送休眠命令:{hex}");
                                    ble.SendData(sleepCmd);
                                }
                            }
                            else
                            {
                                break;
                            }
                            Thread.Sleep(100);
                        }

                        if (RecvSleepCmdRT)
                        {
                            AppendMessageWithTime("发送休眠命令:成功");
                        }
                        else
                        {
                            AppendMessageWithTime("发送休眠命令:失败");
                        }
                    }
                    Thread.Sleep(100);
                }
                catch (Exception ex)
                {
                    AppendMessageWithTime("执行异常:" + ex.Message);
                }
                finally
                {
                    BluetoothController.RestartBL(3);
                    DisConnAndClear(ble, connParam).Wait();
                    ble = null;
                    connParam = null;
                    GC.Collect();
                    Thread.Sleep(2000);
                    GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced, blocking: true);
                    FlashTJ();
                }

            });

            Task CheckSleepCurrent = new Task(() =>
            {
                try
                {
                    AppendMessageWithTime($"获取休眠电流前延迟{DelayForGetCurrentSec}秒");
                    Thread.Sleep(DelayForGetCurrentSec * 1000);
                    AppendMessageWithTime("开始获取休眠电流");
                    SleepCurrentEventArgs recv3 = GetSleepCurrent(tagMac, virPadCom, 3);
                    AppendMessageWithTime(recv3.ToString());
                    bool isSleep = recv3.IsSleep;
                    if (isSleep)
                    {
                        SleepCount++;
                    }
                    else
                    {
                        SleepFaultCount++;
                        HaveSleepFault = true;
                        if (SleepFailedStop)
                        {
                            AppendMessageWithTime("保护板:" + tagMac + " 休眠失败,退出测试!");
                        }
                    }
                }
                catch (Exception)
                {

                }
            });

            Task TaskWakeUp = new Task(() =>
            {
                ScanResultEnd = false;
                FindServiceEnd = false;
                FindCharacterEnd = false;
                BleCore2 ble = new BleCore2();
                ConnectedDeviceParam connParam = null;
                try
                {
                    AppendMessageWithTime("扫描-唤醒");
                    ble.StartScan(10, mindb, filterName);

                    ble.ScanResultEvent += Ble_ScanResultEvent;
                    ble.ServiceResultEvent += Ble_ServiceResultEvent;
                    ble.CharacterResultEvent += Ble_CharacterResultEvent;
                    ble.ConnectChangedEvent += Ble_ConnectChangedEvent;
                    ble.DataRecvEvent += Ble_DataRecvEvent;
                    connParam = new ConnectedDeviceParam();

                    for (int i = 0; i < 10; i++)
                    {
                        Thread.Sleep(1000);
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
                    var devex = ble.DeviceList.Where(a => a.MAC == tagMac).First();
                    connParam.dev = devex;

                    AppendMessageWithTime("查找服务");
                    ble.FindService(10, devex);
                    for (int i = 0; i < 10; i++)
                    {
                        Thread.Sleep(1000);
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
                            Thread.Sleep(1000);
                            if (FindCharacterEnd)
                            {
                                break;
                            }
                        }

                        connParam = ble.BuildConnectedDevice(connParam, tagWriteChar, tagNotifyChar);
                        AppendMessageWithTime($"连接:{connParam.dev}");
                        ble.ConnectDevice(connParam).Wait();

                        RecvWakeUpData = false;
                        long minLoopCount = 2;
                        if (CheckLoop == false) minLoopCount = 2;
                        for (long i = 0; i < minLoopCount; i++)
                        {
                            Thread.Sleep(500);
                            byte[] sendData = Form1.BuildSendFrame(0, 2);
                            string hex = string.Join(" ", sendData.Select(a => a.ToString("X2")).ToArray());
                            AppendMessageWithTime($"发送数据:{hex} 发送次数:{SendCount++}");
                            ble.SendData(sendData);

                            Thread.Sleep(500);
                            AppendMessageWithTime($"发送数据:{hex} 发送次数:{SendCount++}");
                            ble.SendData(sendData);
                            FlashTJ();
                            if (CheckLoop == false) minLoopCount = 0; // 测试过程中修改,这样才会退出
                        }

                        if (RecvWakeUpData)
                        {
                            AppendMessageWithTime("唤醒:成功");
                            WakeUpCount++;
                        }
                        else
                        {
                            AppendMessageWithTime("唤醒:失败");
                            WakeUpFaultCount++;
                        }
                    }
                    Thread.Sleep(500);
                }
                catch (Exception ex)
                {
                    AppendMessageWithTime("执行异常:" + ex.Message);
                }
                finally
                {
                    BluetoothController.RestartBL(3);
                    DisConnAndClear(ble, connParam).Wait();
                    ble = null;
                    connParam = null;
                    GC.Collect();
                    Thread.Sleep(2000);
                    GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced, blocking: true);
                    FlashTJ();
                }
            });

            Task Main = Task.Run(() =>
            {
                try
                {
                    TaskSleep.Start();
                    TaskSleep.Wait();
                    if (ConnedFlag)
                    {
                        CheckSleepCurrent.Start();
                        CheckSleepCurrent.Wait();
                        TaskWakeUp.Start();
                        TaskWakeUp.Wait();
                    }
                    if (CheckLoop)
                    {
                        AppendMessageWithTime($"完成一轮休眠唤醒,开始进行延迟{SleepUpLoopDelaySec}秒");
                        Thread.Sleep(SleepUpLoopDelaySec * 1000);
                    }
                }
                catch (Exception ex)
                {
                    AppendMessageWithTime($"任务执行失败: {ex.Message}");
                }
                finally
                {
                    AppendMessageWithTime($"===执行结束:第{SleepUpLoopCount++}轮,休眠成功次数:{SleepCount} 休眠失败次数:{SleepFaultCount},唤醒成功次数:{WakeUpCount} 唤醒失败次数:{WakeUpFaultCount}===");
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

        public SleepCurrentEventArgs GetSleepCurrent(string mac, string COM, int C = 3)
        {
            VirtualPad pad = new VirtualPad(COM);
            SleepCurrentEventArgs tmp = pad.GetSleepCurrent(mac, C);
            bool flag = !tmp.IsSleep;
            if (flag)
            {
                for (int i = 0; i < C; i++)
                {
                    bool flag2 = !tmp.IsSleep;
                    if (flag2)
                    {
                        Thread.Sleep(2000);
                        tmp = pad.GetSleepCurrent(mac, C);
                    }
                }
            }
            return tmp;
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
        private bool RecvSleepCmdRT = false;
        private bool RecvWakeUpData = false;
        private void Ble_DataRecvEvent(object sender, MyBluetoothLEDeviceEx dev, List<byte> data)
        {
            RecvWakeUpData = true;
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
            if (data[1] == 0x10)
            {
                RecvSleepCmdRT = true;
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

        private System.Windows.Forms.Timer dllTimer = null;
        private void chk_DLLDebugLoop_CheckedChanged(object sender, EventArgs e)
        {
            if (dllTimer == null)
            {
                dllTimer = new System.Windows.Forms.Timer();
                dllTimer.Interval = 5 * 1000;
                dllTimer.Tick += DllTimer_Tick;
            }

            dllTimer.Enabled = chk_DLLDebugLoop.Checked;// 停止时钟
            CheckLoop = chk_DLLDebugLoop.Checked;
            if (dllTimer.Enabled == true && StartParam == null)
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

        private void num_MaxSleepCurrent_ValueChanged(object sender, EventArgs e)
        {
            MaxSleepCurrent_mA = (double)num_MaxSleepCurrent.Value;
            SleepTestParam.MaxSleepCurrent_mA = MaxSleepCurrent_mA;
        }

        private void num_SleepUpLoopDelay_ValueChanged(object sender, EventArgs e)
        {
            SleepUpLoopDelaySec = (int)num_SleepUpLoopDelay.Value;
        }

        private void btn_ClearTJ_Click(object sender, EventArgs e)
        {
            var rt = MessageBox.Show("清零统计数据", "清空", MessageBoxButtons.YesNoCancel);
            if (rt == DialogResult.Yes)
            {
                SendCount = 0;
                RecvCount = 0;
                SleepCount = 0;
                SleepFaultCount = 0;
                WakeUpCount = 0;
                WakeUpFaultCount = 0;
                SleepUpLoopCount = 0;
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
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"发送:{SendCount} 接收:{RecvCount}");
                sb.AppendLine($"休眠成功次数:{SleepCount} 休眠失败次数:{SleepFaultCount}");
                sb.AppendLine($"唤醒成功次数:{WakeUpCount} 唤醒失败次数:{WakeUpFaultCount}");
                sb.AppendLine($"循环次数:{SleepUpLoopCount}");
                sb.AppendLine($"开始时间:{StartTime.ToString("yyyy-MM-dd HH:mm:ss")}时长: {sp.TotalHours:F4}H");
                txt_TJ.Text = sb.ToString();
            }
        }

        private void btn_FlashTJ_Click(object sender, EventArgs e)
        {
            FlashTJ();
        }

        private enum SleepCurrentSrc
        {
            WorkCurrect,
            SleepCurrent,
        }
        SleepCurrentSrc CurrentSrcMood = SleepCurrentSrc.WorkCurrect;
        private void com_SleepCurrentSrc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (com_SleepCurrentSrc.SelectedIndex >= 0 && com_SleepCurrentSrc.SelectedIndex <= 1)
            {
                CurrentSrcMood = (SleepCurrentSrc)com_SleepCurrentSrc.SelectedIndex;
                SleepTestParam.UseCurrent_Work = (CurrentSrcMood == SleepCurrentSrc.WorkCurrect);
            }
        }

        private void com_VirPadPort_Click(object sender, EventArgs e)
        {
            com_VirPadPort.Items.Clear();
            var ports = SerialPort.GetPortNames();
            com_VirPadPort.Items.AddRange(ports);
        }

        /// <summary>
        /// 获取休眠电流前延迟
        /// </summary>
        private int DelayForGetCurrentSec = 5;
        private void nmu_DelayForGetCurrent_ValueChanged(object sender, EventArgs e)
        {
            DelayForGetCurrentSec = (int)nmu_DelayForGetCurrent.Value;
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
