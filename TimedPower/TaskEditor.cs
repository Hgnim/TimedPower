using ReaLTaiizor.Forms;
using static TimedPower.DataCore;
using System.Globalization;
using static TimedPower.TimedPowerTask;
using System.Resources;

namespace TimedPower
{
	public partial class TaskEditor : PoisonForm {
		public TaskEditor() {
			UpdateLanguageResource();
			InitializeComponent();
			Main.ProgramLanguage.UpdateLanguage += UpdateLanguage;

			void UpdateTheme() => themeManager.UpdateFormTheme(ref poisonStyleManager);
			themeManager.UpdateTheme += UpdateTheme;
			UpdateTheme();
		}
		static ResourceManager langRes = null!;
		internal static string GetLangStr(string key, string head = "taskEditor") => langRes.GetString($"{head}.{key}", CultureInfo.CurrentUICulture)!;
		void UpdateLanguage() {
			UpdateLanguageResource();
			LanguageData.UpdateFormLanguage(this);
		}
		static void UpdateLanguageResource() => LanguageData.UpdateLanguageResource(out langRes, FilePath.MainLanguageFile);


		private void TaskEditor_FormClosing(object sender, FormClosingEventArgs e) {

		}
		private void TaskEditor_Load(object sender, EventArgs e) {
			ActionSelect.SelectedIndex = (int)ActionSelectItems.userlock;
			TimeInput.Text = "5min";
			timeTypeSelect.SelectedIndex = (int)TimeTypeSelectItems.after;
		}
		private void TaskEditor_DragEnter(object sender, DragEventArgs e) {
			if (e.Data != null) {
				if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
					e.Effect = DragDropEffects.Copy;
				}
				else {
					e.Effect = DragDropEffects.None;
				}
			}
		}
		private void TaskEditor_DragDrop(object sender, DragEventArgs e) {
			if (e.Data != null) {
				if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
					string[]? files = (string[]?)e.Data.GetData(DataFormats.FileDrop);
					if (files != null && files.Length > 0) {
						if (!LoadFile(files[0])) {
							MessageBox.Show(GetLangStr("loadFailed"), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
						}
					}
				}
			}
		}

		string openFile = "";
		bool SaveFile(string path) {
			try {
				TPTSave(path,
					new() {
						Action = (ActionSelectItems)ActionSelect.SelectedIndex
											switch {
												ActionSelectItems.shutdown => TaskAction.shutdown,
												ActionSelectItems.reboot => TaskAction.reboot,
												ActionSelectItems.useroff => TaskAction.useroff,
												ActionSelectItems.userlock => TaskAction.userlock,
												ActionSelectItems.sleep => TaskAction.sleep,
												ActionSelectItems.hibernate => TaskAction.hibernate,
												_ => throw new NotImplementedException(),
											},
						Time = TimeInput.Text,
						TimeType = (TimeTypeSelectItems)timeTypeSelect.SelectedIndex
												switch {
													TimeTypeSelectItems.after => TaskTimeType.after,
													TimeTypeSelectItems.ontime => TaskTimeType.ontime,
													_ => throw new NotImplementedException(),
												},
					}
				);
				return true;
			} catch { return false; }
		}
		bool LoadFile(string path) {
			try {
				TPT tpt = TPTRead(path)!;
				int actionSelectSI = (int)(tpt.Action switch {
					TaskAction.shutdown => ActionSelectItems.shutdown,
					TaskAction.reboot => ActionSelectItems.reboot,
					TaskAction.useroff => ActionSelectItems.useroff,
					TaskAction.userlock => ActionSelectItems.userlock,
					TaskAction.sleep => ActionSelectItems.sleep,
					TaskAction.hibernate => ActionSelectItems.hibernate,
					_ => throw new NotImplementedException(),
				});
				string timeInputT = tpt.Time;
				int timeTypeSelectSI = (int)(tpt.TimeType switch {
					TaskTimeType.after => TimeTypeSelectItems.after,
					TaskTimeType.ontime => TimeTypeSelectItems.ontime,
					_ => throw new NotImplementedException(),
				});
				//读取完后确认没有错误再赋值

				ActionSelect.SelectedIndex = actionSelectSI;
				TimeInput.Text = timeInputT;
				timeTypeSelect.SelectedIndex = timeTypeSelectSI;
				return true;
			} catch { return false; }
		}




		private void SaveasButton_Click(object sender, EventArgs e) {
			SaveFileDialog saveFileDialog = new() {
				Title = GetLangStr("fileWindow.newTaskFile.title", "main"),
				DefaultExt = "tpt",
				Filter = string.Format(GetLangStr("fileWindow.newTaskFile.filter", "main"), "(*.tpt)|*.tpt"),
				//InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
			};
			if (saveFileDialog.ShowDialog() == DialogResult.OK) {
				if (SaveFile(saveFileDialog.FileName)) {
					openFile = saveFileDialog.FileName;
				}
				else {
					MessageBox.Show(GetLangStr("saveFailed"), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}
		private void SaveButton_Click(object sender, EventArgs e) {
			if (openFile != "") {
				if (!SaveFile(openFile)) {
					MessageBox.Show(GetLangStr("saveFailed"), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			else {
				SaveasButton_Click(sender, e);
			}
		}
		private void CancelButton_Click(object sender, EventArgs e) => this.Close();
	}
}
