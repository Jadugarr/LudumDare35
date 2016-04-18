using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class PointSystem : MonoBehaviour 
{
	private EventManager eventManager = EventManager.Instance;
	private MonsterPointsMap pointsMap = MonsterPointsMap.Instance;
	private float points;
	private float comboMultiplier;

	void Awake()
	{
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
		eventManager.RegisterForEvent (EventTypes.MonsterMissed, OnMonsterKilled);
	}

	private void RemoveEventListeners()
	{
		eventManager.RemoveFromEvent (EventTypes.MonsterKilled, OnMonsterKilled);
		eventManager.RemoveFromEvent (EventTypes.MonsterMissed, OnMonsterKilled);
	}

	private void OnMonsterKilled(IEvent evt)
	{
		MonsterKilledEvent evtArgs = (MonsterKilledEvent)evt;

		this.points += this.pointsMap.GetPointsByMonsterType (evtArgs.KilledMonster.GetComponent<MonsterTypeComponent>().monsterType) * this.comboMultiplier;
		this.comboMultiplier += 0.5f;
	}

	private void OnMonsterMissed(IEvent evt)
	{
		this.comboMultiplier = 1f;
	}
}
