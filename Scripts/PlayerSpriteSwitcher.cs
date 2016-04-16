using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using AssemblyCSharp;

public class PlayerSpriteSwitcher : MonoBehaviour 
{
	public Sprite crabSprite;
	public Sprite elephantSprite;
	public Sprite mantisSprite;
	public Sprite neutralSprite;
	public float fightStanceTimer;
	public SpriteRenderer spriteRenderer;

	private float currentStanceTime = 0f;
	private bool inFightingStance = false;
	private EventManager eventManager = EventManager.Instance;
	private Dictionary<WeaponType, Sprite> spriteMap;

	void Awake()
	{
		AddEventListeners ();
	}

	void Start()
	{
		this.spriteMap = new Dictionary<WeaponType, Sprite> () 
		{
			{WeaponType.Crab, this.crabSprite},
			{WeaponType.Elephant, this.elephantSprite},
			{WeaponType.Mantis, this.mantisSprite}
		};
	}

	// Update is called once per frame
	void Update () 
	{
		if(inFightingStance)
		{
			currentStanceTime += Time.deltaTime;
			if(currentStanceTime >= fightStanceTimer)
			{
				SetNeutralState ();
			}
		}
	}

	private void AddEventListeners()
	{
		eventManager.RegisterForEvent (EventTypes.CheckHit, OnCheckHit);
	}

	private void RemoveEventListeners()
	{
		eventManager.RemoveFromEvent (EventTypes.CheckHit, OnCheckHit);
	}

	private void SetNeutralState()
	{
		this.inFightingStance = false;
		this.spriteRenderer.sprite = this.neutralSprite;
		this.currentStanceTime = 0f;
	}

	private void OnCheckHit(IEvent evtArgs)
	{
		CheckHitEvent evt = (CheckHitEvent)evtArgs;
		Sprite attackSprite;

		if(this.spriteMap.TryGetValue(evt.WeaponType, out attackSprite))
		{
			this.spriteRenderer.sprite = attackSprite;
		}

		this.inFightingStance = true;
		this.currentStanceTime = 0f;
	}

	void OnDestroy()
	{
		RemoveEventListeners ();
	}
}
