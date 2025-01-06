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
			okButton = new Button();
			cancelButton = new Button();
			applyButton = new Button();
			SuspendLayout();
			// 
			// ContextMenuSetting
			// 
			ContextMenuSetting.AutoSize = true;
			ContextMenuSetting.Location = new Point(12, 12);
			ContextMenuSetting.Name = "ContextMenuSetting";
			ContextMenuSetting.Size = new Size(212, 21);
			ContextMenuSetting.TabIndex = 0;
			ContextMenuSetting.Text = "添加快捷按钮至Windows右键菜单";
			ContextMenuSetting.UseVisualStyleBackColor = true;
			ContextMenuSetting.CheckedChanged += ChangeSettingEH;
			// 
			// SelfStartingSetting
			// 
			SelfStartingSetting.AutoSize = true;
			SelfStartingSetting.Location = new Point(12, 39);
			SelfStartingSetting.Name = "SelfStartingSetting";
			SelfStartingSetting.Size = new Size(87, 21);
			SelfStartingSetting.TabIndex = 1;
			SelfStartingSetting.Text = "开机自启动";
			SelfStartingSetting.UseVisualStyleBackColor = true;
			SelfStartingSetting.CheckedChanged += ChangeSettingEH;
			// 
			// CloseToTaskBarSetting
			// 
			CloseToTaskBarSetting.AutoSize = true;
			CloseToTaskBarSetting.Location = new Point(12, 66);
			CloseToTaskBarSetting.Name = "CloseToTaskBarSetting";
			CloseToTaskBarSetting.Size = new Size(135, 21);
			CloseToTaskBarSetting.TabIndex = 2;
			CloseToTaskBarSetting.Text = "关闭时最小化至托盘";
			CloseToTaskBarSetting.UseVisualStyleBackColor = true;
			CloseToTaskBarSetting.CheckedChanged += ChangeSettingEH;
			// 
			// okButton
			// 
			okButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			okButton.Location = new Point(122, 93);
			okButton.Name = "okButton";
			okButton.Size = new Size(57, 26);
			okButton.TabIndex = 0;
			okButton.Text = "确定";
			okButton.UseVisualStyleBackColor = true;
			okButton.Click += OkButton_Click;
			// 
			// cancelButton
			// 
			cancelButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			cancelButton.Location = new Point(179, 93);
			cancelButton.Name = "cancelButton";
			cancelButton.Size = new Size(57, 26);
			cancelButton.TabIndex = 3;
			cancelButton.Text = "取消";
			cancelButton.UseVisualStyleBackColor = true;
			cancelButton.Click += CancelButton_Click;
			// 
			// applyButton
			// 
			applyButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			applyButton.Enabled = false;
			applyButton.Location = new Point(236, 93);
			applyButton.Name = "applyButton";
			applyButton.Size = new Size(57, 26);
			applyButton.TabIndex = 4;
			applyButton.Text = "应用";
			applyButton.UseVisualStyleBackColor = true;
			applyButton.Click += ApplyButton_Click;
			// 
			// SettingForm
			// 
			AutoScaleDimensions = new SizeF(7F, 17F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(295, 124);
			Controls.Add(applyButton);
			Controls.Add(cancelButton);
			Controls.Add(okButton);
			Controls.Add(CloseToTaskBarSetting);
			Controls.Add(SelfStartingSetting);
			Controls.Add(ContextMenuSetting);
			FormBorderStyle = FormBorderStyle.FixedDialog;
			Icon = (Icon)resources.GetObject("$this.Icon");
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "SettingForm";
			StartPosition = FormStartPosition.CenterParent;
			Text = "设置";
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
	}
}