using YamlDotNet.Core.Tokens;

namespace TimedPower {
	partial class SettingForm {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingForm));
			ContextMenuSetting = new CheckBox();
			SelfStartingSetting = new CheckBox();
			CloseToTaskBarSetting = new CheckBox();
			labelFor_languageSetting = new Label();
			languageSetting = new ComboBox();
			okButton = new Button();
			cancelButton = new Button();
			applyButton = new Button();
			SuspendLayout();
			// 
			// ContextMenuSetting
			// 
			resources.ApplyResources(ContextMenuSetting, "ContextMenuSetting");
			ContextMenuSetting.Name = "ContextMenuSetting";
			ContextMenuSetting.UseVisualStyleBackColor = true;
			ContextMenuSetting.CheckedChanged += ChangeSettingEH;
			// 
			// SelfStartingSetting
			// 
			resources.ApplyResources(SelfStartingSetting, "SelfStartingSetting");
			SelfStartingSetting.Name = "SelfStartingSetting";
			SelfStartingSetting.UseVisualStyleBackColor = true;
			SelfStartingSetting.CheckedChanged += ChangeSettingEH;
			// 
			// CloseToTaskBarSetting
			// 
			resources.ApplyResources(CloseToTaskBarSetting, "CloseToTaskBarSetting");
			CloseToTaskBarSetting.Name = "CloseToTaskBarSetting";
			CloseToTaskBarSetting.UseVisualStyleBackColor = true;
			CloseToTaskBarSetting.CheckedChanged += ChangeSettingEH;
			// 
			// labelFor_languageSetting
			// 
			resources.ApplyResources(labelFor_languageSetting, "labelFor_languageSetting");
			labelFor_languageSetting.Name = "labelFor_languageSetting";
			// 
			// languageSetting
			// 
			resources.ApplyResources(languageSetting, "languageSetting");
			languageSetting.DropDownStyle = ComboBoxStyle.DropDownList;
			languageSetting.Items.AddRange(new object[] { resources.GetString("languageSetting.Items"), resources.GetString("languageSetting.Items1") });
			languageSetting.Name = "languageSetting";
			languageSetting.SelectedIndexChanged += ChangeSettingEH;
			// 
			// okButton
			// 
			resources.ApplyResources(okButton, "okButton");
			okButton.Name = "okButton";
			okButton.UseVisualStyleBackColor = true;
			okButton.Click += OkButton_Click;
			// 
			// cancelButton
			// 
			resources.ApplyResources(cancelButton, "cancelButton");
			cancelButton.Name = "cancelButton";
			cancelButton.UseVisualStyleBackColor = true;
			cancelButton.Click += CancelButton_Click;
			// 
			// applyButton
			// 
			resources.ApplyResources(applyButton, "applyButton");
			applyButton.Name = "applyButton";
			applyButton.UseVisualStyleBackColor = true;
			applyButton.Click += ApplyButton_Click;
			// 
			// SettingForm
			// 
			resources.ApplyResources(this, "$this");
			AutoScaleMode = AutoScaleMode.Font;
			Controls.Add(applyButton);
			Controls.Add(cancelButton);
			Controls.Add(okButton);
			Controls.Add(languageSetting);
			Controls.Add(labelFor_languageSetting);
			Controls.Add(CloseToTaskBarSetting);
			Controls.Add(SelfStartingSetting);
			Controls.Add(ContextMenuSetting);
			FormBorderStyle = FormBorderStyle.FixedDialog;
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "SettingForm";
			Load += SettingForm_Load;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private CheckBox ContextMenuSetting;
		private CheckBox SelfStartingSetting;
		private CheckBox CloseToTaskBarSetting;
		private Button okButton;
		private Button cancelButton;
		private Button applyButton;
		private Label labelFor_languageSetting;
		private ComboBox languageSetting;
	}
}