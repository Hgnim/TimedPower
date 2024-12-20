﻿namespace TimedPower
{
    partial class Main
    {
        public const string ThisFormText = "定时电源";


        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
			ActionSelect = new ComboBox();
			TimePicker = new DateTimePicker();
			TimeInput_ContextMenu = new ContextMenuStrip(components);
			s10 = new ToolStripMenuItem();
			s30 = new ToolStripMenuItem();
			min1 = new ToolStripMenuItem();
			min5 = new ToolStripMenuItem();
			min10 = new ToolStripMenuItem();
			min20 = new ToolStripMenuItem();
			min40 = new ToolStripMenuItem();
			h1 = new ToolStripMenuItem();
			h2 = new ToolStripMenuItem();
			label1 = new Label();
			label2 = new Label();
			TimeTypeSelect = new ComboBox();
			TimeInput = new TextBox();
			countdownLabel = new Label();
			StartButton = new Button();
			StopButton = new Button();
			FormMenuStrip = new ContextMenuStrip(components);
			windows右键菜单ToolStripMenuItem = new ToolStripMenuItem();
			AddOrFixWindowsRightClickMenu_MenuItem = new ToolStripMenuItem();
			RemoveWindowsRightClickMenu_MenuItem = new ToolStripMenuItem();
			软件开机自启ToolStripMenuItem = new ToolStripMenuItem();
			enabledSelfStarting = new ToolStripMenuItem();
			disabledSelfStarting = new ToolStripMenuItem();
			FormMenuStrip_CloseToTaskBarToggle = new ToolStripMenuItem();
			autoTask_ToolStripMenuItem = new ToolStripMenuItem();
			toolStripMenuItem1 = new ToolStripSeparator();
			FormMenuStrip_Help = new ToolStripMenuItem();
			FormMenuStrip_Help_CheckUpdate = new ToolStripMenuItem();
			FormMenuStrip_Help_AutoCheckUpdate = new ToolStripMenuItem();
			toolStripMenuItem3 = new ToolStripSeparator();
			FormMenuStrip_Help_HelpDoc = new ToolStripMenuItem();
			GyToolStripMenuItem = new ToolStripMenuItem();
			notifyIcon_main = new NotifyIcon(components);
			notifyIcon_main_ContextMenu = new ContextMenuStrip(components);
			notifyIcon_main_ContextMenu_ShowButton = new ToolStripMenuItem();
			notifyIcon_main_ContextMenu_HiddenButton = new ToolStripMenuItem();
			自动定时任务ToolStripMenuItem = new ToolStripMenuItem();
			toolStripMenuItem2 = new ToolStripSeparator();
			帮助ToolStripMenuItem = new ToolStripMenuItem();
			nmc_CheckUpdate = new ToolStripMenuItem();
			nmc__AutoCheckUpdate = new ToolStripMenuItem();
			toolStripMenuItem4 = new ToolStripSeparator();
			帮助文档ToolStripMenuItem = new ToolStripMenuItem();
			关于ToolStripMenuItem = new ToolStripMenuItem();
			notifyIcon_main_ContextMenu_ExitButton = new ToolStripMenuItem();
			TimeInput_ContextMenu.SuspendLayout();
			FormMenuStrip.SuspendLayout();
			notifyIcon_main_ContextMenu.SuspendLayout();
			SuspendLayout();
			// 
			// ActionSelect
			// 
			ActionSelect.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			ActionSelect.DropDownStyle = ComboBoxStyle.DropDownList;
			ActionSelect.FormattingEnabled = true;
			ActionSelect.Items.AddRange(new object[] { "关机", "重启", "睡眠", "休眠", "锁定", "注销" });
			ActionSelect.Location = new Point(51, 8);
			ActionSelect.Name = "ActionSelect";
			ActionSelect.Size = new Size(212, 25);
			ActionSelect.TabIndex = 0;
			// 
			// TimePicker
			// 
			TimePicker.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			TimePicker.CustomFormat = "yyyy/MM/dd HH:mm:ss";
			TimePicker.Font = new Font("Microsoft YaHei UI", 10F);
			TimePicker.Format = DateTimePickerFormat.Custom;
			TimePicker.Location = new Point(51, 38);
			TimePicker.Name = "TimePicker";
			TimePicker.ShowUpDown = true;
			TimePicker.Size = new Size(161, 24);
			TimePicker.TabIndex = 1;
			TimePicker.Visible = false;
			TimePicker.KeyPress += TimePicker_KeyPress;
			TimePicker.KeyUp += TimePicker_KeyUp;
			// 
			// TimeInput_ContextMenu
			// 
			TimeInput_ContextMenu.Items.AddRange(new ToolStripItem[] { s10, s30, min1, min5, min10, min20, min40, h1, h2 });
			TimeInput_ContextMenu.Name = "TimePicker_ContextMenu";
			TimeInput_ContextMenu.Size = new Size(115, 202);
			// 
			// s10
			// 
			s10.Name = "s10";
			s10.Size = new Size(114, 22);
			s10.Text = "10秒";
			s10.Click += TPCM_s10_Click;
			// 
			// s30
			// 
			s30.Name = "s30";
			s30.Size = new Size(114, 22);
			s30.Text = "30秒";
			s30.Click += TPCM_s30_Click;
			// 
			// min1
			// 
			min1.Name = "min1";
			min1.Size = new Size(114, 22);
			min1.Text = "1分钟";
			min1.Click += TPCM_min1_Click;
			// 
			// min5
			// 
			min5.Name = "min5";
			min5.Size = new Size(114, 22);
			min5.Text = "5分钟";
			min5.Click += TPCM_min5_Click;
			// 
			// min10
			// 
			min10.Name = "min10";
			min10.Size = new Size(114, 22);
			min10.Text = "10分钟";
			min10.Click += TPCM_min10_Click;
			// 
			// min20
			// 
			min20.Name = "min20";
			min20.Size = new Size(114, 22);
			min20.Text = "20分钟";
			min20.Click += TPCM_min20_Click;
			// 
			// min40
			// 
			min40.Name = "min40";
			min40.Size = new Size(114, 22);
			min40.Text = "40分钟";
			min40.Click += TPCM_min40_Click;
			// 
			// h1
			// 
			h1.Name = "h1";
			h1.Size = new Size(114, 22);
			h1.Text = "1小时";
			h1.Click += TPCM_h1_Click;
			// 
			// h2
			// 
			h2.Name = "h2";
			h2.Size = new Size(114, 22);
			h2.Text = "2小时";
			h2.Click += TPCM_h2_Click;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Microsoft YaHei UI", 10F);
			label1.Location = new Point(5, 9);
			label1.Name = "label1";
			label1.Size = new Size(40, 20);
			label1.TabIndex = 21;
			label1.Text = "操作:";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Font = new Font("Microsoft YaHei UI", 10F);
			label2.Location = new Point(5, 38);
			label2.Name = "label2";
			label2.Size = new Size(40, 20);
			label2.TabIndex = 22;
			label2.Text = "时间:";
			// 
			// TimeTypeSelect
			// 
			TimeTypeSelect.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			TimeTypeSelect.DropDownStyle = ComboBoxStyle.DropDownList;
			TimeTypeSelect.FormattingEnabled = true;
			TimeTypeSelect.Items.AddRange(new object[] { "此后", "此时" });
			TimeTypeSelect.Location = new Point(215, 38);
			TimeTypeSelect.Name = "TimeTypeSelect";
			TimeTypeSelect.Size = new Size(48, 25);
			TimeTypeSelect.TabIndex = 2;
			TimeTypeSelect.SelectedIndexChanged += TimeTypeSelect_SelectedIndexChanged;
			// 
			// TimeInput
			// 
			TimeInput.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			TimeInput.CharacterCasing = CharacterCasing.Lower;
			TimeInput.ContextMenuStrip = TimeInput_ContextMenu;
			TimeInput.Location = new Point(51, 38);
			TimeInput.Name = "TimeInput";
			TimeInput.PlaceholderText = "0:1:0或1min或1分";
			TimeInput.Size = new Size(161, 23);
			TimeInput.TabIndex = 1;
			TimeInput.TextAlign = HorizontalAlignment.Center;
			TimeInput.KeyPress += TimeInput_KeyPress;
			TimeInput.KeyUp += TimeInput_KeyUp;
			TimeInput.Leave += TimeInput_Leave;
			// 
			// countdownLabel
			// 
			countdownLabel.Anchor = AnchorStyles.Bottom;
			countdownLabel.Font = new Font("Microsoft YaHei UI", 20F);
			countdownLabel.Location = new Point(4, 64);
			countdownLabel.Name = "countdownLabel";
			countdownLabel.Size = new Size(225, 35);
			countdownLabel.TabIndex = 20;
			countdownLabel.Tag = "";
			countdownLabel.Text = "00:00:00";
			countdownLabel.TextAlign = ContentAlignment.MiddleCenter;
			countdownLabel.Visible = false;
			countdownLabel.Resize += CountdownLabel_Resize;
			// 
			// StartButton
			// 
			StartButton.Anchor = AnchorStyles.Top;
			StartButton.Font = new Font("Microsoft YaHei UI", 10F);
			StartButton.Location = new Point(101, 67);
			StartButton.Name = "StartButton";
			StartButton.Size = new Size(75, 28);
			StartButton.TabIndex = 3;
			StartButton.Text = "开始";
			StartButton.UseVisualStyleBackColor = true;
			StartButton.Click += StartButton_Click;
			// 
			// StopButton
			// 
			StopButton.Anchor = AnchorStyles.Top;
			StopButton.Enabled = false;
			StopButton.Font = new Font("Microsoft YaHei UI", 10F);
			StopButton.Location = new Point(226, 67);
			StopButton.Name = "StopButton";
			StopButton.Size = new Size(49, 28);
			StopButton.TabIndex = 5;
			StopButton.Text = "停止";
			StopButton.UseVisualStyleBackColor = true;
			StopButton.Visible = false;
			StopButton.Click += StopButton_Click;
			// 
			// FormMenuStrip
			// 
			FormMenuStrip.Items.AddRange(new ToolStripItem[] { windows右键菜单ToolStripMenuItem, 软件开机自启ToolStripMenuItem, FormMenuStrip_CloseToTaskBarToggle, autoTask_ToolStripMenuItem, toolStripMenuItem1, FormMenuStrip_Help });
			FormMenuStrip.Name = "GyMenuStrip";
			FormMenuStrip.Size = new Size(185, 120);
			FormMenuStrip.Opening += FormMenuStrip_Opening;
			// 
			// windows右键菜单ToolStripMenuItem
			// 
			windows右键菜单ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { AddOrFixWindowsRightClickMenu_MenuItem, RemoveWindowsRightClickMenu_MenuItem });
			windows右键菜单ToolStripMenuItem.Name = "windows右键菜单ToolStripMenuItem";
			windows右键菜单ToolStripMenuItem.Size = new Size(184, 22);
			windows右键菜单ToolStripMenuItem.Text = "Windows右键菜单";
			// 
			// AddOrFixWindowsRightClickMenu_MenuItem
			// 
			AddOrFixWindowsRightClickMenu_MenuItem.Name = "AddOrFixWindowsRightClickMenu_MenuItem";
			AddOrFixWindowsRightClickMenu_MenuItem.Size = new Size(184, 22);
			AddOrFixWindowsRightClickMenu_MenuItem.Text = "添加或修复右键菜单";
			AddOrFixWindowsRightClickMenu_MenuItem.Click += AddOrFixWindowsRightClickMenu_MenuItem_Click;
			// 
			// RemoveWindowsRightClickMenu_MenuItem
			// 
			RemoveWindowsRightClickMenu_MenuItem.Name = "RemoveWindowsRightClickMenu_MenuItem";
			RemoveWindowsRightClickMenu_MenuItem.Size = new Size(184, 22);
			RemoveWindowsRightClickMenu_MenuItem.Text = "移除右键菜单";
			RemoveWindowsRightClickMenu_MenuItem.Click += RemoveWindowsRightClickMenu_MenuItem_Click;
			// 
			// 软件开机自启ToolStripMenuItem
			// 
			软件开机自启ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { enabledSelfStarting, disabledSelfStarting });
			软件开机自启ToolStripMenuItem.Name = "软件开机自启ToolStripMenuItem";
			软件开机自启ToolStripMenuItem.Size = new Size(184, 22);
			软件开机自启ToolStripMenuItem.Text = "软件开机自启";
			// 
			// enabledSelfStarting
			// 
			enabledSelfStarting.Name = "enabledSelfStarting";
			enabledSelfStarting.Size = new Size(184, 22);
			enabledSelfStarting.Text = "启用或修复开机自启";
			enabledSelfStarting.Click += EnabledSelfStarting_Click;
			// 
			// disabledSelfStarting
			// 
			disabledSelfStarting.Name = "disabledSelfStarting";
			disabledSelfStarting.Size = new Size(184, 22);
			disabledSelfStarting.Text = "禁用开机自启";
			disabledSelfStarting.Click += DisabledSelfStarting_Click;
			// 
			// FormMenuStrip_CloseToTaskBarToggle
			// 
			FormMenuStrip_CloseToTaskBarToggle.CheckOnClick = true;
			FormMenuStrip_CloseToTaskBarToggle.Name = "FormMenuStrip_CloseToTaskBarToggle";
			FormMenuStrip_CloseToTaskBarToggle.Size = new Size(184, 22);
			FormMenuStrip_CloseToTaskBarToggle.Text = "关闭时最小化至托盘";
			FormMenuStrip_CloseToTaskBarToggle.CheckedChanged += FormMenuStrip_CloseToTaskBarToggle_CheckedChanged;
			// 
			// autoTask_ToolStripMenuItem
			// 
			autoTask_ToolStripMenuItem.Name = "autoTask_ToolStripMenuItem";
			autoTask_ToolStripMenuItem.Size = new Size(184, 22);
			autoTask_ToolStripMenuItem.Text = "自动定时任务";
			autoTask_ToolStripMenuItem.Click += AutoTask_ToolStripMenuItem_Click;
			// 
			// toolStripMenuItem1
			// 
			toolStripMenuItem1.Name = "toolStripMenuItem1";
			toolStripMenuItem1.Size = new Size(181, 6);
			// 
			// FormMenuStrip_Help
			// 
			FormMenuStrip_Help.DropDownItems.AddRange(new ToolStripItem[] { FormMenuStrip_Help_CheckUpdate, FormMenuStrip_Help_AutoCheckUpdate, toolStripMenuItem3, FormMenuStrip_Help_HelpDoc, GyToolStripMenuItem });
			FormMenuStrip_Help.Name = "FormMenuStrip_Help";
			FormMenuStrip_Help.Size = new Size(184, 22);
			FormMenuStrip_Help.Text = "帮助";
			// 
			// FormMenuStrip_Help_CheckUpdate
			// 
			FormMenuStrip_Help_CheckUpdate.Name = "FormMenuStrip_Help_CheckUpdate";
			FormMenuStrip_Help_CheckUpdate.Size = new Size(180, 22);
			FormMenuStrip_Help_CheckUpdate.Text = "检查更新";
			FormMenuStrip_Help_CheckUpdate.Click += FormMenuStrip_Help_CheckUpdate_Click;
			// 
			// FormMenuStrip_Help_AutoCheckUpdate
			// 
			FormMenuStrip_Help_AutoCheckUpdate.Checked = true;
			FormMenuStrip_Help_AutoCheckUpdate.CheckState = CheckState.Checked;
			FormMenuStrip_Help_AutoCheckUpdate.Name = "FormMenuStrip_Help_AutoCheckUpdate";
			FormMenuStrip_Help_AutoCheckUpdate.Size = new Size(180, 22);
			FormMenuStrip_Help_AutoCheckUpdate.Text = "自动检测更新";
			FormMenuStrip_Help_AutoCheckUpdate.Click += FormMenuStrip_Help_AutoCheckUpdate_Click;
			// 
			// toolStripMenuItem3
			// 
			toolStripMenuItem3.Name = "toolStripMenuItem3";
			toolStripMenuItem3.Size = new Size(177, 6);
			// 
			// FormMenuStrip_Help_HelpDoc
			// 
			FormMenuStrip_Help_HelpDoc.Name = "FormMenuStrip_Help_HelpDoc";
			FormMenuStrip_Help_HelpDoc.Size = new Size(180, 22);
			FormMenuStrip_Help_HelpDoc.Text = "帮助文档";
			FormMenuStrip_Help_HelpDoc.Click += FormMenuStrip_Help_HelpDoc_Click;
			// 
			// GyToolStripMenuItem
			// 
			GyToolStripMenuItem.Name = "GyToolStripMenuItem";
			GyToolStripMenuItem.Size = new Size(180, 22);
			GyToolStripMenuItem.Text = "关于";
			GyToolStripMenuItem.Click += GyToolStripMenuItem_Click;
			// 
			// notifyIcon_main
			// 
			notifyIcon_main.ContextMenuStrip = notifyIcon_main_ContextMenu;
			notifyIcon_main.Icon = (Icon)resources.GetObject("notifyIcon_main.Icon");
			notifyIcon_main.Text = "定时电源";
			notifyIcon_main.Visible = true;
			notifyIcon_main.MouseClick += NotifyIcon_main_MouseClick;
			// 
			// notifyIcon_main_ContextMenu
			// 
			notifyIcon_main_ContextMenu.Items.AddRange(new ToolStripItem[] { notifyIcon_main_ContextMenu_ShowButton, notifyIcon_main_ContextMenu_HiddenButton, 自动定时任务ToolStripMenuItem, toolStripMenuItem2, 帮助ToolStripMenuItem, notifyIcon_main_ContextMenu_ExitButton });
			notifyIcon_main_ContextMenu.Name = "notifyIcon_main_ContextMenu";
			notifyIcon_main_ContextMenu.Size = new Size(181, 142);
			notifyIcon_main_ContextMenu.Opening += NotifyIcon_main_ContextMenu_Opening;
			// 
			// notifyIcon_main_ContextMenu_ShowButton
			// 
			notifyIcon_main_ContextMenu_ShowButton.Name = "notifyIcon_main_ContextMenu_ShowButton";
			notifyIcon_main_ContextMenu_ShowButton.Size = new Size(180, 22);
			notifyIcon_main_ContextMenu_ShowButton.Text = "显示主窗口";
			notifyIcon_main_ContextMenu_ShowButton.Click += NotifyIcon_main_ContextMenu_ShowButton_Click;
			// 
			// notifyIcon_main_ContextMenu_HiddenButton
			// 
			notifyIcon_main_ContextMenu_HiddenButton.Name = "notifyIcon_main_ContextMenu_HiddenButton";
			notifyIcon_main_ContextMenu_HiddenButton.Size = new Size(180, 22);
			notifyIcon_main_ContextMenu_HiddenButton.Text = "隐藏主窗口";
			notifyIcon_main_ContextMenu_HiddenButton.Click += NotifyIcon_main_ContextMenu_HiddenButton_Click;
			// 
			// 自动定时任务ToolStripMenuItem
			// 
			自动定时任务ToolStripMenuItem.Name = "自动定时任务ToolStripMenuItem";
			自动定时任务ToolStripMenuItem.Size = new Size(180, 22);
			自动定时任务ToolStripMenuItem.Text = "自动定时任务";
			自动定时任务ToolStripMenuItem.Click += AutoTask_ToolStripMenuItem_Click;
			// 
			// toolStripMenuItem2
			// 
			toolStripMenuItem2.Name = "toolStripMenuItem2";
			toolStripMenuItem2.Size = new Size(177, 6);
			// 
			// 帮助ToolStripMenuItem
			// 
			帮助ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { nmc_CheckUpdate, nmc__AutoCheckUpdate, toolStripMenuItem4, 帮助文档ToolStripMenuItem, 关于ToolStripMenuItem });
			帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
			帮助ToolStripMenuItem.Size = new Size(180, 22);
			帮助ToolStripMenuItem.Text = "帮助";
			// 
			// nmc_CheckUpdate
			// 
			nmc_CheckUpdate.Name = "nmc_CheckUpdate";
			nmc_CheckUpdate.Size = new Size(180, 22);
			nmc_CheckUpdate.Text = "检查更新";
			nmc_CheckUpdate.Click += FormMenuStrip_Help_CheckUpdate_Click;
			// 
			// nmc__AutoCheckUpdate
			// 
			nmc__AutoCheckUpdate.Checked = true;
			nmc__AutoCheckUpdate.CheckState = CheckState.Checked;
			nmc__AutoCheckUpdate.Name = "nmc__AutoCheckUpdate";
			nmc__AutoCheckUpdate.Size = new Size(180, 22);
			nmc__AutoCheckUpdate.Text = "自动检查更新";
			nmc__AutoCheckUpdate.Click += FormMenuStrip_Help_AutoCheckUpdate_Click;
			// 
			// toolStripMenuItem4
			// 
			toolStripMenuItem4.Name = "toolStripMenuItem4";
			toolStripMenuItem4.Size = new Size(177, 6);
			// 
			// 帮助文档ToolStripMenuItem
			// 
			帮助文档ToolStripMenuItem.Name = "帮助文档ToolStripMenuItem";
			帮助文档ToolStripMenuItem.Size = new Size(180, 22);
			帮助文档ToolStripMenuItem.Text = "帮助文档";
			帮助文档ToolStripMenuItem.Click += FormMenuStrip_Help_HelpDoc_Click;
			// 
			// 关于ToolStripMenuItem
			// 
			关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
			关于ToolStripMenuItem.Size = new Size(180, 22);
			关于ToolStripMenuItem.Text = "关于";
			关于ToolStripMenuItem.Click += GyToolStripMenuItem_Click;
			// 
			// notifyIcon_main_ContextMenu_ExitButton
			// 
			notifyIcon_main_ContextMenu_ExitButton.Name = "notifyIcon_main_ContextMenu_ExitButton";
			notifyIcon_main_ContextMenu_ExitButton.Size = new Size(180, 22);
			notifyIcon_main_ContextMenu_ExitButton.Text = "退出";
			notifyIcon_main_ContextMenu_ExitButton.Click += NotifyIcon_main_ContextMenu_ExitButton_Click;
			// 
			// Main
			// 
			AutoScaleDimensions = new SizeF(7F, 17F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(276, 102);
			ContextMenuStrip = FormMenuStrip;
			Controls.Add(StopButton);
			Controls.Add(countdownLabel);
			Controls.Add(TimeInput);
			Controls.Add(TimeTypeSelect);
			Controls.Add(label2);
			Controls.Add(label1);
			Controls.Add(TimePicker);
			Controls.Add(ActionSelect);
			Controls.Add(StartButton);
			FormBorderStyle = FormBorderStyle.FixedSingle;
			Icon = (Icon)resources.GetObject("$this.Icon");
			MaximizeBox = false;
			MinimumSize = new Size(292, 0);
			Name = "Main";
			Opacity = 0D;
			Text = "定时电源";
			FormClosing += Main_FormClosing;
			FormClosed += Main_FormClosed;
			Load += Main_Load;
			Shown += Main_Shown;
			TimeInput_ContextMenu.ResumeLayout(false);
			FormMenuStrip.ResumeLayout(false);
			notifyIcon_main_ContextMenu.ResumeLayout(false);
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private ComboBox ActionSelect;
        private DateTimePicker TimePicker;
        private Label label1;
        private Label label2;
        private ComboBox TimeTypeSelect;
        private ContextMenuStrip TimeInput_ContextMenu;
        private ToolStripMenuItem s10;
        private ToolStripMenuItem s30;
        private ToolStripMenuItem min1;
        private ToolStripMenuItem min5;
        private ToolStripMenuItem min10;
        private ToolStripMenuItem min20;
        private ToolStripMenuItem min40;
        private ToolStripMenuItem h1;
        private ToolStripMenuItem h2;
        private TextBox TimeInput;
        private Label countdownLabel;
        private Button StartButton;
        private Button StopButton;
        private ContextMenuStrip FormMenuStrip;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem windows右键菜单ToolStripMenuItem;
        private ToolStripMenuItem AddOrFixWindowsRightClickMenu_MenuItem;
        private ToolStripMenuItem RemoveWindowsRightClickMenu_MenuItem;
        private NotifyIcon notifyIcon_main;
        private ToolStripMenuItem autoTask_ToolStripMenuItem;
        private ContextMenuStrip notifyIcon_main_ContextMenu;
        private ToolStripMenuItem notifyIcon_main_ContextMenu_ShowButton;
        private ToolStripMenuItem notifyIcon_main_ContextMenu_HiddenButton;
        private ToolStripSeparator toolStripMenuItem2;
        private ToolStripMenuItem notifyIcon_main_ContextMenu_ExitButton;
        private ToolStripMenuItem 软件开机自启ToolStripMenuItem;
        private ToolStripMenuItem enabledSelfStarting;
        private ToolStripMenuItem disabledSelfStarting;
		private ToolStripMenuItem FormMenuStrip_Help;
		private ToolStripMenuItem FormMenuStrip_Help_HelpDoc;
		private ToolStripMenuItem GyToolStripMenuItem;
		private ToolStripMenuItem 帮助ToolStripMenuItem;
		private ToolStripMenuItem 帮助文档ToolStripMenuItem;
		private ToolStripMenuItem 关于ToolStripMenuItem;
		private ToolStripMenuItem 自动定时任务ToolStripMenuItem;
		private ToolStripMenuItem FormMenuStrip_CloseToTaskBarToggle;
		private ToolStripMenuItem FormMenuStrip_Help_CheckUpdate;
		private ToolStripMenuItem FormMenuStrip_Help_AutoCheckUpdate;
		private ToolStripSeparator toolStripMenuItem3;
		private ToolStripMenuItem nmc_CheckUpdate;
		private ToolStripMenuItem nmc__AutoCheckUpdate;
		private ToolStripSeparator toolStripMenuItem4;
	}
}
