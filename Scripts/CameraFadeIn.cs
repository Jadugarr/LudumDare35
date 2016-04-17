using UnityEngine;
using System.Collections;

public class CameraFadeIn : MonoBehaviour {

	public float DelayInSeconds;
	public float DurationInSeconds;
	public SpriteRenderer FadeSprite;

	private float StartTimeStamp;
	private Color FadeColor;

	// Use this for initialization
	void Start () {
		FadeColor = Color.black;
		StartTimeStamp = Time.realtimeSinceStartup;
		FadeSprite.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		float passedTime = Time.realtimeSinceStartup - StartTimeStamp;
		if(passedTime < DelayInSeconds)
			return;

		FadeColor.a = 1f - ((passedTime - DelayInSeconds) / DurationInSeconds);
		FadeSprite.color = FadeColor;

		if(passedTime > DurationInSeconds + DelayInSeconds)
		{
			Destroy(FadeSprite);
			Destroy(this);
		}
	}
}
