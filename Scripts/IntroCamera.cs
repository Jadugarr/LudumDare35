using UnityEngine;
using System.Collections;

public class IntroCamera : MonoBehaviour {

	public Vector3 point1;
	public Vector3 point2;
	public float duration;
	public float delay;

	private float startTimestamp;
	private Vector3 transitionNorm;

	// Use this for initialization
	void Start () {
		startTimestamp = Time.realtimeSinceStartup;

		this.transform.position = point1;
		transitionNorm = point2 - point1;
	}
	
	// Update is called once per frame
	void Update () {
		float passedTime = Time.realtimeSinceStartup - startTimestamp;

		if(passedTime < delay)
			return;

		this.transform.position = point1 + (transitionNorm * ((passedTime -delay) / duration));

		if( passedTime >= duration + delay)
		{
			this.transform.position = point2;
			Destroy(this);
		}
	}
}
