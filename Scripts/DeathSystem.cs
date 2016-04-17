using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class DeathSystem : MonoBehaviour 
{
	private const float xRange = 0.05f;
	private const float yRange = 0.05f;

	private EventManager eventManager = EventManager.Instance;
	private float deathTimer = 2f;

	private float currentDeathTime = 0f;
	private bool currentlyKillingEnemy = false;
	private GameObject monsterToKill;
	private Vector2 deathPosition;

	private DeathSystem(){
	}

	void Update()
	{
		if(currentlyKillingEnemy)
		{
			currentDeathTime += Time.deltaTime;
			ShakeMonster ();
			if(currentDeathTime >= deathTimer)
			{
				KillObject (this.monsterToKill);
				this.currentDeathTime = 0f;
				this.currentlyKillingEnemy = false;
			}
		}
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

	private void ShakeMonster()
	{
		Vector2 newPosition = new Vector2 (
			                      this.deathPosition.x + Random.Range (-xRange, xRange),
			                      this.deathPosition.y + Random.Range (-yRange, yRange)
		                      );
		this.monsterToKill.transform.position = newPosition;
	}

	private void OnKillMonster(IEvent evtArgs)
	{
		KillMonsterEvent evt = (KillMonsterEvent)evtArgs;

		this.monsterToKill = evt.Monster;
		this.deathPosition = evt.Monster.transform.position;
		this.currentlyKillingEnemy = true;
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
