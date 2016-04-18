using UnityEngine;
using System.Collections;

public class CloudMoving : MonoBehaviour {

    public float velocity = 1f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 speed = new Vector3(-(velocity * Time.deltaTime), 0f, 0f);
       // Debug.Log(speed);
        this.transform.Translate(speed);
        if(this.transform.position.x < -5f)
        {
            Destroy(this.gameObject);
        }
	}
}
