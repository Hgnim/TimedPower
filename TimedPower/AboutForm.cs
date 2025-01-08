using static TimedPower.DataCore.DataFiles;
using static TimedPower.DataCore;
using System.Globalization;
using System.Resources;
namespace TimedPower {
	public partial class AboutForm : Form {
		public AboutForm() { 
			InitializeComponent();

			Main.ProgramLanguage.UpdateLanguage += UpdateLanguage;
			UpdateLanguage();
		}
		static ResourceManager langRes = null!;
		static string GetLangStr(string key, string head = "aboutForm") => langRes.GetString($"{head}.{key}", CultureInfo.CurrentUICulture)!;
		void UpdateLanguage() {
			LanguageData.UpdateLanguageResource(out langRes, FilePath.MainLanguageFile);
			LanguageData.UpdateFormLanguage(this);
		}

		private void AboutForm_Load(object sender, EventArgs e) {
			info_name.Text = PInfo.Alias;
			info_version.Text = $"V{PInfo.version}";
			info_copyright.Text = PInfo.copyright;
			info_githubUrl.Text = PInfo.githubUrl;

			statsBox_stats.Text =string.Format(GetLangStr("stats"),
				statsData.StartNum,
				statsData.DoActionNum
				);
		}

		private void LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => 
			System.Diagnostics.Process.Start("explorer.exe", (sender as LinkLabel)?.Text!);
	}
}
