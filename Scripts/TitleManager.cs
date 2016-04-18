using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour {

	public CameraFade FadeManager;
	public GameObject ArrowUp;
	public GameObject ArrowDown;

	private bool isStartSelected = true;
	private bool isAxisDown = false;
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetButtonDown("Fire1"))
		{
			FadeManager.FadeOut( isStartSelected? "Scene" : "Instructions" );
		}
		else if(!isAxisDown && Input.GetAxisRaw("Vertical") != 0)
		{
			isStartSelected = !isStartSelected;
			ArrowUp.SetActive( isStartSelected );
			ArrowDown.SetActive( !isStartSelected );
		}
		isAxisDown = Input.GetAxisRaw("Vertical") != 0;
	}
}
