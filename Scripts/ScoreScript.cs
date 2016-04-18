using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class ScoreScript : MonoBehaviour {

    public Text pointText;
    private float timeAcc = 0f;

	// Use this for initialization
	void Start () {
        pointText.text = PointSystem.points.ToString();
	}
	
	// Update is called once per frame
	void Update () {
        timeAcc += Time.deltaTime;
        if(timeAcc > 2f)
        {
            if (Input.anyKeyDown)
            {
                SceneManager.LoadScene("Title");
            }
        }
	}
}
