using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.ViewManagement;

namespace TimedPower {
	//原本打算通过更改控件颜色来实现主题切换，但是因原版控件的局限性，实现效果不佳，故放弃
	//此类暂时废弃
	internal class Theme {
		internal enum Themes {
			light,dark
		}
		internal Themes CurrentTheme { get; set; } = Themes.light;
		private readonly ThemeColor[] themeColors = [
			new(){//light
				Form = new() {
					Background = Color.GhostWhite,
					Foreground = Color.Black
				},
				Button = new() {
					Background = Color.GhostWhite,
					Foreground = Color.Black,
					Broder = Color.Gray
				},
				TextBox=new(){
					Background = Color.GhostWhite,
					Foreground = Color.Black,
				}
			},
			new(){//dark
				Form = new() {
					Background = ColorTranslator.FromHtml("#212121"),
					Foreground = Color.GhostWhite
				},
				Button = new() {
					Background = Color.Black,
					Foreground = Color.GhostWhite,
					Broder = Color.Gray
				},
				TextBox=new(){
					Background = Color.Black,
					Foreground = Color.GhostWhite,
				}
			}
			];
		private struct ThemeColor {
			internal struct FormS {
				internal required Color Background { get; set; }
				internal required Color Foreground { get; set; }
			}
			internal required FormS Form { get; set; }
			internal struct ButtonS {
				internal required Color Background { get; set; }
				internal required Color Foreground { get; set; }
				internal required Color Broder { get; set; }
			}
			internal required ButtonS Button { get; set; }
			internal struct TextBoxS {
				internal required Color Background { get; set; }
				internal required Color Foreground { get; set; }
			}
			internal required TextBoxS TextBox { get; set; }
		}
		/// <summary>
		/// 更新当前主题
		/// </summary>
		/// <param name="form">窗体实例</param>			
		/// <param name="moreObj">更多对象，一般填入不是Form的子对象的目标</param>
		/// <exception cref="ArgumentException"></exception>
		internal void UpdateFormTheme(Form form, object[]? moreObj = null) {
			ArgumentNullException.ThrowIfNull(form);

			void FindAndDoAction(object obj) {
				void DoAction(dynamic obj) {
					void ApplyTheme(dynamic obj) {
						ThemeColor themeColor = themeColors[(int)CurrentTheme];
						if (obj is Form) {
							obj.BackColor = themeColor.Form.Background;
							obj.ForeColor = themeColor.Form.Foreground;
						}
						else {
							if (obj is Button) {
								//obj.FlatAppearance.BorderSize = 0;
								obj.FlatStyle = FlatStyle.Flat;
								obj.FlatAppearance.BorderColor = themeColor.Button.Broder;
								obj.BackColor = themeColor.Button.Background;
								obj.ForeColor = themeColor.Button.Foreground;
							}
							else if (obj is ComboBox or TextBox) {
								if(obj is TextBox)
									obj.BorderStyle = BorderStyle.FixedSingle;
								obj.BackColor = themeColor.TextBox.Background;
								obj.ForeColor = themeColor.TextBox.Foreground;
							}
							else {
								obj.BackColor = themeColor.Form.Background;
								obj.ForeColor = themeColor.Form.Foreground;
							}
						}
					}
					ApplyTheme(obj);
					if (obj.HasChildren) {
						FindAndDoAction(obj.Controls);
					}
				}
				if (obj is Control.ControlCollection controls) {
					foreach (Control con in controls) {
						DoAction(con);
					}
				}
				else if (obj is Form) {
					DoAction((Form)obj);
				}
			}

			FindAndDoAction(form);
			if (moreObj != null) {
				foreach (var obj in moreObj) {
					FindAndDoAction(obj);
				}
			}
		}
	}
}
