using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class SpriteShadeConfig : MonoBehaviour 
{
	public SpriteRenderer spriteRenderer;
	public Color visibleColor;

	private EventManager eventManager = EventManager.Instance;

	void Awake()
	{
		AddEventListeners ();
	}

	private void AddEventListeners()
	{
		eventManager.RegisterForEvent (EventTypes.MonsterReachedDestination, OnMonsterDestinationReached);
	}

	private void RemoveEventListeners()
	{
		eventManager.RemoveFromEvent (EventTypes.MonsterReachedDestination, OnMonsterDestinationReached);
	}

	private void OnMonsterDestinationReached(IEvent evtArgs)
	{
		MonsterReachedDestinationEvent evt = (MonsterReachedDestinationEvent)evtArgs;

		if(evt.Monster == this.gameObject)
		{
			this.spriteRenderer.color = this.visibleColor;
		}
	}

	void OnDestroy()
	{
		RemoveEventListeners ();	
	}
}
