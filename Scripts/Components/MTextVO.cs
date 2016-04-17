using System;
using System.Collections.Generic;

namespace AssemblyCSharp
{
	public class MTextVO : IMonsterTextVO
	{
		private List<string> standardLines;
		private string defeatLine;

		public MTextVO ()
		{
			this.standardLines = new List<string> () {
				"I am finally happy! :D",
				"Is this what normal life feels like? :D",
				"Nothing can whipe this smile off my face! :D",
			};
			this.defeatLine = "Why must life be nothing but suffering?! Q_Q";
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

