using EasyUpdateFromGithub;

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
					File.Delete(FilePath.commandFile);
                    using (StreamWriter sw = new(FilePath.commandFile + ".tmp", false, System.Text.Encoding.UTF8)) {
                        if (args.Length > 0) {
                            foreach (string arg in args) {
                                sw.WriteLine(arg);
                            }
                        }
                        else {
                            sw.WriteLine("-focus");//���û�в����������ʱ�û�˫���򿪣��򴫵ݻ�ȡ�������
                        }
                    }
                    File.Move(FilePath.commandFile + ".tmp", FilePath.commandFile);
					//MessageBox.Show("������ͬʱ�����������ʵ����",TimedPower.Main.ThisFormText, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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