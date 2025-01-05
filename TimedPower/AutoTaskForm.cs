using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static TimedPower.AutoTaskData;

namespace TimedPower
{
	public partial class AutoTaskForm : Form
	{
		public bool IsStart => isStart;
		bool isStart = false;
		public AutoTaskForm() => InitializeComponent();

		private void AutoTaskForm_Load(object sender, EventArgs e)
		{
			TaskListUpdate();
			timeTypeSelect.SelectedIndex = 0;

			isStart = true;
		}
		private void AutoTaskForm_FormClosed(object sender, FormClosedEventArgs e) => isStart = false;
		private void AutoTaskForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (userIsChange)
			{
				if (!UnsaveNotify())
					return;
			}
		}


		private void TimeTypeSelect_SelectedIndexChanged(object sender, EventArgs e)
		{
			switch (timeTypeSelect.SelectedIndex)
			{
				case 0:
					//每天
					TimePicker.CustomFormat = "HH:mm:ss";
					TimePicker.Visible = true;
					TimeInput.Visible = false;
					break;
				case 1:
					//指定时间					
					TimePicker.CustomFormat = "yyyy/MM/dd HH:mm:ss";
					TimePicker.Visible = true;
					TimeInput.Visible = false;
					break;
				case 2:
					//程序启动后
					TimePicker.Visible = false;
					TimeInput.Visible = true;
					break;

			}
			UserChangeCheck();
		}
		#region TaskList
		/// <summary>
		/// 列表项目刷新
		/// </summary>
		void TaskListUpdate()
		{
			//清除所有项后将取消当前选择
			taskList.Items.Clear();
			for (int i = 0; i < AutoTaskData.GetATDataCount(); i++)
			{
				_ = taskList.Items.Add(AutoTaskData.GetData(i, AutoTaskData.ATDataHead.name)!);
			}
			TaskListSelectCheck();
			if (taskList_LastSelect != -1)
			{
				taskList.SelectedIndex = taskList_LastSelect < taskList.Items.Count ? taskList_LastSelect : taskList.Items.Count - 1;
			}
		}
		/// <summary>
		/// 检查列表项目是否为0，或者未被选中。因此来控制信息面板的启用状态
		/// </summary>
		void TaskListSelectCheck() => infoPanel.Enabled = taskList.Items.Count != 0 && taskList.SelectedIndex != -1;
		#region TaskList_UIEvent
		private void TaskList_DrawItem(object sender, DrawItemEventArgs e)
		{
			if (e.Index >= 0)
			{
				e.DrawBackground();
				Brush mybsh = AutoTaskData.GetData(e.Index, AutoTaskData.ATDataHead.enable) == AutoTaskData.ATDataHead_enable.t.ToString()
					? Brushes.Green
					: Brushes.Red;
				//根据任务的启动状态绘制列表中的项目颜色
				/*else if (listBox1.Items[e.Index].ToString().IndexOf("test2") != -1)
{
	mybsh = Brushes.Red;
}*/
				// 焦点框
				e.DrawFocusRectangle();
				//文本 
				e.Graphics.DrawString(taskList.Items[e.Index].ToString(), e.Font!, mybsh, e.Bounds, StringFormat.GenericDefault);
			}
		}
		int taskList_LastSelect = -1;
		private void TaskList_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (userIsChange &&
				taskList.SelectedIndex != taskList_LastSelect//避免重复判断
				)
			{
				if (!UnsaveNotify())
				{
					taskList.SelectedIndex = taskList_LastSelect;
					return;
				}
			}
			else if (taskList.SelectedIndex == taskList_LastSelect)//如果发现两数相等，则跳出，不进行加载
				goto end;
			taskList_LastSelect = taskList.SelectedIndex;


			userChangeCheckSwitch = false;
			SetUserIsChangeState(false);
			int index = taskList.SelectedIndex;
			enableCheck.Checked = AutoTaskData.GetData(index, AutoTaskData.ATDataHead.enable) == AutoTaskData.ATDataHead_enable.t.ToString();
			taskName_TextBox.Text = AutoTaskData.GetData(index, AutoTaskData.ATDataHead.name)!.ToString();
			{
				switch (Enum.Parse(typeof(ATDataHead_timeType), AutoTaskData.GetData(index, AutoTaskData.ATDataHead.timeType)!))
				{
					case AutoTaskData.ATDataHead_timeType.everyday:
						timeTypeSelect.SelectedIndex = 0; break;
					case AutoTaskData.ATDataHead_timeType.singleTimed:
						timeTypeSelect.SelectedIndex = 1; break;
					case ATDataHead_timeType.appStart:
						timeTypeSelect.SelectedIndex = 2; break;
				}
			}
			{
				string cache = AutoTaskData.GetData(index, AutoTaskData.ATDataHead.action)!.ToString();
				if (cache == AutoTaskData.ATDataHead_action.shutdown.ToString())
					ActionSelect.SelectedIndex = 0;
				else if (cache == AutoTaskData.ATDataHead_action.reboot.ToString())
					ActionSelect.SelectedIndex = 1;
				else if (cache == AutoTaskData.ATDataHead_action.sleep.ToString())
					ActionSelect.SelectedIndex = 2;
				else if (cache == AutoTaskData.ATDataHead_action.hibernate.ToString())
					ActionSelect.SelectedIndex = 3;
				else if (cache == AutoTaskData.ATDataHead_action.userlock.ToString())
					ActionSelect.SelectedIndex = 4;
				else if (cache == AutoTaskData.ATDataHead_action.useroff.ToString())
					ActionSelect.SelectedIndex = 5;
			}

			switch (Enum.Parse(typeof(ATDataHead_timeType), AutoTaskData.GetData(index, AutoTaskData.ATDataHead.timeType)!))
			{
				case ATDataHead_timeType.everyday:
				case ATDataHead_timeType.singleTimed:
					TimePicker.Value = AutoTaskData.ATtimeDataToDateTime(AutoTaskData.GetData(index, AutoTaskData.ATDataHead.timeData)!.ToString());
					break;
				case ATDataHead_timeType.appStart:
					TimeInput.Text = AutoTaskData.ATtimeDataToString(AutoTaskData.GetData(index, AutoTaskData.ATDataHead.timeData)!.ToString());
					break;
			}

end:;
			TaskListSelectCheck();
			userChangeCheckSwitch = true;
		}
		#endregion
		#endregion

		#region Button_Event
		private void CreateButton_Click(object sender, EventArgs e)
		{
			if (userIsChange)
			{
				if (!UnsaveNotify())
					return;
			}
			AutoTaskData.CreateATData();
			TaskListUpdate();
			taskList.SelectedIndex = taskList.Items.Count - 1;//选择新创建的项

			DefendAutoTask.SetDefendTime(10);//设置配置项后进行保护
			AutoTaskData.CountdownStateControl.UpdateData();//刷新自动任务执行程序
		}
		private void DeleteButton_Click(object sender, EventArgs e)
		{
			try
			{
				AutoTaskData.RemoveATData(taskList.SelectedIndex);
			}
			catch { _ = MessageBox.Show("删除失败!", Main.ThisFormText, MessageBoxButtons.OK, MessageBoxIcon.Error); }
			TaskListUpdate();

			DefendAutoTask.SetDefendTime(10);//设置配置项后进行保护
			AutoTaskData.CountdownStateControl.UpdateData();//刷新自动任务执行程序
		}
		private void SaveButton_Click(object sender, EventArgs e)
		{
			//检查内容合法性
			switch (timeTypeSelect.Text)
			{
				case "指定时间":
					if (((long)Main.GetTimeStamp(TimePicker.Value) - (long)Main.GetTimeStamp(DateTime.Now)) > 0) { }
					else
					{
						_ = MessageBox.Show("只能选择未来的时间！", Main.ThisFormText, MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}
					break;
				case "软件启动后":
					if (FormatdInputBool(TimeInput.Text)) TimeInput.Text = atv.GetFormatdTime();//再次检查一遍合法性
					else return;
					break;
			}

			SetUserIsChangeState(false);

			//将数据保存至数据组变量中
			{
				ATDataHead_enable aTDataHead_Enable = enableCheck.Checked ? AutoTaskData.ATDataHead_enable.t : AutoTaskData.ATDataHead_enable.f;
				ATDataHead_timeType aTDataHead_TimeType;
				string timeData;
				switch (timeTypeSelect.Text)
				{
					case "每天":
					default:
						aTDataHead_TimeType = AutoTaskData.ATDataHead_timeType.everyday;
						timeData = TimePicker.Value.ToString("0,0,0,HH,mm,ss");
						break;
					case "指定时间":
						aTDataHead_TimeType = AutoTaskData.ATDataHead_timeType.singleTimed;
						timeData = TimePicker.Value.ToString("yyyy,MM,dd,HH,mm,ss");
						break;
					case "软件启动后":
						aTDataHead_TimeType = ATDataHead_timeType.appStart;
						timeData = $"-1,-1,-1,{TimeInput.Text.Split(':')[0]},{TimeInput.Text.Split(':')[1]},{TimeInput.Text.Split(':')[2]}";
						break;
				}
				ATDataHead_action aTDataHead_Action = ActionSelect.Text switch {
					"重启" => ATDataHead_action.reboot,
					"睡眠" => ATDataHead_action.sleep,
					"休眠" => ATDataHead_action.hibernate,
					"锁定" => ATDataHead_action.userlock,
					"注销" => ATDataHead_action.useroff,
					_ => ATDataHead_action.shutdown,
				};
				AutoTaskData.SetATData(taskList.SelectedIndex, [
					ATDataHead.name.ToString(),taskName_TextBox.Text,
				ATDataHead.enable.ToString(),aTDataHead_Enable.ToString(),
				ATDataHead.timeType.ToString(),aTDataHead_TimeType.ToString(),
				ATDataHead.timeData.ToString(),timeData,
				ATDataHead.action.ToString(),aTDataHead_Action.ToString()
					]);
			}

			TaskListUpdate();

			DefendAutoTask.SetDefendTime(10);//设置配置项后进行保护
			AutoTaskData.CountdownStateControl.UpdateData();//刷新自动任务执行程序
		}
		private void UnsaveButton_Click(object sender, EventArgs e)
		{
			SetUserIsChangeState(false);
			TaskListUpdate();
		}
		#endregion

		#region Change_Event        
		private void EnableCheck_CheckedChanged(object sender, EventArgs e) => UserChangeCheck();

		private void TaskName_TextBox_TextChanged(object sender, EventArgs e) => UserChangeCheck();

		private void ActionSelect_SelectedIndexChanged(object sender, EventArgs e) => UserChangeCheck();

		private void TimePicker_ValueChanged(object sender, EventArgs e) => UserChangeCheck();
		private void TimeInput_TextChanged(object sender, EventArgs e) => UserChangeCheck();
		/// <summary>
		/// 表示是否启用用户更改检查<br/>一般等待数据加载完毕后再启用用户更改检查，避免在部署数据时触发
		/// </summary>
		bool userChangeCheckSwitch = false;
		/// <summary>
		/// 表示用户是否已经更改了自动任务内容数据
		/// </summary>
		bool userIsChange = false;
		/// <summary>
		/// 检查用户是否更改了任务内容。
		/// </summary>
		void UserChangeCheck()
		{
			if (userChangeCheckSwitch && !userIsChange)
			{
				SetUserIsChangeState(true);
			}
		}
		/// <summary>
		/// 设置用户是否更改了任务内容的状态
		/// </summary>
		/// <param name="isEnabled">布尔值，是与否</param>
		void SetUserIsChangeState(bool isEnabled)
		{
			saveButton.Enabled = isEnabled;
			unsaveButton.Enabled = isEnabled;
			userIsChange = isEnabled;
		}

		/// <summary>
		/// 未保存时离开时的用户弹窗提示
		/// </summary>
		/// <returns>根据用户的选择进行返回</returns>
		static bool UnsaveNotify()
		{
			DialogResult dr = MessageBox.Show("当前有未保存的内容，是否继续？", Main.ThisFormText,
				MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
			return dr == DialogResult.OK;
		}
		#endregion


		readonly AfterTimeValue atv = new();
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
				_ = MessageBox.Show("时间数值过大！", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
			else
			{
				_ = MessageBox.Show("时间格式错误！", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
		}
		private void TimeInput_Leave(object sender, EventArgs e)
		{
			if (TimeInput.Text != "" && FormatdInputBool(TimeInput.Text))
				TimeInput.Text = atv.GetFormatdTime();
		}
	}
	internal static class AutoTaskData
    {
        private static readonly List<string[]> atData = [];
        /// <summary>
        /// 根据数据头获取AutoTaskData.atData变量的指定数据
        /// </summary>
        /// <param name="index">数据组序号</param>
        /// <param name="head">数据头</param>
        /// <returns>返回获取的数据。<br/>如果发生错误，则返回null</returns>
        internal static string? GetData(int index, ATDataHead head)
        {
            try
            {
                string[] cacheData = atData[index];
                for (int i = 0; i < cacheData.Length; i += 2)
                {
                    if (cacheData[i] == head.ToString())
                        return cacheData[i + 1];
                }
                return null;
            }
            catch { return null; }
        }
        /// <summary>
        /// 根据数据头获取参数autoTask的指定数据
        /// </summary>
        /// <param name="autoTask">数据组</param>
        /// <param name="head">数据头</param>
        /// <returns>返回获取的数据。<br/>如果发生错误，则返回null</returns>
        internal static string? GetData(string[] autoTask, ATDataHead head)
        {
            try
            {
                for (int i = 0; i < autoTask.Length; i += 2)
                {
                    if (autoTask[i] == head.ToString())
                        return autoTask[i + 1];
                }
                return null;
            }
            catch { return null; }
        }
        /// <summary>
        /// 根据数据头修改参数autoTask的指定数据
        /// </summary>
        /// <param name="autoTask">数据组</param>
        /// <param name="head">数据头</param>
        /// <param name="setData">更改的数据</param>
        /// <returns>返回操作后的数据组。如果更改失败，则返回原来输入的数据组。</returns>
        internal static string[] SetData(string[] autoTask,ATDataHead head,string setData)
        {
            string[] cache = autoTask;
            for (int i = 0; i < cache.Length; i += 2)
            {
                if (cache[i] == head.ToString())
                { 
                    cache[i + 1]=setData; 
                    return cache;
                }
            }
            return autoTask;
        }
		/// <summary>
		/// 获取数据组的个数
		/// </summary>
		/// <returns></returns>
		internal static int GetATDataCount() => atData.Count;
		/// <summary>
		/// 新建一个自动任务数据组
		/// </summary>
		internal static void CreateATData() => atData.Add([
				ATDataHead.name.ToString(),"新的自动任务",
				ATDataHead.enable.ToString(),ATDataHead_enable.f.ToString(),
				ATDataHead.timeType.ToString(),ATDataHead_timeType.everyday.ToString(),
				ATDataHead.timeData.ToString(),"0,0,0,"+DateTime.Now.ToString("HH,mm,ss"),
				ATDataHead.action.ToString(),ATDataHead_action.shutdown.ToString()
				]);
		/// <summary>
		/// 设置自动任务数据组
		/// </summary>
		/// <param name="index">数据组编号</param>
		/// <param name="data">数据组</param>
		internal static void SetATData(int index, string[] data) => atData[index] = data;
		/// <summary>
		/// 删除指定编号的数据组
		/// </summary>
		/// <param name="index">数据组编号</param>
		internal static void RemoveATData(int index) => atData.RemoveAt(index);
		internal enum ATDataHead
        {
            enable, name, timeType, action, timeData
        }
        internal enum ATDataHead_timeType
        {
            everyday//每天
                , singleTimed//单次计时
                , appStart//软件启动后
        }
        internal enum ATDataHead_action
        {
            shutdown, reboot, useroff, userlock, sleep, hibernate
        }
        internal enum ATDataHead_enable
        {
            t, f
        }
        /// <summary>
        /// 初始化所有数据
        /// </summary>
        internal static void GetDataFromFile()
        {
            XmlDocument xmlDoc = new();
            XmlNode xmlRoot;
            xmlDoc.Load(FilePath.AutoTaskFile);
            xmlRoot = xmlDoc.SelectSingleNode("TimedPower_AutoTask")!.SelectSingleNode("task")!;
            XmlNodeList xmlNL = xmlRoot.ChildNodes;
            XmlElement xmlE;
            foreach (XmlNode xn in xmlNL)
            {
                xmlE = (XmlElement)xn;
                if (xmlE.Name == "item")
                {
                    List<string> cache = [];
                    foreach (ATDataHead at in Enum.GetValues(typeof(ATDataHead)))
                    {
                        cache.Add(at.ToString());
                        cache.Add(xmlE.GetAttribute(at.ToString()));
                    }
                    atData.Add([.. cache]/*"cache.ToArray()"的集合表达式*/);
                }
            }
        }
        internal static void SaveToFile()
        {
            XmlDocument xmlDoc = new();
            XmlNode xmlRoot;
            xmlDoc.Load(FilePath.AutoTaskFile);
            xmlRoot = xmlDoc.SelectSingleNode("TimedPower_AutoTask")!.SelectSingleNode("task")!;
            //XmlNodeList xmlNL = xmlRoot!.ChildNodes;
            XmlElement xmlE;
            xmlRoot.RemoveAll();//先删除所有项目
            for (int i = 0; i < atData.Count; i++)
            {
                xmlE = xmlDoc.CreateElement("item");
                foreach (ATDataHead at in Enum.GetValues(typeof(ATDataHead)))
                    xmlE.SetAttribute(at.ToString(), GetData(i, at));
				_ = xmlRoot.AppendChild(xmlE);
            }
            xmlDoc.Save(FilePath.AutoTaskFile);
        }
        /// <summary>
        /// 自动任务倒计时状态控制器，锁定一个数据组进行数据给予
        /// </summary>
        internal static class CountdownStateControl
        {
            public delegate void isEnable_delegate(bool isEnable);
            public static event isEnable_delegate? IsEnable_Change;
            private static bool isEnable = false;
            /// <summary>
            /// 是否启动
            /// </summary>
            internal static bool IsEnable {
				get => isEnable;
				set {
					isEnable = value;
					IsEnable_Change!(isEnable);
				}
			}
			/// <summary>
			/// 自动任务数据组编号
			/// </summary>
			static int atdat_index=-1;
            /// <summary>
            /// 自动任务数据组
            /// </summary>
            static string[] atdat=[];
            /// <summary>
            /// 等待线程结束后刷新数据
            /// </summary>
            public static bool updateWaitLock = false;
            /// <summary>
            /// 刷新所有数据并执行函数
            /// </summary>
            internal static void UpdateData()
            {
                Thread t = new(() =>
                {
                    IsEnable = false;
                    while (updateWaitLock && !Main.trueExitProgram/*加一个判断防止主线程退出后该线程锁死在这里*/) { Thread.Sleep(1); }//等待计时线程关闭
					if (Main.trueExitProgram) goto exitThread;//如果主线程退出，则结束该线程
                    atdat = [];
                    atdat_index = -1;
                    for(int i=0;i<AutoTaskData.atData.Count;i++)//排序，引用最小的任务时间值
                    {
                        if (GetData(i, ATDataHead.enable)!.ToString() == ATDataHead_enable.t.ToString())//判断任务是否为启动状态
                        {
                            DateTime targetDt = AutoTaskData.ATtimeDataToDateTime(GetData(i, ATDataHead.timeData)!);//扫描的目标时间值
                            if (DateTime.Compare(targetDt, DateTime.Now) > 0)//判断任务的目标时间是否大于当前时间
                            {                                
                                if (atdat.Length > 0)//判断当前是否已引入了值到本地
                                {
                                    DateTime myDt = AutoTaskData.ATtimeDataToDateTime(GetData(atdat, ATDataHead.timeData)!);//当前引入的时间值
                                    if (DateTime.Compare(targetDt,myDt) < 0)//判断如果目标值比本地值小，则引用更小的值
                                    {
                                        atdat = atData[i];
                                        atdat_index = i;
                                    }
                                }
                                else
                                {
                                    atdat = atData[i];//如果值为空，则先直接引用
                                    atdat_index= i;
                                }
                            }
                        }
                    }
                    if (atdat_index != -1)
                        IsEnable = true;

exitThread:;
                }); t.Start();
            }
			/// <summary>
			/// 获取本地单个数据组中的时间数据
			/// </summary>
			/// <returns></returns>
			internal static DateTime GetDateTime() => AutoTaskData.ATtimeDataToDateTime(GetData(atdat, ATDataHead.timeData)!);
			/// <summary>
			/// 获取本地单个数据组中的任务名数据
			/// </summary>
			/// <returns></returns>
			internal static string GetTaskName() => GetData(atdat, ATDataHead.name)!;
			/// <summary>
			/// 获取本地单个数据组中的操作类型数据
			/// </summary>
			/// <returns></returns>
			internal static ATDataHead_action GetAction() => (ATDataHead_action)Enum.Parse(typeof(ATDataHead_action), GetData(atdat, ATDataHead.action)!);
			/// <summary>
			/// 终止并禁用当前自动任务
			/// </summary>
			internal static void StopNowTask()
            {
                atData[atdat_index] = SetData(atdat, ATDataHead.enable, ATDataHead_enable.f.ToString());//将正在进行的任务禁用
                UpdateData();//刷新自动任务数据
            }
        }
        /// <summary>
        /// 将autoTaskData中的timeData的string类型的数据转换为DateTime类型的数据
        /// </summary>
        /// <param name="autoTaskData_timeData">autoTaskData中的timeData数据</param>
        /// <returns>转换后的DateTime数据</returns>
        internal static DateTime ATtimeDataToDateTime(string autoTaskData_timeData)
        {
            string[] cache = autoTaskData_timeData.Split(',');
            DateTime dt;
            if (cache[0] == "0" && cache[1] == "0" && cache[2] == "0")
            {
                dt = new(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, int.Parse(cache[3]), int.Parse(cache[4]), int.Parse(cache[5]));
                if (DateTime.Compare(dt, DateTime.Now) <= 0)//如果数据时间早于当前时间，则增加一天时间
					_ = dt.AddDays(1);
            }
            else if (cache[0]=="-1" && cache[1]=="-1" && cache[2] == "-1")
            {
                dt = DateTime.Now;
                dt = dt.AddHours(int.Parse(cache[3]));
				dt = dt.AddMinutes(int.Parse(cache[4]));
				dt = dt.AddSeconds(int.Parse(cache[5]));
            }
            else
                dt = new(int.Parse(cache[0]), int.Parse(cache[1]), int.Parse(cache[2]), int.Parse(cache[3]), int.Parse(cache[4]), int.Parse(cache[5]));
            return dt;
        }
		/// <summary>
		/// 将autoTaskData中的timeData的string类型的数据转换为可视化的string类型的数据
		/// </summary>
		/// <param name="autoTaskData_timeData">autoTaskData中的timeData数据</param>
		/// <returns>转换后的string数据</returns>
		internal static string ATtimeDataToString(string autoTaskData_timeData)
		{
			string[] cache = autoTaskData_timeData.Split(',');
			string str = cache[0] == "-1" && cache[1] == "-1" && cache[2] == "-1" ? $"{cache[3]}:{cache[4]}:{cache[5]}" : "error";
			return str;
		}
	}
    /// <summary>
    /// 自动任务防御程序，用于避免用户错误的设置或程序的Bug导致的严重后果。
    /// </summary>
    internal static class DefendAutoTask
    {
        static int defendTime=0;
        /// <summary>
        /// 添加防御时间并开启防御，该方法将在线程内进行操作<br/>
        /// 如果已经有正在进行的防御计时，则应用最大的时间为新的保护时间。
        /// </summary>
        /// <param name="time">防御时间(单位: s)</param>
        internal static void SetDefendTime(int time)
        {            
            Thread t = new(() =>
            {
                if (!DefendState())//判断是否有正在进行的计时
                {
                    defendTime = time;
                    while (defendTime > 0)
                    {
                        defendTime--;
                        Thread.Sleep(1000);
                    }
                }
                else
                {
                    if(time>defendTime)
                         defendTime = time;
                }
            });t.Start();
        }
		/// <summary>
		/// 当前防御程序的状态
		/// </summary>
		/// <returns>如果防御程序正在运行，则返回true；反之则返回false</returns>
		internal static bool DefendState() => defendTime > 0;
		/// <summary>
		/// 弹出自动定时保护程序阻止操作后的信息
		/// </summary>
		internal static void DefendMessage_Msgbox() => _ = MessageBox.Show("警告，自动定时任务保护程序已阻止了一个可能的异常任务操作。\r\n" +
				"自动定时任务保护程序将在程序启动的30秒内和更改完自动定时任务设置的10秒内阻止任何电源操作。以避免可能的误操作。\r\n" +
				"点击确认以退出程序。", Main.ThisFormText, MessageBoxButtons.OK, MessageBoxIcon.Warning);
		/// <summary>
		/// 关闭保护程序，一般在软件关闭时调用
		/// </summary>
		internal static void CloseDefend() => defendTime = 0;
	}
}
