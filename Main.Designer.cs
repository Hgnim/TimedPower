namespace TimedPower
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
            autoTask_ToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripSeparator();
            GyToolStripMenuItem = new ToolStripMenuItem();
            notifyIcon_main = new NotifyIcon(components);
            notifyIcon_main_ContextMenu = new ContextMenuStrip(components);
            notifyIcon_main_ContextMenu_ShowButton = new ToolStripMenuItem();
            notifyIcon_main_ContextMenu_HiddenButton = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripSeparator();
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
            FormMenuStrip.Items.AddRange(new ToolStripItem[] { windows右键菜单ToolStripMenuItem, 软件开机自启ToolStripMenuItem, autoTask_ToolStripMenuItem, toolStripMenuItem1, GyToolStripMenuItem });
            FormMenuStrip.Name = "GyMenuStrip";
            FormMenuStrip.Size = new Size(178, 98);
            // 
            // windows右键菜单ToolStripMenuItem
            // 
            windows右键菜单ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { AddOrFixWindowsRightClickMenu_MenuItem, RemoveWindowsRightClickMenu_MenuItem });
            windows右键菜单ToolStripMenuItem.Name = "windows右键菜单ToolStripMenuItem";
            windows右键菜单ToolStripMenuItem.Size = new Size(177, 22);
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
            软件开机自启ToolStripMenuItem.Size = new Size(177, 22);
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
            // autoTask_ToolStripMenuItem
            // 
            autoTask_ToolStripMenuItem.Name = "autoTask_ToolStripMenuItem";
            autoTask_ToolStripMenuItem.Size = new Size(177, 22);
            autoTask_ToolStripMenuItem.Text = "自动定时任务";
            autoTask_ToolStripMenuItem.Click += AutoTask_ToolStripMenuItem_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(174, 6);
            // 
            // GyToolStripMenuItem
            // 
            GyToolStripMenuItem.Name = "GyToolStripMenuItem";
            GyToolStripMenuItem.Size = new Size(177, 22);
            GyToolStripMenuItem.Text = "关于";
            GyToolStripMenuItem.Click += GyToolStripMenuItem_Click;
            // 
            // notifyIcon_main
            // 
            notifyIcon_main.ContextMenuStrip = notifyIcon_main_ContextMenu;
            notifyIcon_main.Icon = (Icon)resources.GetObject("notifyIcon_main.Icon");
            notifyIcon_main.Text = "定时电源";
            notifyIcon_main.Visible = true;
            notifyIcon_main.DoubleClick += NotifyIcon_main_DoubleClick;
            // 
            // notifyIcon_main_ContextMenu
            // 
            notifyIcon_main_ContextMenu.Items.AddRange(new ToolStripItem[] { notifyIcon_main_ContextMenu_ShowButton, notifyIcon_main_ContextMenu_HiddenButton, toolStripMenuItem2, notifyIcon_main_ContextMenu_ExitButton });
            notifyIcon_main_ContextMenu.Name = "notifyIcon_main_ContextMenu";
            notifyIcon_main_ContextMenu.Size = new Size(101, 76);
            notifyIcon_main_ContextMenu.Opening += NotifyIcon_main_ContextMenu_Opening;
            // 
            // notifyIcon_main_ContextMenu_ShowButton
            // 
            notifyIcon_main_ContextMenu_ShowButton.Name = "notifyIcon_main_ContextMenu_ShowButton";
            notifyIcon_main_ContextMenu_ShowButton.Size = new Size(100, 22);
            notifyIcon_main_ContextMenu_ShowButton.Text = "显示";
            notifyIcon_main_ContextMenu_ShowButton.Click += NotifyIcon_main_ContextMenu_ShowButton_Click;
            // 
            // notifyIcon_main_ContextMenu_HiddenButton
            // 
            notifyIcon_main_ContextMenu_HiddenButton.Name = "notifyIcon_main_ContextMenu_HiddenButton";
            notifyIcon_main_ContextMenu_HiddenButton.Size = new Size(100, 22);
            notifyIcon_main_ContextMenu_HiddenButton.Text = "隐藏";
            notifyIcon_main_ContextMenu_HiddenButton.Click += NotifyIcon_main_ContextMenu_HiddenButton_Click;
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(97, 6);
            // 
            // notifyIcon_main_ContextMenu_ExitButton
            // 
            notifyIcon_main_ContextMenu_ExitButton.Name = "notifyIcon_main_ContextMenu_ExitButton";
            notifyIcon_main_ContextMenu_ExitButton.Size = new Size(100, 22);
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
        private ToolStripMenuItem GyToolStripMenuItem;
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
    }
}
