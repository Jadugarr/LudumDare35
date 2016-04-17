using System;
using System.Collections.Generic;

namespace AssemblyCSharp
{
	public class WeekneesTextVO : IMonsterTextVO
	{
		private List<string> standardLines;
		private string defeatLine;

		public WeekneesTextVO ()
		{
			this.standardLines = new List<string> () {
				"H-...hi... *KNEES shaking*",
				"Y- you're... kinda CUTe.",
				"You make my KNEES go weak. *blushes*"
			};
			this.defeatLine = "Ow! Why must you hurt me so much?!";
		}

		public List<string> GetStandardLines {
			get {
				return this.standardLines;
			}
		}

		public string GetDefeatLine {
			get {
				return this.defeatLine;
			}
		}
	}
}

