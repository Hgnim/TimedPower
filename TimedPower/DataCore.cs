using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimedPower {
	internal struct DataCore {
		internal struct DataFiles {
			public static DataFile.MainData mainData=new() {
				First = true,
				Window = new() { X=0,Y=0},
				Action = 0,
				TimeType = 0,
				TimeInput = "",
				CloseToTaskBar = true,
				AutoCheckUpdate = true
			};
		}
	}
	internal readonly struct FilePath {
		

		internal static readonly string ConfigDir = $"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\\{PInfo.name}\\";//踩坑提醒，之前该字符串使用@$前缀，而其中的\会将{转义，报出非常莫名其妙毫不相干的错误，在此作为提醒。
		internal static readonly string MainDataFile = ConfigDir + "data.yml";
		internal static readonly string MainDataFile_Obsolete = ConfigDir + "data.xml";
		internal static readonly string AutoTaskFile = ConfigDir + "autoTask.xml";

		internal static readonly string TempDir = System.IO.Path.GetTempPath() + @$"{PInfo.name}\";
		internal static readonly string CommandDir = @$"{TempDir}Command\";
		internal static readonly string commandFile = CommandDir + "Command.dat";
	}
}
