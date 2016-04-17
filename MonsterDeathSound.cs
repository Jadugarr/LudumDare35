using UnityEngine;
using System.Collections;

public class MonsterDeathSound : MonoBehaviour 
{
	public AudioSource source;
	public AudioClip monsterDeathClip;

	private EventManager eventManager = EventManager.Instance;
	
	void Awake()
	{
		AddEventListeners ();
	}

	private void AddEventListeners()
	{
		this.eventManager.RegisterForEvent (EventTypes.MonsterKilled, OnMonsterKilled);
	}

	private void RemoveEventListeners()
	{
		this.eventManager.RemoveFromEvent (EventTypes.MonsterKilled, OnMonsterKilled);
	}

	private void OnMonsterKilled(IEvent evt)
	{
		this.source.clip = this.monsterDeathClip;
		this.source.Play ();
	}

	void OnDestroy()
	{
		RemoveEventListeners();
	}
}
