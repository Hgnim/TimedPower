namespace TimedPower
{
    partial class AutoTaskForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AutoTaskForm));
            taskList = new ListBox();
            createButton = new Button();
            buttonPanel = new Panel();
            saveButton = new Button();
            unsaveButton = new Button();
            deleteButton = new Button();
            infoPanel = new Panel();
            label4 = new Label();
            timeTypeSelect = new ComboBox();
            label3 = new Label();
            TimePicker = new DateTimePicker();
            label2 = new Label();
            ActionSelect = new ComboBox();
            taskName_TextBox = new TextBox();
            label1 = new Label();
            enableCheck = new CheckBox();
            buttonPanel.SuspendLayout();
            infoPanel.SuspendLayout();
            SuspendLayout();
            // 
            // taskList
            // 
            taskList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            taskList.BackColor = SystemColors.ButtonFace;
            taskList.DrawMode = DrawMode.OwnerDrawVariable;
            taskList.Font = new Font("Microsoft YaHei UI", 10F);
            taskList.FormattingEnabled = true;
            taskList.ItemHeight = 19;
            taskList.Location = new Point(3, 3);
            taskList.Name = "taskList";
            taskList.Size = new Size(312, 61);
            taskList.TabIndex = 0;
            taskList.DrawItem += TaskList_DrawItem;
            taskList.SelectedIndexChanged += TaskList_SelectedIndexChanged;
            // 
            // createButton
            // 
            createButton.Anchor = AnchorStyles.Left;
            createButton.Font = new Font("Microsoft YaHei UI", 10F);
            createButton.Location = new Point(0, 0);
            createButton.Name = "createButton";
            createButton.Size = new Size(74, 32);
            createButton.TabIndex = 1;
            createButton.Text = "新建任务";
            createButton.UseVisualStyleBackColor = true;
            createButton.Click += CreateButton_Click;
            // 
            // buttonPanel
            // 
            buttonPanel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            buttonPanel.Controls.Add(saveButton);
            buttonPanel.Controls.Add(unsaveButton);
            buttonPanel.Controls.Add(deleteButton);
            buttonPanel.Controls.Add(createButton);
            buttonPanel.Location = new Point(3, 196);
            buttonPanel.Name = "buttonPanel";
            buttonPanel.Size = new Size(312, 33);
            buttonPanel.TabIndex = 2;
            // 
            // saveButton
            // 
            saveButton.Anchor = AnchorStyles.Right;
            saveButton.Enabled = false;
            saveButton.Font = new Font("Microsoft YaHei UI", 10F);
            saveButton.Location = new Point(158, 0);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(74, 32);
            saveButton.TabIndex = 4;
            saveButton.Text = "保存";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += SaveButton_Click;
            // 
            // unsaveButton
            // 
            unsaveButton.Anchor = AnchorStyles.Right;
            unsaveButton.Enabled = false;
            unsaveButton.Font = new Font("Microsoft YaHei UI", 10F);
            unsaveButton.Location = new Point(238, 0);
            unsaveButton.Name = "unsaveButton";
            unsaveButton.Size = new Size(74, 32);
            unsaveButton.TabIndex = 3;
            unsaveButton.Text = "取消";
            unsaveButton.UseVisualStyleBackColor = true;
            unsaveButton.Click += UnsaveButton_Click;
            // 
            // deleteButton
            // 
            deleteButton.Anchor = AnchorStyles.Left;
            deleteButton.Font = new Font("Microsoft YaHei UI", 10F);
            deleteButton.Location = new Point(80, 0);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(74, 32);
            deleteButton.TabIndex = 2;
            deleteButton.Text = "删除任务";
            deleteButton.UseVisualStyleBackColor = true;
            deleteButton.Click += DeleteButton_Click;
            // 
            // infoPanel
            // 
            infoPanel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            infoPanel.Controls.Add(label4);
            infoPanel.Controls.Add(timeTypeSelect);
            infoPanel.Controls.Add(label3);
            infoPanel.Controls.Add(TimePicker);
            infoPanel.Controls.Add(label2);
            infoPanel.Controls.Add(ActionSelect);
            infoPanel.Controls.Add(taskName_TextBox);
            infoPanel.Controls.Add(label1);
            infoPanel.Controls.Add(enableCheck);
            infoPanel.Location = new Point(3, 70);
            infoPanel.Name = "infoPanel";
            infoPanel.Size = new Size(312, 120);
            infoPanel.TabIndex = 3;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Bottom;
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft YaHei UI", 10F);
            label4.Location = new Point(40, 90);
            label4.Name = "label4";
            label4.Size = new Size(65, 20);
            label4.TabIndex = 0;
            label4.Text = "时间设置";
            // 
            // timeTypeSelect
            // 
            timeTypeSelect.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            timeTypeSelect.DropDownStyle = ComboBoxStyle.DropDownList;
            timeTypeSelect.Font = new Font("Microsoft YaHei UI", 10F);
            timeTypeSelect.FormattingEnabled = true;
            timeTypeSelect.Items.AddRange(new object[] { "每天", "指定时间" });
            timeTypeSelect.Location = new Point(229, 27);
            timeTypeSelect.Name = "timeTypeSelect";
            timeTypeSelect.Size = new Size(78, 27);
            timeTypeSelect.TabIndex = 5;
            timeTypeSelect.SelectedIndexChanged += TimeTypeSelect_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft YaHei UI", 10F);
            label3.Location = new Point(158, 30);
            label3.Name = "label3";
            label3.Size = new Size(65, 20);
            label3.TabIndex = 0;
            label3.Text = "时间类型";
            // 
            // TimePicker
            // 
            TimePicker.Anchor = AnchorStyles.Bottom;
            TimePicker.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            TimePicker.Font = new Font("Microsoft YaHei UI", 10F);
            TimePicker.Format = DateTimePickerFormat.Custom;
            TimePicker.Location = new Point(111, 90);
            TimePicker.Name = "TimePicker";
            TimePicker.ShowUpDown = true;
            TimePicker.Size = new Size(161, 24);
            TimePicker.TabIndex = 4;
            TimePicker.ValueChanged += TimePicker_ValueChanged;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft YaHei UI", 10F);
            label2.Location = new Point(186, 60);
            label2.Name = "label2";
            label2.Size = new Size(37, 20);
            label2.TabIndex = 0;
            label2.Text = "操作";
            // 
            // ActionSelect
            // 
            ActionSelect.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ActionSelect.DropDownStyle = ComboBoxStyle.DropDownList;
            ActionSelect.Font = new Font("Microsoft YaHei UI", 10F);
            ActionSelect.FormattingEnabled = true;
            ActionSelect.Items.AddRange(new object[] { "关机", "重启", "睡眠", "休眠", "锁定", "注销" });
            ActionSelect.Location = new Point(229, 57);
            ActionSelect.Name = "ActionSelect";
            ActionSelect.Size = new Size(78, 27);
            ActionSelect.TabIndex = 3;
            ActionSelect.SelectedIndexChanged += ActionSelect_SelectedIndexChanged;
            // 
            // taskName_TextBox
            // 
            taskName_TextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            taskName_TextBox.Font = new Font("Microsoft YaHei UI", 10F);
            taskName_TextBox.Location = new Point(60, 27);
            taskName_TextBox.MaxLength = 50;
            taskName_TextBox.Name = "taskName_TextBox";
            taskName_TextBox.Size = new Size(94, 24);
            taskName_TextBox.TabIndex = 2;
            taskName_TextBox.TextChanged += TaskName_TextBox_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft YaHei UI", 10F);
            label1.Location = new Point(3, 30);
            label1.Name = "label1";
            label1.Size = new Size(51, 20);
            label1.TabIndex = 0;
            label1.Text = "任务名";
            // 
            // enableCheck
            // 
            enableCheck.Anchor = AnchorStyles.Top;
            enableCheck.AutoSize = true;
            enableCheck.CheckAlign = ContentAlignment.MiddleRight;
            enableCheck.Font = new Font("Microsoft YaHei UI", 10F);
            enableCheck.Location = new Point(116, 3);
            enableCheck.Name = "enableCheck";
            enableCheck.Size = new Size(56, 24);
            enableCheck.TabIndex = 1;
            enableCheck.Text = "启用";
            enableCheck.UseVisualStyleBackColor = true;
            enableCheck.CheckedChanged += EnableCheck_CheckedChanged;
            // 
            // AutoTaskForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(317, 230);
            Controls.Add(infoPanel);
            Controls.Add(buttonPanel);
            Controls.Add(taskList);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(333, 269);
            Name = "AutoTaskForm";
            Text = "自动定时任务";
            FormClosing += AutoTaskForm_FormClosing;
            Load += AutoTaskForm_Load;
            buttonPanel.ResumeLayout(false);
            infoPanel.ResumeLayout(false);
            infoPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ListBox taskList;
        private Button createButton;
        private Panel buttonPanel;
        private Panel infoPanel;
        private Button saveButton;
        private Button unsaveButton;
        private Button deleteButton;
        private Label label1;
        private CheckBox enableCheck;
        private TextBox taskName_TextBox;
        private Label label2;
        private ComboBox ActionSelect;
        private DateTimePicker TimePicker;
        private ComboBox timeTypeSelect;
        private Label label3;
        private Label label4;
    }
}