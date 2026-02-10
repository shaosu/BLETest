using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.Devices.Radios;

namespace BLETest1.ViewModel
{
    public class BluetoothController
    {
        /// <summary>
        /// 获取蓝牙无线电对象
        /// </summary>
        /// <returns></returns>
        private async Task<Radio> GetBluetoothRadioAsync()
        {
            var radios = await Radio.GetRadiosAsync();
            return radios.FirstOrDefault(radio => radio.Kind == RadioKind.Bluetooth);
        }

        /// <summary>
        /// 检查蓝牙是否开启
        /// </summary>
        /// <returns></returns>
        public async Task<bool> IsBluetoothEnabledAsync()
        {
            var bluetoothRadio = await GetBluetoothRadioAsync();
            return bluetoothRadio?.State == RadioState.On;
        }

        /// <summary>
        /// 开启或关闭蓝牙
        /// </summary>
        /// <param name="turnOn"></param>
        /// <returns></returns>
        public async Task<bool> SetBluetoothStateAsync(bool turnOn)
        {
            var bluetoothRadio = await GetBluetoothRadioAsync();
            if (bluetoothRadio == null)
            {
                return false; // 设备不支持蓝牙
            }

            var desiredState = turnOn ? RadioState.On : RadioState.Off;

            // 检查当前状态，避免重复操作
            if (bluetoothRadio.State == desiredState)
                return true;

            // 尝试设置状态
            var result = await bluetoothRadio.SetStateAsync(desiredState);
            return result == RadioAccessStatus.Allowed;
        }

        public async Task RestartBLUseRadio(int delaySec = 3)
        {
            if (delaySec < 3)
            {
                delaySec = 3;
            }
            await SetBluetoothStateAsync(false);
            await Task.Delay(delaySec * 1000);
            await SetBluetoothStateAsync(true);
        }

        public static void RestartBL(int delaySec = 3)
        {
            if (delaySec < 3)
            {
                delaySec = 3;
            }
            ToggleBluetoothRadio(false);
            Thread.Sleep(delaySec * 1000);
            ToggleBluetoothRadio(true);
        }

        public static void ToggleBluetoothRadio(bool enable, bool showMsg = false)
        {
            try
            {
                // 使用 PowerShell 命令控制蓝牙
                string script = enable
                    ? @"Add-Type -AssemblyName System.Runtime.WindowsRuntime
                        $asTaskGeneric = ([System.WindowsRuntimeSystemExtensions].GetMethods() | Where-Object { $_.Name -eq 'AsTask' -and $_.GetParameters().Count -eq 1 -and $_.GetParameters()[0].ParameterType.Name -eq 'IAsyncOperation`1' })[0]
                        Function Await($WinRtTask, $ResultType) {
                            $asTask = $asTaskGeneric.MakeGenericMethod($ResultType)
                            $netTask = $asTask.Invoke($null, @($WinRtTask))
                            $netTask.Wait(-1) | Out-Null
                            $netTask.Result
                        }
                        [Windows.Devices.Radios.Radio,Windows.System.Devices,ContentType=WindowsRuntime] | Out-Null
                        [Windows.Devices.Radios.RadioState,Windows.System.Devices,ContentType=WindowsRuntime] | Out-Null
                        $radios = Await ([Windows.Devices.Radios.Radio]::RequestAccessAsync()) ([Windows.Devices.Radios.RadioAccessStatus])
                        $radios = Await ([Windows.Devices.Radios.Radio]::GetRadiosAsync()) ([System.Collections.Generic.IReadOnlyList[Windows.Devices.Radios.Radio]])
                        $bluetooth = $radios | Where-Object { $_.Kind -eq 'Bluetooth' }
                        if ($bluetooth) { Await ($bluetooth.SetStateAsync('On')) ([Windows.Devices.Radios.RadioAccessStatus]) }"
                    : @"Add-Type -AssemblyName System.Runtime.WindowsRuntime
                        $asTaskGeneric = ([System.WindowsRuntimeSystemExtensions].GetMethods() | Where-Object { $_.Name -eq 'AsTask' -and $_.GetParameters().Count -eq 1 -and $_.GetParameters()[0].ParameterType.Name -eq 'IAsyncOperation`1' })[0]
                        Function Await($WinRtTask, $ResultType) {
                            $asTask = $asTaskGeneric.MakeGenericMethod($ResultType)
                            $netTask = $asTask.Invoke($null, @($WinRtTask))
                            $netTask.Wait(-1) | Out-Null
                            $netTask.Result
                        }
                        [Windows.Devices.Radios.Radio,Windows.System.Devices,ContentType=WindowsRuntime] | Out-Null
                        [Windows.Devices.Radios.RadioState,Windows.System.Devices,ContentType=WindowsRuntime] | Out-Null
                        $radios = Await ([Windows.Devices.Radios.Radio]::RequestAccessAsync()) ([Windows.Devices.Radios.RadioAccessStatus])
                        $radios = Await ([Windows.Devices.Radios.Radio]::GetRadiosAsync()) ([System.Collections.Generic.IReadOnlyList[Windows.Devices.Radios.Radio]])
                        $bluetooth = $radios | Where-Object { $_.Kind -eq 'Bluetooth' }
                        if ($bluetooth) { Await ($bluetooth.SetStateAsync('Off')) ([Windows.Devices.Radios.RadioAccessStatus]) }";

                var psi = new ProcessStartInfo
                {
                    FileName = "powershell.exe",
                    Arguments = $"-NoProfile -ExecutionPolicy Bypass -Command \"{script.Replace("\"", "\\\"")}\"",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true
                };

                using (var process = Process.Start(psi))
                {
                    process.WaitForExit(10000);
                    string error = process.StandardError.ReadToEnd();

                    if (process.ExitCode == 0 && string.IsNullOrEmpty(error))
                    {
                        if (showMsg)
                            MessageBox.Show(enable ? "蓝牙已打开" : "蓝牙已关闭", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        if (showMsg)
                            MessageBox.Show($"操作可能未成功: {error}", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                if (showMsg)
                    MessageBox.Show($"操作失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static bool IsBluetoothEnabled()
        {

            return false;
        }
    }
}
