using EasyUpdateFromGithub;
using System.ComponentModel.Design;
using static TimedPower.DataCore;

namespace TimedPower
{
		internal static class Program
    {       
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
                    if(!Directory.Exists(FilePath.CommandDir))
                        Directory.CreateDirectory(FilePath.CommandDir);
					File.Delete(FilePath.commandFile);
                    using (StreamWriter sw = new(FilePath.commandFile + ".tmp", false, System.Text.Encoding.UTF8)) {
                        if (args.Length > 0) {
                            foreach (string arg in args) {
                                sw.WriteLine(arg);
                            }
                        }
                        else {
                            sw.WriteLine("-focus");//如果没有参数，则代表时用户双击打开，则传递获取焦点参数
                        }
                    }
                    File.Move(FilePath.commandFile + ".tmp", FilePath.commandFile);
					//MessageBox.Show("不允许同时启动多个程序实例！",TimedPower.Main.ThisFormText, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            ufg = new()
            {
                EasySetCacheDir = PInfo.name,
                ProgramVersion = PInfo.version,
                RepositoryURL = PInfo.githubUrl
			};

            ApplicationConfiguration.Initialize();
            Application.Run(new Main(args));
        }
    }
}