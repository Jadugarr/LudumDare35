using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MonsterTimer : MonoBehaviour 
{
	public CanvasGroup timerContainer;
	public Text timerField;
	public float startTimer;

	private EventManager eventManager = EventManager.Instance;
	private float currentTimer;
	private bool monsterPresent;

	// Use this for initialization
	void Start () 
	{
		timerContainer.alpha = 0f;
	}

	void Awake()
	{
		AddEventListeners ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(monsterPresent)
		{
			this.currentTimer -= Time.deltaTime;
			ShowTime ();
		}
	}

	private void AddEventListeners()
	{
		eventManager.RegisterForEvent (EventTypes.MonsterReachedDestination, OnMonsterReachedDestination);
		eventManager.RegisterForEvent (EventTypes.KillMonster, OnKillMonster);
	}

	private void RemoveEventListeners()
	{
		eventManager.RemoveFromEvent (EventTypes.MonsterReachedDestination, OnMonsterReachedDestination);
		eventManager.RemoveFromEvent (EventTypes.KillMonster, OnKillMonster);
	}

	void OnDestroy()
	{
		RemoveEventListeners ();
	}

	private void ShowTime()
	{
		this.timerField.text = this.currentTimer.ToString ("F1");
	}

	private void OnMonsterReachedDestination(IEvent evt)
	{
		this.monsterPresent = true;
		this.timerContainer.alpha = 1f;
		this.currentTimer = startTimer;
	}

	private void OnKillMonster(IEvent evt)
	{
		this.monsterPresent = false;
		this.timerContainer.alpha = 0f;
	}
}
