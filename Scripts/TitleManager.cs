using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour {

	public CameraFade FadeManager;
	public GameObject Arrow;

	public Vector3 StartPos;
	public Vector3 InstructionsPos;
	public Vector3 QuitPos;

	private bool isAxisDown = false;

	private int arrowPos = 0;
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.Return))  
		{
			switch(arrowPos)
			{
			case 0:
				FadeManager.FadeOut("Scene" );

				break;
			case 1:
				FadeManager.FadeOut("Instructions" );

				break;
			case 2:
				Application.Quit();
				break;
			}

		}
		else if(!isAxisDown && Input.GetAxisRaw("Vertical") != 0)
		{
			if(Input.GetAxisRaw("Vertical") < 0 )
			{
				arrowPos = (arrowPos + 1) % 3;
			}
			else
			{
				arrowPos = (arrowPos == 0) ? 2 : arrowPos -1;
			}

			switch(arrowPos)
			{
			case 0:
				Arrow.transform.position = StartPos;
				break;
			case 1:
				Arrow.transform.position = InstructionsPos;
				break;
			case 2:
				Arrow.transform.position = QuitPos;
				break;
			}
		}
		isAxisDown = Input.GetAxisRaw("Vertical") != 0;
	}
}
