using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class DebugHitDisplay : MonoBehaviour {

	public SpriteRenderer renderer;
	public Color hitColor;
	public Color missColor;
	public Color neutralColor;
	public float colorTime;
	private EventManager eventManager = EventManager.Instance;

	private bool currentlyHit = false;
	private bool hitTiming = false;
	private float hitTimer = 0f;

	void Awake()
	{
		AddEventListeners ();
	}

	void Update()
	{
		if(hitTiming == true)
		{
			hitTimer += Time.deltaTime;

			if(hitTimer >= colorTime)
			{
				SetNeutralState ();
			}
		}
	}

	private void AddEventListeners()
	{
		eventManager.RegisterForEvent (EventTypes.DebugObjectHit, OnDebugObjectHit);
		eventManager.RegisterForEvent (EventTypes.CheckHit, OnCheckHit);
	}

	private void RemoveEventListeners()
	{
		eventManager.RemoveFromEvent (EventTypes.DebugObjectHit, OnDebugObjectHit);
		eventManager.RemoveFromEvent (EventTypes.CheckHit, OnCheckHit);
	}

	private void OnDebugObjectHit(IEvent evtArgs)
	{
		if(this.hitTiming == false)
		{
			ObjectHitEvent evt = (ObjectHitEvent)evtArgs;

			if (evt.HitObject && evt.HitObject == this.gameObject) {
				this.renderer.enabled = true;
				this.currentlyHit = true;
			} else {
				this.renderer.enabled = false;
				this.currentlyHit = false;
			}
		}
	}

	private void OnCheckHit(IEvent evtArgs)
	{
		if(!this.hitTiming)
		{
			this.renderer.enabled = true;
			this.hitTiming = true;

			if (this.currentlyHit) {
				this.renderer.color = hitColor;
			} else {
				this.renderer.color = missColor;
			}
		}
	}

	private void SetNeutralState()
	{
		this.renderer.enabled = false;
		this.renderer.color = neutralColor;
		this.hitTiming = false;
		this.hitTimer = 0f;
	}

	void OnDestroy()
	{
		RemoveEventListeners ();
	}
}
