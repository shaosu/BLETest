using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLETest1.Devices
{
    public class MiTemperatureSensor
    {
        /// <summary>
        /// 温度湿度服务UUID
        /// </summary>
        public static string ServiceUUID { get; set; } = "EBEOCCBO-7AOA-4BOC-8A1A-6FF2997DA3A6";
        /// <summary>
        /// 温度湿度的读和通知特征
        /// </summary>
        public static string ChartUUID { get; set; } = "EBE0CCC1-7A0A-4B0C-8A1A-6FF2997DA3A6";

        /// <summary>
        /// 温度:摄氏度
        /// </summary>
        public float Temperature { get; set; }
        /// <summary>
        /// 湿度:百分比
        /// </summary>
        public float Humidity { get; set; }
        /// <summary>
        /// 电量:电池百分比
        /// </summary>
        public byte Battery { get; set; }
        /// <summary>
        /// 时间:电脑时间
        /// </summary>
        public DateTime Timestamp { get; set; }

        public override string ToString()
        {
            return $"时间:{Timestamp}  温度:{Temperature:F2}℃ 湿度:{Humidity}% 电量:{Battery}%";
        }

        public static MiTemperatureSensor ParseTemperatureData(byte[] data)
        {
            if (data == null || data.Length < 5)
            {
                throw new ArgumentException("数据长度不足，至少需要5个字节");
            }

            var result = new MiTemperatureSensor
            {
                Timestamp = DateTime.Now
            };

            // 1. 解析温度（2字节，有符号，小端）
            // 温度 = (温度高字节 << 8 | 温度低字节) / 100.0f
            int temperatureRaw = (data[1] << 8) | data[0];

            // 转换为有符号整数
            if (temperatureRaw > 32767)  // 处理负数温度
            {
                temperatureRaw -= 65536;
            }

            result.Temperature = temperatureRaw / 100.0f;

            // 2. 解析湿度（2字节，无符号，小端）
            // 湿度 = (湿度高字节 << 8 | 湿度低字节) - 52992; // 0xCF00
            float humidityRaw = ((data[3] << 8) | data[2]) - 52992;
            result.Humidity = humidityRaw / 1.0F;

            // 3. 解析电池电量（1字节）
            result.Battery = data[4];
            return result;
        }

    }

}
