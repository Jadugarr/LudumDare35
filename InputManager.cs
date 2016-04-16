using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

	private EventManager eventManager = EventManager.Instance;

	// Update is called once per frame
	void Update () {
		CheckInput ();
	}

	private void CheckInput()
	{
		if(Input.GetKeyDown(KeyCode.Space) == true)
		{
			eventManager.FireEvent (EventTypes.CheckHit, null);
		}
	}
}
