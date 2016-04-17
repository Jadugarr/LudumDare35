using System;
using System.Collections.Generic;

namespace AssemblyCSharp
{
	public class MandibleTextVO : IMonsterTextVO
	{
		private List<string> standardLines;
		private string defeatLine;

		public MandibleTextVO ()
		{
			this.standardLines = new List<string> () {
				"Beware! I'm really thick-HEADed.",
				"Don't even bother hitting my HEAD with BLUNT force.",
				"I once fought an Elephant and he, like, hit my HEAD and died, yaknow?"
			};
			this.defeatLine = "Joke's on you - I was only pretending!";
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

