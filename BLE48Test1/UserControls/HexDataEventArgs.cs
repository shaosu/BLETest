using BLETest1.DataTypes;
using System;

namespace BLETest1.UserControls
{
    public class ItemValueDw
    {
        public string Title { get; set; }
        public double TitleValue { get; set; }
        public string TitleDW { get; set; }

        public ItemValueDw(string t, double v, string dw)
        {
            Title = t;
            TitleValue = v;
            TitleDW = dw;
        }

        public override string ToString()
        {
            return $"{Title}:{TitleValue}{TitleDW}";
        }
    }

    public class HexDataEventArgs : EventArgs
    {
        public ItemValueDw Value1 { get; set; }
        public ItemValueDw Value2 { get; set; }

        public string MAC { get; set; }
        public byte[] Data { get; private set; }
        public HexDataEventArgs(string sn, byte[] data)
        {
            MAC = sn;
            Data = data;
        }

        private bool? Crc { get; set; }
        public bool CheckCRC()
        {
            if (Data == null || Data.Length < 3)
            {
                return false;
            }
            if (Crc == null)
            {
                PubMod.ShortHL crc = 0;
                crc.LByte = Data[Data.Length - 2];
                crc.HByte = Data[Data.Length - 1];
                PubMod.ShortHL crc_cal = PubMod.Get_CRC16(Data, Data.Length - 2);
                Crc = crc.data == crc_cal.data;
            }
            return Crc.Value;
        }
        public override string ToString()
        {
            if (Data == null || Data.Length == 0)
            {
                return $"MAC:[{MAC}] Data:无数据";
            }
            if (CheckCRC() == false)
            {
                return $"MAC:[{MAC}] Data:{BitConverter.ToString(Data).Replace("-", " ")} CRC错误";
            }
            else
            {
                if (Value1 == null)
                {
                    return $"MAC:[{MAC}] Data:{BitConverter.ToString(Data).Replace("-", " ")}";
                }
                else
                {
                    if (Value2 == null)
                    {
                        return $"MAC:[{MAC}] Data:{BitConverter.ToString(Data).Replace("-", " ")} [{Value1}]";
                    }
                    else
                    {
                        return $"MAC:[{MAC}] Data:{BitConverter.ToString(Data).Replace("-", " ")} [{Value1},{Value2}]";
                    }
                }
            }
        }
    }

    public class SleepCurrentEventArgs : EventArgs
    {
        public SleepCurrentEventArgs(string sn, double curr)
        {
            Mac = sn;
            Current_mA = curr;
        }

        public string Mac { get; set; }
        /// <summary>
        /// mA
        /// </summary>
        public double Current_mA { get; private set; }
        public bool IsSleep { get { return Current_mA <= SleepTestParam.MaxSleepCurrent_mA; } }

        public override string ToString()
        {
            if (IsSleep)
            {
                return $"MAC:[{Mac}] 休眠成功,休眠电流:{Current_mA:F3}mA,判定休眠电流最大值:{SleepTestParam.MaxSleepCurrent_mA:F3}mA";
            }
            else
            {
                return $"MAC:[{Mac}] 休眠失败,休眠电流:{Current_mA:F3}mA,判定休眠电流最大值:{SleepTestParam.MaxSleepCurrent_mA:F3}mA";
            }
        }
    }

}
