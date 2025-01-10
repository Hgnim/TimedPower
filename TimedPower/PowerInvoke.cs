using System.Diagnostics;
using System.Runtime.InteropServices;

namespace TimedPower
{
    public static partial class PowerInvoke
    {
#pragma warning disable IDE0079
#pragma warning disable CA1401 // P/Invokes 应该是不可见的
		[LibraryImport("user32")]
		public static partial void LockWorkStation();
#pragma warning restore CA1401 // P/Invokes 应该是不可见的
#pragma warning restore IDE0079
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
            SetSuspendState(false, true, false);
        }
        /// <summary>
        /// 休眠
        /// </summary>
        public static void Hibernate()
        {
            /*if(*/
            ProcExec("shutdown", " " +
                         "/h");
                /*==0
                ) {
				MessageBox.Show("执行操作失败，可能是因为此系统没有启用休眠。",
					DataCore.LanguageData.GetLangStr(
						DataCore.LanguageData.GetLanguageResource(DataCore.FilePath.MainLanguageFile), "global.alias"
						),
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}*/
        }

        static int ProcExec(string fileName, string arguments)
        {
            using Process process = new()
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
            return process.ExitCode;
        }
    }
}
