using BLETest1.DataTypes;
using BLETest1.UserControls;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace BLETest1.Devices
{
    public class VirtualPad
    {
        protected void WaitBytesToReadFixedness(SerialPort com_Pace)
        {
            int btr = com_Pace.BytesToRead;
            int newbtr = 0;
            try
            {
                do
                {
                    btr = newbtr;
                    Thread.Sleep(this.FixednessDelay);
                    bool isOpen = com_Pace.IsOpen;
                    if (!isOpen)
                    {
                        break;
                    }
                    newbtr = com_Pace.BytesToRead;
                }
                while (newbtr != btr);
            }
            catch (Exception)
            {
            }
        }

        public VirtualPad(string COM)
        {
            this.COM = COM;
        }

        public static byte[] BuildPaceReadDataCmd(byte cmd, byte[] data, byte addr = 0, string version = "25", string cid1 = "46")
        {
            return new MiniEntity
            {
                Cid1 = cid1,
                Cid2 = cmd,
                InfoBytes = data
            }.BuildAsciiDataFrame(addr, version);
        }

        public SleepCurrentEventArgs GetSleepCurrent(string mac, int C = 3)
        {
            try
            {
                this.port = new SerialPort();
                this.port.PortName = this.COM;
                this.port.BaudRate = 9600;
                this.port.DataReceived += new SerialDataReceivedEventHandler(this.VitrualPadPort_DataReceived);
                this.port.Open();
                Thread.Sleep(100);
                for (int i = 0; i < C; i++)
                {
                    byte[] send = VirtualPad.BuildPaceReadDataCmd(byte.MaxValue, new byte[]
                    {
                        242
                    }, 0, "25", "46");
                    this.port.Write(send, 0, send.Length);
                    Thread.Sleep(2000);
                    this.COM_PaceQueue.Clear();
                    byte[] send2 = VirtualPad.BuildPaceReadDataCmd(byte.MaxValue, new byte[]
                    {
                        240
                    }, 0, "25", "46");
                    this.port.Write(send2, 0, send2.Length);
                    byte[] ok = this.WaitData(3, this.COM_PaceQueue);
                    bool flag = ok != null;
                    if (flag)
                    {
                        byte[] only = MiniEntity.GetOnlyData(ok);
                        bool flag2 = only.Length >= 10;
                        if (flag2)
                        {
                            PubMod.ShortHL ma = 0;
                            bool useCurrent_Work = SleepTestParam.UseCurrent_Work;
                            if (useCurrent_Work)
                            {
                                ma.HByte = only[6];
                                ma.LByte = only[7];
                                this.SleepCurrent_mA = (double)ma.data / 10.0;
                            }
                            else
                            {
                                ma.HByte = only[8];
                                ma.LByte = only[9];
                                this.SleepCurrent_mA = (double)ma.data / 10.0 / 1000.0;
                            }
                            break;
                        }
                    }
                    Thread.Sleep(1000);
                }
                this.port.Close();
            }
            catch (Exception)
            {
            }
            finally
            {
                bool flag3 = this.port != null && this.port.IsOpen;
                if (flag3)
                {
                    this.port.Close();
                }
            }
            return new SleepCurrentEventArgs(mac, this.SleepCurrent_mA);
        }

        private byte[] WaitData(int timeoutSec, Queue<byte[]> queue)
        {
            int ms = timeoutSec * 1000;
            DateTime st = DateTime.Now;
            while (queue.Count <= 0 && (DateTime.Now - st).TotalMilliseconds < (double)ms)
            {
                Thread.Sleep(100);
            }
            bool flag = queue.Count > 0;
            byte[] result;
            if (flag)
            {
                result = queue.Dequeue();
            }
            else
            {
                result = new byte[0];
            }
            return result;
        }

        private void VitrualPadPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            this.WaitBytesToReadFixedness(this.port);
            try
            {
                byte[] readData = new byte[4096];
                bool flag = !this.port.IsOpen;
                if (!flag)
                {
                    int num = this.port.Read(readData, 0, 4096);
                    bool flag2 = num < 0;
                    if (!flag2)
                    {
                        byte[] array2 = new byte[num];
                        Array.Copy(readData, 0, array2, 0, num);
                        this.Recv(array2);
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void Recv(byte[] array2)
        {
            bool flag = array2[0] != 126;
            if (!flag)
            {
                bool flag2 = array2[array2.Length - 1] != 13;
                if (!flag2)
                {
                    bool crc = MiniEntity.IsChkCorrect(array2);
                    bool flag3 = !crc;
                    if (!flag3)
                    {
                        bool crc2 = MiniEntity.ResponseDataCheckSum(array2);
                        bool flag4 = !crc2;
                        if (!flag4)
                        {
                            byte[] bs = MiniEntity.AsciiByte2ByteArray(array2);
                            this.COM_PaceQueue.Enqueue(bs);
                        }
                    }
                }
            }
        }

        public int FixednessDelay = 20;

        private SerialPort port;

        private string COM;

        protected Queue<byte[]> COM_PaceQueue = new Queue<byte[]>();

        private double SleepCurrent_mA = 65535.0;
    }

    public class MiniEntity
    {
        public MiniEntity()
        {
            this.Cid1 = "46";
        }

        public MiniEntity(string cid1)
        {
            this.Cid1 = cid1;
        }

        public string Cid1 { get; set; }

        public byte Cid2 { get; set; }

        public byte[] InfoBytes { get; set; }

        public byte[] BuildAsciiDataFrame(byte addr, string version)
        {
            string text = "0000";
            string text2 = "";
            bool flag = this.InfoBytes != null && this.InfoBytes.Length != 0;
            if (flag)
            {
                for (int i = 0; i < this.InfoBytes.Length; i++)
                {
                    text2 += this.InfoBytes[i].ToString("X2");
                }
                byte[] bytes = Encoding.ASCII.GetBytes(text2);
                text = this.BuildInfoLength(bytes.Length);
            }
            string text3 = version + addr.ToString("X2") + this.Cid1 + this.Cid2.ToString("X2");
            byte[] bytes2 = Encoding.ASCII.GetBytes(text3 + text + text2);
            byte[] sourceArray = this.BuildChkSum(bytes2, 0, bytes2.Length);
            byte[] array = new byte[bytes2.Length + 6];
            array[0] = 126;
            array[array.Length - 1] = 13;
            Array.Copy(bytes2, 0, array, 1, bytes2.Length);
            Array.Copy(sourceArray, 0, array, array.Length - 5, 4);
            return array;
        }

        private byte[] BuildChkSum(byte[] chk, int start, int leng)
        {
            int num = 0;
            for (int i = 0; i < leng; i++)
            {
                num = (int)((ushort)((int)chk[i + start] + num));
            }
            string s = ((ushort)(~(num % 65536) + 1)).ToString("X2");
            return Encoding.ASCII.GetBytes(s);
        }

        private string BuildInfoLength(int leng)
        {
            short num = (short)((leng & 15) + ((leng & 240) >> 4) + ((leng & 3840) >> 8));
            byte b = (byte)(~(num % 16) + 1);
            return ((ushort)(leng | (int)b << 12)).ToString("X2");
        }

        public static bool LenCheckSum(ushort rawLenInfo, out ushort len)
        {
            len = (ushort)(rawLenInfo & 4095);
            byte recvCheckSum = (byte)(rawLenInfo >> 12);
            int tmp = (int)(len & 15) + ((len & 240) >> 4) + ((len & 3840) >> 8);
            byte calCheckSum = (byte)(~(tmp % 16) + 1 & 15);
            bool flag = recvCheckSum != calCheckSum;
            return !flag;
        }

        public static bool ResponseDataCheckSum(byte[] data)
        {
            int num = 0;
            string str = Encoding.ASCII.GetString(data, data.Length - 5, 4);
            for (int i = 1; i < data.Length - 5; i++)
            {
                num = (int)((ushort)((int)data[i] + num));
            }
            string value = ((ushort)(~(num % 65536) + 1)).ToString("X2").PadLeft(4, '0');
            return str == value;
        }

        private static byte GetValByASCII(byte[] data, int start)
        {
            byte result;
            try
            {
                string chars = Encoding.ASCII.GetString(data, start, 2);
                result = byte.Parse(chars, NumberStyles.HexNumber);
            }
            catch (Exception)
            {
                result = 0;
            }
            return result;
        }

        public static byte[] AsciiByte2ByteArray(byte[] responseData)
        {
            List<byte> list = new List<byte>
            {
                responseData[0]
            };
            for (int i = 1; i < responseData.Length - 1; i += 2)
            {
                list.Add(MiniEntity.GetValByASCII(responseData, i));
            }
            list.Add(responseData[responseData.Length - 1]);
            return list.ToArray();
        }

        public static byte[] HexStringToByteArray(string val)
        {
            bool flag = string.IsNullOrWhiteSpace(val);
            byte[] result;
            if (flag)
            {
                result = new byte[0];
            }
            else
            {
                Regex rx = new Regex("\\s*");
                string val2 = rx.Replace(val, "");
                bool flag2 = val2.Length % 2 != 0 && val2.Length >= 1;
                if (flag2)
                {
                    val2 = val2.Substring(0, val2.Length - 1);
                }
                bool flag3 = val2.Length >= 2 && val2.Length % 2 == 0;
                if (flag3)
                {
                    byte[] data = new byte[val2.Length / 2];
                    int i = 0;
                    for (int j = 0; j < val2.Length; j += 2)
                    {
                        string tmp = val2.Substring(j, 2);
                        byte Cur = Convert.ToByte(tmp, 16);
                        data[i] = Cur;
                        i++;
                    }
                    result = data;
                }
                else
                {
                    result = new byte[0];
                }
            }
            return result;
        }

        public static bool IsChkCorrect(byte[] _surplusByte)
        {
            bool flag = _surplusByte.Length < 18;
            bool result;
            if (flag)
            {
                result = false;
            }
            else
            {
                ushort lens = 0;
                bool ok = ushort.TryParse(Encoding.ASCII.GetString(_surplusByte, 9, 4), NumberStyles.HexNumber, null, out lens);
                bool flag2 = !ok;
                if (flag2)
                {
                    result = false;
                }
                else
                {
                    byte lenCkSum = (byte)(lens >> 12);
                    int sum = (int)(lens & 15) + ((lens & 240) >> 4) + ((lens & 3840) >> 8);
                    byte lenSum = (byte)(~(sum % 16) + 1 & 15);
                    bool flag3 = lenCkSum != lenSum;
                    if (flag3)
                    {
                        result = false;
                    }
                    else
                    {
                        int infoLen = (int)(lens & 4095);
                        bool flag4 = _surplusByte.Length < 18 + infoLen;
                        if (flag4)
                        {
                            result = false;
                        }
                        else
                        {
                            bool flag5 = _surplusByte[0] != 126 || _surplusByte[_surplusByte.Length - 1] != 13;
                            result = !flag5;
                        }
                    }
                }
            }
            return result;
        }

        public static byte[] GetOnlyData(byte[] frame)
        {
            PubMod.ShortHL hl = 0;
            hl.HByte = frame[5];
            hl.LByte = frame[6];
            hl.data &= 4095;
            int len = (int)(hl.data / 2);
            byte[] bytes = new byte[len];
            int min = Math.Min(frame.Length - 7 - 3, bytes.Length);
            Array.Copy(frame, 7, bytes, 0, min);
            return bytes;
        }

        public const byte Frame_Start = 126;

        public const byte Frame_End = 13;

        public const byte Frame_MinLength = 18;
    }
}
