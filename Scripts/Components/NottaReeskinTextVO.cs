using System;
using System.Collections.Generic;

namespace AssemblyCSharp
{
	public class NottaReeskinTextVO : IMonsterTextVO
	{
		private List<string> standardLines;
		private string defeatLine;

		public NottaReeskinTextVO ()
		{
			this.standardLines = new List<string> () {
				"I will avenge my brother!",
				"He was the only one who ever loved me!",
				"What did you just say about my name?!"
			};
			this.defeatLine = "No one really loves me and it's killing me inside!";
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

