using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class InstructionsManager : MonoBehaviour {

	public CameraFade FadeManager;
	public float ButtonPushDelay = 1f;
	private float CooldownEndTime;

	void Start ()
	{
		CooldownEndTime = Time.realtimeSinceStartup + ButtonPushDelay;
	}

	// Update is called once per frame
	void Update () 
	{
		if(Time.realtimeSinceStartup > CooldownEndTime && (Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire2") || Input.GetButtonDown("Fire3")))
		{
			FadeManager.FadeOut( "Title", 1 );
		}
	}
}
