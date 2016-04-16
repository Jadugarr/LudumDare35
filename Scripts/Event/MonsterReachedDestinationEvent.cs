using System;
using UnityEngine;

namespace AssemblyCSharp
{
	public class MonsterReachedDestinationEvent : IEvent
	{
		private GameObject monster;

		public GameObject Monster
		{
			get
			{
				return this.monster;
			}
		}

		public MonsterReachedDestinationEvent (GameObject monster)
		{
			this.monster = monster;
		}
	}
}

