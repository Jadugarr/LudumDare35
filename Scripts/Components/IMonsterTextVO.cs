using System;
using System.Collections.Generic;

namespace AssemblyCSharp
{
	public interface IMonsterTextVO
	{
		List<string> GetStandardLines { get; }
		string GetDefeatLine { get; }
	}
}

