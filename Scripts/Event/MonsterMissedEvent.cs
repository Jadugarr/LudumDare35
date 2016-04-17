using System;
using UnityEngine;

namespace AssemblyCSharp
{
	public class MonsterMissedEvent : IEvent
	{
		private GameObject monster;

		public GameObject Monster
		{
			get
			{ 
				return this.monster;
			}
		}

		public MonsterMissedEvent (GameObject monster)
		{
			this.monster = monster;
		}
	}
}

