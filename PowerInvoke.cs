using System.Diagnostics;
using System.Runtime.InteropServices;

namespace TimedPower
{
    public static partial class PowerInvoke
    {
        /*/// <summary>
        /// 如果启用了终端服务，则此标志不起作用。 否则，系统不会发送 WM_QUERYENDSESSION 消息。 这可能会导致应用程序丢失数据。 因此，应仅在紧急情况下使用此标志。
        /// </summary>
        const uint EWX_FORCE = 0x00000004;
        /// <summary>
        /// 如果进程在超时间隔内不响应 WM_QUERYENDSESSION 或 WM_ENDSESSION 消息，则强制终止。
        /// </summary>
        const uint EWX_FORCEIFHUNG = 0x00000010;
        /// <summary>
        /// 关闭系统并关闭电源。 系统必须支持关机功能。
        /// 调用进程必须具有SE_SHUTDOWN_NAME特权。
        /// </summary>
        const uint EWX_POWEROFF = 0x00000008;
        /// <summary>
        /// 将系统关闭到可以安全关闭电源的点。 所有文件缓冲区都已刷新到磁盘，并且所有正在运行的进程都已停止。
        /// 调用进程必须具有SE_SHUTDOWN_NAME特权。 有关更多信息，请参见下面的“备注”部分。
        /// 指定此标志不会关闭电源，即使系统支持关机功能。 必须指定EWX_POWEROFF才能执行此操作。使用 SP1 的 Windows XP： 如果系统支持关机功能，则指定此标志会关闭电源。
        /// </summary>
        const uint EWX_SHUTDOWN = 0x00000001;
        /// <summary>
        /// 关闭系统，然后重启系统。
        /// 调用进程必须具有SE_SHUTDOWN_NAME特权。
        /// </summary>
        const uint EWX_REBOOT = 0x00000002;
        /// <summary>
        /// 关闭调用 ExitWindowsEx 函数的进程登录会话中运行的所有进程。 然后，它会注销用户。
        /// 此标志只能由在交互式用户的登录会话中运行的进程使用。
        /// </summary>
        const uint EWX_LOGOFF = 0x00000000;
        //https://learn.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-exitwindowsex

        /// <summary>
        /// 其他问题。
        /// </summary>
        const uint SHTDN_REASON_MAJOR_OTHER = 0x00000000;
        /// <summary>
        /// 其他问题。
        /// </summary>
        const uint SHTDN_REASON_MINOR_OTHER = 0x00000000;
        /// <summary>
        /// 计划关闭。 系统 (SSD) 文件生成系统状态数据。 此文件包含系统状态信息，例如进程、线程、内存使用情况和配置。
        /// </summary>
        const uint SHTDN_REASON_FLAG_PLANNED = 0x80000000;
        //https://learn.microsoft.com/zh-cn/windows/win32/shutdown/system-shutdown-reason-codes


        [LibraryImport("user32")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static partial bool ExitWindowsEx(uint uFlags, uint dwReason);*/
#pragma warning disable CA1401 // P/Invokes 应该是不可见的
        [LibraryImport("user32")]
        public static partial void LockWorkStation();
#pragma warning restore CA1401 // P/Invokes 应该是不可见的
        [LibraryImport("PowrProf.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static partial bool SetSuspendState([MarshalAs(UnmanagedType.Bool)] bool hiberate, [MarshalAs(UnmanagedType.Bool)] bool forceCritical, [MarshalAs(UnmanagedType.Bool)] bool disableWakeEvent);


        /*/// <summary>
        /// 强制关闭系统并关闭电源
        /// </summary>
        public static void Poweroff()
        {
            ExitWindowsEx(EWX_POWEROFF | EWX_FORCE,
                SHTDN_REASON_MAJOR_OTHER | SHTDN_REASON_MINOR_OTHER | SHTDN_REASON_FLAG_PLANNED);
        }*/
        /*/// <summary>
        /// 将系统关闭到可以安全关闭电源的点(安全关机)
        /// </summary>*/
        /// /// <summary>
        /// 关机
        /// </summary>
        public static void Shutdown()
        {
            /*ExitWindowsEx(EWX_SHUTDOWN | EWX_FORCEIFHUNG
                , SHTDN_REASON_MAJOR_OTHER | SHTDN_REASON_MINOR_OTHER | SHTDN_REASON_FLAG_PLANNED);*/
            ProcExec("shutdown", " /d p:0:0 /c \"TimedPower定时电源进行的操作\" " +
                                 "/s /t 0");
        }
        /// <summary>
        /// 重启
        /// </summary>
        public static void Reboot()
        {
            /*ExitWindowsEx(EWX_REBOOT | EWX_FORCEIFHUNG
                , SHTDN_REASON_MAJOR_OTHER | SHTDN_REASON_MINOR_OTHER | SHTDN_REASON_FLAG_PLANNED);*/
            ProcExec("shutdown", " /d p:0:0 /c \"TimedPower定时电源进行的操作\" " +
                                 "/r /t 0");
        }
        /// <summary>
        /// 注销
        /// </summary>
        public static void UserOff()
        {
            /*ExitWindowsEx(EWX_LOGOFF | EWX_FORCEIFHUNG,
                SHTDN_REASON_MAJOR_OTHER | SHTDN_REASON_MINOR_OTHER | SHTDN_REASON_FLAG_PLANNED);*/
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

       static void ProcExec(string fileName,string arguments)
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
