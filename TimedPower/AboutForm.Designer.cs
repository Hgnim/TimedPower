using System.Resources;

namespace TimedPower {
	partial class AboutForm {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
			info_githubUrl = new LinkLabel();
			info_github = new Label();
			info_copyright = new Label();
			info_version = new Label();
			info_name = new Label();
			statsBox = new GroupBox();
			statsBox_stats = new TextBox();
			statsBox.SuspendLayout();
			SuspendLayout();
			// 
			// info_githubUrl
			// 
			resources.ApplyResources(info_githubUrl, "info_githubUrl");
			info_githubUrl.Name = "info_githubUrl";
			info_githubUrl.LinkClicked += LinkClicked;
			// 
			// info_github
			// 
			resources.ApplyResources(info_github, "info_github");
			info_github.Name = "info_github";
			// 
			// info_copyright
			// 
			resources.ApplyResources(info_copyright, "info_copyright");
			info_copyright.Name = "info_copyright";
			// 
			// info_version
			// 
			resources.ApplyResources(info_version, "info_version");
			info_version.Name = "info_version";
			// 
			// info_name
			// 
			resources.ApplyResources(info_name, "info_name");
			info_name.Name = "info_name";
			// 
			// statsBox
			// 
			resources.ApplyResources(statsBox, "statsBox");
			statsBox.Controls.Add(statsBox_stats);
			statsBox.Name = "statsBox";
			statsBox.TabStop = false;
			// 
			// statsBox_stats
			// 
			resources.ApplyResources(statsBox_stats, "statsBox_stats");
			statsBox_stats.Name = "statsBox_stats";
			statsBox_stats.ReadOnly = true;
			statsBox_stats.TabStop = false;
			// 
			// AboutForm
			// 
			resources.ApplyResources(this, "$this");
			AutoScaleMode = AutoScaleMode.Font;
			Controls.Add(statsBox);
			Controls.Add(info_githubUrl);
			Controls.Add(info_github);
			Controls.Add(info_copyright);
			Controls.Add(info_name);
			Controls.Add(info_version);
			FormBorderStyle = FormBorderStyle.FixedDialog;
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "AboutForm";
			Load += AboutForm_Load;
			statsBox.ResumeLayout(false);
			statsBox.PerformLayout();
			ResumeLayout(false);
		}

		#endregion

		private Label info_copyright;
		private Label info_version;
		private Label info_name;
		private Label info_github;
		private LinkLabel info_githubUrl;
		private GroupBox statsBox;
		private TextBox statsBox_stats;
	}
}