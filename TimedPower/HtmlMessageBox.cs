using System.Text;
using System.Media;
using System.Diagnostics;
using System;
using Microsoft.Web.WebView2.Core;

namespace TimedPower {
	public partial class HtmlMessageBox : Form {
		/// <summary>
		/// 结果代码
		/// </summary>
		public int ResultCode { get; set; } = -1;

		public Sounds PlaySound { get; set; } = Sounds.none;

		string tmpFilePath;
		/// <summary>
		/// 显示Html的消息框
		/// </summary>
		/// <param name="htmlMessage">html文本</param>
		/// <param name="buttons">窗口下的多个按钮</param>
		/// <param name="title">窗口标题</param>
		/// <param name="playSound">弹出窗口时播放的系统提示音</param>
		/// <param name="defaultButtonIndex">默认选择的按钮的序号</param>
		/// <param name="formSize">窗口打开时的大小</param>
		/// <param name="userCanChangeFormSize">窗口大小是否能被用户更改</param>
		/// <param name="webCacheAndUserDataFolder">WebView2引擎使用时生成的缓存文件与用户文件的存储位置，如果为null则存在与程序同级的目录中</param>
		public HtmlMessageBox(
				string htmlMessage, 
				HMsgBoxButton[] buttons, string title = "", 
				Sounds playSound = Sounds.none, 
				int defaultButtonIndex = 0, 
				Size? formSize = null, 
				bool userCanChangeFormSize = false,
				string? webCacheAndUserDataFolder = "normal"
			) {
			InitializeComponent();
			if(webCacheAndUserDataFolder=="normal") webCacheAndUserDataFolder = DataCore.FilePath.webViewCacheDir;
			htmlView.EnsureCoreWebView2Async(CoreWebView2Environment.CreateAsync(null, webCacheAndUserDataFolder).Result);//更改WebView2的数据存储目录

			this.Text = title;
			this.FormBorderStyle = userCanChangeFormSize ? FormBorderStyle.Sizable : FormBorderStyle.FixedDialog;
			PlaySound = playSound;
			for (int i = 0; true; i++) {
				tmpFilePath = $"{DataCore.FilePath.htmlMessageBoxDir}hmb-tmp_{i}.html";
				if (!File.Exists(tmpFilePath)) {
					if (!Directory.Exists(DataCore.FilePath.htmlMessageBoxDir)) Directory.CreateDirectory(DataCore.FilePath.htmlMessageBoxDir);
					using (StreamWriter sw = new(tmpFilePath, false, Encoding.UTF8)) {
						sw.Write(htmlMessage);
					}
					break;
				}
			}
			htmlView.Source = new Uri($"file:///{tmpFilePath}", UriKind.Absolute);
			for (int i = 0; i < buttons.Length; i++) {
				Button btn = new() {
					Text = buttons[i].Text,
					Anchor = AnchorStyles.Bottom | AnchorStyles.Right,
					AutoSize = true,
					Location = new Point(0/*245*/, 143),
					Name = $"actionButton-{i}",
					Size = new Size(0/*56*/, 27),
					TabIndex = i,
					UseVisualStyleBackColor = true,
				};
				btn.Click += (sender, e) => {
					int index = int.Parse((sender as Button)!.Name.Split('-')[1]);
					{
						DialogResult? dr = buttons[index].Result;
						if (dr != null) this.DialogResult = (DialogResult)dr;
					}
					ResultCode = buttons[index].ResultCode;

					this.Close();
				};

				this.Controls.Add(btn);

				if (i != 0)
					btn.Location = new Point(hmsgBoxButtons[i - 1].Location.X - hmsgBoxButtons[i - 1].Size.Width - 5, btn.Location.Y);
				else
					btn.Location = new Point(this.Size.Width - 25 - btn.Size.Width, btn.Location.Y);

				if (i == defaultButtonIndex)
					btn.Select();

				hmsgBoxButtons.Add(btn);
			}
			if (formSize != null) this.Size = (Size)formSize;
		}
		readonly List<Button> hmsgBoxButtons = [];

		private void HtmlMessageBox_FormClosed(object sender, FormClosedEventArgs e) => File.Delete(tmpFilePath);

		public class HMsgBoxButton {
			/// <summary>
			/// 设置按钮的文本
			/// </summary>
			public required string Text { get; set; }
			/// <summary>
			/// 设置点击按钮后的结果
			/// </summary>
			public DialogResult? Result { get; set; } = null;
			/// <summary>
			/// 设置点击按钮后的结果代码
			/// </summary>
			public int ResultCode { get; set; } = 0;
		}

		public enum Sounds {
			none, information, warning, error
		}

		private void HtmlMessageBox_Shown(object sender, EventArgs e) {
			switch (PlaySound) {
				case Sounds.information:
					SystemSounds.Asterisk.Play();
					break;
				case Sounds.warning:
					SystemSounds.Exclamation.Play();
					break;
				case Sounds.error:
					SystemSounds.Hand.Play();
					break;
			}
		}

		private void HtmlMessageBox_Load(object sender, EventArgs e) {
#if DEBUG
			SizeChanged += (object? sender, EventArgs e) => Debug.WriteLine($"HtmlMessageBox Size: {this.Size}");
#endif
		}
	}
}
