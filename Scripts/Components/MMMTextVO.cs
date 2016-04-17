using System;
using System.Collections.Generic;

namespace AssemblyCSharp
{
	public class MMMTextVO : IMonsterTextVO
	{
		private List<string> standardLines;
		private string defeatLine;

		public MMMTextVO ()
		{
			this.standardLines = new List<string> () {
				"Whee! I'M ON TOP OF THE WORLD! :D",
				"I am already dead inside. :|",
				"Why am I the bottom one? AGAIN?! :["
			};
			this.defeatLine = "Tumbling down, tumbling down! Q_Q";
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

