using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLETest1.ViewModel
{

    public enum RunType
    {
        LoopRead,
        LoopSleep
    }

    public class LoopReadParam
    {
        public int LoopType { get; set; }
        public ushort ReadCount { get; set; }
        public int ReadIntervalMs { get; set; }
    }

    public class SleepParam
    {
        public string VirPadCOM { get; set; }

        public long SleepCount { get; set; }
        public long SleepFaultCount { get; set; }

        public long WakeUpCount { get; set; }
        public long WakeUpFaultCount { get; set; }

        public long SleepUpLoopCount { get; set; }

        public double MaxSleepCurrent_mA { get; set; }

        public int SleepUpLoopDelaySec { get; set; }

        public int SleepCurrentSrc { get; set; }

        public int DelayForGetCurrent { get; set; }
    }

    public class StartParam
    {
        public const string StartParamFile = "StartParam.dat";
        public string MAC { get; set; }
        public RunType RunType { get; set; }

        public long SendCount { get; set; }
        public long RecvCount { get; set; }
        public string ServiceUUID { get; set; }
        public string WriteChartUUID { get; set; }
        public string NotifyChartUUID { get; set; }
        public int BLSelectIndex { get; set; }

        public string FilterName { get; set; }
        public short MinDB { get; set; }
        public DateTime StartTime { get; set; }
        public LoopReadParam LoopReadP { get; set; }
        public SleepParam SleepP { get; set; }


        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static StartParam ToParam(string json)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<StartParam>(json);
        }

        public static void AppExitAndRestart(StartParam param)
        {
            try
            {
                string json = param.ToJson();
                System.IO.File.WriteAllText(StartParam.StartParamFile, json);
                Thread.Sleep(500);
                System.Diagnostics.Process.Start(Application.ExecutablePath);
                // 退出当前实例
                Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show("重启应用失败: " + ex.Message);
            }
        }
    }
}
