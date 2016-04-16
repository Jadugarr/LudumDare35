using System;

namespace AssemblyCSharp
{
	public class CheckHitEvent : IEvent
	{
		private WeaponType weaponType;

		public WeaponType WeaponType
		{
			get
			{
				return this.weaponType;
			}
		}

		public CheckHitEvent (WeaponType weaponType)
		{
			this.weaponType = weaponType;
		}
	}
}

