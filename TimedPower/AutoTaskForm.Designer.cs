namespace TimedPower
{
    partial class AutoTaskForm
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
		internal enum TimeTypeSelectItems {
			everyday,
			singleTimed,
			appStart
		}

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
		private void InitializeComponent() {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AutoTaskForm));
			taskList = new ListBox();
			createButton = new Button();
			buttonPanel = new Panel();
			saveButton = new Button();
			unsaveButton = new Button();
			deleteButton = new Button();
			infoPanel = new Panel();
			TimeInput = new TextBox();
			timeTypeSelect = new ComboBox();
			label3 = new Label();
			TimePicker = new DateTimePicker();
			ActionSelect = new ComboBox();
			taskName_TextBox = new TextBox();
			label1 = new Label();
			enableCheck = new CheckBox();
			label2 = new Label();
			label4 = new Label();
			buttonPanel.SuspendLayout();
			infoPanel.SuspendLayout();
			SuspendLayout();
			// 
			// taskList
			// 
			resources.ApplyResources(taskList, "taskList");
			taskList.BackColor = SystemColors.ButtonFace;
			taskList.DrawMode = DrawMode.OwnerDrawVariable;
			taskList.FormattingEnabled = true;
			taskList.Name = "taskList";
			taskList.DrawItem += TaskList_DrawItem;
			taskList.SelectedIndexChanged += TaskList_SelectedIndexChanged;
			// 
			// createButton
			// 
			resources.ApplyResources(createButton, "createButton");
			createButton.Name = "createButton";
			createButton.UseVisualStyleBackColor = true;
			createButton.Click += CreateButton_Click;
			// 
			// buttonPanel
			// 
			resources.ApplyResources(buttonPanel, "buttonPanel");
			buttonPanel.Controls.Add(saveButton);
			buttonPanel.Controls.Add(unsaveButton);
			buttonPanel.Controls.Add(deleteButton);
			buttonPanel.Controls.Add(createButton);
			buttonPanel.Name = "buttonPanel";
			// 
			// saveButton
			// 
			resources.ApplyResources(saveButton, "saveButton");
			saveButton.Name = "saveButton";
			saveButton.UseVisualStyleBackColor = true;
			saveButton.Click += SaveButton_Click;
			// 
			// unsaveButton
			// 
			resources.ApplyResources(unsaveButton, "unsaveButton");
			unsaveButton.Name = "unsaveButton";
			unsaveButton.UseVisualStyleBackColor = true;
			unsaveButton.Click += UnsaveButton_Click;
			// 
			// deleteButton
			// 
			resources.ApplyResources(deleteButton, "deleteButton");
			deleteButton.Name = "deleteButton";
			deleteButton.UseVisualStyleBackColor = true;
			deleteButton.Click += DeleteButton_Click;
			// 
			// infoPanel
			// 
			resources.ApplyResources(infoPanel, "infoPanel");
			infoPanel.Controls.Add(TimeInput);
			infoPanel.Controls.Add(timeTypeSelect);
			infoPanel.Controls.Add(label3);
			infoPanel.Controls.Add(TimePicker);
			infoPanel.Controls.Add(ActionSelect);
			infoPanel.Controls.Add(taskName_TextBox);
			infoPanel.Controls.Add(label1);
			infoPanel.Controls.Add(enableCheck);
			infoPanel.Controls.Add(label2);
			infoPanel.Controls.Add(label4);
			infoPanel.Name = "infoPanel";
			// 
			// TimeInput
			// 
			resources.ApplyResources(TimeInput, "TimeInput");
			TimeInput.CharacterCasing = CharacterCasing.Lower;
			TimeInput.Name = "TimeInput";
			TimeInput.TextChanged += TimeInput_TextChanged;
			TimeInput.Leave += TimeInput_Leave;
			// 
			// timeTypeSelect
			// 
			resources.ApplyResources(timeTypeSelect, "timeTypeSelect");
			timeTypeSelect.DropDownStyle = ComboBoxStyle.DropDownList;
			timeTypeSelect.FormattingEnabled = true;
			timeTypeSelect.Items.AddRange(new object[] { resources.GetString("timeTypeSelect.Items"), resources.GetString("timeTypeSelect.Items1"), resources.GetString("timeTypeSelect.Items2") });
			timeTypeSelect.Name = "timeTypeSelect";
			timeTypeSelect.SelectedIndexChanged += TimeTypeSelect_SelectedIndexChanged;
			// 
			// label3
			// 
			resources.ApplyResources(label3, "label3");
			label3.Name = "label3";
			// 
			// TimePicker
			// 
			resources.ApplyResources(TimePicker, "TimePicker");
			TimePicker.Format = DateTimePickerFormat.Custom;
			TimePicker.Name = "TimePicker";
			TimePicker.ShowUpDown = true;
			TimePicker.ValueChanged += TimePicker_ValueChanged;
			// 
			// ActionSelect
			// 
			resources.ApplyResources(ActionSelect, "ActionSelect");
			ActionSelect.DropDownStyle = ComboBoxStyle.DropDownList;
			ActionSelect.FormattingEnabled = true;
			ActionSelect.Items.AddRange(new object[] { resources.GetString("ActionSelect.Items"), resources.GetString("ActionSelect.Items1"), resources.GetString("ActionSelect.Items2"), resources.GetString("ActionSelect.Items3"), resources.GetString("ActionSelect.Items4"), resources.GetString("ActionSelect.Items5") });
			ActionSelect.Name = "ActionSelect";
			ActionSelect.SelectedIndexChanged += ActionSelect_SelectedIndexChanged;
			// 
			// taskName_TextBox
			// 
			resources.ApplyResources(taskName_TextBox, "taskName_TextBox");
			taskName_TextBox.Name = "taskName_TextBox";
			taskName_TextBox.TextChanged += TaskName_TextBox_TextChanged;
			// 
			// label1
			// 
			resources.ApplyResources(label1, "label1");
			label1.Name = "label1";
			// 
			// enableCheck
			// 
			resources.ApplyResources(enableCheck, "enableCheck");
			enableCheck.Name = "enableCheck";
			enableCheck.UseVisualStyleBackColor = true;
			enableCheck.CheckedChanged += EnableCheck_CheckedChanged;
			// 
			// label2
			// 
			resources.ApplyResources(label2, "label2");
			label2.Name = "label2";
			// 
			// label4
			// 
			resources.ApplyResources(label4, "label4");
			label4.Name = "label4";
			// 
			// AutoTaskForm
			// 
			resources.ApplyResources(this, "$this");
			AutoScaleMode = AutoScaleMode.Font;
			Controls.Add(infoPanel);
			Controls.Add(buttonPanel);
			Controls.Add(taskList);
			Name = "AutoTaskForm";
			FormClosing += AutoTaskForm_FormClosing;
			FormClosed += AutoTaskForm_FormClosed;
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
		private TextBox TimeInput;
	}
}