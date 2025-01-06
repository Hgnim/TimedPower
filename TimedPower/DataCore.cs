using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimedPower {
	internal readonly struct PInfo {
		internal const string name = "TimedPower";
		public const string version = "2.7.7.20250104-pre1";
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
		public const string aboutText =
@$"程序名: 定时电源
别名: {name}
版本: V{version}
Copyright (C) 2024-2025 Hgnim, All rights reserved.
Github: {githubUrl}";
	}
	internal struct DataCore {
		internal struct DataFiles {
			public static DataFile.MainData mainData = new() {
				First = true,
				Window = new() { X = 0, Y = 0 },
				Action = 0,
				TimeType = 0,
				TimeInput = "",
				CloseToTaskBar = true,
				AutoCheckUpdate = true,
				Version = 0
			};
		}
	}
	internal readonly struct FilePath {
		internal static readonly string thisExeFilePath = System.Windows.Forms.Application.ExecutablePath;

		internal static readonly string ConfigDir = $"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\\{PInfo.name}\\";//踩坑提醒，之前该字符串使用@$前缀，而其中的\会将{转义，报出非常莫名其妙毫不相干的错误，在此作为提醒。
		internal static readonly string MainDataFile = ConfigDir + "data.yml";
		internal static readonly string MainDataFile_Obsolete = ConfigDir + "data.xml";
		internal static readonly string AutoTaskFile = ConfigDir + "autoTask.xml";

		internal static readonly string TempDir = System.IO.Path.GetTempPath() + @$"{PInfo.name}\";
		internal static readonly string CommandDir = @$"{TempDir}Command\";
		internal static readonly string commandFile = CommandDir + "Command.dat";
	}
	internal readonly struct RegPath {
		internal readonly struct CU {
			internal static RegistryKey root= Registry.CurrentUser;
			internal static string ContextMenuPath = @"Software\Classes\Directory\Background\shell\" +PInfo.name;
			internal static string SelfStartingKey = @"Software\Microsoft\Windows\CurrentVersion\Run\"+ PInfo.name;
		}
	}
}
