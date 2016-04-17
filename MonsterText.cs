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
	}

	private void RemoveEventListeners()
	{
		eventManager.RemoveFromEvent (EventTypes.MonsterReachedDestination, OnMonsterReachedDestination);
		eventManager.RemoveFromEvent (EventTypes.MonsterKilled, OnMonsterKilled);
	}

	private void OnMonsterReachedDestination(IEvent evt)
	{
		MonsterReachedDestinationEvent evtArgs = (MonsterReachedDestinationEvent)evt;
		canvasGroup.alpha = 1;

		IMonsterTextVO textVO = this.monsterTextModel.GetMonsterTextVO (evtArgs.Monster.GetComponent<MonsterTypeComponent>().monsterType);
		int textIndex = Random.Range (0, textVO.GetStandardLines.Count);
		this.textField.text = textVO.GetStandardLines [textIndex];
	}

	private void OnMonsterKilled(IEvent evt)
	{
		MonsterKilledEvent evtArgs = (MonsterKilledEvent)evt;
		canvasGroup.alpha = 1;

		this.textField.text = this.monsterTextModel.GetMonsterTextVO(evtArgs.KilledMonster.GetComponent<MonsterTypeComponent>().monsterType).GetDefeatLine;
	}

	void OnDestroy()
	{
		RemoveEventListeners ();
	}
}
