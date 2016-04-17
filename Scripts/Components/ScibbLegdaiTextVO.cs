using System;
using System.Collections.Generic;

namespace AssemblyCSharp
{
	public class ScibbLegdaiTextVO : IMonsterTextVO
	{
		private List<string> standardLines;
		private string defeatLine;

		public ScibbLegdaiTextVO ()
		{
			this.standardLines = new List<string> () {
				"I train my arms every day to beat meatbags like you!",
				"My upper body is perfect! Cuz I'm CUTting, bro.",
				"You can't sweep me off my FEET!"
			};
			this.defeatLine = "But they told me it's okay to skip leg day!";
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

