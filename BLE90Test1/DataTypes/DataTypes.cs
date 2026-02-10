using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLETest1.DataTypes
{
    public enum BLType
    {
        /// <summary>
        /// 国民
        /// </summary>
        国民 = 0,
        /// <summary>
        /// 巨微
        /// </summary>
        巨微 = 1,
    }

    public class BLGlobalParam
    {
        public static BLType Tpye { get; set; } = BLType.国民;
        public static bool ShowRSSIBar { get; set; } = true;
        public static bool ShowRSSI { get; set; } = true;

        public static bool ConfirmConnection { get; set; } = true;

        /// <summary>
        /// 连接后等待N秒确认状态
        /// </summary>
        public static ushort ConfirmConnection_Delay { get; set; } = 3;
        /// <summary>
        /// 连接前是否重启主机模块
        /// </summary>
        public static bool Restart_OnConn { get; set; } = false;
        /// <summary>
        /// 扫描后延迟
        /// </summary>
        public static ushort Scan_Delay { get; set; } = 8;

        public static bool ShowPortRecv { get; set; } = true;
    }


    public class LoopTestParam
    {
        public static ushort ReadCount { get; set; } = 2;
        public static bool ShowSend { get; set; } = false;
    }

    public class SleepTestParam
    {
        public static double MaxSleepCurrent_mA { get; set; } = 5;
        /// <summary>
        /// 工作电流:0.1mA,需要转换为mA单位
        /// 休眠电流:0.1uA ,需要转换为mA单位
        /// </summary>
        public static bool UseCurrent_Work { get; set; } = true;

        public static int TryConnBLMaxCount { get; set; } = 5;
    }

    public enum BluetoothSignalStrength
    {
        /// <summary>
        /// 最差/无信号
        /// </summary>
        最差 = 0,

        /// <summary>
        /// 差
        /// </summary>
        差 = 1,

        /// <summary>
        /// 良
        /// </summary>
        良 = 2,

        /// <summary>
        /// 优
        /// </summary>
        优 = 3,

        /// <summary>
        /// 优
        /// </summary>
        最优 = 4
    }

    public static class BluetoothSignalClassifier
    {
        // 可配置的阈值（单位：dBm）
        private static readonly Dictionary<BluetoothSignalStrength, int> DefaultThresholds = new Dictionary<BluetoothSignalStrength, int>()
    {
        { BluetoothSignalStrength.最差, -90 },     // ≤ -90dBm
        { BluetoothSignalStrength.差, -80 },      // (-90, -80]
        { BluetoothSignalStrength.良, -70 },      // (-80, -70]
        { BluetoothSignalStrength.优, -60 },      // (-70, -60]
        { BluetoothSignalStrength.最优, int.MaxValue } // > -60dBm
    };

        /// <summary>
        /// 根据RSSI值获取信号强度等级（使用默认阈值）
        /// </summary>
        /// <param name="rssi">信号强度值（dBm）</param>
        /// <returns>信号强度等级</returns>
        public static BluetoothSignalStrength GetSignalStrength(int rssi)
        {
            // 确保阈值按从小到大排序
            var thresholds = DefaultThresholds
                .OrderBy(t => t.Value)
                .ToList();

            // 从最差的等级开始检查
            foreach (var threshold in thresholds)
            {
                if (rssi <= threshold.Value)
                {
                    return threshold.Key;
                }
            }

            // 如果所有阈值都不满足，返回最优等级
            return BluetoothSignalStrength.最优;
        }

        /// <summary>
        /// 根据RSSI值获取信号强度等级（自定义阈值）
        /// </summary>
        /// <param name="rssi">信号强度值（dBm）</param>
        /// <param name="customThresholds">自定义阈值字典</param>
        /// <returns>信号强度等级</returns>
        public static BluetoothSignalStrength GetSignalStrength(int rssi, Dictionary<BluetoothSignalStrength, int> customThresholds)
        {
            if (customThresholds == null || !customThresholds.Any())
            {
                return GetSignalStrength(rssi);
            }

            var thresholds = customThresholds
                .OrderBy(t => t.Value)
                .ToList();

            foreach (var threshold in thresholds)
            {
                if (rssi <= threshold.Value)
                {
                    return threshold.Key;
                }
            }

            return thresholds.Last().Key;
        }

        /// <summary>
        /// 获取信号等级的描述文本
        /// </summary>
        public static string GetSignalDescription(BluetoothSignalStrength strength)
        {
            return strength.ToString("G");
        }

        /// <summary>
        /// 获取信号等级对应的图标或颜色（可用于UI显示）
        /// </summary>
        public static (System.Drawing.Color Color, string Icon) GetSignalDisplayInfo(BluetoothSignalStrength strength)
        {
            switch (strength)
            {
                case BluetoothSignalStrength.最差:
                    return (System.Drawing.Color.FromArgb(0xFF, 0, 0), "🔴");// 红色   "#FF0000"
                case BluetoothSignalStrength.差:
                    return (System.Drawing.Color.FromArgb(0xFF, 0xA5, 0), "⚫");  // 橙色  #FFA500
                case BluetoothSignalStrength.良:
                    return (System.Drawing.Color.Yellow, "⚫"); // 黄色   #FFFF00
                case BluetoothSignalStrength.优:
                    return (System.Drawing.Color.FromArgb(0x90, 0xEE, 90), "⚫"); // 浅绿色 #90EE90
                case BluetoothSignalStrength.最优:
                    return (System.Drawing.Color.Green, "⚫");  // 绿色 #00FF00
                default:
                    return (System.Drawing.Color.Gray, "⚫"); // 灰色 #808080
            }
        }
    }

}
