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
            com_BLList.SelectedIndex = 0;
            com_LoopMode.SelectedIndex = 0;
        }

        internal override void AppendToLogFile(string timeMsg)
        {
            string file = $"Log\\循环读测试{DateTime.Now.ToString("yyyMMdd")}.txt";
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

        private void btn_Test_Click(object sender, EventArgs e)
        {
            string tagMac = txt_MAC.Text.ToLower();// "30:83:98:fc:b4:3e"; ; "30:83:98:FC:B4:3E"
            string tagService = txt_tagService.Text.ToLower();// "0000fff0-0000-1000-8000-00805f9b34fb";
            string tagWriteChar = txt_tagWriteChar.Text.ToLower();// "0000fff1-0000-1000-8000-00805f9b34fb";
            string tagNotifyChar = txt_tagNotifyChar.Text.ToLower();// "0000fff2-0000-1000-8000-00805f9b34fb";
            string filterName = txt_filterName.Text.Trim();
            short mindb = (short)num_minDb.Value;
            Form1.SetControlEnable(btn_Test, false);

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
                    var devex = ble.DeviceList.Where(a => a.MAC == tagMac).First();
                    connParam.dev = devex;

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
                    ble = null;
                    connParam = null;
                    AppendMessageWithTime("===执行结束===");
                    GC.Collect();
                    Form1.SetControlEnable(btn_Test, true);
                    FlashTJ();
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
            if (dllTimer.Enabled == true)
            {
                StartTime = DateTime.Now;
                AppendMessageWithTime("开始时间:" + StartTime.ToString("yyyy-MM-dd HH:mm:ss"));
            }
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
    }
}
