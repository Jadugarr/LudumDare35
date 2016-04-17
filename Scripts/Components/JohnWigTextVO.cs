using System;
using System.Collections.Generic;

namespace AssemblyCSharp
{
	public class JohnWigTextVO : IMonsterTextVO
	{
		private List<string> standardLines;
		private string defeatLine;

		public JohnWigTextVO ()
		{
			this.standardLines = new List<string> () {
				"Can you sssee my new HAIR?",
				"It'sss perfect. Sssuperbebly CUT .",
				"I ssshould fight you but I can't look away from my exsstensssionsss."
			};
			this.defeatLine = "You are jussst jealousss!";
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

