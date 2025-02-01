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
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AutoTaskForm));
			taskList = new ListBox();
			createButton = new ReaLTaiizor.Controls.PoisonButton();
			buttonPanel = new ReaLTaiizor.Controls.PoisonPanel();
			saveButton = new ReaLTaiizor.Controls.PoisonButton();
			unsaveButton = new ReaLTaiizor.Controls.PoisonButton();
			deleteButton = new ReaLTaiizor.Controls.PoisonButton();
			infoPanel = new ReaLTaiizor.Controls.PoisonPanel();
			TimeInput = new ReaLTaiizor.Controls.PoisonTextBox();
			timeTypeSelect = new ReaLTaiizor.Controls.PoisonComboBox();
			label3 = new ReaLTaiizor.Controls.PoisonLabel();
			TimePicker = new ReaLTaiizor.Controls.PoisonDateTime();
			ActionSelect = new ReaLTaiizor.Controls.PoisonComboBox();
			taskName_TextBox = new ReaLTaiizor.Controls.PoisonTextBox();
			label1 = new ReaLTaiizor.Controls.PoisonLabel();
			enableCheck = new ReaLTaiizor.Controls.PoisonCheckBox();
			label2 = new ReaLTaiizor.Controls.PoisonLabel();
			label4 = new ReaLTaiizor.Controls.PoisonLabel();
			formTitle = new ReaLTaiizor.Controls.PoisonLabel();
			poisonStyleManager = new ReaLTaiizor.Manager.PoisonStyleManager(components);
			buttonPanel.SuspendLayout();
			infoPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)poisonStyleManager).BeginInit();
			SuspendLayout();
			// 
			// taskList
			// 
			resources.ApplyResources(taskList, "taskList");
			taskList.BackColor = SystemColors.ButtonFace;
			taskList.BorderStyle = BorderStyle.FixedSingle;
			taskList.DrawMode = DrawMode.OwnerDrawVariable;
			taskList.FormattingEnabled = true;
			taskList.Name = "taskList";
			taskList.DrawItem += TaskList_DrawItem;
			taskList.SelectedIndexChanged += TaskList_SelectedIndexChanged;
			// 
			// createButton
			// 
			resources.ApplyResources(createButton, "createButton");
			createButton.FontWeight = ReaLTaiizor.Extension.Poison.PoisonButtonWeight.Regular;
			createButton.Name = "createButton";
			createButton.UseSelectable = true;
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
			buttonPanel.HorizontalScrollbarBarColor = true;
			buttonPanel.HorizontalScrollbarHighlightOnWheel = false;
			buttonPanel.HorizontalScrollbarSize = 10;
			buttonPanel.Name = "buttonPanel";
			buttonPanel.VerticalScrollbarBarColor = true;
			buttonPanel.VerticalScrollbarHighlightOnWheel = false;
			buttonPanel.VerticalScrollbarSize = 10;
			// 
			// saveButton
			// 
			resources.ApplyResources(saveButton, "saveButton");
			saveButton.FontWeight = ReaLTaiizor.Extension.Poison.PoisonButtonWeight.Regular;
			saveButton.Name = "saveButton";
			saveButton.UseSelectable = true;
			saveButton.UseVisualStyleBackColor = true;
			saveButton.Click += SaveButton_Click;
			// 
			// unsaveButton
			// 
			resources.ApplyResources(unsaveButton, "unsaveButton");
			unsaveButton.FontWeight = ReaLTaiizor.Extension.Poison.PoisonButtonWeight.Regular;
			unsaveButton.Name = "unsaveButton";
			unsaveButton.UseSelectable = true;
			unsaveButton.UseVisualStyleBackColor = true;
			unsaveButton.Click += UnsaveButton_Click;
			// 
			// deleteButton
			// 
			resources.ApplyResources(deleteButton, "deleteButton");
			deleteButton.FontWeight = ReaLTaiizor.Extension.Poison.PoisonButtonWeight.Regular;
			deleteButton.Name = "deleteButton";
			deleteButton.UseSelectable = true;
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
			infoPanel.HorizontalScrollbarBarColor = true;
			infoPanel.HorizontalScrollbarHighlightOnWheel = false;
			infoPanel.HorizontalScrollbarSize = 10;
			infoPanel.Name = "infoPanel";
			infoPanel.VerticalScrollbarBarColor = true;
			infoPanel.VerticalScrollbarHighlightOnWheel = false;
			infoPanel.VerticalScrollbarSize = 10;
			// 
			// TimeInput
			// 
			resources.ApplyResources(TimeInput, "TimeInput");
			TimeInput.CharacterCasing = CharacterCasing.Lower;
			// 
			// 
			// 
			TimeInput.CustomButton.AccessibleDescription = resources.GetString("resource.AccessibleDescription");
			TimeInput.CustomButton.AccessibleName = resources.GetString("resource.AccessibleName");
			TimeInput.CustomButton.Anchor = (AnchorStyles)resources.GetObject("resource.Anchor");
			TimeInput.CustomButton.AutoSize = (bool)resources.GetObject("resource.AutoSize");
			TimeInput.CustomButton.AutoSizeMode = (AutoSizeMode)resources.GetObject("resource.AutoSizeMode");
			TimeInput.CustomButton.BackgroundImage = (Image)resources.GetObject("resource.BackgroundImage");
			TimeInput.CustomButton.BackgroundImageLayout = (ImageLayout)resources.GetObject("resource.BackgroundImageLayout");
			TimeInput.CustomButton.Dock = (DockStyle)resources.GetObject("resource.Dock");
			TimeInput.CustomButton.FlatStyle = (FlatStyle)resources.GetObject("resource.FlatStyle");
			TimeInput.CustomButton.Font = (Font)resources.GetObject("resource.Font");
			TimeInput.CustomButton.Image = (Image)resources.GetObject("resource.Image");
			TimeInput.CustomButton.ImageAlign = (ContentAlignment)resources.GetObject("resource.ImageAlign");
			TimeInput.CustomButton.ImageIndex = (int)resources.GetObject("resource.ImageIndex");
			TimeInput.CustomButton.ImageKey = resources.GetString("resource.ImageKey");
			TimeInput.CustomButton.ImeMode = (ImeMode)resources.GetObject("resource.ImeMode");
			TimeInput.CustomButton.Location = (Point)resources.GetObject("resource.Location");
			TimeInput.CustomButton.MaximumSize = (Size)resources.GetObject("resource.MaximumSize");
			TimeInput.CustomButton.Name = "";
			TimeInput.CustomButton.RightToLeft = (RightToLeft)resources.GetObject("resource.RightToLeft");
			TimeInput.CustomButton.Size = (Size)resources.GetObject("resource.Size");
			TimeInput.CustomButton.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Blue;
			TimeInput.CustomButton.TabIndex = (int)resources.GetObject("resource.TabIndex");
			TimeInput.CustomButton.TextAlign = (ContentAlignment)resources.GetObject("resource.TextAlign");
			TimeInput.CustomButton.TextImageRelation = (TextImageRelation)resources.GetObject("resource.TextImageRelation");
			TimeInput.CustomButton.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Light;
			TimeInput.CustomButton.UseSelectable = true;
			TimeInput.CustomButton.Visible = (bool)resources.GetObject("resource.Visible");
			TimeInput.FontSize = ReaLTaiizor.Extension.Poison.PoisonTextBoxSize.Medium;
			TimeInput.MaxLength = 32767;
			TimeInput.Name = "TimeInput";
			TimeInput.PasswordChar = '\0';
			TimeInput.ScrollBars = ScrollBars.None;
			TimeInput.SelectedText = "";
			TimeInput.SelectionLength = 0;
			TimeInput.SelectionStart = 0;
			TimeInput.ShortcutsEnabled = true;
			TimeInput.TextAlign = HorizontalAlignment.Center;
			TimeInput.UseSelectable = true;
			TimeInput.WaterMarkColor = Color.FromArgb(109, 109, 109);
			TimeInput.WaterMarkFont = new Font("Segoe UI", 12F, FontStyle.Italic, GraphicsUnit.Pixel);
			TimeInput.TextChanged += TimeInput_TextChanged;
			TimeInput.Leave += TimeInput_Leave;
			// 
			// timeTypeSelect
			// 
			resources.ApplyResources(timeTypeSelect, "timeTypeSelect");
			timeTypeSelect.FormattingEnabled = true;
			timeTypeSelect.Items.AddRange(new object[] { resources.GetString("timeTypeSelect.Items"), resources.GetString("timeTypeSelect.Items1"), resources.GetString("timeTypeSelect.Items2") });
			timeTypeSelect.Name = "timeTypeSelect";
			timeTypeSelect.UseSelectable = true;
			timeTypeSelect.SelectedIndexChanged += TimeTypeSelect_SelectedIndexChanged;
			// 
			// label3
			// 
			resources.ApplyResources(label3, "label3");
			label3.BackColor = Color.Transparent;
			label3.ForeColor = Color.FromArgb(142, 142, 142);
			label3.Name = "label3";
			// 
			// TimePicker
			// 
			resources.ApplyResources(TimePicker, "TimePicker");
			TimePicker.FontSize = ReaLTaiizor.Extension.Poison.PoisonDateTimeSize.Medium;
			TimePicker.Format = DateTimePickerFormat.Custom;
			TimePicker.Name = "TimePicker";
			TimePicker.ValueChanged += TimePicker_ValueChanged;
			// 
			// ActionSelect
			// 
			resources.ApplyResources(ActionSelect, "ActionSelect");
			ActionSelect.FormattingEnabled = true;
			ActionSelect.Items.AddRange(new object[] { resources.GetString("ActionSelect.Items"), resources.GetString("ActionSelect.Items1"), resources.GetString("ActionSelect.Items2"), resources.GetString("ActionSelect.Items3"), resources.GetString("ActionSelect.Items4"), resources.GetString("ActionSelect.Items5") });
			ActionSelect.Name = "ActionSelect";
			ActionSelect.UseSelectable = true;
			ActionSelect.SelectedIndexChanged += ActionSelect_SelectedIndexChanged;
			// 
			// taskName_TextBox
			// 
			resources.ApplyResources(taskName_TextBox, "taskName_TextBox");
			// 
			// 
			// 
			taskName_TextBox.CustomButton.AccessibleDescription = resources.GetString("resource.AccessibleDescription1");
			taskName_TextBox.CustomButton.AccessibleName = resources.GetString("resource.AccessibleName1");
			taskName_TextBox.CustomButton.Anchor = (AnchorStyles)resources.GetObject("resource.Anchor1");
			taskName_TextBox.CustomButton.AutoSize = (bool)resources.GetObject("resource.AutoSize1");
			taskName_TextBox.CustomButton.AutoSizeMode = (AutoSizeMode)resources.GetObject("resource.AutoSizeMode1");
			taskName_TextBox.CustomButton.BackgroundImage = (Image)resources.GetObject("resource.BackgroundImage1");
			taskName_TextBox.CustomButton.BackgroundImageLayout = (ImageLayout)resources.GetObject("resource.BackgroundImageLayout1");
			taskName_TextBox.CustomButton.Dock = (DockStyle)resources.GetObject("resource.Dock1");
			taskName_TextBox.CustomButton.FlatStyle = (FlatStyle)resources.GetObject("resource.FlatStyle1");
			taskName_TextBox.CustomButton.Font = (Font)resources.GetObject("resource.Font1");
			taskName_TextBox.CustomButton.Image = (Image)resources.GetObject("resource.Image1");
			taskName_TextBox.CustomButton.ImageAlign = (ContentAlignment)resources.GetObject("resource.ImageAlign1");
			taskName_TextBox.CustomButton.ImageIndex = (int)resources.GetObject("resource.ImageIndex1");
			taskName_TextBox.CustomButton.ImageKey = resources.GetString("resource.ImageKey1");
			taskName_TextBox.CustomButton.ImeMode = (ImeMode)resources.GetObject("resource.ImeMode1");
			taskName_TextBox.CustomButton.Location = (Point)resources.GetObject("resource.Location1");
			taskName_TextBox.CustomButton.MaximumSize = (Size)resources.GetObject("resource.MaximumSize1");
			taskName_TextBox.CustomButton.Name = "";
			taskName_TextBox.CustomButton.RightToLeft = (RightToLeft)resources.GetObject("resource.RightToLeft1");
			taskName_TextBox.CustomButton.Size = (Size)resources.GetObject("resource.Size1");
			taskName_TextBox.CustomButton.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Blue;
			taskName_TextBox.CustomButton.TabIndex = (int)resources.GetObject("resource.TabIndex1");
			taskName_TextBox.CustomButton.TextAlign = (ContentAlignment)resources.GetObject("resource.TextAlign1");
			taskName_TextBox.CustomButton.TextImageRelation = (TextImageRelation)resources.GetObject("resource.TextImageRelation1");
			taskName_TextBox.CustomButton.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Light;
			taskName_TextBox.CustomButton.UseSelectable = true;
			taskName_TextBox.CustomButton.Visible = (bool)resources.GetObject("resource.Visible1");
			taskName_TextBox.FontSize = ReaLTaiizor.Extension.Poison.PoisonTextBoxSize.Medium;
			taskName_TextBox.MaxLength = 50;
			taskName_TextBox.Name = "taskName_TextBox";
			taskName_TextBox.PasswordChar = '\0';
			taskName_TextBox.ScrollBars = ScrollBars.None;
			taskName_TextBox.SelectedText = "";
			taskName_TextBox.SelectionLength = 0;
			taskName_TextBox.SelectionStart = 0;
			taskName_TextBox.ShortcutsEnabled = true;
			taskName_TextBox.UseSelectable = true;
			taskName_TextBox.WaterMarkColor = Color.FromArgb(109, 109, 109);
			taskName_TextBox.WaterMarkFont = new Font("Segoe UI", 12F, FontStyle.Italic, GraphicsUnit.Pixel);
			taskName_TextBox.TextChanged += TaskName_TextBox_TextChanged;
			// 
			// label1
			// 
			resources.ApplyResources(label1, "label1");
			label1.BackColor = Color.Transparent;
			label1.ForeColor = Color.FromArgb(142, 142, 142);
			label1.Name = "label1";
			// 
			// enableCheck
			// 
			resources.ApplyResources(enableCheck, "enableCheck");
			enableCheck.Name = "enableCheck";
			enableCheck.UseSelectable = true;
			enableCheck.UseVisualStyleBackColor = true;
			enableCheck.CheckedChanged += EnableCheck_CheckedChanged;
			// 
			// label2
			// 
			resources.ApplyResources(label2, "label2");
			label2.BackColor = Color.Transparent;
			label2.ForeColor = Color.FromArgb(142, 142, 142);
			label2.Name = "label2";
			// 
			// label4
			// 
			resources.ApplyResources(label4, "label4");
			label4.BackColor = Color.Transparent;
			label4.ForeColor = Color.FromArgb(142, 142, 142);
			label4.Name = "label4";
			// 
			// formTitle
			// 
			resources.ApplyResources(formTitle, "formTitle");
			formTitle.Name = "formTitle";
			// 
			// poisonStyleManager
			// 
			poisonStyleManager.Owner = this;
			// 
			// AutoTaskForm
			// 
			resources.ApplyResources(this, "$this");
			AutoScaleMode = AutoScaleMode.None;
			Controls.Add(formTitle);
			Controls.Add(infoPanel);
			Controls.Add(buttonPanel);
			Controls.Add(taskList);
			DisplayHeader = false;
			Name = "AutoTaskForm";
			ShadowType = ReaLTaiizor.Enum.Poison.FormShadowType.SystemShadow;
			StyleManager = poisonStyleManager;
			FormClosing += AutoTaskForm_FormClosing;
			FormClosed += AutoTaskForm_FormClosed;
			Load += AutoTaskForm_Load;
			buttonPanel.ResumeLayout(false);
			infoPanel.ResumeLayout(false);
			infoPanel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)poisonStyleManager).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private ListBox taskList;
        private ReaLTaiizor.Controls.PoisonButton createButton;
        private ReaLTaiizor.Controls.PoisonPanel buttonPanel;
        private ReaLTaiizor.Controls.PoisonPanel infoPanel;
        private ReaLTaiizor.Controls.PoisonButton saveButton;
        private ReaLTaiizor.Controls.PoisonButton unsaveButton;
        private ReaLTaiizor.Controls.PoisonButton deleteButton;
        private ReaLTaiizor.Controls.PoisonLabel label1;
        private ReaLTaiizor.Controls.PoisonCheckBox enableCheck;
        private ReaLTaiizor.Controls.PoisonTextBox taskName_TextBox;
        private ReaLTaiizor.Controls.PoisonLabel label2;
        private ReaLTaiizor.Controls.PoisonComboBox ActionSelect;
        private ReaLTaiizor.Controls.PoisonDateTime TimePicker;
        private ReaLTaiizor.Controls.PoisonComboBox timeTypeSelect;
        private ReaLTaiizor.Controls.PoisonLabel label3;
        private ReaLTaiizor.Controls.PoisonLabel label4;
		private ReaLTaiizor.Controls.PoisonTextBox TimeInput;
		private ReaLTaiizor.Controls.PoisonLabel formTitle;
		private ReaLTaiizor.Manager.PoisonStyleManager poisonStyleManager;
	}
}