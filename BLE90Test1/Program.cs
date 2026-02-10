using BLETest1.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLETest1
{
    internal static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。 可用
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            StartParam param = null;
            //BluetoothController.ResartBluetooth();

            if (File.Exists(StartParam.StartParamFile))
            {
                try
                {
                    string json = File.ReadAllText(StartParam.StartParamFile);
                    param = StartParam.ToParam(json);
                    System.Threading.Thread.Sleep(3000);
                }
                catch
                {

                }
            }

            File.Delete(StartParam.StartParamFile);

            Application.Run(new Form1(param));
        }
    }
}
