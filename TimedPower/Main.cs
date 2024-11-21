using Microsoft.Toolkit.Uwp.Notifications;
using System.Diagnostics;
using Windows.Foundation.Collections;
using static TimedPower.TaskbarProgressBar;
using System.Xml;
using static TimedPower.AutoTaskData;
using static TimedPower.Program;
using EasyUpdateFromGithub;

namespace TimedPower
{
    internal readonly struct FilePath
    {
		internal static readonly string name = "TimedPower";

		internal static readonly string ConfigDir = $"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\\{name}\\";//踩坑提醒，之前该字符串使用@$前缀，而其中的\会将{转义，报出非常莫名其妙毫不相干的错误，在此作为提醒。
        internal static readonly string MainDataFile = ConfigDir + "data.xml";
        internal static readonly string AutoTaskFile = ConfigDir + "autoTask.xml";

		internal static readonly string TempDir = System.IO.Path.GetTempPath() + @$"{name}\";
		internal static readonly string CommandDir = @$"{TempDir}Command\";
		internal static readonly string commandFile = CommandDir + "Command.dat";
	}
	public partial class Main : Form
	{
		static string[] args = [];

		public Main(string[] args)
		{
			Main.args = args;
			InitializeComponent();
		}

		AfterTimeValue atv = new();
		#region Main_From		
		private void Main_Load(object sender, EventArgs e)
		{
			bool firstStart = false;//是否首次启动程序

			ActionSelect.SelectedIndex = 0;
			TimeTypeSelect.SelectedIndex = 0;

			if (!Directory.Exists(FilePath.ConfigDir)) Directory.CreateDirectory(FilePath.ConfigDir);
			if (!Directory.Exists(FilePath.TempDir)) Directory.CreateDirectory(FilePath.TempDir);
			if (!Directory.Exists(FilePath.CommandDir)) Directory.CreateDirectory(FilePath.CommandDir);
			if (!File.Exists(FilePath.MainDataFile))
			{
				XmlTextWriter xmlWriter = new(FilePath.MainDataFile, System.Text.Encoding.GetEncoding("utf-8")) { Formatting = System.Xml.Formatting.Indented };

				xmlWriter.WriteRaw("<?xml version=\"1.0\" encoding=\"utf-8\" ?>");
				xmlWriter.WriteComment("注意，私自修改数据文件导致的程序错误开发者概不负责!");
				xmlWriter.WriteStartElement("TimedPower_Data");

				xmlWriter.WriteStartElement("first");
				xmlWriter.WriteAttributeString("value", "1");
				xmlWriter.WriteEndElement();

				xmlWriter.WriteStartElement("Window");
				xmlWriter.WriteAttributeString("x", this.Left.ToString());
				xmlWriter.WriteAttributeString("y", this.Top.ToString());
				xmlWriter.WriteEndElement();

				xmlWriter.WriteStartElement("Action");
				xmlWriter.WriteAttributeString("index", ActionSelect.SelectedIndex.ToString());
				xmlWriter.WriteEndElement();

				xmlWriter.WriteStartElement("TimeType");
				xmlWriter.WriteAttributeString("index", TimeTypeSelect.SelectedIndex.ToString());
				xmlWriter.WriteEndElement();

				xmlWriter.WriteStartElement("TimeInput");
				xmlWriter.WriteAttributeString("value", "");
				xmlWriter.WriteEndElement();

				xmlWriter.WriteStartElement("CloseToTaskBar");
				xmlWriter.WriteAttributeString("boolean", "true");
				xmlWriter.WriteEndElement(); 

				xmlWriter.WriteStartElement("AutoCheckUpdate");
				xmlWriter.WriteAttributeString("boolean", "true");
				xmlWriter.WriteEndElement();

				xmlWriter.WriteFullEndElement();
				xmlWriter.Close();
			}
			else
			{
				try
				{
					XmlDocument xmlDoc = new();
					XmlNode xmlRoot;
					xmlDoc.Load(FilePath.MainDataFile);
					xmlRoot = xmlDoc.SelectSingleNode("TimedPower_Data")!;
					XmlNodeList xmlNL = xmlRoot.ChildNodes;
					foreach (XmlNode xn in xmlNL)
					{
						XmlElement xmlE = (XmlElement)xn;
						switch (xmlE.Name)
						{
							case "first":
								try { firstStart = Convert.ToBoolean(int.Parse(xmlE.GetAttribute("value"))); } catch { }
								break;
							case "Window":
								try
								{
									int[] temp = [int.Parse(xmlE.GetAttribute("x")), int.Parse(xmlE.GetAttribute("y"))];
									if (temp[0] >= 0 && temp[0] + this.Width <= System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Width)
										this.Left = temp[0];
									if (temp[1] >= 0 && temp[1] + this.Height <= System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Height)
										this.Top = temp[1];
								}
								catch { }
								break;
							case "Action":
								try { ActionSelect.SelectedIndex = int.Parse(xmlE.GetAttribute("index")); } catch { }
								break;
							case "TimeType":
								try { TimeTypeSelect.SelectedIndex = int.Parse(xmlE.GetAttribute("index")); } catch { }
								break;
							case "TimeInput":
								try { TimeInput.Text = xmlE.GetAttribute("value"); } catch { }
								break;
							case "CloseToTaskBar":
								try { CloseToTaskBar = bool.Parse(xmlE.GetAttribute("boolean")); } catch { }
								break;
							case "AutoCheckUpdate":
								try { IsAutoCheckUpdate = bool.Parse(xmlE.GetAttribute("boolean")); }catch { }
								break;
						}
					}
				}
				catch { }
			}
			if (!File.Exists(FilePath.AutoTaskFile))
			{
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
			if (!firstStart)
			{
				if (MessageBox.Show("是否将快捷按钮添加至Windows右键菜单？稍后也可以右键程序进行设置。", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
				{
					AddOrFixWindowsRightClickMenu_MenuItem_Click(null!, null!);
				}
				if (MessageBox.Show("是否启用软件开机自动启动？这可以为自动定时任务功能带来更好的体验。稍后也可以右键程序进行设置。",
					this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
				{
					EnabledSelfStarting_Click(null!, null!);
				}
				MessageBox.Show("提示：点击软件的关闭按钮后将会最小化至任务栏托盘。若想关闭软件，请右键任务栏托盘的该软件的小图标后点击退出即可。",
					this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
			}

			DefendAutoTask.SetDefendTime(30);//程序启动后将有30秒的自动任务防御时间
			CountdownStateControl.IsEnable_Change += AutoTask_CountdownState_IsEnable_Change;
			AutoTaskData.CountdownStateControl.UpdateData();//刷新自动任务


			FileSystemWatcher commandWatcher = new(FilePath.CommandDir)
			{
				EnableRaisingEvents = true,
				Filter = "Command.dat"
			};
			commandWatcher.Renamed += (s, e) =>
			{
				bool canStart = false;
				{
					bool wait = false;
					this.Invoke(new Action(() =>
					{
						ShowMainForm();
						canStart = StartButton.Visible;
						wait = true;
					}));
					while (!wait) ;
				}
				if (canStart)
				{
					List<string> cacheReadArgs = [];
					StreamReader sr = new(FilePath.commandFile, System.Text.Encoding.UTF8);
					while (true)
					{
						string? read = sr.ReadLine();
						if (read != null && read != "")
						{
							cacheReadArgs.Add(read);
						}
						else break;
					}
					sr.Close();
					string[] cwReadArgs = [.. cacheReadArgs];

					ArgsCompute ad = new()
					{
						PriArgs = cwReadArgs
					};
					if (ad.HaveArgs())
					{
						ad.Compute();
						this.Invoke(new Action(() =>
						{
							AutoStartTimed(ad.Type, ad.Time);
						}));
					}
				}
			};
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
		private void Main_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (!trueExitProgram && CloseToTaskBar)
			{
				this.Visible = false;
				e.Cancel = true;
				Thread t = new(() =>
				{
					DataSave();
				}); t.Start();
			}
			else Visible = false;
		}
		private void Main_FormClosed(object sender, FormClosedEventArgs e)
		{
			//确保该值在退出时为true，避免其它依赖此值的线程锁死
			trueExitProgram = true;//此行代码不能删，因为还有可能时因为CloseToTaskBar值为false而退出，而trueExitProgram不会因此为true。需要再次设置确保其为true
			bool wait = false;
			Thread t = new(() =>
			{
				DataSave();
				wait = true;
			}); t.Start();
			while (!wait) { Application.DoEvents(); Thread.Sleep(1); }

			fuse = false;
			fuse_autoTask = false;
			DefendAutoTask.CloseDefend();
			ToastNotificationManagerCompat.Uninstall();//清除且卸载所有通知（实测使用该方法后该实例将无法再发送通知）                      
		}
		private void Main_Shown(object sender, EventArgs e)
		{
			this.Visible = false;
			this.Opacity = 1;

			ArgsCompute ad = new()
			{
				PriArgs = args
			};
			if (ad.HaveArgs())
			{
				ad.Compute();
				AutoStartTimed(ad.Type, ad.Time);
			}

			if (ad.ShowTheForm)
				this.Visible = true;

			if (IsAutoCheckUpdate)
			{
				Task.Run(() =>
				{
					Thread.Sleep(4000);//等待一段时间后再进行自动更新检查
					ProgramUpdate(true);
				});
			}
		}
		/// <summary>
		/// 自动调整控件并开始
		/// </summary>
		/// <param name="type"></param>
		/// <param name="time"></param>
		/// <returns>返回true表示成功，false则失败</returns>
		private bool AutoStartTimed(ArgsCompute.AllTypes type, string time)
		{
			switch (type)
			{
				case ArgsCompute.AllTypes.shutdown:
					//typeStr = "关机";
					ActionSelect.SelectedIndex = 0;
					break;
				case ArgsCompute.AllTypes.reboot:
					//typeStr = "重启";
					ActionSelect.SelectedIndex = 1;
					break;
				case ArgsCompute.AllTypes.sleep:
					//typeStr = "睡眠";
					ActionSelect.SelectedIndex = 2;
					break;
				case ArgsCompute.AllTypes.hibernate:
					//typeStr = "休眠";
					ActionSelect.SelectedIndex = 3;
					break;
				case ArgsCompute.AllTypes.userlock:
					//typeStr = "锁定";
					ActionSelect.SelectedIndex = 4;
					break;
				case ArgsCompute.AllTypes.useroff:
					//typeStr = "注销";
					ActionSelect.SelectedIndex = 5;
					break;
				default:
					return false;
			}
			TimeTypeSelect.SelectedIndex = 0;
			TimeInput.Text = time;
			StartButton_Click(null!, null!);
			return true;
		}
		internal class ArgsCompute
		{
			private string[] priArgs = [];
			/// <summary>
			/// 使用类的其它方法之前，需将参数输入至类，用于之后的判断
			/// </summary>
			internal string[] PriArgs
			{
				set => priArgs = value;
			}
			internal enum AllTypes
			{
				none, shutdown, reboot, sleep, hibernate, userlock, useroff
			};
			private AllTypes type = AllTypes.none;
			/// <summary>
			/// 执行的类型
			/// </summary>
			internal AllTypes Type
			{
				get => type;
			}
			private string time = "";
			/// <summary>
			/// 倒计时时间
			/// </summary>
			internal string Time
			{
				get => time;
			}
			private bool showTheForm = true;
			/// <summary>
			/// 是否在函数最后显示窗体，如果有-hidden标签，则在最后不显示窗体
			/// </summary>
			internal bool ShowTheForm
			{
				get => showTheForm;
			}

			/// <summary>
			/// 判断类中的参数变量是否包含参数值
			/// </summary>
			/// <returns></returns>
			internal bool HaveArgs()
			{
				if (priArgs.Length != 0)
					return true;
				else return false;
			}
			/// <summary>
			/// 处理参数并将返回值设置在类的属性里
			/// </summary>
			internal void Compute()
			{
				for (int i = 0; i < priArgs.Length; i++)
				{
					switch (priArgs[i].ToLower())
					{
						case "-type":
							i++;
							type = (AllTypes)Enum.Parse(typeof(AllTypes), priArgs[i].ToLower());
							break;
						case "-time":
							i++;
							time = priArgs[i].ToLower();
							break;
						case "-hidden":
							showTheForm = false;
							break;
					}
				}
			}
		}

		/// <summary>
		/// 数据保存函数。注意，此函数必须在线程内运行，否则会导致主线程无响应
		/// </summary>
		void DataSave()
		{
			bool wait = false;
			this.Invoke(new Action(() =>
			{
				bool[] checkExist = new bool[6];//用于排查是否有丢失项
				XmlElement xmlEleDo(int id, XmlElement xmlEle, XmlDocument? xmlDoc = null)
				{
					switch (id)
					{
						case 0:
							if (xmlDoc != null) xmlEle = xmlDoc.CreateElement("Window");
							xmlEle.SetAttribute("x", this.Left.ToString());
							xmlEle.SetAttribute("y", this.Top.ToString());
							checkExist[0] = true; break;
						case 1:
							if (xmlDoc != null) xmlEle = xmlDoc.CreateElement("Action");
							xmlEle.SetAttribute("index", ActionSelect.SelectedIndex.ToString());
							checkExist[1] = true; break;
						case 2:
							if (xmlDoc != null) xmlEle = xmlDoc.CreateElement("TimeType");
							xmlEle.SetAttribute("index", TimeTypeSelect.SelectedIndex.ToString());
							checkExist[2] = true; break;
						case 3:
							if (xmlDoc != null) xmlEle = xmlDoc.CreateElement("TimeInput");
							xmlEle.SetAttribute("value", TimeInput.Text);
							checkExist[3] = true; break;
						case 4:
							if (xmlDoc != null) xmlEle = xmlDoc.CreateElement("CloseToTaskBar");
							xmlEle.SetAttribute("boolean", CloseToTaskBar.ToString());
							checkExist[4] = true; break;
						case 5:
							if (xmlDoc != null) xmlEle = xmlDoc.CreateElement("AutoCheckUpdate");
							xmlEle.SetAttribute("boolean", IsAutoCheckUpdate.ToString());
							checkExist[5] = true; break;
					}
					return xmlEle;
				}

				XmlDocument xmlDoc = new();
				XmlNodeList xmlNL;
				XmlElement xmlEle;
				xmlDoc.Load(FilePath.MainDataFile);
				xmlNL = xmlDoc.SelectSingleNode("TimedPower_Data")!.ChildNodes;
				foreach (XmlNode xn in xmlNL)
				{
					xmlEle = (XmlElement)xn;
					switch (xmlEle.Name)
					{
						case "Window":
							xmlEleDo(0, xmlEle);
							break;
						case "Action":
							xmlEleDo(1, xmlEle);
							break;
						case "TimeType":
							xmlEleDo(2, xmlEle);
							break;
						case "TimeInput":
							xmlEleDo(3, xmlEle);
							break;
						case "CloseToTaskBar":
							xmlEleDo(4, xmlEle);
							break;
						case "AutoCheckUpdate":
							xmlEleDo(5, xmlEle);
							break;
					}
				}
				xmlDoc.Save(FilePath.MainDataFile);

				XmlNode xmlRoot = xmlDoc.SelectSingleNode("TimedPower_Data")!;
				for (int i = 0; i < checkExist.Length; i++)//检查，修补丢失的项
				{
					if (!checkExist[i])
					{
						xmlRoot.AppendChild(xmlEleDo(i, null!, xmlDoc));
					}
				}
				xmlDoc.Save(FilePath.MainDataFile);

				AutoTaskData.SaveToFile();
				wait = true;
			}));
			while (!wait) ;
		}

		/// <summary>
		/// 是否正在检测更新，避免重复检查
		/// </summary>
		bool isCheckingUpdate = false;
		/// <summary>
		/// 是否正在检测更新，避免重复检查
		/// </summary>
		bool IsCheckingUpdate
		{
			set
			{
				isCheckingUpdate = value;
				FormMenuStrip_Help_CheckUpdate.Enabled = !value;
				nmc_CheckUpdate.Enabled=!value;
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
		async void ProgramUpdate(bool isAuto=false)
		{
			if (!isCheckingUpdate)
			{
				IsCheckingUpdate = true;
				try
				{
					UpdateFromGithub.CheckUpdateValue cuv = await ufg.CheckUpdateAsync();
					if (cuv.haveUpdate)
					{
						switch (MessageBox.Show(
@$"检查到可用的更新，是否进行更新？
当前版本: V{version}
最新版本: {cuv.newVersionStr}
发布时间: {DateTime.Parse(cuv.publishedTime).AddHours(8)}"/*将UTC时间转换为北京时间*/
										, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Information))
						{
							case DialogResult.Yes:
								UpdateFromGithub.InfoOfInstall? ioi = await ufg.DownloadReleaseAsync(0);
								if (ioi != null)
								{
									if (MessageBox.Show("最新版本下载完毕，是否执行安装？", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
									{
										ufg.InstallFile(ioi,waitTime: 900);
										this.Invoke(new Action(() =>
										{
											NotifyIcon_main_ContextMenu_ExitButton_Click(null!, null!);
										}));
									}
								}
								else
								{
									MessageBox.Show("下载更新失败！", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
						}
								break;
							default:
								break;
						}
					}
					else if (!isAuto)
						MessageBox.Show("当前已是最新版本", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				catch { if(!isAuto)
					MessageBox.Show("更新检查失败！",this.Text,MessageBoxButtons.OK, MessageBoxIcon.Error); }
				IsCheckingUpdate = false;
			}
		}
		#endregion
		private void TimeTypeSelect_SelectedIndexChanged(object sender, EventArgs e)
		{
			switch (TimeTypeSelect.SelectedIndex)
			{
				case 0:
					TimePicker.Visible = false;
					TimeInput.Visible = true;
					break;
				case 1:
					TimeInput.Visible = false;
					TimePicker.Visible = true;
					break;
			}
		}
		private void CountdownLabel_Resize(object sender, EventArgs e)
		{
			//countdownLabel.Left = (int)(((float)this.Width / 2) - ((float)countdownLabel.Width / 2));
		}
		#region TimeInput&TimePicker
		#region TimeInput
		private void TimeInput_Leave(object sender, EventArgs e)
		{
			if (TimeInput.Text != "" && FormatdInputBool(TimeInput.Text))
				TimeInput.Text = atv.GetFormatdTime();
		}
		private void TimeInput_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				e.Handled = true;
				StartButton.Focus();
			}
		}
		private void TimeInput_KeyPress(object sender, KeyPressEventArgs e)
		{//避免按下回车键报警
			if (e.KeyChar == System.Convert.ToChar(13))
			{
				e.Handled = true;
			}
		}
		#region TimeInput_ContextMenu.Items
		private void TPCM_s10_Click(object sender, EventArgs e)
		{
			atv.SetTimeValue(seconds: 10);
			TimeInput.Text = atv.GetFormatdTime();
		}
		private void TPCM_s30_Click(object sender, EventArgs e)
		{
			atv.SetTimeValue(seconds: 30);
			TimeInput.Text = atv.GetFormatdTime();
		}
		private void TPCM_min1_Click(object sender, EventArgs e)
		{
			atv.SetTimeValue(minutes: 1);
			TimeInput.Text = atv.GetFormatdTime();
		}
		private void TPCM_min2_Click(object sender, EventArgs e)
		{
			atv.SetTimeValue(minutes: 2);
			TimeInput.Text = atv.GetFormatdTime();
		}
		private void TPCM_min5_Click(object sender, EventArgs e)
		{
			atv.SetTimeValue(minutes: 5);
			TimeInput.Text = atv.GetFormatdTime();
		}
		private void TPCM_min10_Click(object sender, EventArgs e)
		{
			atv.SetTimeValue(minutes: 10);
			TimeInput.Text = atv.GetFormatdTime();
		}
		private void TPCM_min20_Click(object sender, EventArgs e)
		{
			atv.SetTimeValue(minutes: 20);
			TimeInput.Text = atv.GetFormatdTime();
		}
		private void TPCM_min40_Click(object sender, EventArgs e)
		{
			atv.SetTimeValue(minutes: 40);
			TimeInput.Text = atv.GetFormatdTime();
		}
		private void TPCM_h1_Click(object sender, EventArgs e)
		{
			atv.SetTimeValue(hours: 1);
			TimeInput.Text = atv.GetFormatdTime();
		}
		private void TPCM_h2_Click(object sender, EventArgs e)
		{
			atv.SetTimeValue(hours: 2);
			TimeInput.Text = atv.GetFormatdTime();
		}
		#endregion

		#endregion
		#region TimePicker
		private void TimePicker_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				e.Handled = true;
				StartButton.Focus();
			}
		}
		private void TimePicker_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == System.Convert.ToChar(13))
			{
				e.Handled = true;
			}
		}
		#endregion
		#endregion


		AfterTimeValue? countdown;
		Thread? countdownThread;
		Thread? countdownThread_autoTask;
		static bool fuse = false;//保险变量，倒计时和执行电源操作时必须为true
		private void StartButton_Click(object sender, EventArgs e)
		{
			switch (TimeTypeSelect.SelectedItem!.ToString())
			{
				case "此后":
					if (FormatdInputBool(TimeInput.Text)) TimeInput.Text = atv.GetFormatdTime();
					else return;
					break;
				case "此时":
					if (((long)GetTimeStamp(TimePicker.Value) - (long)GetTimeStamp(DateTime.Now)) > 0) { }
					else
					{
						MessageBox.Show("只能选择未来的时间！", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}
					break;
			}

			StartButton.Enabled = false;
			if (countdownThread != null)
			{ while (countdownThread.IsAlive) { Thread.Sleep(1); Application.DoEvents(); } }
			ControlModeSet("start");
			fuse = true;
			switch (TimeTypeSelect.SelectedItem!.ToString())
			{
				case "此后":
					countdown = atv;
					break;
				case "此时":
					//TimePicker.Value
					countdown = new();
					countdown.SetTimeValue(seconds: ((long)GetTimeStamp(TimePicker.Value) - (long)GetTimeStamp(DateTime.Now)));
					break;
			}
			countdownLabel.Text = countdown!.GetFormatdTime();
			if (countdown!.AllSeconds <= 5)
			{
				if (MessageBox.Show("计时时间小于5秒，确定继续吗？", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
					!= DialogResult.Yes)
				{
					StopButton_Click(null!, null!);
					return;
				}
			}
			CountdownProgressControl.SetStartValue(countdown.AllSeconds);

			countdownThread = new(CountdownThread);
			countdownThread.Start();
		}
		private void StopButton_Click(object sender, EventArgs e)
		{
			StopButton.Enabled = false;
			fuse = false;
			if (countdownThread != null)
			{ while (countdownThread.IsAlive) { Thread.Sleep(1); Application.DoEvents(); } }
			CountdownProgressControl.Close();
			ControlModeSet("stop");
		}
		void CountdownThread()
		{
			void LastWarning(string type, string time)
			{
				//侦听Windows通知点击事件
				ToastNotificationManagerCompat.OnActivated += toastArgs =>
				{
					//通知参数
					ToastArguments args = ToastArguments.Parse(toastArgs.Argument);
					//获取任何用户输入
					ValueSet userInput = toastArgs.UserInput;

					if (args.ToString() == "StopCountdown;TimeWarning")
						this.Invoke(new Action(() => { if (fuse) StopButton_Click(null!, null!); }));
					else if (args.ToString() == "TimeWarning")
					{
						this.Invoke(new Action(() =>
						{
							[System.Runtime.InteropServices.DllImport("user32.dll", EntryPoint = "SetForegroundWindow")]
							static extern bool SetForegroundWindow(IntPtr hWnd);
							SetForegroundWindow(this.Handle);
						}));
					}
				};
				new ToastContentBuilder()
					.AddArgument("TimeWarning")
					.AddText("警告，将在" + time + "后" + type)
					.AddButton(new ToastButton()
					.SetContent("终止定时")
					.AddArgument("StopCountdown"))
					.Show();
			}

			string actionSelect = "";
			{
				bool threadLock = false;
				this.Invoke(new Action(() => { actionSelect = ActionSelect.SelectedItem!.ToString()!; threadLock = true; }));
				while (!threadLock) { }
			}
			string typeSelect = "";
			{
				bool threadLock = false;
				this.Invoke(new Action(() => { typeSelect = TimeTypeSelect.SelectedItem!.ToString()!; threadLock = true; }));
				while (!threadLock) { }
			}
			switch (typeSelect)
			{
				case "此后":
					while (countdown!.AllSeconds > 0 && fuse)
					{
						CountdownProgressControl.Flush(countdown.AllSeconds);
						switch (countdown!.AllSeconds)
						{
							case 3 * 60:
							case 1 * 60:
							case 30:
							case 15:
							case 5:
								LastWarning(actionSelect, countdown.GetVisualTime());
								break;
						}
						Sleep(1000);
						countdown.OnlySeconds--;
						try { this.Invoke(new Action(() => { countdownLabel.Text = countdown.GetFormatdTime(); })); } catch { }
					}
					break;
				case "此时":
					{
						long endTimeStamp = 0;
						void TimeReload()//将时间差刷新至countdown内，且将格式化的数据刷新至UI
						{
							countdown!.SetTimeValue(seconds: ((long)endTimeStamp - (long)GetTimeStamp(DateTime.Now)));
							try { this.Invoke(new Action(() => { countdownLabel.Text = countdown.GetFormatdTime(); })); } catch { }
						}

						{
							bool threadLock = false;
							this.Invoke(new Action(() => { endTimeStamp = GetTimeStamp(TimePicker.Value); threadLock = true; }));
							while (!threadLock) { }
						}
						TimeReload();
						while (countdown!.AllSeconds > 0 && fuse)
						{
							CountdownProgressControl.Flush(countdown.AllSeconds);
							switch (countdown!.AllSeconds)
							{
								case 3 * 60:
								case 1 * 60:
								case 30:
								case 15:
								case 5:
									LastWarning(actionSelect, countdown.GetVisualTime());
									break;
							}
							Sleep(950);
							TimeReload();
						}
					}
					break;
			}
			if (fuse)
			{
				DataSave();//操作前保存所有
				switch (actionSelect)
				{
					case "关机":
						if (fuse) PowerInvoke.Shutdown();
						break;
					case "重启":
						if (fuse) PowerInvoke.Reboot();
						break;
					case "睡眠":
						if (fuse) PowerInvoke.Sleep();
						break;
					case "休眠":
						if (fuse) PowerInvoke.Hibernate();
						break;
					case "锁定":
						if (fuse) PowerInvoke.UserLock();
						break;
					case "注销":
						if (fuse) PowerInvoke.UserOff();
						break;
				}
				this.Invoke(new Action(() =>
				{
					trueExitProgram = true;
					this.Close();
				}));
				/*this.Invoke(new Action(() =>{ if (fuse) StopButton_Click(null!, null!);}));*/
			}
		}

		AfterTimeValue countdown_autoTask;
		/// <summary>
		/// autoTask的保险变量
		/// </summary>
		bool fuse_autoTask = false;
		void AutoTaskCountdownThread()
		{
			countdown_autoTask = new();

			void LastWarning(AutoTaskData.ATDataHead_action type, string time, string taskName)
			{
				string typeStr;
				switch (type)
				{
					case AutoTaskData.ATDataHead_action.shutdown:
						typeStr = "关机";
						break;
					case ATDataHead_action.reboot:
						typeStr = "重启";
						break;
					case ATDataHead_action.sleep:
						typeStr = "睡眠";
						break;
					case ATDataHead_action.hibernate:
						typeStr = "休眠";
						break;
					case ATDataHead_action.userlock:
						typeStr = "锁定";
						break;
					case ATDataHead_action.useroff:
						typeStr = "注销";
						break;
					default:
						typeStr = "错误";
						break;
				}
				//侦听Windows通知点击事件
				ToastNotificationManagerCompat.OnActivated += toastArgs =>
				{
					//通知参数
					ToastArguments args = ToastArguments.Parse(toastArgs.Argument);
					//获取任何用户输入
					ValueSet userInput = toastArgs.UserInput;

					if (args.ToString() == "StopCountdown;TimeWarning_autoTask")
						this.Invoke(new Action(() => { if (fuse_autoTask) AutoTaskData.CountdownStateControl.StopNowTask(); }));
					else if (args.ToString() == "TimeWarning_autoTask")
					{
						this.Invoke(new Action(() =>
						{
							[System.Runtime.InteropServices.DllImport("user32.dll", EntryPoint = "SetForegroundWindow")]
							static extern bool SetForegroundWindow(IntPtr hWnd);
							SetForegroundWindow(this.Handle);
						}));
					}
				};
				new ToastContentBuilder()
					.AddArgument("TimeWarning_autoTask")
					.AddText("警告，名为\"" + taskName + "\"的自动定时任务将在" + time + "后执行" + typeStr + "操作")
					.AddButton(new ToastButton()
					.SetContent("禁用当前任务")
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
				{
					countdown_autoTask.SetTimeValue(seconds: ((long)endTimeStamp - (long)GetTimeStamp(DateTime.Now)));
					//try { this.Invoke(new Action(() => { countdownLabel.Text = countdown_autoTask.GetFormatdTime(); })); } catch { }//将格式化的数据刷新至UI
				}

				endTimeStamp = GetTimeStamp(AutoTaskData.CountdownStateControl.GetDateTime());

				TimeReload();
				while (countdown_autoTask.AllSeconds > 0 && fuse_autoTask)
				{
					if (countdown_autoTask.AllSeconds <= 3 * 60)
					{
						switch (countdown_autoTask.AllSeconds)
						{
							case 3 * 60:
							case 1 * 60:
							case 30:
							case 15:
							case 5:
								LastWarning(actionSelect, countdown_autoTask.GetVisualTime(), AutoTaskData.CountdownStateControl.GetTaskName());
								break;
						}
					}
					Sleep(950);
					TimeReload();
				}
			}
			if (fuse_autoTask)
			{
				if (!DefendAutoTask.DefendState())//自动任务防御程序，防止不可预测的意外
				{
					DataSave();//操作前保存所有
					switch (actionSelect)
					{
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
				}
				else
					DefendAutoTask.DefendMessage_Msgbox();
				this.Invoke(new Action(() =>
				{
					trueExitProgram = true;
					this.Close();
				}));
				/*this.Invoke(new Action(() =>{ if (fuse_autoTask) StopButton_Click(null!, null!);}));*/
			}
			AutoTaskData.CountdownStateControl.updateWaitLock = false;
		}
		void AutoTask_CountdownState_IsEnable_Change(bool isEnable)
		{
			if (isEnable)
			{
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
		bool FormatdInputBool(string input)
		{
			string output = atv.FormatdInputTime(input);
			if (output == "done")
			{
				return true;
			}
			else if (output == "ToBig")
			{
				MessageBox.Show("时间数值过大！", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
			else
			{
				MessageBox.Show("时间格式错误！", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
		}
		/// <summary>
		/// 根据当前控件状态更改控件模式
		/// </summary>
		/// <param name="id">状态ID: start; stop</param>
		void ControlModeSet(string id)
		{
			switch (id)
			{
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
		static void Sleep(int ms)
		{
			var sw = Stopwatch.StartNew();
			var sleepMs = ms - 16;
			if (sleepMs > 0)
			{
				Thread.Sleep(sleepMs);
			}
			while (sw.ElapsedMilliseconds < ms)
			{
				Thread.Sleep(0);
			}
		}
		/// <summary>
		/// 取指定时间的时间戳
		/// </summary>
		/// <param name="dateTime">需要转换的DateTime类型</param>
		/// <param name="accurateToMilliseconds">是否精确到毫秒</param>
		/// <returns>返回long类型时间戳</returns>
		public static long GetTimeStamp(DateTime dateTime, bool accurateToMilliseconds = false)
		{
			if (accurateToMilliseconds)
			{
				return new DateTimeOffset(dateTime).ToUnixTimeMilliseconds();
			}
			else
			{
				return new DateTimeOffset(dateTime).ToUnixTimeSeconds();
			}
		}

		static class CountdownProgressControl
		{
			private static long StartValue;
			private const int stage1 = 30;
			private const int stage2 = 10;
			private const int stage3 = 0;//三个阶段，当时间倒计时到各个阶段时进度条颜色随之改变
			/// <summary>
			/// 设置进度开始的值（计时的秒数数值）
			/// </summary>
			/// <param name="startValue">进度开始值</param>
			public static void SetStartValue(long startValue)
			{
				StartValue = startValue;
				TaskbarManager.SetProgressValue(1, 1);

				if (startValue <= stage1 && startValue > stage2)
					TaskbarManager.SetProgressState(TaskbarProgressBarState.Paused);
				else if (startValue <= stage2 && startValue > stage3)
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
			public static void Flush(long nowValue)
			{
				switch (nowValue)
				{
					case stage1:
						TaskbarManager.SetProgressState(TaskbarProgressBarState.Paused); break;
					case stage2:
						TaskbarManager.SetProgressState(TaskbarProgressBarState.Error); break;
					case stage3:
						TaskbarManager.SetProgressState(TaskbarProgressBarState.NoProgress); return;
				}
				TaskbarManager.SetProgressValue((int)(((float)nowValue / (float)StartValue) * 100), 100);
			}
			public static void Close()
			{
				TaskbarManager.SetProgressState(TaskbarProgressBarState.NoProgress);
			}
		}

		#region notifyIcon_main_EVENT
		#region NotifyIcon_main_ContextMenu_EVENT
		private void NotifyIcon_main_ContextMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
		{
			notifyIcon_main_ContextMenu_ShowButton.Enabled = !Visible;
			notifyIcon_main_ContextMenu_HiddenButton.Enabled = Visible;
			nmc__AutoCheckUpdate.Checked = IsAutoCheckUpdate;
		}
		private void NotifyIcon_main_ContextMenu_ShowButton_Click(object sender, EventArgs e)
		{
			this.Visible = true;
		}

		private void NotifyIcon_main_ContextMenu_HiddenButton_Click(object sender, EventArgs e)
		{
			this.Visible = false;
		}

		private void NotifyIcon_main_ContextMenu_ExitButton_Click(object sender, EventArgs e)
		{
			trueExitProgram = true;
			this.Close();
		}
		#endregion
		private void NotifyIcon_main_MouseClick(object sender, MouseEventArgs e)
		{
			switch (e.Button)
			{
				case MouseButtons.Left:
					ShowMainForm();
					break;
			}
		}
		private void ShowMainForm()
		{
			if (this.Visible == false)
				NotifyIcon_main_ContextMenu_ShowButton_Click(null!, null!);
			else
			{
				TopMost = true;
				TopMost = false;
				this.Focus();
			}
		}
		#endregion

		#region FormMenuStrip
		private void FormMenuStrip_Opening(object sender, System.ComponentModel.CancelEventArgs e)
		{
			FormMenuStrip_CloseToTaskBarToggle.Checked = CloseToTaskBar;
			FormMenuStrip_Help_AutoCheckUpdate.Checked = IsAutoCheckUpdate;
		}
		private void AddOrFixWindowsRightClickMenu_MenuItem_Click(object sender, EventArgs e)
		{
			BatFile.WindowsRightClickMenu.RunAdd();
		}
		private void RemoveWindowsRightClickMenu_MenuItem_Click(object sender, EventArgs e)
		{
			BatFile.WindowsRightClickMenu.RunRemove();
		}
		private void EnabledSelfStarting_Click(object sender, EventArgs e)
		{
			BatFile.WindowsSelfStarting.RunAdd();
		}
		private void DisabledSelfStarting_Click(object sender, EventArgs e)
		{
			BatFile.WindowsSelfStarting.RunRemove();
		}
		private void FormMenuStrip_CloseToTaskBarToggle_CheckedChanged(object sender, EventArgs e)
		{
			CloseToTaskBar = FormMenuStrip_CloseToTaskBarToggle.Checked;
		}
		AutoTaskForm autoTaskForm;
		private void AutoTask_ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (autoTaskForm == null || autoTaskForm.IsStart == false)
			{
				autoTaskForm = new();
				autoTaskForm.Show/*Dialog*/();
			}
			else
			{
				autoTaskForm.Focus();
			}
		}
		private void FormMenuStrip_Help_CheckUpdate_Click(object sender, EventArgs e)
		{
			Task.Run(() =>
			{
				ProgramUpdate();
			});
		}
		private void FormMenuStrip_Help_AutoCheckUpdate_Click(object sender, EventArgs e)
		{
			IsAutoCheckUpdate=!IsAutoCheckUpdate;
		}
		private void FormMenuStrip_Help_HelpDoc_Click(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start("explorer.exe", "https://github.com/Hgnim/TimedPower/wiki");
		}
		private void GyToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MessageBox.Show(Program.aboutText, "关于");
		}
		#endregion
	}
}
