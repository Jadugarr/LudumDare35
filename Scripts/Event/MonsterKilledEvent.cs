using System;
using UnityEngine;

namespace AssemblyCSharp
{
	public class MonsterKilledEvent : IEvent
	{
		private GameObject killedMonster;

		public GameObject KilledMonster
		{
			get
			{
				return this.killedMonster;
			}
		}

		public MonsterKilledEvent (GameObject killedMonster)
		{
			this.killedMonster = killedMonster;
		}
	}
}

