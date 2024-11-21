using EasyUpdateFromGithub;

namespace TimedPower
{
    internal static class Program
    {
       public const string version = "2.6.5.20241121";
        public const string aboutText =
@$"程序名: 定时电源
别名: TimedPower
版本: V{version}
Copyright (C) 2024 Hgnim, All rights reserved.
Github: https://github.com/Hgnim/TimedPower";
        public static UpdateFromGithub ufg=null!;
		/// <summary>
		///  The main entry point for the application.
		/// </summary>
		[STAThread]
        static void Main(string[] args)
        {
			{
				_ = new System.Threading.Mutex(true, "single_program", out bool runone);
				if (!runone)
                {
					File.Delete(FilePath.commandFile);
					StreamWriter streamWriter = new(FilePath.commandFile+".tmp", false, System.Text.Encoding.UTF8);
					foreach (string arg in args)
					{
						streamWriter.WriteLine(arg);
					}
					streamWriter.Close();
                    File.Move(FilePath.commandFile + ".tmp", FilePath.commandFile);
					//MessageBox.Show("不允许同时启动多个程序实例！",TimedPower.Main.ThisFormText, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            ufg = new()
            {
                EasySetCacheDir = FilePath.name,
                ProgramVersion = version,
                RepositoryURL = "https://github.com/Hgnim/TimedPower"
            };

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Main(args));
        }
    }
}