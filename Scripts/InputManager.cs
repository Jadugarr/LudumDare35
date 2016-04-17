using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class InputManager : MonoBehaviour {

	private EventManager eventManager = EventManager.Instance;

	private bool active = true;

	void Awake()
	{
		AddEventListeners ();
	}

	// Update is called once per frame
	void Update () {
		if(active)
		{
			CheckInput ();
		}
	}

	void OnDestroy()
	{
		RemoveEventListeners ();
	}

	private void AddEventListeners()
	{
		eventManager.RegisterForEvent (EventTypes.KillMonster, OnKillMonster);
		eventManager.RegisterForEvent (EventTypes.MonsterKilled, OnMonsterKilled);
	}

	private void RemoveEventListeners()
	{
		eventManager.RemoveFromEvent (EventTypes.KillMonster, OnKillMonster);
		eventManager.RemoveFromEvent (EventTypes.MonsterKilled, OnMonsterKilled);
	}

	private void CheckInput()
	{
		if(Input.GetKeyDown(KeyCode.Alpha1) == true)
		{
			eventManager.FireEvent (EventTypes.CheckHit, new CheckHitEvent(WeaponType.Crab));
		}
		if(Input.GetKeyDown(KeyCode.Alpha2) == true)
		{
			eventManager.FireEvent (EventTypes.CheckHit, new CheckHitEvent(WeaponType.Elephant));
		}
		if(Input.GetKeyDown(KeyCode.Alpha3) == true)
		{
			eventManager.FireEvent (EventTypes.CheckHit, new CheckHitEvent(WeaponType.Mantis));
		}
	}

	private void OnKillMonster(IEvent evt)
	{
		this.active = false;
	}

	private void OnMonsterKilled(IEvent evt)
	{
		this.active = true;
	}
}
