using System;
using System.Collections.Generic;
using UnityEngine;

namespace AssemblyCSharp
{
	public class MonsterTextModel
	{
		private static MonsterTextModel instance = new MonsterTextModel();

		public static MonsterTextModel Instance
		{
			get
			{
				return MonsterTextModel.instance;
			}
		}

		private Dictionary<MonsterType,IMonsterTextVO> textMap; 

		private MonsterTextModel ()
		{
			CreateTextMap ();
		}

		private void CreateTextMap()
		{
			this.textMap = new Dictionary<MonsterType, IMonsterTextVO> ()
			{
				{MonsterType.HarveyeEyetel, new HarveyeTextVO()},
				{MonsterType.Hoarsethrot, new HoarsethrotTextVO()},
				{MonsterType.JohnWig, new JohnWigTextVO()},
				{MonsterType.LeviNomster, new LeviNomsterTextVO()},
				{MonsterType.M, new MTextVO()},
				{MonsterType.MM, new MMTextVO()},
				{MonsterType.MMMs, new MMMTextVO()},
				{MonsterType.Mandible, new MandibleTextVO()},
				{MonsterType.NottaReeskin, new NottaReeskinTextVO()},
				{MonsterType.ScibbLegdai, new ScibbLegdaiTextVO()},
				{MonsterType.Weeknees, new WeekneesTextVO()}
			};
		}

		public IMonsterTextVO GetMonsterTextVO(MonsterType monsterType)
		{
			IMonsterTextVO textVO;

			if(this.textMap.TryGetValue(monsterType, out textVO) == false)
			{
				Debug.LogError ("No TextVO for " + monsterType.ToString());
			}

			return textVO;
		}
	}
}

