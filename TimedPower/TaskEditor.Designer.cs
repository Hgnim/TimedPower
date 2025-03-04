using ReaLTaiizor.Manager;
using System.Resources;

namespace TimedPower {
	partial class TaskEditor {

		/// <summary>
		/// 对应控件的选项枚举，注意，此处枚举排序必须和控件中的项目排序一致
		/// </summary>
		enum ActionSelectItems {
			shutdown,
			reboot,
			sleep,
			hibernate,
			userlock,
			useroff
		}
		enum TimeTypeSelectItems {
			after,
			ontime
		}


		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TaskEditor));
			formTitle = new ReaLTaiizor.Controls.PoisonLabel();
			poisonStyleManager = new PoisonStyleManager(components);
			poisonLabel1 = new ReaLTaiizor.Controls.PoisonLabel();
			poisonLabel2 = new ReaLTaiizor.Controls.PoisonLabel();
			timeTypeSelect = new ReaLTaiizor.Controls.PoisonComboBox();
			TimeInput = new ReaLTaiizor.Controls.PoisonTextBox();
			poisonLabel3 = new ReaLTaiizor.Controls.PoisonLabel();
			saveButton = new ReaLTaiizor.Controls.PoisonButton();
			cancelButton = new ReaLTaiizor.Controls.PoisonButton();
			saveasButton = new ReaLTaiizor.Controls.PoisonButton();
			ActionSelect = new ReaLTaiizor.Controls.PoisonComboBox();
			((System.ComponentModel.ISupportInitialize)poisonStyleManager).BeginInit();
			SuspendLayout();
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
			// poisonLabel1
			// 
			resources.ApplyResources(poisonLabel1, "poisonLabel1");
			poisonLabel1.BackColor = Color.Transparent;
			poisonLabel1.ForeColor = Color.FromArgb(142, 142, 142);
			poisonLabel1.Name = "poisonLabel1";
			// 
			// poisonLabel2
			// 
			resources.ApplyResources(poisonLabel2, "poisonLabel2");
			poisonLabel2.BackColor = Color.Transparent;
			poisonLabel2.ForeColor = Color.FromArgb(142, 142, 142);
			poisonLabel2.Name = "poisonLabel2";
			// 
			// timeTypeSelect
			// 
			resources.ApplyResources(timeTypeSelect, "timeTypeSelect");
			timeTypeSelect.FormattingEnabled = true;
			timeTypeSelect.Items.AddRange(new object[] { resources.GetString("timeTypeSelect.Items"), resources.GetString("timeTypeSelect.Items1") });
			timeTypeSelect.Name = "timeTypeSelect";
			timeTypeSelect.UseSelectable = true;
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
			TimeInput.ScrollBars = ScrollBars.Vertical;
			TimeInput.SelectedText = "";
			TimeInput.SelectionLength = 0;
			TimeInput.SelectionStart = 0;
			TimeInput.ShortcutsEnabled = true;
			TimeInput.TextAlign = HorizontalAlignment.Center;
			TimeInput.UseSelectable = true;
			TimeInput.WaterMarkColor = Color.FromArgb(109, 109, 109);
			TimeInput.WaterMarkFont = new Font("Segoe UI", 12F, FontStyle.Italic, GraphicsUnit.Pixel);
			// 
			// poisonLabel3
			// 
			resources.ApplyResources(poisonLabel3, "poisonLabel3");
			poisonLabel3.BackColor = Color.Transparent;
			poisonLabel3.ForeColor = Color.FromArgb(142, 142, 142);
			poisonLabel3.Name = "poisonLabel3";
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
			// cancelButton
			// 
			resources.ApplyResources(cancelButton, "cancelButton");
			cancelButton.FontWeight = ReaLTaiizor.Extension.Poison.PoisonButtonWeight.Regular;
			cancelButton.Name = "cancelButton";
			cancelButton.UseSelectable = true;
			cancelButton.UseVisualStyleBackColor = true;
			cancelButton.Click += CancelButton_Click;
			// 
			// saveasButton
			// 
			resources.ApplyResources(saveasButton, "saveasButton");
			saveasButton.FontWeight = ReaLTaiizor.Extension.Poison.PoisonButtonWeight.Regular;
			saveasButton.Name = "saveasButton";
			saveasButton.UseSelectable = true;
			saveasButton.UseVisualStyleBackColor = true;
			saveasButton.Click += SaveasButton_Click;
			// 
			// ActionSelect
			// 
			resources.ApplyResources(ActionSelect, "ActionSelect");
			ActionSelect.FormattingEnabled = true;
			ActionSelect.Items.AddRange(new object[] { resources.GetString("ActionSelect.Items"), resources.GetString("ActionSelect.Items1"), resources.GetString("ActionSelect.Items2"), resources.GetString("ActionSelect.Items3"), resources.GetString("ActionSelect.Items4"), resources.GetString("ActionSelect.Items5") });
			ActionSelect.Name = "ActionSelect";
			ActionSelect.UseSelectable = true;
			// 
			// TaskEditor
			// 
			resources.ApplyResources(this, "$this");
			AllowDrop = true;
			AutoScaleMode = AutoScaleMode.None;
			Controls.Add(ActionSelect);
			Controls.Add(saveasButton);
			Controls.Add(saveButton);
			Controls.Add(cancelButton);
			Controls.Add(poisonLabel3);
			Controls.Add(TimeInput);
			Controls.Add(timeTypeSelect);
			Controls.Add(poisonLabel2);
			Controls.Add(poisonLabel1);
			Controls.Add(formTitle);
			DisplayHeader = false;
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "TaskEditor";
			Resizable = false;
			ShadowType = ReaLTaiizor.Enum.Poison.FormShadowType.SystemShadow;
			StyleManager = poisonStyleManager;
			FormClosing += TaskEditor_FormClosing;
			Load += TaskEditor_Load;
			DragDrop += TaskEditor_DragDrop;
			DragEnter += TaskEditor_DragEnter;
			((System.ComponentModel.ISupportInitialize)poisonStyleManager).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion
		private ReaLTaiizor.Manager.PoisonStyleManager poisonStyleManager;
		private ReaLTaiizor.Controls.PoisonLabel formTitle;
		private ReaLTaiizor.Controls.PoisonLabel poisonLabel1;
		private ReaLTaiizor.Controls.PoisonLabel poisonLabel2;
		private ReaLTaiizor.Controls.PoisonComboBox timeTypeSelect;
		private ReaLTaiizor.Controls.PoisonLabel poisonLabel3;
		private ReaLTaiizor.Controls.PoisonTextBox TimeInput;
		private ReaLTaiizor.Controls.PoisonButton saveasButton;
		private ReaLTaiizor.Controls.PoisonButton saveButton;
		private ReaLTaiizor.Controls.PoisonButton cancelButton;
		private ReaLTaiizor.Controls.PoisonComboBox ActionSelect;
	}
}