namespace TimedPower
{
    partial class Main
    {
		/// <summary>
		/// 对应控件的选项枚举，注意，此处枚举排序必须和控件中的项目排序一致
		/// </summary>
		internal enum ActionSelectItems {
			shutdown,
			reboot,
			sleep,
			hibernate,
			userlock,
			useroff
		}
		/// <summary>
		/// 对应控件的选项枚举，注意，此处枚举排序必须和控件中的项目排序一致
		/// </summary>
		internal enum TimeTypeSelectItems {
			after,
			ontime
		}


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
		private void InitializeComponent() {
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
			ActionSelect = new ReaLTaiizor.Controls.PoisonComboBox();
			TimePicker = new ReaLTaiizor.Controls.PoisonDateTime();
			TimeInput_ContextMenu = new ReaLTaiizor.Controls.PoisonContextMenuStrip(components);
			s10 = new ToolStripMenuItem();
			s30 = new ToolStripMenuItem();
			min1 = new ToolStripMenuItem();
			min5 = new ToolStripMenuItem();
			min10 = new ToolStripMenuItem();
			min20 = new ToolStripMenuItem();
			min40 = new ToolStripMenuItem();
			h1 = new ToolStripMenuItem();
			h2 = new ToolStripMenuItem();
			label1 = new ReaLTaiizor.Controls.SmallLabel();
			label2 = new ReaLTaiizor.Controls.SmallLabel();
			TimeTypeSelect = new ReaLTaiizor.Controls.PoisonComboBox();
			TimeInput = new ControlOverride.PoisonTextBox_OR();
			countdownLabel = new ReaLTaiizor.Controls.BigLabel();
			StartButton = new ReaLTaiizor.Controls.PoisonButton();
			StopButton = new ReaLTaiizor.Controls.PoisonButton();
			FormMenuStrip = new ReaLTaiizor.Controls.PoisonContextMenuStrip(components);
			FormMenuStrip_NewTaskFile = new ToolStripMenuItem();
			toolStripMenuItem5 = new ToolStripSeparator();
			FormMenuStrip_Setting = new ToolStripMenuItem();
			autoTask_ToolStripMenuItem = new ToolStripMenuItem();
			toolStripMenuItem1 = new ToolStripSeparator();
			FormMenuStrip_Help = new ToolStripMenuItem();
			FormMenuStrip_Help_CheckUpdate = new ToolStripMenuItem();
			FormMenuStrip_Help_AutoCheckUpdate = new ToolStripMenuItem();
			toolStripMenuItem3 = new ToolStripSeparator();
			FormMenuStrip_Help_HelpDoc = new ToolStripMenuItem();
			GyToolStripMenuItem = new ToolStripMenuItem();
			notifyIcon_main = new NotifyIcon(components);
			notifyIcon_main_ContextMenu = new ReaLTaiizor.Controls.PoisonContextMenuStrip(components);
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
			poisonStyleManager = new ReaLTaiizor.Manager.PoisonStyleManager(components);
			TimeInput_ContextMenu.SuspendLayout();
			FormMenuStrip.SuspendLayout();
			notifyIcon_main_ContextMenu.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)poisonStyleManager).BeginInit();
			SuspendLayout();
			// 
			// ActionSelect
			// 
			resources.ApplyResources(ActionSelect, "ActionSelect");
			ActionSelect.FormattingEnabled = true;
			ActionSelect.Items.AddRange(new object[] { resources.GetString("ActionSelect.Items"), resources.GetString("ActionSelect.Items1"), resources.GetString("ActionSelect.Items2"), resources.GetString("ActionSelect.Items3"), resources.GetString("ActionSelect.Items4"), resources.GetString("ActionSelect.Items5") });
			ActionSelect.Name = "ActionSelect";
			ActionSelect.UseSelectable = true;
			// 
			// TimePicker
			// 
			resources.ApplyResources(TimePicker, "TimePicker");
			TimePicker.FontSize = ReaLTaiizor.Extension.Poison.PoisonDateTimeSize.Tall;
			TimePicker.Format = DateTimePickerFormat.Custom;
			TimePicker.Name = "TimePicker";
			TimePicker.KeyPress += TimePicker_KeyPress;
			TimePicker.KeyUp += TimePicker_KeyUp;
			// 
			// TimeInput_ContextMenu
			// 
			TimeInput_ContextMenu.Items.AddRange(new ToolStripItem[] { s10, s30, min1, min5, min10, min20, min40, h1, h2 });
			TimeInput_ContextMenu.Name = "TimePicker_ContextMenu";
			resources.ApplyResources(TimeInput_ContextMenu, "TimeInput_ContextMenu");
			// 
			// s10
			// 
			resources.ApplyResources(s10, "s10");
			s10.Name = "s10";
			s10.Click += TPCM_s10_Click;
			// 
			// s30
			// 
			resources.ApplyResources(s30, "s30");
			s30.Name = "s30";
			s30.Click += TPCM_s30_Click;
			// 
			// min1
			// 
			resources.ApplyResources(min1, "min1");
			min1.Name = "min1";
			min1.Click += TPCM_min1_Click;
			// 
			// min5
			// 
			resources.ApplyResources(min5, "min5");
			min5.Name = "min5";
			min5.Click += TPCM_min5_Click;
			// 
			// min10
			// 
			resources.ApplyResources(min10, "min10");
			min10.Name = "min10";
			min10.Click += TPCM_min10_Click;
			// 
			// min20
			// 
			resources.ApplyResources(min20, "min20");
			min20.Name = "min20";
			min20.Click += TPCM_min20_Click;
			// 
			// min40
			// 
			resources.ApplyResources(min40, "min40");
			min40.Name = "min40";
			min40.Click += TPCM_min40_Click;
			// 
			// h1
			// 
			resources.ApplyResources(h1, "h1");
			h1.Name = "h1";
			h1.Click += TPCM_h1_Click;
			// 
			// h2
			// 
			resources.ApplyResources(h2, "h2");
			h2.Name = "h2";
			h2.Click += TPCM_h2_Click;
			// 
			// label1
			// 
			label1.BackColor = Color.Transparent;
			resources.ApplyResources(label1, "label1");
			label1.ForeColor = Color.FromArgb(142, 142, 142);
			label1.Name = "label1";
			// 
			// label2
			// 
			label2.BackColor = Color.Transparent;
			resources.ApplyResources(label2, "label2");
			label2.ForeColor = Color.FromArgb(142, 142, 142);
			label2.Name = "label2";
			// 
			// TimeTypeSelect
			// 
			resources.ApplyResources(TimeTypeSelect, "TimeTypeSelect");
			TimeTypeSelect.FormattingEnabled = true;
			TimeTypeSelect.Items.AddRange(new object[] { resources.GetString("TimeTypeSelect.Items"), resources.GetString("TimeTypeSelect.Items1") });
			TimeTypeSelect.Name = "TimeTypeSelect";
			TimeTypeSelect.UseSelectable = true;
			TimeTypeSelect.SelectedIndexChanged += TimeTypeSelect_SelectedIndexChanged;
			// 
			// TimeInput
			// 
			resources.ApplyResources(TimeInput, "TimeInput");
			TimeInput.CharacterCasing = CharacterCasing.Lower;
			TimeInput.ContextMenuStrip = TimeInput_ContextMenu;
			// 
			// 
			// 
			TimeInput.CustomButton.Image = (Image)resources.GetObject("resource.Image");
			TimeInput.CustomButton.ImeMode = (ImeMode)resources.GetObject("resource.ImeMode");
			TimeInput.CustomButton.Location = (Point)resources.GetObject("resource.Location");
			TimeInput.CustomButton.Name = "";
			TimeInput.CustomButton.Size = (Size)resources.GetObject("resource.Size");
			TimeInput.CustomButton.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Blue;
			TimeInput.CustomButton.TabIndex = (int)resources.GetObject("resource.TabIndex");
			TimeInput.CustomButton.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Light;
			TimeInput.CustomButton.UseSelectable = true;
			TimeInput.CustomButton.Visible = (bool)resources.GetObject("resource.Visible");
			TimeInput.FontSize = ReaLTaiizor.Extension.Poison.PoisonTextBoxSize.Tall;
			TimeInput.MaxLength = 32767;
			TimeInput.Name = "TimeInput";
			TimeInput.PasswordChar = '\0';
			TimeInput.ScrollBars = ScrollBars.None;
			TimeInput.SelectedText = "";
			TimeInput.SelectionLength = 0;
			TimeInput.SelectionStart = 0;
			TimeInput.ShortcutsEnabled = true;
			TimeInput.ShowClearButton = true;
			TimeInput.UseSelectable = true;
			TimeInput.WaterMarkColor = Color.Gray;
			TimeInput.WaterMarkFont = new Font("Microsoft YaHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
			TimeInput.KeyPress += TimeInput_KeyPress;
			TimeInput.KeyUp += TimeInput_KeyUp;
			TimeInput.Leave += TimeInput_Leave;
			// 
			// countdownLabel
			// 
			resources.ApplyResources(countdownLabel, "countdownLabel");
			countdownLabel.BackColor = Color.Transparent;
			countdownLabel.ForeColor = Color.Black;
			countdownLabel.Name = "countdownLabel";
			countdownLabel.Tag = "";
			countdownLabel.Resize += CountdownLabel_Resize;
			// 
			// StartButton
			// 
			resources.ApplyResources(StartButton, "StartButton");
			StartButton.FontSize = ReaLTaiizor.Extension.Poison.PoisonButtonSize.Medium;
			StartButton.FontWeight = ReaLTaiizor.Extension.Poison.PoisonButtonWeight.Regular;
			StartButton.Name = "StartButton";
			StartButton.UseSelectable = true;
			StartButton.UseVisualStyleBackColor = true;
			StartButton.Click += StartButton_Click;
			// 
			// StopButton
			// 
			resources.ApplyResources(StopButton, "StopButton");
			StopButton.FontSize = ReaLTaiizor.Extension.Poison.PoisonButtonSize.Medium;
			StopButton.FontWeight = ReaLTaiizor.Extension.Poison.PoisonButtonWeight.Regular;
			StopButton.Name = "StopButton";
			StopButton.UseSelectable = true;
			StopButton.UseVisualStyleBackColor = true;
			StopButton.Click += StopButton_Click;
			// 
			// FormMenuStrip
			// 
			FormMenuStrip.Items.AddRange(new ToolStripItem[] { FormMenuStrip_NewTaskFile, toolStripMenuItem5, FormMenuStrip_Setting, autoTask_ToolStripMenuItem, toolStripMenuItem1, FormMenuStrip_Help });
			FormMenuStrip.Name = "GyMenuStrip";
			resources.ApplyResources(FormMenuStrip, "FormMenuStrip");
			FormMenuStrip.Opening += FormMenuStrip_Opening;
			// 
			// FormMenuStrip_NewTaskFile
			// 
			resources.ApplyResources(FormMenuStrip_NewTaskFile, "FormMenuStrip_NewTaskFile");
			FormMenuStrip_NewTaskFile.Name = "FormMenuStrip_NewTaskFile";
			FormMenuStrip_NewTaskFile.Click += FormMenuStrip_NewTaskFile_Click;
			// 
			// toolStripMenuItem5
			// 
			toolStripMenuItem5.Name = "toolStripMenuItem5";
			resources.ApplyResources(toolStripMenuItem5, "toolStripMenuItem5");
			// 
			// FormMenuStrip_Setting
			// 
			resources.ApplyResources(FormMenuStrip_Setting, "FormMenuStrip_Setting");
			FormMenuStrip_Setting.Name = "FormMenuStrip_Setting";
			FormMenuStrip_Setting.Click += FormMenuStrip_Setting_Click;
			// 
			// autoTask_ToolStripMenuItem
			// 
			resources.ApplyResources(autoTask_ToolStripMenuItem, "autoTask_ToolStripMenuItem");
			autoTask_ToolStripMenuItem.Name = "autoTask_ToolStripMenuItem";
			autoTask_ToolStripMenuItem.Click += AutoTask_ToolStripMenuItem_Click;
			// 
			// toolStripMenuItem1
			// 
			toolStripMenuItem1.Name = "toolStripMenuItem1";
			resources.ApplyResources(toolStripMenuItem1, "toolStripMenuItem1");
			// 
			// FormMenuStrip_Help
			// 
			resources.ApplyResources(FormMenuStrip_Help, "FormMenuStrip_Help");
			FormMenuStrip_Help.DropDownItems.AddRange(new ToolStripItem[] { FormMenuStrip_Help_CheckUpdate, FormMenuStrip_Help_AutoCheckUpdate, toolStripMenuItem3, FormMenuStrip_Help_HelpDoc, GyToolStripMenuItem });
			FormMenuStrip_Help.Name = "FormMenuStrip_Help";
			// 
			// FormMenuStrip_Help_CheckUpdate
			// 
			resources.ApplyResources(FormMenuStrip_Help_CheckUpdate, "FormMenuStrip_Help_CheckUpdate");
			FormMenuStrip_Help_CheckUpdate.Name = "FormMenuStrip_Help_CheckUpdate";
			FormMenuStrip_Help_CheckUpdate.Click += FormMenuStrip_Help_CheckUpdate_Click;
			// 
			// FormMenuStrip_Help_AutoCheckUpdate
			// 
			resources.ApplyResources(FormMenuStrip_Help_AutoCheckUpdate, "FormMenuStrip_Help_AutoCheckUpdate");
			FormMenuStrip_Help_AutoCheckUpdate.Checked = true;
			FormMenuStrip_Help_AutoCheckUpdate.CheckState = CheckState.Checked;
			FormMenuStrip_Help_AutoCheckUpdate.Name = "FormMenuStrip_Help_AutoCheckUpdate";
			FormMenuStrip_Help_AutoCheckUpdate.Click += FormMenuStrip_Help_AutoCheckUpdate_Click;
			// 
			// toolStripMenuItem3
			// 
			toolStripMenuItem3.Name = "toolStripMenuItem3";
			resources.ApplyResources(toolStripMenuItem3, "toolStripMenuItem3");
			// 
			// FormMenuStrip_Help_HelpDoc
			// 
			resources.ApplyResources(FormMenuStrip_Help_HelpDoc, "FormMenuStrip_Help_HelpDoc");
			FormMenuStrip_Help_HelpDoc.Name = "FormMenuStrip_Help_HelpDoc";
			FormMenuStrip_Help_HelpDoc.Click += FormMenuStrip_Help_HelpDoc_Click;
			// 
			// GyToolStripMenuItem
			// 
			resources.ApplyResources(GyToolStripMenuItem, "GyToolStripMenuItem");
			GyToolStripMenuItem.Name = "GyToolStripMenuItem";
			GyToolStripMenuItem.Click += GyToolStripMenuItem_Click;
			// 
			// notifyIcon_main
			// 
			notifyIcon_main.ContextMenuStrip = notifyIcon_main_ContextMenu;
			resources.ApplyResources(notifyIcon_main, "notifyIcon_main");
			notifyIcon_main.MouseClick += NotifyIcon_main_MouseClick;
			// 
			// notifyIcon_main_ContextMenu
			// 
			notifyIcon_main_ContextMenu.Items.AddRange(new ToolStripItem[] { notifyIcon_main_ContextMenu_ShowButton, notifyIcon_main_ContextMenu_HiddenButton, 自动定时任务ToolStripMenuItem, toolStripMenuItem2, 帮助ToolStripMenuItem, notifyIcon_main_ContextMenu_ExitButton });
			notifyIcon_main_ContextMenu.Name = "notifyIcon_main_ContextMenu";
			resources.ApplyResources(notifyIcon_main_ContextMenu, "notifyIcon_main_ContextMenu");
			notifyIcon_main_ContextMenu.Opening += NotifyIcon_main_ContextMenu_Opening;
			// 
			// notifyIcon_main_ContextMenu_ShowButton
			// 
			resources.ApplyResources(notifyIcon_main_ContextMenu_ShowButton, "notifyIcon_main_ContextMenu_ShowButton");
			notifyIcon_main_ContextMenu_ShowButton.Name = "notifyIcon_main_ContextMenu_ShowButton";
			notifyIcon_main_ContextMenu_ShowButton.Click += NotifyIcon_main_ContextMenu_ShowButton_Click;
			// 
			// notifyIcon_main_ContextMenu_HiddenButton
			// 
			resources.ApplyResources(notifyIcon_main_ContextMenu_HiddenButton, "notifyIcon_main_ContextMenu_HiddenButton");
			notifyIcon_main_ContextMenu_HiddenButton.Name = "notifyIcon_main_ContextMenu_HiddenButton";
			notifyIcon_main_ContextMenu_HiddenButton.Click += NotifyIcon_main_ContextMenu_HiddenButton_Click;
			// 
			// 自动定时任务ToolStripMenuItem
			// 
			resources.ApplyResources(自动定时任务ToolStripMenuItem, "自动定时任务ToolStripMenuItem");
			自动定时任务ToolStripMenuItem.Name = "自动定时任务ToolStripMenuItem";
			自动定时任务ToolStripMenuItem.Click += AutoTask_ToolStripMenuItem_Click;
			// 
			// toolStripMenuItem2
			// 
			toolStripMenuItem2.Name = "toolStripMenuItem2";
			resources.ApplyResources(toolStripMenuItem2, "toolStripMenuItem2");
			// 
			// 帮助ToolStripMenuItem
			// 
			resources.ApplyResources(帮助ToolStripMenuItem, "帮助ToolStripMenuItem");
			帮助ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { nmc_CheckUpdate, nmc__AutoCheckUpdate, toolStripMenuItem4, 帮助文档ToolStripMenuItem, 关于ToolStripMenuItem });
			帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
			// 
			// nmc_CheckUpdate
			// 
			resources.ApplyResources(nmc_CheckUpdate, "nmc_CheckUpdate");
			nmc_CheckUpdate.Name = "nmc_CheckUpdate";
			nmc_CheckUpdate.Click += FormMenuStrip_Help_CheckUpdate_Click;
			// 
			// nmc__AutoCheckUpdate
			// 
			resources.ApplyResources(nmc__AutoCheckUpdate, "nmc__AutoCheckUpdate");
			nmc__AutoCheckUpdate.Checked = true;
			nmc__AutoCheckUpdate.CheckState = CheckState.Checked;
			nmc__AutoCheckUpdate.Name = "nmc__AutoCheckUpdate";
			nmc__AutoCheckUpdate.Click += FormMenuStrip_Help_AutoCheckUpdate_Click;
			// 
			// toolStripMenuItem4
			// 
			toolStripMenuItem4.Name = "toolStripMenuItem4";
			resources.ApplyResources(toolStripMenuItem4, "toolStripMenuItem4");
			// 
			// 帮助文档ToolStripMenuItem
			// 
			resources.ApplyResources(帮助文档ToolStripMenuItem, "帮助文档ToolStripMenuItem");
			帮助文档ToolStripMenuItem.Name = "帮助文档ToolStripMenuItem";
			帮助文档ToolStripMenuItem.Click += FormMenuStrip_Help_HelpDoc_Click;
			// 
			// 关于ToolStripMenuItem
			// 
			resources.ApplyResources(关于ToolStripMenuItem, "关于ToolStripMenuItem");
			关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
			关于ToolStripMenuItem.Click += GyToolStripMenuItem_Click;
			// 
			// notifyIcon_main_ContextMenu_ExitButton
			// 
			resources.ApplyResources(notifyIcon_main_ContextMenu_ExitButton, "notifyIcon_main_ContextMenu_ExitButton");
			notifyIcon_main_ContextMenu_ExitButton.Name = "notifyIcon_main_ContextMenu_ExitButton";
			notifyIcon_main_ContextMenu_ExitButton.Click += NotifyIcon_main_ContextMenu_ExitButton_Click;
			// 
			// poisonStyleManager
			// 
			poisonStyleManager.Owner = this;
			// 
			// Main
			// 
			resources.ApplyResources(this, "$this");
			AutoScaleMode = AutoScaleMode.Font;
			BackImage = Resources.langs.language.image_logo_png_32x;
			BackImagePadding = new Padding(3, 5, 0, 0);
			BackMaxSize = 24;
			ContextMenuStrip = FormMenuStrip;
			Controls.Add(StartButton);
			Controls.Add(StopButton);
			Controls.Add(countdownLabel);
			Controls.Add(TimeInput);
			Controls.Add(TimeTypeSelect);
			Controls.Add(TimePicker);
			Controls.Add(ActionSelect);
			Controls.Add(label2);
			Controls.Add(label1);
			DisplayHeader = false;
			MaximizeBox = false;
			Name = "Main";
			Resizable = false;
			ShadowType = ReaLTaiizor.Enum.Poison.FormShadowType.SystemShadow;
			StyleManager = poisonStyleManager;
			FormClosing += Main_FormClosing;
			FormClosed += Main_FormClosed;
			Load += Main_Load;
			Shown += Main_Shown;
			TimeInput_ContextMenu.ResumeLayout(false);
			FormMenuStrip.ResumeLayout(false);
			notifyIcon_main_ContextMenu.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)poisonStyleManager).EndInit();
			ResumeLayout(false);
		}

		#endregion

		private ReaLTaiizor.Controls.PoisonComboBox ActionSelect;
        private ReaLTaiizor.Controls.PoisonDateTime TimePicker;
        private ReaLTaiizor.Controls.SmallLabel label1;
        private ReaLTaiizor.Controls.SmallLabel label2;
        private ReaLTaiizor.Controls.PoisonComboBox TimeTypeSelect;
        private ReaLTaiizor.Controls.PoisonContextMenuStrip TimeInput_ContextMenu;
        private ToolStripMenuItem s10;
        private ToolStripMenuItem s30;
        private ToolStripMenuItem min1;
        private ToolStripMenuItem min5;
        private ToolStripMenuItem min10;
        private ToolStripMenuItem min20;
        private ToolStripMenuItem min40;
        private ToolStripMenuItem h1;
        private ToolStripMenuItem h2;
        private ControlOverride.PoisonTextBox_OR TimeInput;
        private ReaLTaiizor.Controls.BigLabel countdownLabel;
        private ReaLTaiizor.Controls.PoisonButton StartButton;
        private ReaLTaiizor.Controls.PoisonButton StopButton;
        private ReaLTaiizor.Controls.PoisonContextMenuStrip FormMenuStrip;
        private NotifyIcon notifyIcon_main;
        private ToolStripMenuItem autoTask_ToolStripMenuItem;
        private ReaLTaiizor.Controls.PoisonContextMenuStrip notifyIcon_main_ContextMenu;
        private ToolStripMenuItem notifyIcon_main_ContextMenu_ShowButton;
        private ToolStripMenuItem notifyIcon_main_ContextMenu_HiddenButton;
        private ToolStripSeparator toolStripMenuItem2;
        private ToolStripMenuItem notifyIcon_main_ContextMenu_ExitButton;
		private ToolStripMenuItem FormMenuStrip_Help;
		private ToolStripMenuItem FormMenuStrip_Help_HelpDoc;
		private ToolStripMenuItem GyToolStripMenuItem;
		private ToolStripMenuItem 帮助ToolStripMenuItem;
		private ToolStripMenuItem 帮助文档ToolStripMenuItem;
		private ToolStripMenuItem 关于ToolStripMenuItem;
		private ToolStripMenuItem 自动定时任务ToolStripMenuItem;
		private ToolStripMenuItem FormMenuStrip_Help_CheckUpdate;
		private ToolStripMenuItem FormMenuStrip_Help_AutoCheckUpdate;
		private ToolStripSeparator toolStripMenuItem3;
		private ToolStripMenuItem nmc_CheckUpdate;
		private ToolStripMenuItem nmc__AutoCheckUpdate;
		private ToolStripSeparator toolStripMenuItem4;
		private ToolStripSeparator toolStripMenuItem5;
		private ToolStripMenuItem FormMenuStrip_NewTaskFile;
		private ToolStripMenuItem FormMenuStrip_Setting;
		private ToolStripSeparator toolStripMenuItem1;
		private ReaLTaiizor.Manager.PoisonStyleManager poisonStyleManager;
	}
}
