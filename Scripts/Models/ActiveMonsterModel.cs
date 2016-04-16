using UnityEngine;
using System.Collections;

public class ActiveMonsterModel : MonoBehaviour 
{
	private static ActiveMonsterModel instance = new ActiveMonsterModel();

	public GameObject activeMonster;

	public static ActiveMonsterModel Instance
	{
		get
		{
			return ActiveMonsterModel.instance;
		}
	}

	private ActiveMonsterModel(){
	}
}
