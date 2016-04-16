using System;
using UnityEngine;

namespace AssemblyCSharp
{
	public class ObjectHitEvent : IEvent
	{
		private GameObject gameObject;

		public GameObject HitObject
		{
			get
			{
				return this.gameObject;
			}
		}

		public ObjectHitEvent (GameObject gameObject)
		{
			this.gameObject = gameObject;
		}
	}
}

