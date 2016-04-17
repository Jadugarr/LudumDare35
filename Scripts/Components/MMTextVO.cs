using System;
using System.Collections.Generic;

namespace AssemblyCSharp
{
	public class MMTextVO : IMonsterTextVO
	{
		private List<string> standardLines;
		private string defeatLine;

		public MMTextVO ()
		{
			this.standardLines = new List<string> () {
				"This... isn't half bad! :D",
				"The weight got less but I couldn't care less. :|",
				"There is always one who has to suffer for the wellbeing of others."
			};
			this.defeatLine = "Nothing good in life lasts forever! Q_Q";
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

