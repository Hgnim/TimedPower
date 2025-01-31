using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TimedPower.DataCore.LanguageData.Language;
using System.Resources;
using static TimedPower.DataCore;
using static TimedPower.DataCore.DataFiles;
using Markdig;
using static TimedPower.DataFile;

namespace TimedPower {
	internal class About {
		internal About() =>
			UpdateLanguageResource();

		ResourceManager langRes = null!;
		string GetLangStr(string key, string head = "about") => langRes.GetString($"{head}.{key}", CultureInfo.CurrentUICulture)!;
		void UpdateLanguageResource() => LanguageData.UpdateLanguageResource(out langRes, FilePath.MainLanguageFile);

		static string VersionColorAdd() {
			if (!PInfo.version.Contains('-', StringComparison.CurrentCulture))
				return "unset";

			if (PInfo.version.Contains("pre", StringComparison.CurrentCulture))
				return "yellow";
			else if (PInfo.version.Contains("debug", StringComparison.CurrentCulture))
				return "red";
			else
				return "unset";
		}
		internal void Show() =>
			 new HtmlMessageBox(
				Markdown.ToHtml(
					string.Format(GetLangStr("main"),
									PInfo.copyright,
									PInfo.Alias,
									$"V{PInfo.version}",
									PInfo.githubUrl,
									string.Format(GetLangStr("stats"),
														statsData.StartNum,
														statsData.DoActionNum)
								)
					)+
@$"
<style>
	.version-color{{
		color: {VersionColorAdd()};
	}}
</style>
",
				[
					new(){Text=GetLangStr("button.ok")}
				],
				GetLangStr("title"),
				formSize:new(470,411),
				userCanChangeFormSize: true
				)
				.ShowDialog();
	}
}
