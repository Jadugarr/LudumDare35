using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class HitCheckSystem : MonoBehaviour 
{
	public GameObject crosshair;

	private EventManager eventManager = EventManager.Instance;

	void Awake()
	{
		AddEventListeners ();
	}

	private void AddEventListeners()
	{
		eventManager.RegisterForEvent (EventTypes.CheckHit, OnCheckHit);
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
		GameObject hitObject = GetHitObject ();

		if(hitObject)
		{
			eventManager.FireEvent (EventTypes.ObjectHit, new ObjectHitEvent (hitObject));
		}
	}

	void Update()
	{
		DebugHitCheck ();
	}
}
