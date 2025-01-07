using Microsoft.Win32;
using System.Globalization;
using System.Resources;
using static TimedPower.DataCore;

namespace TimedPower {
	public partial class SettingForm : Form {
		public SettingForm() 
		{ 
			InitializeComponent();

			Main.ProgramLanguage.UpdateLanguage += UpdateLanguage;
			UpdateLanguage();
		}
		static ResourceManager langRes = null!;
		static string GetLangStr(string key, string head = "setting") => langRes.GetString($"{head}.{key}", CultureInfo.CurrentUICulture)!;
		void UpdateLanguage() {
			LanguageData.UpdateLanguageResource(out langRes, FilePath.MainLanguageFile);
			LanguageData.UpdateFormLanguage(this);
		}

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
			if(languageSetting.Tag as string == "change") {
				Main.ProgramLanguage.SettingValue=(LanguageData.Language.Langs)languageSetting.SelectedIndex;//该下拉框内的选项顺序必须和枚举的顺序一致
			}
			applyButton.Enabled = false;
		}

		void ChangeSettingEH(object sender, EventArgs e) {
			if (!loadLock) {
				dynamic? obj = sender ;
				if (obj != null) {
					if (obj.Tag as string != "change")
						obj.Tag = "change";
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
			languageSetting.SelectedIndex=(int)Main.ProgramLanguage.SettingValue;
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
							//获取语言资源
							ResourceManager langRes = LanguageData.GetLanguageResource(FilePath.MainLanguageFile);
							string GetLangStr(string key, string head = "setting.contextMenu") => 
								langRes.GetString($"{head}.{key}", CultureInfo.CurrentUICulture)!;


							DeleteReg();

							RegPath.CU.root.CreateSubKey(RegPath.CU.ContextMenuPath).Close();
							using (RegistryKey key = RegPath.CU.root.OpenSubKey(RegPath.CU.ContextMenuPath, true)!) {
								key.SetValue("MUIVerb", GetLangStr("title"), RegistryValueKind.String);
								key.SetValue("icon", FilePath.thisExeFilePath, RegistryValueKind.String);
								key.SetValue("SubCommands", "", RegistryValueKind.String);
							}

							string ContextMenuPath2 = RegPath.CU.ContextMenuPath + @"\shell";//二级目录
							RegPath.CU.root.CreateSubKey(ContextMenuPath2).Close();

							string[,] str1 = new string[,]
									{{ "15s",GetLangStr("af15s")},{"1min",GetLangStr("af1min")} };
							string[,] str2 = new string[,]
							{ { "Shutdown",GetLangStr("shutdown","global")} ,
							{"Reboot",GetLangStr("reboot","global")},
							{"Sleep",GetLangStr("sleep","global")} ,
								{"Hibernate",GetLangStr("hibernate","global")},
								{ "UserLock",GetLangStr("userlock","global")},
								{ "UserOff",GetLangStr("useroff","global")} };

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
