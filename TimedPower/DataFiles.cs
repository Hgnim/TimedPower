using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
using static TimedPower.DataCore.DataFiles;
using static TimedPower.DataCore.FilePath;

namespace TimedPower {
	public struct DataFile {
		/// <summary>
		/// 将配置数据保存至配置文件中
		/// </summary>
		internal static void SaveData() {
			ISerializer yamlS = new SerializerBuilder()
				.WithNamingConvention(CamelCaseNamingConvention.Instance)
				.Build();
			using (StreamWriter sw = new(MainDataFile, false)) {
				sw.WriteLine("#注意，私自修改数据文件导致的程序错误开发者概不负责!");
				sw.Write(yamlS.Serialize(mainData));
			}
			using (StreamWriter sw = new(StatsDataFile, false)) {
				sw.WriteLine("#注意，私自修改数据文件导致的程序错误开发者概不负责!");
				sw.Write(yamlS.Serialize(statsData));
			}
		}
		/// <summary>
		/// 读取数据文件并将数据写入实例中
		/// </summary>
		internal static void ReadData() {
			IDeserializer yamlD = new DeserializerBuilder()
				.IgnoreUnmatchedProperties()//忽略不匹配错误
				.WithNamingConvention(CamelCaseNamingConvention.Instance)
				.Build();

			if (File.Exists(MainDataFile))
				mainData = yamlD.Deserialize<MainData>(File.ReadAllText(MainDataFile));
			if(File.Exists(StatsDataFile))
				statsData= yamlD.Deserialize<StatsData>(File.ReadAllText(StatsDataFile));
		}
		public struct MainData {
			public required bool First { get; set; }
			public struct SmallPoint {
				public required int X { get; set; }
				public required int Y { get; set; }
			}
			public required SmallPoint Window { get; set; }
			public required int Action { get; set; }
			public required int TimeType { get; set; }
			public required string TimeInput { get; set; }
			public struct SettingS {
				public required bool CloseToTaskBar { get; set; }
				public required bool AutoCheckUpdate { get; set; }
				public required DataCore.LanguageData.Language.Langs Language { get; set; }
				public required TimedPower.Theme.Themes Theme { get; set; }
			}
			public required SettingS Setting {  get; set; }
			public required uint Version { get; set; }

			public MainData() {
				First = true;
				Window = new() { X = 0, Y = 0 };
				Action = 0;
				TimeType = 0;
				TimeInput = "";
				Setting = new() {
					CloseToTaskBar = true,
					AutoCheckUpdate = true,
					Language=DataCore.LanguageData.Language.Langs.zh_cn,
					Theme = Theme.Themes.sysDef
				};
				Version = 0;
			}
		}
		public struct StatsData {
			public required int StartNum { get; set; }
			public required int DoActionNum { get; set; }
			public StatsData() {
				StartNum = 0;
				DoActionNum = 0;
			}
		}
	}
	public struct TimedPowerTask {
		public enum TaskTimeType {
			after//在此之后
			, ontime//在此时
		}
		public enum TaskAction {
			shutdown, reboot, useroff, userlock, sleep, hibernate
		}
		public class TPT {
			public required TaskAction Action { get; set; }
			public required string Time { get; set; }
			public required TaskTimeType TimeType { get; set; }
			public required uint FileVersion { get; set; }
			private bool littleTimeWarning = true;
			public bool LittleTimeWarning {
				get => littleTimeWarning;
				set => littleTimeWarning = value;
			}
		}
		internal static TPT? TPTRead(string filePath) {
			IDeserializer yamlD = new DeserializerBuilder()
				.WithNamingConvention(UnderscoredNamingConvention.Instance)
					.Build();

			return 
				File.Exists(filePath) 
				? yamlD.Deserialize<TPT>(File.ReadAllText(filePath)) 
				: null;
		}
		internal static void TPTSave(string filePath, TPT data) {
			ISerializer yamlS = new SerializerBuilder()
				.WithNamingConvention(UnderscoredNamingConvention.Instance)
				.Build();

			File.WriteAllText(filePath, yamlS.Serialize(data));
		}
	}
}
