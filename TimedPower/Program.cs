using System.Runtime.InteropServices;

namespace TimedPower
{
    internal static class Program
    {
       public const string version = "2.3.4.20241029";
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            {
                bool runone;
                _ = new System.Threading.Mutex(true, "single_test", out runone);
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