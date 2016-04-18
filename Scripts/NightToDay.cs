using UnityEngine;
using System.Collections;

public class NightToDay : MonoBehaviour 
{
	public bool NightFirst;
	public SpriteRenderer Day;
	public SpriteRenderer Night;
	public float DurationInSeconds;
	public float DelayInSeconds;
	private float StartTimeStamp;

	private Color FadeColor;

	// Use this for initialization
	void Start () {
		if(NightFirst)
		{
			Vector3 pos = Night.transform.position;
			pos.z = 0.1f;
			Night.transform.position = pos;
		}
		else
		{
			Vector3 pos = Day.transform.position;
			pos.z = 0.1f;
			Day.transform.position = pos;
		}

		FadeColor = new Color(1f,1f,1f, 0f);
		StartTimeStamp = Time.realtimeSinceStartup;
		UpdateColor();
	}
	
	// Update is called once per frame
	void Update () 
	{
		float passedTime = Time.realtimeSinceStartup - StartTimeStamp;
		if(passedTime < DelayInSeconds)
			return;
		
		FadeColor.a = (passedTime - DelayInSeconds) / DurationInSeconds;
		UpdateColor();

		if( FadeColor.a >= 1f)
		{
			Destroy(this);
		}			
	}

	private void UpdateColor()
	{
		if(NightFirst)
		{
			Day.color = FadeColor;
		}
		else
		{
			Night.color = FadeColor;
		}
	}
}
