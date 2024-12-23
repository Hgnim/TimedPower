using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
using static TimedPower.DataCore.DataFiles;
using static TimedPower.FilePath;

namespace TimedPower {
	public struct DataFile {
		/// <summary>
		/// 将配置数据保存至配置文件中
		/// </summary>
		internal static void SaveData() {
			ISerializer yamlS = new SerializerBuilder()
				.WithNamingConvention(CamelCaseNamingConvention.Instance)
				.Build();
			using StreamWriter sw = new(MainDataFile, false);
			sw.WriteLine("#注意，私自修改数据文件导致的程序错误开发者概不负责!");
			sw.Write(yamlS.Serialize(mainData));
		}
		/// <summary>
		/// 读取数据文件并将数据写入实例中
		/// </summary>
		internal static void ReadData() {
			IDeserializer yamlD = new DeserializerBuilder()
				.WithNamingConvention(CamelCaseNamingConvention.Instance)
					.Build();

			if (File.Exists(MainDataFile))
				mainData = yamlD.Deserialize<MainData>(File.ReadAllText(MainDataFile));
		}
		public struct MainData {
			public struct SmallPoint {
				public required int X { get; set; }
				public required int Y { get; set; }
			}
			public required bool First { get; set; }
			public required SmallPoint Window { get; set; }
			public required int Action { get; set; }
			public required int TimeType { get; set; }
			public required string TimeInput { get; set; }
			public required bool CloseToTaskBar {  get; set; }
			public required bool AutoCheckUpdate { get; set; }
		}
	}
}
