using Microsoft.Toolkit.Uwp.Notifications;
using System.Diagnostics;
using Windows.Foundation.Collections;
using static TimedPower.TaskbarProgressBar;
using System.Xml;
using static TimedPower.AutoTaskData;
using static TimedPower.Program;
using EasyUpdateFromGithub;
using static TimedPower.DataCore;
using static TimedPower.DataCore.DataFiles;
using static TimedPower.TimedPowerTask;
using System.Resources;
using System.Globalization;
using Markdig;
using ReaLTaiizor.Enum.Poison;
using ReaLTaiizor.Forms;

namespace TimedPower
{
	public partial class Main : PoisonForm {
		static string[] args = [];

		public Main(string[] args) {
			Main.args = args;
	
			if (File.Exists(FilePath.MainDataFile)) {
				DataFile.ReadData();
				ProgramLanguage.SettingValue = mainData.Setting.Language;
				themeManager.CurrentTheme = mainData.Setting.Theme;
			}

			UpdateLanguageResource();
			InitializeComponent();
			ProgramLanguage.UpdateLanguage += UpdateLanguage;

			void UpdateTheme() => themeManager.UpdateFormTheme(ref poisonStyleManager);
			themeManager.UpdateTheme += UpdateTheme;
			UpdateTheme();
		}
		static ResourceManager? langRes;
		static string GetLangStr(string key, string head = "main") => langRes?.GetString($"{head}.{key}", CultureInfo.CurrentUICulture)!;
		void UpdateLanguage() {
			UpdateLanguageResource();
			if (countdownThread==null || !countdownThread.IsAlive) {//必须在主要计时器停止工作的情况下刷新主窗口，否则会导致UI异常
				LanguageData.UpdateFormLanguage(this,
					moreObj: [new LanguageData.CustomObjName() { Name = nameof(notifyIcon_main), Obj = notifyIcon_main }]);

				TimeTypeSelect_SelectedIndexChanged(null!,null!);//刷新时间类型，解决在刷新主窗口后时间输入框消失的问题
			}
		}
		void UpdateLanguageResource() => LanguageData.UpdateLanguageResource(out langRes, FilePath.MainLanguageFile);


		readonly AfterTimeValue atv = new();
		#region Main_From		
		/// <summary>
		/// 监视命令文件夹，用于接收命令
		/// </summary>
		FileSystemWatcher? commandWatcher;
		private void Main_Load(object sender, EventArgs e) {
			ActionSelect.SelectedIndex = 0;
			TimeTypeSelect.SelectedIndex = 0;

			if (!Directory.Exists(FilePath.ConfigDir)) _ = Directory.CreateDirectory(FilePath.ConfigDir);
			if (!Directory.Exists(FilePath.TempDir)) _ = Directory.CreateDirectory(FilePath.TempDir);
			if (!Directory.Exists(FilePath.CommandDir)) _ = Directory.CreateDirectory(FilePath.CommandDir);
			if (File.Exists(FilePath.MainDataFile)) {
				//将读取文件函数调用转移至类初始化区域
				{
					do {
						if (!(mainData.Window.X >= 0 && mainData.Window.X + Width <= System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Width))
							break;
						if (!(mainData.Window.Y >= 0 && mainData.Window.Y + Height <= System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Height))
							break;
						Left = mainData.Window.X;
						Top = mainData.Window.Y;
					} while (false);

					ActionSelect.SelectedIndex = mainData.Action;

					TimeTypeSelect.SelectedIndex = mainData.TimeType;

					TimeInput.Text = mainData.TimeInput;

					CloseToTaskBar = mainData.Setting.CloseToTaskBar;

					IsAutoCheckUpdate = mainData.Setting.AutoCheckUpdate;

					//根据不同版本的变化进行更新操作
					if (mainData.Version < PInfo.ShortVersionNum) {
						if (mainData.Version < 277) {
							MessageBox.Show(GetLangStr("messagebox.newVersionNeedRemoveOldVersionReg"), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
							//新版本的注册表数据将保存在用户目录，旧版本中存放在注册表系统目录中的数据需要被删除，避免重复
							BatFileControl.RunBat(["RemoveOldVersionRegData.bat"], true);
						}
					}
				}
			}
			else if (File.Exists(FilePath.MainDataFile_Obsolete)) {
				//检查程序是否还存在旧的2.6.6版本前的xml格式的数据文件，如果存在则读取
				try {
					XmlDocument xmlDoc = new();
					XmlNode xmlRoot;
					xmlDoc.Load(FilePath.MainDataFile_Obsolete);
					xmlRoot = xmlDoc.SelectSingleNode("TimedPower_Data")!;
					XmlNodeList xmlNL = xmlRoot.ChildNodes;
					foreach (XmlNode xn in xmlNL) {
						XmlElement xmlE = (XmlElement)xn;
						switch (xmlE.Name) {
							case "first":
								try { DataFiles.mainData.First = !Convert.ToBoolean(int.Parse(xmlE.GetAttribute("value"))); } catch { }
								break;
							case "Window":
								try {
									int[] temp = [int.Parse(xmlE.GetAttribute("x")), int.Parse(xmlE.GetAttribute("y"))];
									if (temp[0] >= 0 && temp[0] + Width <= System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Width)
										Left = temp[0];
									if (temp[1] >= 0 && temp[1] + Height <= System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Height)
										Top = temp[1];
								} catch { }
								break;
							case "Action":
								try { ActionSelect.SelectedIndex = int.Parse(xmlE.GetAttribute("index")); } catch { }
								break;
							case "TkAction":
								try { TimeTypeSelect.SelectedIndex = int.Parse(xmlE.GetAttribute("index")); } catch { }
								break;
							case "TimeInput":
								try { TimeInput.Text = xmlE.GetAttribute("value"); } catch { }
								break;
							case "CloseToTaskBar":
								try { CloseToTaskBar = bool.Parse(xmlE.GetAttribute("boolean")); } catch { }
								break;
							case "AutoCheckUpdate":
								try { IsAutoCheckUpdate = bool.Parse(xmlE.GetAttribute("boolean")); } catch { }
								break;
						}
					}
					File.Delete(FilePath.MainDataFile_Obsolete);
				} catch { }
			}
			if (!File.Exists(FilePath.AutoTaskFile)) {
				XmlTextWriter xmlWriter = new(FilePath.AutoTaskFile, System.Text.Encoding.GetEncoding("utf-8")) { Formatting = System.Xml.Formatting.Indented };

				xmlWriter.WriteRaw("<?xml version=\"1.0\" encoding=\"utf-8\" ?>");
				xmlWriter.WriteComment("注意，私自修改数据文件导致的程序错误开发者概不负责!");
				xmlWriter.WriteStartElement("TimedPower_AutoTask");
				xmlWriter.WriteStartElement("task");
				xmlWriter.WriteEndElement();
				xmlWriter.WriteFullEndElement();
				xmlWriter.Close();
			}
			AutoTaskData.GetDataFromFile();
			if (DataFiles.mainData.First) {
				DataFiles.mainData.First = false;

			}

			DefendAutoTask.SetDefendTime(30);//程序启动后将有30秒的自动任务防御时间
			CountdownStateControl.IsEnable_Change += AutoTask_CountdownState_IsEnable_Change;
			AutoTaskData.CountdownStateControl.UpdateData();//刷新自动任务


			//监视命令文件夹，用于接收命令
			commandWatcher = new(FilePath.CommandDir) {
				EnableRaisingEvents = true,
				Filter = "Command.dat"
			};
			commandWatcher.Renamed += (s, e) => {
				bool canStart = false;
				{
					bool wait = false;
					Invoke(new Action(() => {
						ShowMainForm();
						canStart = StartButton.Visible;
						wait = true;
					}));
					while (!wait) ;
				}
				if (canStart) {
					List<string> cacheReadArgs = [];
					StreamReader sr = new(FilePath.commandFile, System.Text.Encoding.UTF8);
					while (true) {
						string? read = sr.ReadLine();
						if (read is not null and not "") {//同(read != null && read != "")
							cacheReadArgs.Add(read);
						}
						else break;
					}
					sr.Close();
					string[] cwReadArgs = [.. cacheReadArgs];

					ArgsCompute ad = new() {
						PriArgs = cwReadArgs
					};
					if (ad.HaveArgs()) {
						if (ad.Compute()) {
							Invoke(new Action(() => _ = AutoStartTimed(ad)));
						}
					}
				}
			};


			statsData.StartNum++;//添加统计
			Task.Run(() => {
				string numStr = statsData.StartNum.ToString();
				if (!(numStr.Length > 1)) return;
				if (numStr[0] != '1') return;
				for(int i=1; i<numStr.Length; i++) {
					if (numStr[i] != '0') return;
				}
				if (MessageBox.Show(string.Format(GetLangStr("messagebox.thanksToUse"), statsData.StartNum), GetLangStr("messagebox.thanksToUse2"),
					MessageBoxButtons.YesNo,MessageBoxIcon.None,MessageBoxDefaultButton.Button1) == DialogResult.Yes) {
					Process.Start("explorer.exe", PInfo.githubUrl);
				}
			});
		}
		/// <summary>
		/// 设置为true后将不会在Main_FormClosing函数中阻止程序退出<br/>
		/// 部分块也会使用该变量来判断程序是否退出
		/// </summary>
		public static bool trueExitProgram = false;
		/// <summary>
		/// 是否在点击关闭按钮时最小化至托盘
		/// </summary>
		public static bool CloseToTaskBar = true;
		internal struct ProgramLanguage {
			internal static LanguageData.Language.Langs SettingValue {
				get => LanguageData.GetLanguage();
				set {
					LanguageData.ChangeLanguage(value);
					UpdateLanguage?.Invoke();
				}
			}
			internal static event Action? UpdateLanguage;
		}
		
		private void Main_FormClosing(object sender, FormClosingEventArgs e) {
			if (!trueExitProgram && CloseToTaskBar) {
				Visible = false;
				e.Cancel = true;
				Thread t = new(() => DataSave()); t.Start();
			}
			else Visible = false;
		}
		private void Main_FormClosed(object sender, FormClosedEventArgs e) {
			//确保该值在退出时为true，避免其它依赖此值的线程锁死
			trueExitProgram = true;//此行代码不能删，因为还有可能时因为CloseToTaskBar值为false而退出，而trueExitProgram不会因此为true。需要再次设置确保其为true
			bool wait = false;
			Thread t = new(() => {
				DataSave();
				wait = true;
			}); t.Start();
			while (!wait) { Application.DoEvents(); Thread.Sleep(1); }

			fuse = false;
			fuse_autoTask = false;
			DefendAutoTask.CloseDefend();
			ToastNotificationManagerCompat.Uninstall();//清除且卸载所有通知（实测使用该方法后该实例将无法再发送通知）                      
		}
		private void Main_Shown(object sender, EventArgs e) {
			Visible = false;
			Opacity = 1;

			ArgsCompute ad = new() {
				PriArgs = args
			};
			if (ad.HaveArgs()) {
				if (ad.Compute())
					_ = AutoStartTimed(ad);
			}

			if (ad.ShowTheForm)
				Visible = true;

			if (IsAutoCheckUpdate) {
				_ = Task.Run(() => {
					Thread.Sleep(4000);//等待一段时间后再进行自动更新检查
					ProgramUpdate(true);
				});
			}
		}
		/// <summary>
		/// 自动调整控件并开始
		/// </summary>
		/// <param name="action"></param>
		/// <param name="time"></param>
		/// <returns>返回true表示成功，false则失败</returns>
		private bool AutoStartTimed(ArgsCompute ac) {
			if (ac.GetFocus) {
				ShowMainForm();
				return true;
			}
			else {
				switch (ac.TkAction) {
					case TaskAction.shutdown:
						ActionSelect.SelectedIndex = 0;
						break;
					case TaskAction.reboot:
						ActionSelect.SelectedIndex = 1;
						break;
					case TaskAction.sleep:
						ActionSelect.SelectedIndex = 2;
						break;
					case TaskAction.hibernate:
						ActionSelect.SelectedIndex = 3;
						break;
					case TaskAction.userlock:
						ActionSelect.SelectedIndex = 4;
						break;
					case TaskAction.useroff:
						ActionSelect.SelectedIndex = 5;
						break;
					case null:
						return false;
				}
				switch (ac.TimeType) {
					case TaskTimeType.after:
						TimeTypeSelect.SelectedIndex = 0;
						TimeInput.Text = ac.Time;
						break;
					case TaskTimeType.ontime:
						TimeTypeSelect.SelectedIndex = 1;
						TimePicker.Value = DateTime.Parse(ac.Time);
						break;
				}
				StartButton_Click(null!, null!);
				return true;
			}
		}
		/// <summary>
		/// 参数处理类
		/// </summary>
		internal class ArgsCompute {
			private string[] priArgs = [];
			/// <summary>
			/// 使用类的其它方法之前，需将参数输入至类，用于之后的判断
			/// </summary>
			internal string[] PriArgs {
				set => priArgs = value;
			}

			private bool getFocus = false;
			internal bool GetFocus => getFocus;

			private TaskAction? tkAction = null;
			/// <summary>
			/// 执行的类型
			/// </summary>
			internal TaskAction? TkAction => tkAction;

			private TaskTimeType timeType = TaskTimeType.after;
			/// <summary>
			/// 时间类型
			/// </summary>
			internal TaskTimeType TimeType => timeType;

			private string time = "";
			/// <summary>
			/// 倒计时时间
			/// </summary>
			internal string Time => time;

			private bool showTheForm = true;
			/// <summary>
			/// 是否在函数最后显示窗体，如果有-hidden标签，则在最后不显示窗体
			/// </summary>
			internal bool ShowTheForm => showTheForm;

			/// <summary>
			/// 判断类中的参数变量是否包含参数值
			/// </summary>
			/// <returns></returns>
			internal bool HaveArgs() => priArgs.Length != 0;
			/// <summary>
			/// 处理参数并将返回值设置在类的属性里
			/// </summary>
			/// <returns>处理成功返回true，否则返回false</returns>
			internal bool Compute() {
				for (int i = 0; i < priArgs.Length; i++) {
					switch (priArgs[i].ToLower()) {
						case "-action":
							i++;
							tkAction = (TaskAction)Enum.Parse(typeof(TaskAction), priArgs[i].ToLower());
							break;
						case "-time":
							i++;
							time = priArgs[i].ToLower();
							break;
						case "-timeType":
							i++;
							timeType = (TaskTimeType)Enum.Parse(typeof(TaskTimeType), priArgs[i].ToLower());
							break;
						case "-hidden":
							showTheForm = false;
							break;
						case "-focus":
							getFocus = true;
							break;
						default:
							if (priArgs.Length == 1) {
								if (File.Exists(priArgs[0])) {
									TPT? tpt = TPTRead(priArgs[0]);
									if (tpt != null) {
										tkAction = tpt.Action;
										time = tpt.Time;
										timeType = tpt.TimeType;
										if (!tpt.LittleTimeWarning)
											littleTimeWarningDis = true;
										return true;
									}
									else
										return false;
								}
								else
									return false;
							}
							break;
					}
				}
				return true;
			}
		}

		/// <summary>
		/// 数据保存函数。注意，此函数必须在线程内运行，否则会导致主线程无响应
		/// </summary>
		void DataSave() {
			AutoResetEvent wait = new(false);
			Invoke(new Action(() => {
				mainData.Window = new() { X = Left, Y = Top };
				mainData.Action = ActionSelect.SelectedIndex;
				mainData.TimeType = TimeTypeSelect.SelectedIndex;
				mainData.TimeInput = TimeInput.Text;
				mainData.Setting = new() {
					CloseToTaskBar = CloseToTaskBar,
					AutoCheckUpdate = IsAutoCheckUpdate,
					Language=ProgramLanguage.SettingValue,
					Theme = themeManager.CurrentTheme,
				};
				if (mainData.Version < PInfo.ShortVersionNum) mainData.Version = PInfo.ShortVersionNum;
				DataFile.SaveData();

				AutoTaskData.SaveToFile();
				_ = wait.Set();
			}));
			_ = wait.WaitOne();
		}

		/// <summary>
		/// 是否正在检测更新，避免重复检查
		/// </summary>
		bool isCheckingUpdate = false;
		/// <summary>
		/// 是否正在检测更新，避免重复检查
		/// </summary>
		bool IsCheckingUpdate {
			set {
				isCheckingUpdate = value;
				FormMenuStrip_Help_CheckUpdate.Enabled = !value;
				nmc_CheckUpdate.Enabled = !value;
			}
		}
		/// <summary>
		/// 是否自动检查更新
		/// </summary>
		bool IsAutoCheckUpdate = true;
		/// <summary>
		/// 检查程序更新
		/// </summary>
		/// <param name="isAuto">是否是自动检查更新，如果不是，则在检查完后反馈</param>
		async void ProgramUpdate(bool isAuto = false) {
			if (!isCheckingUpdate) {
				IsCheckingUpdate = true;
				try {
					UpdateFromGithub.CheckUpdateValue cuv = await ufg.CheckUpdateAsync();
#pragma warning disable IDE0079
#pragma warning disable SYSLIB1045
					UpdateFromGithub.InfoOfDownloadFile iodf = await ufg.GetDownloadFileInfoAsync(fileRegex: new(@".+\.7z"));
#pragma warning restore SYSLIB1045
#pragma warning restore IDE0079
					if (cuv.HaveUpdate) {
						DialogResult? userSelectUpgrade=null;
						{
							AutoResetEvent are = new(false);
							this.Invoke(new Action(() => {
								userSelectUpgrade = new HtmlMessageBox(
									Markdown.ToHtml(string.Format(GetLangStr("messagebox.haveUpdate"),
																PInfo.version, cuv.LatestVersionStr, cuv.PublishedTime_Local, iodf.Size, cuv.ReleaseName, cuv.ReleaseBody)),
											[
												new(){Text=GetLangStr("cancel","main.messagebox.button"),Result=DialogResult.Cancel},
											new(){Text=GetLangStr("upgrade","main.messagebox.button"),Result=DialogResult.Yes}
											],
											Text,HtmlMessageBox.Sounds.information, 1,new Size(433,471), true
									).ShowDialog();
								are.Set();
							}));
							are.WaitOne();
						}
						if(userSelectUpgrade!=null)
						switch (userSelectUpgrade) {
							case DialogResult.Yes:
								void errorMsg() => _ = MessageBox.Show(GetLangStr("messagebox.downloadUpdateFailed")
									, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
								try {
									UpdateFromGithub.InfoOfInstall? ioi = await ufg.DownloadReleaseAsync(iodf);
									if (ioi != null) {
										if (MessageBox.Show(GetLangStr("messagebox.downloadDone"), Text, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes) {
											ufg.InstallFile(ioi, waitTime: 900,enterNested:1);
											Invoke(new Action(() => NotifyIcon_main_ContextMenu_ExitButton_Click(null!, null!)));
										}
									}
									else {
										errorMsg();
									}
								} catch { errorMsg(); }
								break;
							default:
								break;
						}
					}
					else if (!isAuto)
						MessageBox.Show(GetLangStr("messagebox.isNewVersion"),
							Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
#pragma warning restore IDE0079 // 请删除不必要的忽略
				} catch {
					if (!isAuto)
						MessageBox.Show(GetLangStr("messagebox.checkUpdateFailed")
							, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				IsCheckingUpdate = false;
			}
		}
		#endregion
		private void TimeTypeSelect_SelectedIndexChanged(object sender, EventArgs e) {
			switch ((TimeTypeSelectItems)TimeTypeSelect.SelectedIndex) {
				case TimeTypeSelectItems.after:
					TimePicker.Visible = false;
					TimeInput.Visible = true;
					break;
				case TimeTypeSelectItems.ontime:
					TimeInput.Visible = false;
					TimePicker.Visible = true;
					break;
			}
		}
		private void CountdownLabel_Resize(object sender, EventArgs e) {
			//countdownLabel.Left = (int)(((float)this.Width / 2) - ((float)countdownLabel.Width / 2));
		}
		#region TimeInput&TimePicker
		#region TimeInput
		private void TimeInput_Leave(object sender, EventArgs e) {
			if (TimeInput.Text != "" && FormatdInputBool(TimeInput.Text))
				TimeInput.Text = atv.GetFormatdTime();
		}
		private void TimeInput_KeyUp(object sender, KeyEventArgs e) {
			if (e.KeyCode == Keys.Enter) {
				e.Handled = true;
				_ = StartButton.Focus();
			}
		}
		private void TimeInput_KeyPress(object sender, KeyPressEventArgs e) {//避免按下回车键报警
			if (e.KeyChar == System.Convert.ToChar(13)) {
				e.Handled = true;
			}
		}
		#region TimeInput_ContextMenu.Items
		private void TPCM_s10_Click(object sender, EventArgs e) {
			atv.SetTimeValue(seconds: 10);
			TimeInput.Text = atv.GetFormatdTime();
		}
		private void TPCM_s30_Click(object sender, EventArgs e) {
			atv.SetTimeValue(seconds: 30);
			TimeInput.Text = atv.GetFormatdTime();
		}
		private void TPCM_min1_Click(object sender, EventArgs e) {
			atv.SetTimeValue(minutes: 1);
			TimeInput.Text = atv.GetFormatdTime();
		}
		private void TPCM_min2_Click(object sender, EventArgs e) {
			atv.SetTimeValue(minutes: 2);
			TimeInput.Text = atv.GetFormatdTime();
		}
		private void TPCM_min5_Click(object sender, EventArgs e) {
			atv.SetTimeValue(minutes: 5);
			TimeInput.Text = atv.GetFormatdTime();
		}
		private void TPCM_min10_Click(object sender, EventArgs e) {
			atv.SetTimeValue(minutes: 10);
			TimeInput.Text = atv.GetFormatdTime();
		}
		private void TPCM_min20_Click(object sender, EventArgs e) {
			atv.SetTimeValue(minutes: 20);
			TimeInput.Text = atv.GetFormatdTime();
		}
		private void TPCM_min40_Click(object sender, EventArgs e) {
			atv.SetTimeValue(minutes: 40);
			TimeInput.Text = atv.GetFormatdTime();
		}
		private void TPCM_h1_Click(object sender, EventArgs e) {
			atv.SetTimeValue(hours: 1);
			TimeInput.Text = atv.GetFormatdTime();
		}
		private void TPCM_h2_Click(object sender, EventArgs e) {
			atv.SetTimeValue(hours: 2);
			TimeInput.Text = atv.GetFormatdTime();
		}
		#endregion

		#endregion
		#region TimePicker
		private void TimePicker_KeyUp(object sender, KeyEventArgs e) {
			if (e.KeyCode == Keys.Enter) {
				e.Handled = true;
				_ = StartButton.Focus();
			}
		}
		private void TimePicker_KeyPress(object sender, KeyPressEventArgs e) {
			if (e.KeyChar == System.Convert.ToChar(13)) {
				e.Handled = true;
			}
		}
		#endregion
		#endregion


		AfterTimeValue? countdown;
		Thread? countdownThread;
		Thread? countdownThread_autoTask;
		static bool fuse = false;//保险变量，倒计时和执行电源操作时必须为true
		static bool littleTimeWarningDis = false;//是否禁用时间小于等于5秒的警告，该警告目前只能临时禁用
		private void StartButton_Click(object sender, EventArgs e) {
			statsData.DoActionNum++;

			switch ((TimeTypeSelectItems)TimeTypeSelect.SelectedIndex) {
				case TimeTypeSelectItems.after:
					if (FormatdInputBool(TimeInput.Text)) TimeInput.Text = atv.GetFormatdTime();
					else return;
					break;
				case TimeTypeSelectItems.ontime:
					if (((long)GetTimeStamp(TimePicker.Value) - (long)GetTimeStamp(DateTime.Now)) > 0) { }
					else {
						MessageBox.Show(GetLangStr("messagebox.onlyUseFuture"), Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}
					break;
			}

			StartButton.Enabled = false;
			if (countdownThread != null) { while (countdownThread.IsAlive) { Thread.Sleep(1); Application.DoEvents(); } }
			ControlModeSet("start");
			fuse = true;
			switch ((TimeTypeSelectItems)TimeTypeSelect.SelectedIndex) {
				case TimeTypeSelectItems.after:
					countdown = atv;
					break;
				case TimeTypeSelectItems.ontime:
					//TimePicker.Value
					countdown = new();
					countdown.SetTimeValue(seconds: ((long)GetTimeStamp(TimePicker.Value) - (long)GetTimeStamp(DateTime.Now)));
					break;
			}
			countdownLabel.Text = countdown!.GetFormatdTime();
			if (!littleTimeWarningDis) {
				if (countdown!.AllSeconds <= 5) {
					if (MessageBox.Show(GetLangStr("messagebox.littleTimeWarning"), Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
						!= DialogResult.Yes) {
						StopButton_Click(null!, null!);
						return;
					}
				}
			}
			else
				littleTimeWarningDis = false;
			CountdownProgressControl.SetStartValue(countdown.AllSeconds);

			countdownThread = new(CountdownThread);
			countdownThread.Start();
		}
		private void StopButton_Click(object sender, EventArgs e) {
			StopButton.Enabled = false;
			fuse = false;
			if (countdownThread != null) { while (countdownThread.IsAlive) { Thread.Sleep(1); Application.DoEvents(); } }
			CountdownProgressControl.Close();
			ControlModeSet("stop");
		}
		void CountdownThread() {
			void LastWarning(ActionSelectItems action, string time) {
				string actionStr = GetLangStr(action.ToString(), "global");
				//侦听Windows通知点击事件
				ToastNotificationManagerCompat.OnActivated += toastArgs => {
					//通知参数
					ToastArguments args = ToastArguments.Parse(toastArgs.Argument);
					//获取任何用户输入
					ValueSet userInput = toastArgs.UserInput;

					if (args.ToString() == "StopCountdown;TimeWarning")
						Invoke(new Action(() => { if (fuse) StopButton_Click(null!, null!); }));
					else if (args.ToString() == "TimeWarning") {
						Invoke(new Action(() => {
							[System.Runtime.InteropServices.DllImport("user32.dll", EntryPoint = "SetForegroundWindow")]
							static extern bool SetForegroundWindow(IntPtr hWnd);
							SetForegroundWindow(Handle);
						}));
					}
				};
				new ToastContentBuilder()
					.AddArgument("TimeWarning")
					.AddText(string.Format(GetLangStr("winToast.timeWarning.text"),time,actionStr))
					.AddButton(new ToastButton()
					.SetContent(GetLangStr("winToast.timeWarning.button"))
					.AddArgument("StopCountdown"))
					.Show();
			}

			ActionSelectItems actionSelect=ActionSelectItems.userlock;
			{
				AutoResetEvent are = new(false);
				Invoke(new Action(() => { 
					actionSelect = (ActionSelectItems)ActionSelect.SelectedIndex;
					are.Set();
				}));
				are.WaitOne();
			}
			TimeTypeSelectItems typeSelect=TimeTypeSelectItems.after;
			{
				AutoResetEvent are = new(false);
				Invoke(new Action(() => { 
					typeSelect = (TimeTypeSelectItems)TimeTypeSelect.SelectedIndex; 
					are.Set();
				}));
				are.WaitOne();
			}
			void LastWarningCheck() {
				switch (countdown!.AllSeconds) {
					case 3 * 60:
					case 1 * 60:
					case 30:
					case 15:
					case 5:
						LastWarning(actionSelect, 
							countdown.GetVisualTime(
							CultureInfo.CurrentUICulture.ToString().Equals("zh-cn", StringComparison.CurrentCultureIgnoreCase) ? "cn" : "en"
							));//判断当前语言来进行格式选择
						break;
				}
			}
			switch (typeSelect) {
				case TimeTypeSelectItems.after:
					while (countdown!.AllSeconds > 0 && fuse) {
						CountdownProgressControl.Flush(countdown.AllSeconds);
						LastWarningCheck();
						Sleep(1000);
						countdown.OnlySeconds--;
						try { Invoke(new Action(() => countdownLabel.Text = countdown.GetFormatdTime())); } catch { }
					}
					break;
				case TimeTypeSelectItems.ontime: {
						long endTimeStamp = 0;
						void TimeReload()//将时间差刷新至countdown内，且将格式化的数据刷新至UI
						{
							countdown!.SetTimeValue(seconds: ((long)endTimeStamp - (long)GetTimeStamp(DateTime.Now)));
							try { Invoke(new Action(() => countdownLabel.Text = countdown.GetFormatdTime())); } catch { }
						}

						{
							bool threadLock = false;
							Invoke(new Action(() => { endTimeStamp = GetTimeStamp(TimePicker.Value); threadLock = true; }));
							while (!threadLock) { }
						}
						TimeReload();
						while (countdown!.AllSeconds > 0 && fuse) {
							CountdownProgressControl.Flush(countdown.AllSeconds);
							LastWarningCheck();
							Sleep(950);
							TimeReload();
						}
					}
					break;
			}
			if (fuse) {
				DataSave();//操作前保存所有
#if DEBUG
				MessageBox.Show("调试模式：已假装执行" + actionSelect + "操作", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
#else
				switch (actionSelect) {
					case ActionSelectItems.shutdown:
						if (fuse) PowerInvoke.Shutdown();
						break;
					case ActionSelectItems.reboot:
						if (fuse) PowerInvoke.Reboot();
						break;
					case ActionSelectItems.sleep:
						if (fuse) PowerInvoke.Sleep();
						break;
					case ActionSelectItems.hibernate:
						if (fuse) PowerInvoke.Hibernate();
						break;
					case ActionSelectItems.userlock:
						if (fuse) PowerInvoke.UserLock();
						break;
					case ActionSelectItems.useroff:
						if (fuse) PowerInvoke.UserOff();
						break;
				}
#endif
				Invoke(new Action(() => {
					trueExitProgram = true;
					Close();
				}));
				/*this.Invoke(new Action(() =>{ if (fuse) StopButton_Click(null!, null!);}));*/
			}
		}

		AfterTimeValue? countdown_autoTask;
		/// <summary>
		/// autoTask的保险变量
		/// </summary>
		bool fuse_autoTask = false;
		void AutoTaskCountdownThread() {
			countdown_autoTask = new();

			void LastWarning(AutoTaskData.ATDataHead_action action, string time, string taskName) {
				string actionStr = GetLangStr(action.ToString(), "global");
				//侦听Windows通知点击事件
				ToastNotificationManagerCompat.OnActivated += toastArgs => {
					//通知参数
					ToastArguments args = ToastArguments.Parse(toastArgs.Argument);
					//获取任何用户输入
					ValueSet userInput = toastArgs.UserInput;

					if (args.ToString() == "StopCountdown;TimeWarning_autoTask")
						Invoke(new Action(() => { if (fuse_autoTask) AutoTaskData.CountdownStateControl.StopNowTask(); }));
					else if (args.ToString() == "TimeWarning_autoTask") {
						Invoke(new Action(() => {
							[System.Runtime.InteropServices.DllImport("user32.dll", EntryPoint = "SetForegroundWindow")]
							static extern bool SetForegroundWindow(IntPtr hWnd);
							SetForegroundWindow(Handle);
						}));
					}
				};
				new ToastContentBuilder()
					.AddArgument("TimeWarning_autoTask")
					.AddText(string.Format(GetLangStr("winToast.timeWarning_autoTask.text"), taskName, time, actionStr))
					.AddButton(new ToastButton()
					.SetContent(GetLangStr("winToast.timeWarning_autoTask.button"))
					.AddArgument("StopCountdown"))
					.Show();
			}

			/*string actionSelect = "";
            {
                bool threadLock = false;
                this.Invoke(new Action(() => { actionSelect = ActionSelect.SelectedItem!.ToString()!; threadLock = true; }));
                while (!threadLock) { }
            }*/
			AutoTaskData.ATDataHead_action actionSelect;
			actionSelect = AutoTaskData.CountdownStateControl.GetAction();
			{
				long endTimeStamp = 0;
				void TimeReload()//将时间差刷新至countdown内
=> countdown_autoTask.SetTimeValue(seconds: ((long)endTimeStamp - (long)GetTimeStamp(DateTime.Now)));//try { this.Invoke(new Action(() => { countdownLabel.Text = countdown_autoTask.GetFormatdTime(); })); } catch { }//将格式化的数据刷新至UI

				endTimeStamp = GetTimeStamp(AutoTaskData.CountdownStateControl.GetDateTime());

				TimeReload();
				while (countdown_autoTask.AllSeconds > 0 && fuse_autoTask) {
					if (countdown_autoTask.AllSeconds <= 3 * 60) {
						switch (countdown_autoTask.AllSeconds) {
							case 3 * 60:
							case 1 * 60:
							case 30:
							case 15:
							case 5:
								LastWarning(actionSelect,
							countdown_autoTask.GetVisualTime(//判断当前语言来进行时间格式的选择
							CultureInfo.CurrentUICulture.ToString().Equals("zh-cn", StringComparison.CurrentCultureIgnoreCase) ? "cn" : "en"),
							AutoTaskData.CountdownStateControl.GetTaskName());
								break;
						}
					}
					Sleep(950);
					TimeReload();
				}
			}
			if (fuse_autoTask) {
				if (!DefendAutoTask.DefendState())//自动任务防御程序，防止不可预测的意外
				{
					DataSave();//操作前保存所有
#if DEBUG
					MessageBox.Show("调试模式：已假装执行" + actionSelect + "操作", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
#else
					switch (actionSelect) {
						case AutoTaskData.ATDataHead_action.shutdown:
							if (fuse_autoTask) PowerInvoke.Shutdown();
							break;
						case ATDataHead_action.reboot:
							if (fuse_autoTask) PowerInvoke.Reboot();
							break;
						case ATDataHead_action.sleep:
							if (fuse_autoTask) PowerInvoke.Sleep();
							break;
						case ATDataHead_action.hibernate:
							if (fuse_autoTask) PowerInvoke.Hibernate();
							break;
						case ATDataHead_action.userlock:
							if (fuse_autoTask) PowerInvoke.UserLock();
							break;
						case ATDataHead_action.useroff:
							if (fuse_autoTask) PowerInvoke.UserOff();
							break;
					}
#endif
				}
				else
					DefendAutoTask.DefendMessage_Msgbox();
				Invoke(new Action(() => {
					trueExitProgram = true;
					Close();
				}));
				/*this.Invoke(new Action(() =>{ if (fuse_autoTask) StopButton_Click(null!, null!);}));*/
			}
			AutoTaskData.CountdownStateControl.updateWaitLock = false;
		}
		void AutoTask_CountdownState_IsEnable_Change(bool isEnable) {
			if (isEnable) {
				AutoTaskData.CountdownStateControl.updateWaitLock = true;//锁定数据刷新函数，避免在计时器运行过程中刷新数据导致异常

				fuse_autoTask = true;
				countdownThread_autoTask = new(AutoTaskCountdownThread);
				countdownThread_autoTask.Start();
			}
			else
				fuse_autoTask = false;
		}
		/// <summary>
		/// 判断输入时间的内容和格式是否非法，且错误时做出相关处理
		/// </summary>
		/// <returns>返回布尔值</returns>
		bool FormatdInputBool(string input) {
			string output = atv.FormatdInputTime(input);
			if (output == "done") {
				return true;
			}
			else if (output == "ToBig") {
				MessageBox.Show(GetLangStr("messagebox.timeValueTooBig"), Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
			else {
				MessageBox.Show(GetLangStr("messagebox.timeValueError"), Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
		}
		/// <summary>
		/// 根据当前控件状态更改控件模式
		/// </summary>
		/// <param name="id">状态ID: start; stop</param>
		void ControlModeSet(string id) {
			switch (id) {
				case "start":
					StartButton.Enabled = false;
					StartButton.Visible = false;
					StopButton.Enabled = true;
					StopButton.Visible = true;
					ActionSelect.Enabled = false;
					TimePicker.Enabled = false;
					TimeInput.Enabled = false;
					TimeTypeSelect.Enabled = false;
					countdownLabel.Text = "00:00:00";
					countdownLabel.Visible = true;
					//this.Height = 175;
					//countdownLabel.Top = 98;//必须在后面重新定义位置，否则将会随窗体活动到底部不可见位置
					break;
				case "stop":
					StartButton.Enabled = true;
					StartButton.Visible = true;
					StopButton.Enabled = false;
					StopButton.Visible = false;
					ActionSelect.Enabled = true;
					TimePicker.Enabled = true;
					TimeInput.Enabled = true;
					TimeTypeSelect.Enabled = true;
					countdownLabel.Visible = false;
					//this.Width = 292;
					//this.Height = 141;
					break;
			}
		}
		/// <summary>
		/// 更精确的Sleep方法
		/// </summary>
		/// <param name="ms">单位: 毫秒</param>
		static void Sleep(int ms) {
			Stopwatch sw = Stopwatch.StartNew();
			int sleepMs = ms - 16;
			if (sleepMs > 0) {
				Thread.Sleep(sleepMs);
			}
			while (sw.ElapsedMilliseconds < ms) {
				Thread.Sleep(0);
			}
		}
		/// <summary>
		/// 取指定时间的时间戳
		/// </summary>
		/// <param name="dateTime">需要转换的DateTime类型</param>
		/// <param name="accurateToMilliseconds">是否精确到毫秒</param>
		/// <returns>返回long类型时间戳</returns>
		public static long GetTimeStamp(DateTime dateTime, bool accurateToMilliseconds = false) =>
			accurateToMilliseconds
				? new DateTimeOffset(dateTime).ToUnixTimeMilliseconds()
				: new DateTimeOffset(dateTime).ToUnixTimeSeconds();

		static class CountdownProgressControl {
			private static long StartValue;
			private const int stage1 = 30;
			private const int stage2 = 10;
			private const int stage3 = 0;//三个阶段，当时间倒计时到各个阶段时进度条颜色随之改变
			/// <summary>
			/// 设置进度开始的值（计时的秒数数值）
			/// </summary>
			/// <param name="startValue">进度开始值</param>
			public static void SetStartValue(long startValue) {
				StartValue = startValue;
				TaskbarManager.SetProgressValue(1, 1);

				if (startValue is <= stage1 and > stage2)//同(startValue <= stage1 && startValue > stage2)
					TaskbarManager.SetProgressState(TaskbarProgressBarState.Paused);
				else if (startValue is <= stage2 and > stage3)
					TaskbarManager.SetProgressState(TaskbarProgressBarState.Error);
				else if (startValue <= stage3)
					TaskbarManager.SetProgressState(TaskbarProgressBarState.NoProgress);
				else
					TaskbarManager.SetProgressState(TaskbarProgressBarState.Normal);
			}
			/// <summary>
			/// 刷新当前进度条
			/// </summary>
			/// <param name="nowValue">当前数值</param>
			public static void Flush(long nowValue) {
				switch (nowValue) {
					case stage1:
						TaskbarManager.SetProgressState(TaskbarProgressBarState.Paused); break;
					case stage2:
						TaskbarManager.SetProgressState(TaskbarProgressBarState.Error); break;
					case stage3:
						TaskbarManager.SetProgressState(TaskbarProgressBarState.NoProgress); return;
				}
				TaskbarManager.SetProgressValue((int)(((float)nowValue / (float)StartValue) * 100), 100);
			}
			public static void Close() => TaskbarManager.SetProgressState(TaskbarProgressBarState.NoProgress);
		}

		#region notifyIcon_main_EVENT
		#region NotifyIcon_main_ContextMenu_EVENT
		private void NotifyIcon_main_ContextMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e) {
			notifyIcon_main_ContextMenu_ShowButton.Enabled = !Visible;
			notifyIcon_main_ContextMenu_HiddenButton.Enabled = Visible;
			nmc__AutoCheckUpdate.Checked = IsAutoCheckUpdate;
		}
		private void NotifyIcon_main_ContextMenu_ShowButton_Click(object sender, EventArgs e) => Visible = true;

		private void NotifyIcon_main_ContextMenu_HiddenButton_Click(object sender, EventArgs e) => Visible = false;

		private void NotifyIcon_main_ContextMenu_ExitButton_Click(object sender, EventArgs e) {
			trueExitProgram = true;
			Close();
		}
		#endregion
		private void NotifyIcon_main_MouseClick(object sender, MouseEventArgs e) {
			switch (e.Button) {
				case MouseButtons.Left:
					ShowMainForm();
					break;
			}
		}
		/// <summary>
		/// 显示主窗口
		/// </summary>
		private void ShowMainForm() {
			if (Visible == false)
				NotifyIcon_main_ContextMenu_ShowButton_Click(null!, null!);
			else {
				TopMost = true;
				TopMost = false;
				_ = Focus();
			}
		}
		#endregion

		#region FormMenuStrip		
		private void FormMenuStrip_Opening(object sender, System.ComponentModel.CancelEventArgs e) {
			FormMenuStrip_Help_AutoCheckUpdate.Checked = IsAutoCheckUpdate;
		}
		private void FormMenuStrip_NewTaskFile_Click(object sender, EventArgs e) {
			SaveFileDialog saveFileDialog = new() {
				Title = GetLangStr("fileWindow.newTaskFile.title"),
				DefaultExt = "tpt",
				Filter = string.Format(GetLangStr("fileWindow.newTaskFile.filter"), "(*.tpt)|*.tpt"),
				//InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
			};
			if (saveFileDialog.ShowDialog() == DialogResult.OK) {
				TPTSave(saveFileDialog.FileName, new() {
					Action = TimedPowerTask.TaskAction.userlock,
					Time = "5min",
					TimeType = TimedPowerTask.TaskTimeType.after,
					FileVersion = PInfo.ShortVersionNum
				});
			}
		}
		private void FormMenuStrip_Setting_Click(object sender, EventArgs e) {
			SettingForm sf= new();
			sf.ShowDialog();
		}
		AutoTaskForm? autoTaskForm;
		private void AutoTask_ToolStripMenuItem_Click(object sender, EventArgs e) {
			if (autoTaskForm == null || autoTaskForm.IsStart == false) {
				autoTaskForm = new();
				autoTaskForm.Show/*Dialog*/();
			}
			else {
				_ = autoTaskForm.Focus();
			}
		}
		private void FormMenuStrip_Help_CheckUpdate_Click(object sender, EventArgs e) => _ = Task.Run(() => ProgramUpdate());
		private void FormMenuStrip_Help_AutoCheckUpdate_Click(object sender, EventArgs e) => IsAutoCheckUpdate = !IsAutoCheckUpdate;
		private void FormMenuStrip_Help_HelpDoc_Click(object sender, EventArgs e) => _ = System.Diagnostics.Process.Start("explorer.exe", PInfo.githubWiki);
		private void GyToolStripMenuItem_Click(object sender, EventArgs e) => new About().Show();
		#endregion
	}
}
