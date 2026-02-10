using BLETest1.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace BLETest1
{
    public partial class Form1 : Form
    {
        private bool Closing = false;
        private ContextMenuStrip contextMenuStrip1;
        public Form1()
        {
            InitializeComponent();
            this.Init();
        }
        public Form1(StartParam param)
        {
            InitializeComponent();
            this.Init();
            StartParam = param;
            Init(StartParam);
        }
        public StartParam StartParam;
        private void Init()
        {
            this.Load += BlueForm_Load;
            this.FormClosing += BlueForm_FormClosing;
            uc_DebugTest1.listboxMessage = this.listboxMessage;
            uc_ConnDisConnTest1.listboxMessage = this.listboxMessage;
            uc_SleepLoopTest1.listboxMessage = this.listboxMessage;
        }
        private void Init(StartParam param)
        {
            if (param == null) return;

            switch (param.RunType)
            {
                case RunType.LoopRead:
                    uc_ConnDisConnTest1.StartParam = param;
                    break;
                case RunType.LoopSleep:
                    tab_Root.SelectedIndex = 1;
                    uc_SleepLoopTest1.StartParam = param;
                    break;
                default:
                    break;
            }
        }
        private void BlueForm_Load(object sender, EventArgs e)
        {
            contextMenuStrip1 = new ContextMenuStrip();
            // 复制项目
            ToolStripMenuItem copyItem = new ToolStripMenuItem("复制", null, CopyMenuItem_Click);
            copyItem.ShortcutKeys = Keys.Control | Keys.C;

            ToolStripMenuItem copyMACItem = new ToolStripMenuItem("复制MAC", null, CopyMACMenuItem_Click);
            copyMACItem.ShortcutKeys = Keys.Control | Keys.X;

            contextMenuStrip1.Items.AddRange(new ToolStripItem[]
            {
                copyItem,
                copyMACItem,
            });

            listboxMessage.SelectionMode = System.Windows.Forms.SelectionMode.One;
            listboxMessage.ContextMenuStrip = contextMenuStrip1;
        }
        private void ListBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int index = listboxMessage.IndexFromPoint(e.Location);

                if (index >= 0 && index < listboxMessage.Items.Count)
                {
                    // 如果右键点击的项目未被选中，则选中它
                    if (!listboxMessage.SelectedIndices.Contains(index))
                    {
                        listboxMessage.SelectedIndex = index;
                    }
                }
            }
        }

        private void CopyMACMenuItem_Click(object sender, EventArgs e)
        {
            if (listboxMessage.SelectedItems.Count > 0)
            {
                string text = listboxMessage.SelectedItem.ToString();
                if (string.IsNullOrWhiteSpace(text) == false)
                {
                    text = text.ToUpper();
                    string pattern = @"MAC:([0-9A-F]{2}:){5}[0-9A-F]{2}";
                    Regex regex = new Regex(pattern);
                    Match match1 = regex.Match(text);
                    if (match1.Success)
                    {
                        Console.WriteLine($"匹配到的 MAC: {match1.Value}");
                        int index = match1.Value.IndexOf("MAC:");
                        string mac = match1.Value.Substring(index + 4).Trim();
                        Clipboard.SetText(mac);
                    }
                }
            }
        }

        private void CopyMenuItem_Click(object sender, EventArgs e)
        {
            if (listboxMessage.SelectedItems.Count > 0)
            {
                string text = listboxMessage.SelectedItem.ToString();
                Clipboard.SetText(text);
            }
        }
        private void BlueForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Closing = true;
        }

        #region 公共的

        public static List<byte> StringToArray(string str)
        {
            string[] arr = str.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            List<byte> buffer = new List<byte>();
            for (int i = 0; i < arr.Length; i++)
            {
                buffer.Add(Convert.ToByte(arr[i], 16));
            }
            return buffer;
        }

        public static string CRC16(bool HL, string str)
        {
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
            return hex;
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

        public static void SetControlEnable(Control ctrl, bool enable)
        {
            if (ctrl.InvokeRequired)
            {
                Action<Control, bool> action = SetControlEnable;
                ctrl.Invoke(action, ctrl, enable);
                return;
            }
            ctrl.Enabled = enable;
        }


        public static byte[] BuildSendFrame(ushort addr, ushort count)
        {
            byte[] data = new byte[8];
            data[0] = 1;
            data[1] = 3;
            PubMod.ShortHL hl = addr;
            data[2] = hl.HByte;
            data[3] = hl.LByte;
            PubMod.ShortHL hl2 = count;
            data[4] = hl2.HByte;
            data[5] = hl2.LByte;
            PubMod.ShortHL crc = PubMod.Get_CRC16(data, 6);
            data[6] = crc.LByte;
            data[7] = crc.HByte;
            return data;
        }
        #endregion

        private void listboxMessage_DoubleClick(object sender, EventArgs e)
        {
            string msg = listboxMessage.SelectedItem.ToString();
            Clipboard.SetText(msg);
        }
    }
}
