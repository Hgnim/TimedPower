using System.ComponentModel;
using System.Diagnostics;
using System.Text;

namespace TimedPower
{
    public static class BatFile
    {
        /// <summary>
        /// windows桌面右键菜单管理类
        /// </summary>
        public static class WindowsRightClickMenu
        {
            static readonly string filePath = System.IO.Path.GetTempPath() +"TimedPower\\";
            static readonly string addMenu_BatFilePath=filePath +"AddMenu.bat";
            static readonly string removeMenu_BatFilePath = filePath + "RemoveMenu.bat";
            static readonly string thisExeFilePath= System.Windows.Forms.Application.ExecutablePath;//执行文件路径

            static readonly string regPath = "HKEY_CLASSES_ROOT\\Directory\\Background\\shell\\TimedPower";
            static readonly string regPath2 = "HKEY_CLASSES_ROOT\\Directory\\Background\\shell\\TimedPower\\shell\\";//二级目录

            /// <summary>
            /// 执行: 创建windows桌面右键菜单
            /// </summary>
            public static void RunAdd()
            {
                RunBat("add");
            }
            /// <summary>
            /// 执行: 移除windows桌面右键菜单
            /// </summary>
            public static void RunRemove() 
            {
                RunBat("remove");
            }
            /// <summary>
            /// 运行bat文件
            /// </summary>
            /// <param name="fileID">文件ID: add; remove</param>
            public static void RunBat(string fileID)
            {
                FileExistCheck();

                // 检查当前进程是否以管理员身份运行
                //if (!new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator))
                string filePath = "";
                switch (fileID)
                {
                    case "add":
                        filePath=addMenu_BatFilePath; break;
                    case "remove":
                        filePath=removeMenu_BatFilePath;break;
                }

                Process process = new()
                {
                    StartInfo = new ProcessStartInfo
                    {
                        UseShellExecute =true,
                        Verb = "RunAs", // 请求管理员权限
                        CreateNoWindow = true,
                        FileName = "cmd.exe",
                        Arguments = " /c " + filePath
                    }
                };
                try
                {
                    process.Start();
                    process.WaitForExit();
                }
                catch (Win32Exception) { MessageBox.Show("用户取消了授权", Main.ThisFormText, MessageBoxButtons.OK, MessageBoxIcon.Error); }
                catch { MessageBox.Show("发生位置错误！", Main.ThisFormText, MessageBoxButtons.OK, MessageBoxIcon.Error); }
                process.Close();
            }
            /// <summary>
            /// 检查bat文件是否存在，如果不存在则创建
            /// </summary>
            /// <returns>创建或检查成功返回true，创建文件失败则返回false</returns>
            static bool FileExistCheck()
            {
                //try
                //{
                   /* if (!File.Exists(addMenu_BatFilePath) || !File.Exists(removeMenu_BatFilePath))
                    {
                        Directory.CreateDirectory(filePath);
                        if (!File.Exists(addMenu_BatFilePath))    BatFile_Create("add");
                        if (!File.Exists(removeMenu_BatFilePath)) BatFile_Create("remove");
                    }*/
                BatFile_Create("add");
                BatFile_Create("remove");
                //}
                //catch { return false; }
                return true;
            }
            /// <summary>
            /// 创建bat文件
            /// </summary>
            /// <param name="fileID">文件ID: add; remove</param>
            static void BatFile_Create(string fileID)
            {
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                switch (fileID)
                {
                    case "add":
                        {
                            static string GetSub()
                            {
                                string output = "";

                                //在此处设置右键菜单选项的合集，ID和名称
                                string[,] str1 = new string[,]
                                {{ "15s","15秒后"},{"1min","1分钟后"} };
                                string[,] str2 = new string[,]
                                { { "Shutdown","关机"} ,{"Reboot","重启"},{"Sleep","睡眠"} ,
                                {"Hibernate","休眠"},{ "UserLock","锁定"},{ "UserOff","注销"} };

                                for(int i = 0; i < str1.Length/2; i++)
                                {
                                    output +=
                                    "\r\n" + "reg add " + regPath2 + str1[i, 0] + " /f /v \"MUIVerb\" /t REG_SZ /d \"" + str1[i, 1] + "\"" +
                                    "\r\n" + "reg add " + regPath2 + str1[i, 0] + " /f /v \"SubCommands\" /t REG_SZ";
                                    for (int j = 0; j < str2.Length / 2; j++)
                                    {
                                        output +=
                                        "\r\n" + "reg add " + regPath2 + str1[i, 0] + "\\shell\\" + str2[j, 0] + " /f /ve /d \"" + str2[j, 1] + "\"" +
                                        "\r\n" + "reg add " + regPath2 + str1[i, 0] + "\\shell\\" + str2[j, 0] + "\\command /f /ve /d \"" + thisExeFilePath + " -type " + str2[j, 0] + " -time \"" + str1[i, 0] + "\"";
                                    }
                                }
                                return output;
                            }
                            StreamWriter writer=new(addMenu_BatFilePath,false, Encoding.GetEncoding("gbk"));
                            writer.Write
                                (
                                         "reg delete " + regPath + " /f"+
                                "\r\n" + "reg add " + regPath + " /f /v \"MUIVerb\" /t REG_SZ /d \"定时电源\"" +
                                "\r\n" + "reg add "+regPath+" /f /v \"icon\" /t REG_SZ /d \"" + thisExeFilePath +"\"" +
                                "\r\n" + "reg add "+regPath+" /f /v \"SubCommands\" /t REG_SZ" +

                                GetSub()
                                );
                            writer.Close();
                        }break;
                    case "remove":
                        {
                            StreamWriter writer = new(removeMenu_BatFilePath, false, Encoding.GetEncoding("gbk"));
                            writer.Write
                                (
                                         "reg delete " + regPath + " /f" 
                                );
                            writer.Close();
                        }
                        break;
                }
            }
        }
    }
}
