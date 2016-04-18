using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using AssemblyCSharp;

public class PointSystem : MonoBehaviour 
{

    public Text pointText;
	private EventManager eventManager = EventManager.Instance;
	private MonsterPointsMap pointsMap = MonsterPointsMap.Instance;
	public static float points;
	private float comboMultiplier;

	void Awake()
	{
        this.pointText.text = "Score: 0";
        this.comboMultiplier = 1;
		AddEventListeners ();
	}

	void OnDestroy()
	{
		RemoveEventListeners ();
	}

	public PointSystem(){}

	private void AddEventListeners()
	{
		eventManager.RegisterForEvent (EventTypes.MonsterKilled, OnMonsterKilled);
		eventManager.RegisterForEvent (EventTypes.MonsterMissed, OnMonsterMissed);
	}

	private void RemoveEventListeners()
	{
		eventManager.RemoveFromEvent (EventTypes.MonsterKilled, OnMonsterKilled);
		eventManager.RemoveFromEvent (EventTypes.MonsterMissed, OnMonsterMissed);
	}

	private void OnMonsterKilled(IEvent evt)
	{
		MonsterKilledEvent evtArgs = (MonsterKilledEvent)evt;

		PointSystem.points += this.pointsMap.GetPointsByMonsterType (evtArgs.KilledMonster.GetComponent<MonsterTypeComponent>().monsterType) * this.comboMultiplier;
		this.comboMultiplier += 0.5f;
        this.pointText.text = "Score: " + PointSystem.points;
	}

	private void OnMonsterMissed(IEvent evt)
	{
		this.comboMultiplier = 1f;
	}
}
