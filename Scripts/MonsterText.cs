using UnityEngine;
using System.Collections;
using AssemblyCSharp;
using UnityEngine.UI;

public class MonsterText : MonoBehaviour 
{
	public CanvasGroup canvasGroup;
	public Text textField;

	private MonsterTextModel monsterTextModel = MonsterTextModel.Instance;
	private EventManager eventManager = EventManager.Instance;

	void Awake()
	{
		AddEventListeners ();
	}

	void Start()
	{
		canvasGroup.alpha = 0;
	}

	private void AddEventListeners()
	{
		eventManager.RegisterForEvent (EventTypes.MonsterReachedDestination, OnMonsterReachedDestination);
		eventManager.RegisterForEvent (EventTypes.MonsterKilled, OnMonsterKilled);
		eventManager.RegisterForEvent (EventTypes.KillMonster, OnKillMonster);
		eventManager.RegisterForEvent (EventTypes.MonsterMissed, OnMonsterMissed);
	}

	private void RemoveEventListeners()
	{
		eventManager.RemoveFromEvent (EventTypes.MonsterReachedDestination, OnMonsterReachedDestination);
		eventManager.RemoveFromEvent (EventTypes.MonsterKilled, OnMonsterKilled);
		eventManager.RemoveFromEvent (EventTypes.KillMonster, OnKillMonster);
		eventManager.RemoveFromEvent (EventTypes.MonsterMissed, OnMonsterMissed);
	}

	private void OnMonsterReachedDestination(IEvent evt)
	{
		MonsterReachedDestinationEvent evtArgs = (MonsterReachedDestinationEvent)evt;
		canvasGroup.alpha = 1;

		SetStandardText (evtArgs.Monster.GetComponent<MonsterTypeComponent>().monsterType);
	}

	private void OnMonsterMissed (IEvent evt)
	{
		MonsterMissedEvent evtArgs = (MonsterMissedEvent)evt;
		SetStandardText (evtArgs.Monster.GetComponent<MonsterTypeComponent>().monsterType);
	}

	private void SetStandardText(MonsterType monsterType)
	{
		string currentText = this.textField.text;
		string textToSet = "";

		do 
		{
			IMonsterTextVO textVO = this.monsterTextModel.GetMonsterTextVO (monsterType);
			int textIndex = Random.Range (0, textVO.GetStandardLines.Count);
			textToSet = textVO.GetStandardLines [textIndex];
		} while(currentText == textToSet);
		this.textField.text = textToSet;
	}

	private void OnMonsterKilled(IEvent evt)
	{
		canvasGroup.alpha = 0;
	}

	private void OnKillMonster(IEvent evt)
	{
		KillMonsterEvent evtArgs = (KillMonsterEvent)evt;
		this.textField.text = this.monsterTextModel.GetMonsterTextVO(evtArgs.Monster.GetComponent<MonsterTypeComponent>().monsterType).GetDefeatLine;
	}

	void OnDestroy()
	{
		RemoveEventListeners ();
	}
}
