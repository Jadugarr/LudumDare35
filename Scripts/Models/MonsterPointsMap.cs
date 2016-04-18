using System;
using System.Collections.Generic;

namespace AssemblyCSharp
{
	public class MonsterPointsMap
	{
		private static MonsterPointsMap instance = new MonsterPointsMap();
		public static MonsterPointsMap Instance
		{
			get
			{
				return MonsterPointsMap.instance;
			}
		}

		private Dictionary<MonsterType, int> pointMap;

		private MonsterPointsMap ()
		{
			this.pointMap = new Dictionary<MonsterType, int> () {
				{ MonsterType.HarveyeEyetel, 50 },
				{ MonsterType.Hoarsethrot, 50 },
				{ MonsterType.JohnWig, 50 },
				{ MonsterType.LeviNomster, 50 },
				{ MonsterType.M, 50 },
				{ MonsterType.Mandible, 50 },
				{ MonsterType.MM, 50 },
				{ MonsterType.MMMs, 50 },
				{ MonsterType.NottaReeskin, 50 },
				{ MonsterType.ScibbLegdai, 50 },
				{ MonsterType.Weeknees, 50 }
			};
		}

		public int GetPointsByMonsterType(MonsterType monsterType)
		{
			return this.pointMap [monsterType];
		}
	}
}

