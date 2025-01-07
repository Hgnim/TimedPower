using Microsoft.Win32;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Xml.Linq;
using static TimedPower.DataCore.LanguageData.Language;

namespace TimedPower {
	public struct DataCore {
		internal readonly struct PInfo {
			internal const string alias = "定时电源";
			internal const string name = "TimedPower";
			public const string version = "2.7.7.20250106-pre2";
			public static string ShortVersion {
				get {
					string[] v = version.Split('.');
					return $"{v[0]}.{v[1]}.{v[2]}";
				}
			}
			public static uint ShortVersionNum {
				get {
					string[] v = version.Split('.');
					return uint.Parse($"{v[0]}{v[1]}{v[2]}");
				}
			}
			internal const string githubUrl = "https://github.com/Hgnim/TimedPower";
			internal const string githubWiki = "https://github.com/Hgnim/TimedPower/wiki";
			internal const string copyright = "Copyright (C) 2024-2025 Hgnim, All rights reserved.";
		}

		internal struct DataFiles {
			public static DataFile.MainData mainData;
			public static DataFile.StatsData statsData;
		}


		internal readonly struct FilePath {
			internal static readonly string thisExeFilePath = System.Windows.Forms.Application.ExecutablePath;

			internal static readonly string ConfigDir = $"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\\{PInfo.name}\\";//踩坑提醒，之前该字符串使用@$前缀，而其中的\会将{转义，报出非常莫名其妙毫不相干的错误，在此作为提醒。
			internal static readonly string MainDataFile = ConfigDir + "data.yml";
			internal static readonly string MainDataFile_Obsolete = ConfigDir + "data.xml";
			internal static readonly string AutoTaskFile = ConfigDir + "autoTask.xml";
			internal static readonly string StatsDataFile = ConfigDir + "stats.yml";

			internal static readonly string TempDir = System.IO.Path.GetTempPath() + @$"{PInfo.name}\";
			internal static readonly string CommandDir = @$"{TempDir}Command\";
			internal static readonly string commandFile = CommandDir + "Command.dat";

			internal const string ResourceDir = "TimedPower.Resources";
			internal const string MainLanguageFile = ResourceDir + ".langs.language";
		}
		internal readonly struct RegPath {
			internal readonly struct CU {
				internal static RegistryKey root = Registry.CurrentUser;
				internal static string ContextMenuPath = @"Software\Classes\Directory\Background\shell\" + PInfo.name;
				internal static string SelfStartingKey = @"Software\Microsoft\Windows\CurrentVersion\Run\" + PInfo.name;
			}
		}

		public struct LanguageData {
			public readonly struct Language {
				public enum Langs {
					zh_cn,
					en_us
				}
				private static readonly Dictionary<Langs, string> dict = new() {
					{ Langs.zh_cn, "zh-cn" },
					{ Langs.en_us, "en-us" },
				};
				internal static string GetString(Langs value) => 
					dict.TryGetValue(value, out string? stringValue)
						? stringValue
						: throw new ArgumentException("Invalid enum value");
				internal static Langs GetValue(string str) {
					Langs? lang = null;
					lang= dict.FirstOrDefault(x => x.Value == str).Key;
					return lang != null
						? (Langs)lang 
						: throw new ArgumentException("Invalid string value");
				}
			}

			/// <summary>
			/// 更改语言<br/>
			/// 在调用此方法更改语言后再进行资源更新
			/// </summary>
			/// <param name="lang">更改的语言</param>
			internal static void ChangeLanguage(Language.Langs lang) =>
				Thread.CurrentThread.CurrentUICulture = new CultureInfo(Language.GetString(lang));
			internal static Language.Langs GetLanguage() =>
				Language.GetValue(CultureInfo.CurrentUICulture.ToString().ToLower());
			/// <summary>
			/// 更新资源
			/// </summary>
			/// <param name="langResource">语言资源。输出更改后的语言资源</param>
			/// <param name="resourcePath">资源路径</param>
			internal static void UpdateLanguageResource(out ResourceManager langResource, string resourcePath) => 
				langResource = new(resourcePath, Assembly.GetExecutingAssembly());
			/// <summary>
			/// 获取资源，与更新资源同理
			/// </summary>
			/// <param name="resourcePath">资源路径</param>
			/// <returns></returns>
			internal static ResourceManager GetLanguageResource(string resourcePath)=> new(resourcePath, Assembly.GetExecutingAssembly());
			/// <summary>
			/// 更新语言资源
			/// </summary>
			/// <param name="form">窗体实例</param>			
			/// <param name="moreObj">更多对象，一般填入不是Form的子对象的目标</param>
			/// <exception cref="ArgumentException"></exception>
			internal static void UpdateFormLanguage(Form form, object[]? moreObj = null) {
				static void ApplyResourcesToControls(object obj, ComponentResourceManager resources) {
					///执行操作
					static void DoAction(dynamic obj, ComponentResourceManager resources) {
						//if (obj is not Form) {
							if (obj is not CustomObjName) {
								resources.ApplyResources(obj, obj.Name);
							}
							else {
								//自定义属性名的对象类型操作
								resources.ApplyResources(obj.Obj, obj.Name);
								obj = obj.Obj;
							}
						//}
						if (obj is not NotifyIcon) {
							if (obj.HasChildren) {
								ApplyResourcesToControls(obj.Controls, resources);
							}
						}
						if(obj is ComboBox) {
							int itemNum=obj.Items.Count;
							int itemSel = obj.SelectedIndex;//保存先前已经选择的选项
							obj.Items.Clear();
							for(int i = 0; i < itemNum; i++) {
								string key = $"{obj.Name}.Items";
								if (i != 0) key += i.ToString();
								obj.Items.Add(resources.GetString(key, CultureInfo.CurrentUICulture)!);
							}
							obj.SelectedIndex = itemSel;
						}
						//检查是否包含右键菜单
						if (obj.ContextMenuStrip != null) {
							static void ApplyResourcesToContextMenuItems(ToolStripItemCollection items, ComponentResourceManager resources) {
								foreach (ToolStripItem item in items) {
									resources.ApplyResources(item, item.Name!);
									if (item is ToolStripMenuItem menuItem && menuItem.DropDownItems.Count > 0) {
										ApplyResourcesToContextMenuItems(menuItem.DropDownItems, resources);
									}
								}
							}
							//有则将其对象的子项目进行资源应用
							ApplyResourcesToContextMenuItems(obj.ContextMenuStrip.Items, resources);
						}
					}
					if (obj is Control.ControlCollection controls) {
						foreach (Control con in controls) {
							DoAction(con, resources);
						}
					}else if(obj is Form) {
						resources.ApplyResources(obj, "$this");
						DoAction(obj, resources);
					}
					else if(obj is CustomObjName) {
						DoAction(obj, resources);
					}
					else
						throw new ArgumentException("未找到处理此类型所需的合适方法", nameof(obj));
				}
				
				ArgumentNullException.ThrowIfNull(form);
				ComponentResourceManager resources = new(form.GetType());
				ApplyResourcesToControls(form, resources);
				if (moreObj != null) {
					foreach (object obj in moreObj) {
						ApplyResourcesToControls(obj, resources);
					}
				}
			}
			/// <summary>
			/// 为那些实例化中没有名字(Name属性)的对象准备的结构，手动赋予其名字
			/// </summary>
			internal struct CustomObjName {
				public required string Name { get; set; }
				public required dynamic Obj { get; set; }
			}
		}
	}
}
