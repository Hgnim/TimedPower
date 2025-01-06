using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimedPower {
	public partial class SettingForm : Form {
		public SettingForm() => InitializeComponent();

		private void OkButton_Click(object sender, EventArgs e) => Ok();
		private void CancelButton_Click(object sender, EventArgs e) => Cancel();
		private void ApplyButton_Click(object sender, EventArgs e) => Apply();

		void Ok() {
			Apply();
			this.Close();
		}
		void Cancel() => this.Close();
		void Apply() {
			if(ContextMenuSetting.Tag as string == "change") {
				SettingControl.ContextMenu = ContextMenuSetting.Checked;
				ContextMenuSetting.Tag = null;
			}
			if(SelfStartingSetting.Tag as string == "change") {
				SettingControl.SelfStarting=SelfStartingSetting.Checked;
				SelfStartingSetting.Tag = null;
			}
			if(CloseToTaskBarSetting.Tag as string == "change") {
				Main.CloseToTaskBar=CloseToTaskBarSetting.Checked;
				CloseToTaskBarSetting.Tag = null;
			}
			applyButton.Enabled = false;
		}

		void ChangeSettingEH(object sender, EventArgs e) {
			if (!loadLock) {
				CheckBox? cb = sender as CheckBox;
				if (cb != null) {
					if (cb.Tag as string != "change")
						cb.Tag = "change";
				}
				if (!applyButton.Enabled) applyButton.Enabled = true;
			}
		}

		/// <summary>
		/// 如果在加载中，则不进行更改检测
		/// </summary>
		bool loadLock = true;
		private void SettingForm_Load(object sender, EventArgs e) {
			ContextMenuSetting.Checked = SettingControl.ContextMenu;
			SelfStartingSetting.Checked = SettingControl.SelfStarting;
			CloseToTaskBarSetting.Checked = Main.CloseToTaskBar;
			loadLock = false;
		}
	}
	internal static class SettingControl {
		internal static bool ContextMenu {
			// 获取当前设置状态
			get {
				using RegistryKey? key = RegPath.CU.root.OpenSubKey(RegPath.CU.ContextMenuPath, false);
				return key != null;
			}
			set {
				static void DeleteReg() {
					string[] regP = RegPath.CU.ContextMenuPath.Split('\\');
					//删除已有注册表
					RegPath.CU.root.OpenSubKey(
						string.Join('\\', regP.Take(regP.Length - 1)), true)?
						.DeleteSubKeyTree(regP.Last(), false);
				}
				switch (value) {
					case true: {
							DeleteReg();

							RegPath.CU.root.CreateSubKey(RegPath.CU.ContextMenuPath).Close();
							using (RegistryKey key = RegPath.CU.root.OpenSubKey(RegPath.CU.ContextMenuPath, true)!) {
								key.SetValue("MUIVerb", "定时电源", RegistryValueKind.String);
								key.SetValue("icon", FilePath.thisExeFilePath, RegistryValueKind.String);
								key.SetValue("SubCommands", "", RegistryValueKind.String);
							}

							string ContextMenuPath2 = RegPath.CU.ContextMenuPath + @"\shell";//二级目录
							RegPath.CU.root.CreateSubKey(ContextMenuPath2).Close();

							string[,] str1 = new string[,]
									{{ "15s","15秒后"},{"1min","1分钟后"} };
							string[,] str2 = new string[,]
							{ { "Shutdown","关机"} ,{"Reboot","重启"},{"Sleep","睡眠"} ,
								{"Hibernate","休眠"},{ "UserLock","锁定"},{ "UserOff","注销"} };

							for (int i = 0; i < str1.Length / 2; i++) {
								RegPath.CU.root.CreateSubKey($"{ContextMenuPath2}\\{str1[i,0]}").Close();
								using (RegistryKey key = RegPath.CU.root.OpenSubKey($"{ContextMenuPath2}\\{str1[i, 0]}", true)!) {
									key.SetValue("MUIVerb", str1[i,1], RegistryValueKind.String);
									key.SetValue("SubCommands", "", RegistryValueKind.String);
								}
								string ContextMenuPath3 = $"{ContextMenuPath2}\\{str1[i, 0]}\\shell";
								RegPath.CU.root.CreateSubKey(ContextMenuPath3).Close();
								for (int j = 0; j < str2.Length / 2; j++) {
									RegPath.CU.root.CreateSubKey($"{ContextMenuPath3}\\{str2[j,0]}").Close();
									RegPath.CU.root.CreateSubKey($"{ContextMenuPath3}\\{str2[j, 0]}\\command").Close();
									using (RegistryKey key = RegPath.CU.root.OpenSubKey($"{ContextMenuPath3}\\{str2[j, 0]}", true)!) {
										key.SetValue("", str2[j,1], RegistryValueKind.String);
									}
									using (RegistryKey key = RegPath.CU.root.OpenSubKey($"{ContextMenuPath3}\\{str2[j, 0]}\\command", true)!) {
										key.SetValue("", $"{FilePath.thisExeFilePath} -action {str2[j,0]} -time {str1[i,0]}", RegistryValueKind.String);
									}
								}
								}
							break;
						}
					case false:
						DeleteReg();
						break;
				}
			}
		}
		internal static bool SelfStarting {
			get {
				string[] regP = RegPath.CU.SelfStartingKey.Split('\\');
				using RegistryKey? key = RegPath.CU.root.OpenSubKey(string.Join('\\', regP.Take(regP.Length - 1)), false);
				return key?.GetValue(regP.Last()) != null;
			}
			set {
				string parentPath, keyName;
				{
					string[] regP = RegPath.CU.SelfStartingKey.Split('\\');
					parentPath = string.Join('\\', regP.Take(regP.Length - 1));
					keyName = regP.Last();
				}
				void DeleteReg() {
					using RegistryKey? key = RegPath.CU.root.OpenSubKey(parentPath, true);
					key?.DeleteValue(keyName, false);
				}
				switch (value) {
					case true: {
							DeleteReg();
							using RegistryKey? key = RegPath.CU.root.OpenSubKey(parentPath, true);
							key?.SetValue(keyName, $"{FilePath.thisExeFilePath} -hidden", RegistryValueKind.String);
							break;
						}
					case false:
						DeleteReg();
						break;
				}
			}
		}
		/*internal static bool TptFileLink {
			get {

			}
			set {

			}
		}*/
	}
}
