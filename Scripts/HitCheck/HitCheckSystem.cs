using UnityEngine;
using System.Collections;
using AssemblyCSharp;
using System.Collections.Generic;

public class HitCheckSystem : MonoBehaviour 
{
	public GameObject aimObject;
	public GameObject crosshair;
	public GameObject hitmarker;
	public float hitmarkerTimer;
	public List<AudioClip> markerHitClips;
	public AudioClip monsterWoundedClip;
	public AudioClip missClip;
	public AudioSource source;

	private EventManager eventManager = EventManager.Instance;
	private WeaknessMap weaknessMap = WeaknessMap.Instance;
	private ActiveMonsterModel activeMonsterModel = ActiveMonsterModel.Instance;
	private float currentHitmarkerTime = 0f;

	private GameObject activeHitMarker;

	void Awake()
	{
		AddEventListeners ();
	}

	private void AddEventListeners()
	{
		eventManager.RegisterForEvent (EventTypes.CheckHit, OnCheckHit);
		eventManager.RegisterForEvent (EventTypes.MonsterKilled, OnMonsterKilled);
	}

	private void RemoveEventListeners()
	{
		eventManager.RemoveFromEvent (EventTypes.CheckHit, OnCheckHit);
		eventManager.RemoveFromEvent (EventTypes.MonsterKilled, OnMonsterKilled);
	}

	public RaycastHit2D GetHitObject()
	{
		return Physics2D.Raycast (this.crosshair.transform.position, this.crosshair.transform.right, 10f,LayerMask.GetMask("Weakpoints"));
	}

	private void DebugHitCheck()
	{
		if (GetHitObject ()) 
		{
			GameObject hitObject = GetHitObject ().collider.gameObject;

			if(hitObject)
			{
				Debug.Log ("Hit something");
			}
			eventManager.FireEvent (EventTypes.DebugObjectHit, new ObjectHitEvent (hitObject));
		}
	}

	private void CheckHitMarker(float deltaTime)
	{
		if(this.activeHitMarker != null)
		{
			this.currentHitmarkerTime += deltaTime;
			if(this.currentHitmarkerTime >= this.hitmarkerTimer)
			{
				DestroyHitMarker ();
			}
		}
	}

	private void OnCheckHit(IEvent evt)
	{
		CheckHitEvent evtArgs = (CheckHitEvent)evt;
		RaycastHit2D raycastHit = GetHitObject ();
		if (raycastHit) {
			GameObject hitObject = raycastHit.collider.gameObject;

			if (hitObject != null && hitObject.transform.parent.gameObject == this.activeMonsterModel.activeMonster) 
			{
				DestroyHitMarker ();
				this.activeHitMarker = (GameObject)Instantiate (hitmarker, raycastHit.point, hitmarker.transform.rotation);
				if (this.weaknessMap.IsMonsterWeakAgainstWeaponType (this.activeMonsterModel.activeMonster.GetComponent<MonsterTypeComponent> ().monsterType, evtArgs.WeaponType) == true) 
				{
					eventManager.FireEvent (EventTypes.KillMonster, new KillMonsterEvent (this.activeMonsterModel.activeMonster));
					this.aimObject.SetActive (false);
					this.source.clip = this.monsterWoundedClip;
					this.source.Play ();
				} 
				else 
				{
					this.source.clip = this.markerHitClips [Random.Range (0, this.markerHitClips.Count)];
					this.source.Play ();
					if(this.activeMonsterModel.activeMonster != null)
					{
						this.eventManager.FireEvent (EventTypes.MonsterMissed, new MonsterMissedEvent(this.activeMonsterModel.activeMonster));
					}
				}
			}
		}
		else 
		{
			this.source.clip = this.missClip;
			this.source.Play ();
			if(this.activeMonsterModel.activeMonster != null)
			{
				this.eventManager.FireEvent (EventTypes.MonsterMissed, new MonsterMissedEvent(this.activeMonsterModel.activeMonster));
			}
		}
	}

	private void OnMonsterKilled(IEvent evt)
	{
		this.aimObject.SetActive (true);
		DestroyHitMarker ();
	}

	private void DestroyHitMarker()
	{
		if(	this.activeHitMarker != null)
		{
			DestroyObject (this.activeHitMarker);
			this.currentHitmarkerTime = 0f;
		}
	}

	void Update()
	{
		DebugHitCheck ();
		CheckHitMarker (Time.deltaTime);
	}

	void OnDestroy()
	{
		RemoveEventListeners ();
	}
}
