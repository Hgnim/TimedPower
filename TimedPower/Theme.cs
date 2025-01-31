using Microsoft.Win32;
using ReaLTaiizor.Enum.Poison;
using ReaLTaiizor.Manager;

namespace TimedPower {
	public class Theme {
		public enum Themes {
			sysDef,light,dark
		}
		internal Themes CurrentTheme { 
			get=>currentTheme;
			set {
				currentTheme = value;
				UpdateTheme?.Invoke();
			}
		}
		/// <summary>
		/// 获取当前主题的绝对值
		/// </summary>
		internal Themes CurrentThemeValue => currentTheme == Themes.sysDef ? GetSystemTheme() : currentTheme;

		Themes currentTheme = Themes.sysDef;
		internal event Action? UpdateTheme;
		/// <summary>
		/// 更新当前主题
		/// </summary>
		/// <param name="themeManager">当前窗体的主题管理对象</param>	
		/// <exception cref="ArgumentException"></exception>
		internal void UpdateFormTheme(ref PoisonStyleManager themeManager) => 
			themeManager.Theme = (ThemeStyle)(CurrentThemeValue);

		Themes? systemTheme = null;
		/// <summary>
		/// 获取系统主题
		/// </summary>
		/// <returns></returns>
		public Themes GetSystemTheme() {
			if (systemTheme != null)
				return (Themes)systemTheme;//如果已经获取过则直接返回，节省资源
			else {
				using (RegistryKey? key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Themes\Personalize")) {
					if (key != null) {
						switch ((int)key.GetValue("AppsUseLightTheme", -1)) {
							case 0:
								systemTheme = Themes.dark;break;
							case 1:
								systemTheme = Themes.light;break;
						}
					}
				}
				systemTheme ??= Themes.light;

				return (Themes)systemTheme;
			}
		}
	}
}
