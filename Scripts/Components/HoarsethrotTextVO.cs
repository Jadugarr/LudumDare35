using System;
using System.Collections.Generic;

namespace AssemblyCSharp
{
	public class HoarsethrotTextVO : IMonsterTextVO
	{
		private List<string> standardLines;
		private string defeatLine;

		public HoarsethrotTextVO ()
		{
			this.standardLines = new List<string> () {
				"HEY! YOUR END IS NEIGH! *cough*",
				"*cough* MY STRONG BODY *cough* HAS NO WEAKNESS!",
				"I WILL GALLOP OVER Y- *cough* *cough* *cough*"
			};
			this.defeatLine = "Neeeeeiiiiigh!";
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

