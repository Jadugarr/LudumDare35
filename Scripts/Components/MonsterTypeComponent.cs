using System;
using UnityEngine;

namespace AssemblyCSharp
{
	public enum MonsterType
	{
		Mandible,
		Weeknees,
		LeviNomster
	}

	public class MonsterTypeComponent : MonoBehaviour
	{
		public MonsterType monsterType;
	}
}

