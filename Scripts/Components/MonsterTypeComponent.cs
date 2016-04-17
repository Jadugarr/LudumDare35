using System;
using UnityEngine;

namespace AssemblyCSharp
{
	public enum MonsterType
	{
		Mandible,
		Weeknees,
		LeviNomster,
		ScibbLegdai,
		MMMs,
		MM,
		M,
		NottaReeskin,
		JohnWig,
		HarveyeEyetel,
		Hoarsethrot
	}

	public class MonsterTypeComponent : MonoBehaviour
	{
		public MonsterType monsterType;
	}
}

