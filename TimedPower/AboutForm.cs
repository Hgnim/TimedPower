using static TimedPower.DataCore.DataFiles;
namespace TimedPower {
	public partial class AboutForm : Form {
		public AboutForm() => InitializeComponent();

		private void AboutForm_Load(object sender, EventArgs e) {
			info_name.Text = $"{PInfo.alias}({PInfo.name})";
			info_version.Text = $"V{PInfo.version}";
			info_copyright.Text = PInfo.copyright;
			info_githubUrl.Text = PInfo.githubUrl;

			statsBox_stats.Text =
@$"所有统计信息仅会存储在本地
启动次数: {statsData.StartNum}
执行操作次数: {statsData.DoActionNum}

更多统计信息敬请期待...
";
		}

		private void LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => 
			System.Diagnostics.Process.Start("explorer.exe", (sender as LinkLabel)?.Text!);
	}
}
