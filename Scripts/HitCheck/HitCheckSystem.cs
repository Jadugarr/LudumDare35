using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class HitCheckSystem : MonoBehaviour 
{
	public GameObject aimObject;
	public GameObject crosshair;
	public GameObject hitmarker;

	private EventManager eventManager = EventManager.Instance;
	private WeaknessMap weaknessMap = WeaknessMap.Instance;
	private ActiveMonsterModel activeMonsterModel = ActiveMonsterModel.Instance;

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

	private void OnCheckHit(IEvent evt)
	{
		CheckHitEvent evtArgs = (CheckHitEvent)evt;
		RaycastHit2D raycastHit = GetHitObject ();
		if(raycastHit)
		{
			GameObject hitObject = raycastHit.collider.gameObject;

			if(hitObject != null && hitObject.transform.parent.gameObject == this.activeMonsterModel.activeMonster &&
				this.weaknessMap.IsMonsterWeakAgainstWeaponType(this.activeMonsterModel.activeMonster.GetComponent<MonsterTypeComponent>().monsterType, evtArgs.WeaponType) == true)
			{
				this.activeHitMarker = (GameObject)Instantiate (hitmarker, raycastHit.point, hitmarker.transform.rotation);
				eventManager.FireEvent (EventTypes.KillMonster, new KillMonsterEvent (this.activeMonsterModel.activeMonster));
				this.aimObject.SetActive (false);
			}
		}
	}

	private void OnMonsterKilled(IEvent evt)
	{
		this.aimObject.SetActive (true);
		if(	this.activeHitMarker != null)
		{
			DestroyObject (this.activeHitMarker);
		}
	}

	void Update()
	{
		DebugHitCheck ();
	}

	void OnDestroy()
	{
		RemoveEventListeners ();
	}
}
