using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using AssemblyCSharp;

public enum WeaponType
{
	Elephant,
	Mantis,
	Crab
}

public class WeaknessMap
{
	private static WeaknessMap instance = new WeaknessMap();
	private Dictionary<MonsterType,List<WeaponType>> weaknessMap = new Dictionary<MonsterType, List<WeaponType>>();

	public static WeaknessMap Instance
	{
		get
		{
			return WeaknessMap.instance;
		}
	}
	  

	private WeaknessMap()
	{
		this.weaknessMap = new Dictionary<MonsterType, List<WeaponType>> () {
			{ MonsterType.Mandible, new List<WeaponType> (){ WeaponType.Elephant } },
			{MonsterType.Weeknees, new List<WeaponType>(){WeaponType.Elephant, WeaponType.Mantis}},
			{MonsterType.LeviNomster, new List<WeaponType>(){WeaponType.Crab}},
			{MonsterType.ScibbLegdai, new List<WeaponType>(){WeaponType.Crab, WeaponType.Mantis}},
			{MonsterType.HarveyeEyetel, new List<WeaponType>(){WeaponType.Crab, WeaponType.Mantis}},
			{MonsterType.Hoarsethrot, new List<WeaponType>(){WeaponType.Crab, WeaponType.Elephant, WeaponType.Mantis}},
			{MonsterType.NottaReeskin, new List<WeaponType>(){WeaponType.Elephant}},
			{MonsterType.JohnWig, new List<WeaponType>(){WeaponType.Mantis}},
			{MonsterType.M, new List<WeaponType>(){WeaponType.Crab}},
			{MonsterType.MM, new List<WeaponType>(){WeaponType.Elephant}},
			{MonsterType.MMMs, new List<WeaponType>(){WeaponType.Mantis}}
		};
	}

	public bool IsMonsterWeakAgainstWeaponType(MonsterType monsterType, WeaponType weaponType)
	{
		List<WeaponType> weaknesses = new List<WeaponType>();

		if (this.weaknessMap.TryGetValue (monsterType,out weaknesses)) 
		{
			if(weaknesses != null && weaknesses.Contains(weaponType))
			{
				return true;
			}
		}

		return false;
	}

}
