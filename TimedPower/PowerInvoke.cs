using System.Diagnostics;
using System.Runtime.InteropServices;

namespace TimedPower
{
    public static partial class PowerInvoke
    {
#pragma warning disable CA1401 // P/Invokes 应该是不可见的
        [LibraryImport("user32")]
        public static partial void LockWorkStation();
#pragma warning restore CA1401 // P/Invokes 应该是不可见的
        [LibraryImport("PowrProf.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static partial bool SetSuspendState([MarshalAs(UnmanagedType.Bool)] bool hiberate, [MarshalAs(UnmanagedType.Bool)] bool forceCritical, [MarshalAs(UnmanagedType.Bool)] bool disableWakeEvent);


        /// <summary>
        /// 关机
        /// </summary>
        public static void Shutdown()
        {
            ProcExec("shutdown", " /d p:0:0 /c \"TimedPower定时电源进行的操作\" " +
                                 "/s /t 0");
        }
        /// <summary>
        /// 重启
        /// </summary>
        public static void Reboot()
        {
            ProcExec("shutdown", " /d p:0:0 /c \"TimedPower定时电源进行的操作\" " +
                                 "/r /t 0");
        }
        /// <summary>
        /// 注销
        /// </summary>
        public static void UserOff()
        {
            ProcExec("shutdown", " " +
                                 "/l");
        }
        /// <summary>
        /// 锁定
        /// </summary>
        public static void UserLock()
        {
            LockWorkStation();
        }
        /// <summary>
        /// 睡眠
        /// </summary>
        public static void Sleep()
        {
            SetSuspendState(false, true, true);
        }
        /// <summary>
        /// 休眠
        /// </summary>
        public static void Hibernate()
        {
            /*SetSuspendState(true, true, true);*/
            ProcExec("shutdown", " " +
                                 "/h");
            // MessageBox.Show("此系统上没有启用休眠。", TimedPower.Main.ThisFormText, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        static void ProcExec(string fileName, string arguments)
        {
            Process process = new()
            {
                StartInfo = new ProcessStartInfo
                {
                    UseShellExecute = false,
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true,
                    FileName = fileName,
                    Arguments = arguments
                }
            };
            process.Start();
            process.WaitForExit();
            process.Close();
        }
    }
}
