using System;
using UnityEngine;

namespace AssemblyCSharp
{
	public class KillMonsterEvent : IEvent
	{
		private GameObject monster;

		public GameObject Monster
		{
			get
			{
				return this.monster;
			}
		}

		public KillMonsterEvent (GameObject monster)
		{
			this.monster = monster;
		}
	}
}

