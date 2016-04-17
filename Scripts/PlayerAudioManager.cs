using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using AssemblyCSharp;

public class PlayerAudioManager : MonoBehaviour 
{
	public List<AudioClip> bluntClips;
	public List<AudioClip> pokeClips;
	public List<AudioClip> slashClips;
	public AudioSource audioSource;

	private EventManager eventManager = EventManager.Instance;
	private Dictionary<WeaponType, List<AudioClip>> soundMap;

	void Awake()
	{
		AddEventListeners ();

		this.soundMap = new Dictionary<WeaponType, List<AudioClip>> () 
		{
			{WeaponType.Crab, pokeClips},
			{WeaponType.Elephant, bluntClips},
			{WeaponType.Mantis, slashClips}
		};
	}

	private void AddEventListeners()
	{
		eventManager.RegisterForEvent (EventTypes.CheckHit, OnCheckHit);
	}

	private void RemoveEventListeners()
	{
		eventManager.RemoveFromEvent (EventTypes.CheckHit, OnCheckHit);
	}

	private void OnCheckHit(IEvent evt)
	{
		CheckHitEvent evtArgs = (CheckHitEvent)evt;
		List<AudioClip> clips;

		if(this.soundMap.TryGetValue(evtArgs.WeaponType, out clips))
		{
			if(clips != null)
			{
				int clipIndex = Random.Range (0, clips.Count);
				this.audioSource.clip = clips [clipIndex];
				this.audioSource.Play ();
			}
		}
	}

	void OnDestroy()
	{
		RemoveEventListeners ();
	}
}
