using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using static TimedPower.DataCore;

namespace TimedPower
{
    public static class BatFile
    {
    }
	internal static class BatFileControl {
		/// <summary>
		/// 执行
		/// </summary>
		/// <param name="batFiles">文件</param>
        /// <param name="admin">是否使用管理员权限</param>
		public static void RunBat(string[] batFiles ,bool admin=false) {
			foreach (string file in batFiles) {
				Assembly assembly = Assembly.GetExecutingAssembly();
				string resPath = $"TimedPower.BatFiles.{file}";
				Stream stream = assembly.GetManifestResourceStream(resPath)!;
				Stream outFile = File.Create(FilePath.TempDir + file);
				stream.CopyTo(outFile);
				outFile.Close();
				stream.Close();
			}

			string allFileString = "\"";
			for (int i = 0; i < batFiles.Length; i++) {
				allFileString += FilePath.TempDir + batFiles[i];
				if (i + 1 < batFiles.Length)
					allFileString += " & ";
			}
			allFileString += "\"";

			using Process process = new() {
				StartInfo = new ProcessStartInfo {
					UseShellExecute = true,
					CreateNoWindow = true,
					FileName = "cmd.exe",
					Arguments = " /c " + allFileString
				}
			};
			if (admin) {
				process.StartInfo.Verb = "RunAs"; // 请求管理员权限
			}
			try {
				process.Start();
				process.WaitForExit();
			} catch (Win32Exception) { MessageBox.Show("用户取消了授权", Main.ThisFormText, MessageBoxButtons.OK, MessageBoxIcon.Error); } catch { MessageBox.Show("发生未知错误！", Main.ThisFormText, MessageBoxButtons.OK, MessageBoxIcon.Error); }
			//process.Close();
		}
	}
}
