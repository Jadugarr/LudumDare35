using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class HitCheckSystem : MonoBehaviour 
{
	public GameObject aimObject;
	public GameObject crosshair;

	private EventManager eventManager = EventManager.Instance;
	private WeaknessMap weaknessMap = WeaknessMap.Instance;
	private ActiveMonsterModel activeMonsterModel = ActiveMonsterModel.Instance;

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

	public GameObject GetHitObject()
	{
		RaycastHit2D hitObject = Physics2D.Raycast (this.crosshair.transform.position, this.crosshair.transform.right, 10f,LayerMask.GetMask("Weakpoints"));

		if(hitObject)
		{
			return hitObject.collider.gameObject;
		}

		return null;
	}

	private void DebugHitCheck()
	{
		GameObject hitObject = GetHitObject ();

		if(hitObject)
		{
			Debug.Log ("Hit something");
		}
		eventManager.FireEvent (EventTypes.DebugObjectHit, new ObjectHitEvent (hitObject));
	}

	private void OnCheckHit(IEvent evt)
	{
		CheckHitEvent evtArgs = (CheckHitEvent)evt;
		GameObject hitObject = GetHitObject ();

		if(hitObject != null && hitObject.transform.parent.gameObject == this.activeMonsterModel.activeMonster &&
			this.weaknessMap.IsMonsterWeakAgainstWeaponType(this.activeMonsterModel.activeMonster.GetComponent<MonsterTypeComponent>().monsterType, evtArgs.WeaponType) == true)
		{
			eventManager.FireEvent (EventTypes.KillMonster, new KillMonsterEvent (this.activeMonsterModel.activeMonster));
			this.aimObject.SetActive (false);
		}
	}

	private void OnMonsterKilled(IEvent evt)
	{
		this.aimObject.SetActive (true);
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
