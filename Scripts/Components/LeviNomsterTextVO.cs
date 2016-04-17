using System;
using System.Collections.Generic;

namespace AssemblyCSharp
{
	public class LeviNomsterTextVO : IMonsterTextVO
	{
		private List<string> standardLines;
		private string defeatLine;

		public LeviNomsterTextVO ()
		{
			this.standardLines = new List<string> () {
				"I will eat you, meany human!",
				"My STOMACH is ready!",
				"I hate SEAFOOD, though."
			};
			this.defeatLine = "Urgh! Food fight... lost.";
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

