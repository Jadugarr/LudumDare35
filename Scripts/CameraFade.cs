using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

public class CameraFade : MonoBehaviour {

	public GameObject MainCamera;
	private SpriteRenderer FadeSprite;
	private AudioSource[] Music;

	public float StartDelayInSeconds;
	public float FadeInDurationInSeconds;
	public float FadeOutDurationInSeconds;
	public Color FadeColor;

	private float FadeEndTimeStamp;
	private float DelayTimeStamp;
	private bool fadingIn;
	private string nextScene;

	// Use this for initialization
	void Start () {
		FadeSprite = MainCamera.GetComponentInChildren<SpriteRenderer>();
		Music = MainCamera.GetComponents<AudioSource>();
		FadeIn();
	}
	
	// Update is called once per frame
	void Update () {
		float passedTime = Time.realtimeSinceStartup;
		if(!FadeSprite.enabled || passedTime < DelayTimeStamp)
			return;

		if( passedTime < FadeEndTimeStamp)
		{
			if(fadingIn)
			{
				FadeColor.a = ((FadeEndTimeStamp - passedTime) / FadeInDurationInSeconds);
			}
			else
			{
				FadeColor.a = Math.Max(1f - ((FadeEndTimeStamp - passedTime) / FadeOutDurationInSeconds), FadeColor.a);

				foreach(AudioSource m in Music)
				{
					m.volume = 1f - FadeColor.a;
				}
				Debug.Log( passedTime + "-" + FadeEndTimeStamp + "/" + FadeOutDurationInSeconds);
			}
			FadeSprite.color = FadeColor;
		}
		else
		{
			FadeSprite.enabled = !fadingIn;
			if( nextScene != null && !fadingIn)
			{
				SceneManager.LoadScene(nextScene);
			}
		}
	}

	public void FadeOut( string nextScene = null, float fadeOutTime = -1)
	{
		FadeOutDurationInSeconds = (fadeOutTime > 0) ? fadeOutTime : FadeOutDurationInSeconds;

		fadingIn = false;
		DelayTimeStamp = 0;
		FadeEndTimeStamp = Time.realtimeSinceStartup + FadeOutDurationInSeconds;
		FadeSprite.enabled = true;

		//FadeColor.a = 0;
		//FadeSprite.color = FadeColor;

		this.nextScene = nextScene;
	}

	private void FadeIn()
	{
		fadingIn = true;
		DelayTimeStamp = Time.realtimeSinceStartup + StartDelayInSeconds;
		FadeEndTimeStamp = DelayTimeStamp + FadeInDurationInSeconds;
		FadeSprite.enabled = true;
	}

}
