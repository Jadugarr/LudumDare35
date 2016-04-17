using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class InstructionsManager : MonoBehaviour {


	// Update is called once per frame
	void Update () 
	{
		if(Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire2") || Input.GetButtonDown("Fire3"))
		{
			SceneManager.LoadScene( "Title" );
		}
	}
}
