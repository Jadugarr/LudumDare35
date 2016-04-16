using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class DeathSystem : MonoBehaviour 
{
	private EventManager eventManager = EventManager.Instance;

	private DeathSystem(){
	}

	void Awake()
	{
		AddEventListeners ();
	}

	private void AddEventListeners()
	{
		eventManager.RegisterForEvent (EventTypes.KillMonster, OnKillMonster);
	}

	private void RemoveEventListeners()
	{
		eventManager.RemoveFromEvent (EventTypes.KillMonster, OnKillMonster);
	}

	private void OnKillMonster(IEvent evtArgs)
	{
		KillMonsterEvent evt = (KillMonsterEvent)evtArgs;

		KillObject (evt.Monster);
	}

	private void KillObject(GameObject enemy)
	{
		eventManager.FireEvent (EventTypes.MonsterKilled, new MonsterKilledEvent(enemy));
		DestroyObject (enemy);
	}

	private void OnDestroy()
	{
		RemoveEventListeners ();
	}
}
