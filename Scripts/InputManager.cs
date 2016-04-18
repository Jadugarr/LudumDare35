using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class InputManager : MonoBehaviour {

	private EventManager eventManager = EventManager.Instance;
    public SpriteRenderer arrowSprite;
    public float attackDelay = 0.5f;

	private bool active = true;
    private bool hitDelayed = false;
    private float timeAccDelay = 0f;

	void Awake()
	{
		AddEventListeners ();
	}

	// Update is called once per frame
	void Update () {
		if(active)
		{   
			CheckInput ();
		} if(hitDelayed)
        {
            timeAccDelay += Time.deltaTime;
            if(timeAccDelay> attackDelay)
            {
                active = true;
                hitDelayed = false;
                timeAccDelay = 0f;
                arrowSprite.color = new Color(arrowSprite.color.r, arrowSprite.color.g, arrowSprite.color.b, 1f);
            }
        }
	}

	void OnDestroy()
	{
		RemoveEventListeners ();
	}

	private void AddEventListeners()
	{
		eventManager.RegisterForEvent (EventTypes.KillMonster, OnKillMonster);
		eventManager.RegisterForEvent (EventTypes.MonsterReachedDestination, OnMonsterReachedDestination);
	}

	private void RemoveEventListeners()
	{
		eventManager.RemoveFromEvent (EventTypes.KillMonster, OnKillMonster);
		eventManager.RemoveFromEvent (EventTypes.MonsterReachedDestination, OnMonsterReachedDestination);
	}

	private void CheckInput()
	{
		if(Input.GetButtonDown("Fire3") == true)
		{
            setDelay();
            eventManager.FireEvent (EventTypes.CheckHit, new CheckHitEvent(WeaponType.Crab));
		}
		if(Input.GetButtonDown("Fire2") == true)
		{
            setDelay();
            eventManager.FireEvent (EventTypes.CheckHit, new CheckHitEvent(WeaponType.Elephant));
		}
		if(Input.GetButtonDown("Fire1") == true)
		{
            setDelay();
            eventManager.FireEvent (EventTypes.CheckHit, new CheckHitEvent(WeaponType.Mantis));
		}
	}

    private void setDelay()
    {
        active = false;
        hitDelayed = true;
        arrowSprite.color = new Color(arrowSprite.color.r, arrowSprite.color.g, arrowSprite.color.b, 0.5f);
    }

	private void OnKillMonster(IEvent evt)
	{
		this.active = false;
        this.hitDelayed = false;
	}

	private void OnMonsterReachedDestination(IEvent evt)
	{
		this.active = true;
	}
}
