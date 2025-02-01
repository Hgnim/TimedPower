using Microsoft.Web.WebView2.WinForms;

namespace TimedPower {
	partial class HtmlMessageBox {
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
			HtmlPanel = new Panel();
			htmlView = new WebView2();
			HtmlPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)htmlView).BeginInit();
			SuspendLayout();
			// 
			// HtmlPanel
			// 
			HtmlPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			HtmlPanel.Controls.Add(htmlView);
			HtmlPanel.Location = new Point(0, 0);
			HtmlPanel.Name = "HtmlPanel";
			HtmlPanel.Size = new Size(301, 174);
			HtmlPanel.TabIndex = 0;
			// 
			// htmlView
			// 
			htmlView.AllowExternalDrop = false;
			htmlView.CreationProperties = null;
			htmlView.DefaultBackgroundColor = Color.White;
			htmlView.Dock = DockStyle.Fill;
			htmlView.Location = new Point(0, 0);
			htmlView.Name = "htmlView";
			htmlView.Size = new Size(301, 174);
			htmlView.TabIndex = 0;
			htmlView.TabStop = false;
			htmlView.ZoomFactor = 1D;
			// 
			// HtmlMessageBox
			// 
			AutoScaleMode = AutoScaleMode.None;
			ClientSize = new Size(301, 174);
			Controls.Add(HtmlPanel);
			FormBorderStyle = FormBorderStyle.FixedDialog;
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "HtmlMessageBox";
			ShowIcon = false;
			StartPosition = FormStartPosition.CenterParent;
			FormClosed += HtmlMessageBox_FormClosed;
			Load += HtmlMessageBox_Load;
			Shown += HtmlMessageBox_Shown;
			HtmlPanel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)htmlView).EndInit();
			ResumeLayout(false);
		}

		#endregion

		private Panel HtmlPanel;
		private WebView2 htmlView;
	}
}