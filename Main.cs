using Microsoft.Toolkit.Uwp.Notifications;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.PerformanceData;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using Windows.Foundation.Collections;
using static TimedPower.TaskbarProgressBar;
using System.Xml;

namespace TimedPower
{
    public partial class Main : Form
    {
        static string[] args = [];
        const string version = "1.2.1.20240701";
        internal readonly struct FilePath
        {
            internal static readonly string ConfigDir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\TimedPower\\";
            internal static readonly string MainDataFile = ConfigDir + "data.xml";
        }
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

            if (!Directory.Exists(FilePath.ConfigDir))
                Directory.CreateDirectory(FilePath.ConfigDir);
            if (!File.Exists(FilePath.MainDataFile))
            {
                XmlTextWriter xmlWriter = new(FilePath.MainDataFile, System.Text.Encoding.GetEncoding("utf-8")) { Formatting = System.Xml.Formatting.Indented };

                xmlWriter.WriteRaw("<?xml version=\"1.0\" encoding=\"utf-8\" ?>");
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
                        }
                    }
                }
                catch { }
            }
            if (!firstStart)
            {
                if (MessageBox.Show("是否将快捷按钮添加至Windows右键菜单？稍后也可以右键程序进行设置。", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    AddOrFixWindowsRightClickMenu_MenuItem_Click(null!, null!);
                }
            }
        }
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            fuse = false;
            ToastNotificationManagerCompat.Uninstall();//清除且卸载所有通知（实测使用该方法后该实例将无法再发送通知）
            DataSave();
        }
        private void Main_Shown(object sender, EventArgs e)
        {
            if (args.Length != 0)
            {
                string type = "", time = "";
                for (int i = 0; i < args.Length; i++)
                {
                    switch (args[i].ToLower())
                    {
                        case "-type":
                            i++;
                            type = args[i].ToLower();
                            break;
                        case "-time":
                            i++;
                            time = args[i].ToLower();
                            break;
                    }
                }
                //string typeStr="";
                switch (type)
                {
                    case "shutdown":
                        //typeStr = "关机";
                        ActionSelect.SelectedIndex = 0;
                        break;
                    case "reboot":
                        //typeStr = "重启";
                        ActionSelect.SelectedIndex = 1;
                        break;
                    case "sleep":
                        //typeStr = "睡眠";
                        ActionSelect.SelectedIndex = 2;
                        break;
                    case "hibernate":
                        //typeStr = "休眠";
                        ActionSelect.SelectedIndex = 3;
                        break;
                    case "userlock":
                        //typeStr = "锁定";
                        ActionSelect.SelectedIndex = 4;
                        break;
                    case "useroff":
                        //typeStr = "注销";
                        ActionSelect.SelectedIndex = 5;
                        break;
                    default:
                        return;
                }
                TimeTypeSelect.SelectedIndex = 0;
                TimeInput.Text = time;
                StartButton_Click(null!, null!);
            }
        }
        void DataSave()
        {
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
                        xmlEle.SetAttribute("x", this.Left.ToString());
                        xmlEle.SetAttribute("y", this.Top.ToString());
                        break;
                    case "Action":
                        xmlEle.SetAttribute("index", ActionSelect.SelectedIndex.ToString());
                        break;
                    case "TimeType":
                        xmlEle.SetAttribute("index", TimeTypeSelect.SelectedIndex.ToString());
                        break;
                    case "TimeInput":
                        xmlEle.SetAttribute("value", TimeInput.Text);
                        break;
                }
            }
            xmlDoc.Save(FilePath.MainDataFile);

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
            countdownLabel.Left = (int)(((float)this.Width / 2) - ((float)countdownLabel.Width / 2));
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
        #region TimePicker_ContextMenu.Items
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
                    this.Close();
                }));
                /*this.Invoke(new Action(() =>{ if (fuse) StopButton_Click(null!, null!);}));*/
            }
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
                    StopButton.Enabled = true;
                    ActionSelect.Enabled = false;
                    TimePicker.Enabled = false;
                    TimeInput.Enabled = false;
                    TimeTypeSelect.Enabled = false;
                    countdownLabel.Text = "00:00:00";
                    countdownLabel.Visible = true;
                    this.Height = 175;
                    countdownLabel.Top = 98;//必须在后面重新定义位置，否则将会随窗体活动到底部不可见位置
                    break;
                case "stop":
                    StartButton.Enabled = true;
                    StopButton.Enabled = false;
                    ActionSelect.Enabled = true;
                    TimePicker.Enabled = true;
                    TimeInput.Enabled = true;
                    TimeTypeSelect.Enabled = true;
                    countdownLabel.Visible = false;
                    //this.Width = 292;
                    this.Height = 141;
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

        #region FormMenuStrip
        private void AddOrFixWindowsRightClickMenu_MenuItem_Click(object sender, EventArgs e)
        {
            BatFile.WindowsRightClickMenu.RunAdd();
        }
        private void RemoveWindowsRightClickMenu_MenuItem_Click(object sender, EventArgs e)
        {
            BatFile.WindowsRightClickMenu.RunRemove();
        }
        private void GyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("程序名: TimedPower" +
            "\r\n别名: 定时电源" +
            "\r\n版本:V" + version +
            "\r\nCopyright (C) 2024 Hgnim, All rights reserved." +
            "\r\nGithub: https://github.com/Hgnim/TimedPower", "关于");
        }
        #endregion

    }
}
