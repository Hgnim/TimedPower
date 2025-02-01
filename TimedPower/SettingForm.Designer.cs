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
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingForm));
			ContextMenuSetting = new ReaLTaiizor.Controls.PoisonToggle();
			SelfStartingSetting = new ReaLTaiizor.Controls.PoisonToggle();
			CloseToTaskBarSetting = new ReaLTaiizor.Controls.PoisonToggle();
			labelFor_ContextMenuSetting = new ReaLTaiizor.Controls.SmallLabel();
			labelFor_SelfStartingSetting = new ReaLTaiizor.Controls.SmallLabel();
			labelFor_CloseToTaskBarSetting = new ReaLTaiizor.Controls.SmallLabel();
			labelFor_languageSetting = new ReaLTaiizor.Controls.SmallLabel();
			languageSetting = new ReaLTaiizor.Controls.PoisonComboBox();
			okButton = new ReaLTaiizor.Controls.PoisonButton();
			cancelButton = new ReaLTaiizor.Controls.PoisonButton();
			applyButton = new ReaLTaiizor.Controls.PoisonButton();
			poisonStyleManager = new ReaLTaiizor.Manager.PoisonStyleManager(components);
			formTitle = new ReaLTaiizor.Controls.PoisonLabel();
			labelFor_themeSetting = new ReaLTaiizor.Controls.SmallLabel();
			themeSetting = new ReaLTaiizor.Controls.PoisonComboBox();
			((System.ComponentModel.ISupportInitialize)poisonStyleManager).BeginInit();
			SuspendLayout();
			// 
			// ContextMenuSetting
			// 
			resources.ApplyResources(ContextMenuSetting, "ContextMenuSetting");
			ContextMenuSetting.DisplayStatus = false;
			ContextMenuSetting.Name = "ContextMenuSetting";
			ContextMenuSetting.UseSelectable = true;
			ContextMenuSetting.UseVisualStyleBackColor = true;
			ContextMenuSetting.CheckedChanged += ChangeSettingEH;
			// 
			// SelfStartingSetting
			// 
			resources.ApplyResources(SelfStartingSetting, "SelfStartingSetting");
			SelfStartingSetting.DisplayStatus = false;
			SelfStartingSetting.Name = "SelfStartingSetting";
			SelfStartingSetting.UseSelectable = true;
			SelfStartingSetting.UseVisualStyleBackColor = true;
			SelfStartingSetting.CheckedChanged += ChangeSettingEH;
			// 
			// CloseToTaskBarSetting
			// 
			resources.ApplyResources(CloseToTaskBarSetting, "CloseToTaskBarSetting");
			CloseToTaskBarSetting.DisplayStatus = false;
			CloseToTaskBarSetting.Name = "CloseToTaskBarSetting";
			CloseToTaskBarSetting.UseSelectable = true;
			CloseToTaskBarSetting.UseVisualStyleBackColor = true;
			CloseToTaskBarSetting.CheckedChanged += ChangeSettingEH;
			// 
			// labelFor_ContextMenuSetting
			// 
			resources.ApplyResources(labelFor_ContextMenuSetting, "labelFor_ContextMenuSetting");
			labelFor_ContextMenuSetting.BackColor = Color.Transparent;
			labelFor_ContextMenuSetting.ForeColor = Color.FromArgb(142, 142, 142);
			labelFor_ContextMenuSetting.Name = "labelFor_ContextMenuSetting";
			// 
			// labelFor_SelfStartingSetting
			// 
			resources.ApplyResources(labelFor_SelfStartingSetting, "labelFor_SelfStartingSetting");
			labelFor_SelfStartingSetting.BackColor = Color.Transparent;
			labelFor_SelfStartingSetting.ForeColor = Color.FromArgb(142, 142, 142);
			labelFor_SelfStartingSetting.Name = "labelFor_SelfStartingSetting";
			// 
			// labelFor_CloseToTaskBarSetting
			// 
			resources.ApplyResources(labelFor_CloseToTaskBarSetting, "labelFor_CloseToTaskBarSetting");
			labelFor_CloseToTaskBarSetting.BackColor = Color.Transparent;
			labelFor_CloseToTaskBarSetting.ForeColor = Color.FromArgb(142, 142, 142);
			labelFor_CloseToTaskBarSetting.Name = "labelFor_CloseToTaskBarSetting";
			// 
			// labelFor_languageSetting
			// 
			resources.ApplyResources(labelFor_languageSetting, "labelFor_languageSetting");
			labelFor_languageSetting.BackColor = Color.Transparent;
			labelFor_languageSetting.ForeColor = Color.FromArgb(142, 142, 142);
			labelFor_languageSetting.Name = "labelFor_languageSetting";
			// 
			// languageSetting
			// 
			resources.ApplyResources(languageSetting, "languageSetting");
			languageSetting.FontSize = ReaLTaiizor.Extension.Poison.PoisonComboBoxSize.Small;
			languageSetting.Items.AddRange(new object[] { resources.GetString("languageSetting.Items"), resources.GetString("languageSetting.Items1") });
			languageSetting.Name = "languageSetting";
			languageSetting.UseSelectable = true;
			languageSetting.SelectedIndexChanged += ChangeSettingEH;
			// 
			// okButton
			// 
			resources.ApplyResources(okButton, "okButton");
			okButton.FontSize = ReaLTaiizor.Extension.Poison.PoisonButtonSize.Medium;
			okButton.FontWeight = ReaLTaiizor.Extension.Poison.PoisonButtonWeight.Regular;
			okButton.Name = "okButton";
			okButton.UseSelectable = true;
			okButton.UseVisualStyleBackColor = true;
			okButton.Click += OkButton_Click;
			// 
			// cancelButton
			// 
			resources.ApplyResources(cancelButton, "cancelButton");
			cancelButton.FontSize = ReaLTaiizor.Extension.Poison.PoisonButtonSize.Medium;
			cancelButton.FontWeight = ReaLTaiizor.Extension.Poison.PoisonButtonWeight.Regular;
			cancelButton.Name = "cancelButton";
			cancelButton.UseSelectable = true;
			cancelButton.UseVisualStyleBackColor = true;
			cancelButton.Click += CancelButton_Click;
			// 
			// applyButton
			// 
			resources.ApplyResources(applyButton, "applyButton");
			applyButton.FontSize = ReaLTaiizor.Extension.Poison.PoisonButtonSize.Medium;
			applyButton.FontWeight = ReaLTaiizor.Extension.Poison.PoisonButtonWeight.Regular;
			applyButton.Name = "applyButton";
			applyButton.UseSelectable = true;
			applyButton.UseVisualStyleBackColor = true;
			applyButton.Click += ApplyButton_Click;
			// 
			// poisonStyleManager
			// 
			poisonStyleManager.Owner = this;
			// 
			// formTitle
			// 
			resources.ApplyResources(formTitle, "formTitle");
			formTitle.Name = "formTitle";
			// 
			// labelFor_themeSetting
			// 
			resources.ApplyResources(labelFor_themeSetting, "labelFor_themeSetting");
			labelFor_themeSetting.BackColor = Color.Transparent;
			labelFor_themeSetting.ForeColor = Color.FromArgb(142, 142, 142);
			labelFor_themeSetting.Name = "labelFor_themeSetting";
			// 
			// themeSetting
			// 
			resources.ApplyResources(themeSetting, "themeSetting");
			themeSetting.FontSize = ReaLTaiizor.Extension.Poison.PoisonComboBoxSize.Small;
			themeSetting.Items.AddRange(new object[] { resources.GetString("themeSetting.Items"), resources.GetString("themeSetting.Items1"), resources.GetString("themeSetting.Items2") });
			themeSetting.Name = "themeSetting";
			themeSetting.UseSelectable = true;
			themeSetting.SelectedIndexChanged += ChangeSettingEH;
			// 
			// SettingForm
			// 
			AutoScaleMode = AutoScaleMode.None;
			resources.ApplyResources(this, "$this");
			Controls.Add(themeSetting);
			Controls.Add(labelFor_themeSetting);
			Controls.Add(formTitle);
			Controls.Add(applyButton);
			Controls.Add(cancelButton);
			Controls.Add(okButton);
			Controls.Add(languageSetting);
			Controls.Add(labelFor_languageSetting);
			Controls.Add(CloseToTaskBarSetting);
			Controls.Add(SelfStartingSetting);
			Controls.Add(ContextMenuSetting);
			Controls.Add(labelFor_CloseToTaskBarSetting);
			Controls.Add(labelFor_SelfStartingSetting);
			Controls.Add(labelFor_ContextMenuSetting);
			DisplayHeader = false;
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "SettingForm";
			Resizable = false;
			ShadowType = ReaLTaiizor.Enum.Poison.FormShadowType.SystemShadow;
			StyleManager = poisonStyleManager;
			Load += SettingForm_Load;
			((System.ComponentModel.ISupportInitialize)poisonStyleManager).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private ReaLTaiizor.Controls.PoisonToggle ContextMenuSetting;
		private ReaLTaiizor.Controls.SmallLabel labelFor_ContextMenuSetting;
		private ReaLTaiizor.Controls.PoisonToggle SelfStartingSetting;
		private ReaLTaiizor.Controls.SmallLabel labelFor_SelfStartingSetting;
		private ReaLTaiizor.Controls.PoisonToggle CloseToTaskBarSetting;
		private ReaLTaiizor.Controls.SmallLabel labelFor_CloseToTaskBarSetting;
		private ReaLTaiizor.Controls.PoisonButton okButton;
		private ReaLTaiizor.Controls.PoisonButton cancelButton;
		private ReaLTaiizor.Controls.PoisonButton applyButton;
		private ReaLTaiizor.Controls.SmallLabel labelFor_languageSetting;
		private ReaLTaiizor.Controls.PoisonComboBox languageSetting;
		private ReaLTaiizor.Manager.PoisonStyleManager poisonStyleManager;
		private ReaLTaiizor.Controls.PoisonLabel formTitle;
		private ReaLTaiizor.Controls.SmallLabel labelFor_themeSetting;
		private ReaLTaiizor.Controls.PoisonComboBox themeSetting;
	}
}