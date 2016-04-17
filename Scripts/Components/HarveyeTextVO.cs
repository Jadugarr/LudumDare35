using System;
using System.Collections.Generic;

namespace AssemblyCSharp
{
	public class HarveyeTextVO : IMonsterTextVO
	{
		private List<string> standardLines;
		private string defeatLine;

		public HarveyeTextVO ()
		{
			this.standardLines = new List<string> () {
				"EYE can see you.",
				"Prepare to dEYE!",
				"Okay seriously don't POKE it, please. It's pretty sensible."
			};
			this.defeatLine = "WHEEEEEYE?!";
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

