using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace BLETest1
{
    public partial class Form1 : Form
    {
        private bool Closing = false;
        public Form1()
        {
            InitializeComponent();
            this.Init();
        }

        private void Init()
        {
            this.Load += BlueForm_Load;
            this.FormClosing += BlueForm_FormClosing;
            uc_DebugTest1.listboxMessage = this.listboxMessage;
            uc_ConnDisConnTest1.listboxMessage = this.listboxMessage;
            uc_SleepLoopTest1.listboxMessage = this.listboxMessage;
        }

        private void BlueForm_Load(object sender, EventArgs e)
        {

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
