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
			info_githubUrl = new LinkLabel();
			info_github = new Label();
			info_copyright = new Label();
			info_version = new Label();
			info_name = new Label();
			statsBox = new GroupBox();
			statsBox_text = new Label();
			statsBox_stats = new TextBox();
			statsBox.SuspendLayout();
			SuspendLayout();
			// 
			// info_githubUrl
			// 
			info_githubUrl.Location = new Point(49, 34);
			info_githubUrl.Name = "info_githubUrl";
			info_githubUrl.Size = new Size(286, 17);
			info_githubUrl.TabIndex = 4;
			info_githubUrl.LinkClicked += LinkClicked;
			// 
			// info_github
			// 
			info_github.Location = new Point(3, 34);
			info_github.Name = "info_github";
			info_github.Size = new Size(49, 17);
			info_github.TabIndex = 3;
			info_github.Text = "Github:";
			// 
			// info_copyright
			// 
			info_copyright.Anchor = AnchorStyles.Bottom;
			info_copyright.Location = new Point(3, 181);
			info_copyright.Name = "info_copyright";
			info_copyright.Size = new Size(332, 17);
			info_copyright.TabIndex = 2;
			info_copyright.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// info_version
			// 
			info_version.Location = new Point(3, 17);
			info_version.Name = "info_version";
			info_version.Size = new Size(332, 17);
			info_version.TabIndex = 1;
			// 
			// info_name
			// 
			info_name.Location = new Point(3, 0);
			info_name.Name = "info_name";
			info_name.Size = new Size(332, 17);
			info_name.TabIndex = 0;
			// 
			// statsBox
			// 
			statsBox.Controls.Add(statsBox_stats);
			statsBox.Controls.Add(statsBox_text);
			statsBox.Location = new Point(3, 54);
			statsBox.Name = "statsBox";
			statsBox.Size = new Size(332, 124);
			statsBox.TabIndex = 5;
			statsBox.TabStop = false;
			statsBox.Text = "统计";
			// 
			// statsBox_text
			// 
			statsBox_text.AutoSize = true;
			statsBox_text.Font = new Font("Microsoft YaHei UI", 7F);
			statsBox_text.Location = new Point(110, 10);
			statsBox_text.Name = "statsBox_text";
			statsBox_text.Size = new Size(107, 16);
			statsBox_text.TabIndex = 0;
			statsBox_text.Text = "统计信息仅存储在本地";
			// 
			// statsBox_stats
			// 
			statsBox_stats.Location = new Point(9, 29);
			statsBox_stats.Multiline = true;
			statsBox_stats.Name = "statsBox_stats";
			statsBox_stats.ReadOnly = true;
			statsBox_stats.Size = new Size(317, 89);
			statsBox_stats.TabIndex = 1;
			// 
			// AboutForm
			// 
			AutoScaleDimensions = new SizeF(7F, 17F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(337, 198);
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
			StartPosition = FormStartPosition.CenterParent;
			Text = "关于";
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
		private Label statsBox_text;
		private TextBox statsBox_stats;
	}
}