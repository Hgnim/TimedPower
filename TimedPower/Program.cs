using System.Runtime.InteropServices;

namespace TimedPower
{
    internal static class Program
    {
       public const string version = "2.4.4.20241117";
        public const string aboutText =
@$"程序名: 定时电源
别名: TimedPower
版本:V{version}
Copyright (C) 2024 Hgnim, All rights reserved.
Github: https://github.com/Hgnim/TimedPower";
		/// <summary>
		///  The main entry point for the application.
		/// </summary>
		[STAThread]
        static void Main(string[] args)
        {
            {
				_ = new System.Threading.Mutex(true, "single_test", out bool runone);
				if (!runone)
                {
                        MessageBox.Show("不允许同时启动多个程序实例！",TimedPower.Main.ThisFormText, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                }
            }

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Main(args));
        }
    }
}