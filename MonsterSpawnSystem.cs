using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using AssemblyCSharp;

public class MonsterSpawnSystem : MonoBehaviour 
{
	public GameObject MonsterStartPoint;
	public GameObject MonsterWaitingPoint;
	public List<GameObject> templateMonsters = new List<GameObject> ();
	public float spawnTimer;
	public float monsterSpeed;

	private EventManager eventManager = EventManager.Instance;
	private List<GameObject> currentlySpawnedMonsters = new List<GameObject>();
	private bool spawningActive = true;
	private float currentSpawnTime = 0f;
	private GameObject currentActiveMonster;

	private MonsterSpawnSystem(){
	}

	void Awake()
	{
		AddEventListeners ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(spawningActive)
		{
			currentSpawnTime += Time.deltaTime;

			MoveMonsters (Time.deltaTime);
			if (currentSpawnTime >= spawnTimer) 
			{
				currentSpawnTime = 0f;
				SpawnMonster ();
			}
		}
	}

	private void MoveMonsters(float deltaTime)
	{
		foreach (GameObject currentMonster in currentlySpawnedMonsters) 
		{
			Vector2 direction = new Vector2(monsterSpeed * deltaTime, 0);
			currentMonster.transform.Translate (direction);
			if(currentMonster.transform.position.x <= this.MonsterWaitingPoint.transform.position.x)
			{
				eventManager.FireEvent (EventTypes.MonsterReachedDestination, new MonsterReachedDestinationEvent(currentMonster));
			}
		}
	}

	private void SpawnMonster()
	{
		int randomIndex = Random.Range (0, this.templateMonsters.Count);
		GameObject monsterToSpawn = this.templateMonsters [randomIndex];

		GameObject spawnedMonster = (GameObject)Instantiate (monsterToSpawn, this.MonsterStartPoint.transform.position, this.MonsterStartPoint.transform.rotation);
		this.currentlySpawnedMonsters.Add (spawnedMonster);
	}

	private void AddEventListeners()
	{
		eventManager.RegisterForEvent (EventTypes.MonsterReachedDestination, OnMonsterReachedDestination);
		eventManager.RegisterForEvent (EventTypes.MonsterKilled, OnMonsterKilled);
		eventManager.RegisterForEvent (EventTypes.ObjectHit, OnObjectHit);
	}

	private void OnMonsterReachedDestination(IEvent evtArgs)
	{
		spawningActive = false;

		MonsterReachedDestinationEvent evt = (MonsterReachedDestinationEvent)evtArgs;
		this.currentActiveMonster = evt.Monster;
	}

	private void OnMonsterKilled(IEvent evtArgs)
	{
		spawningActive = true;

		MonsterKilledEvent evt = (MonsterKilledEvent)evtArgs;
		this.currentlySpawnedMonsters.Remove (evt.KilledMonster);
		this.currentActiveMonster = null;
	}

	private void OnObjectHit(IEvent evtArgs)
	{
		ObjectHitEvent evt = (ObjectHitEvent)evtArgs;

		if(evt.HitObject.transform.parent.gameObject == this.currentActiveMonster)
		{
			eventManager.FireEvent (EventTypes.KillMonster, new KillMonsterEvent (this.currentActiveMonster));
		}
	}
}
