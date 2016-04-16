using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class InputManager : MonoBehaviour {

	private EventManager eventManager = EventManager.Instance;

	// Update is called once per frame
	void Update () {
		CheckInput ();
	}

	private void CheckInput()
	{
		if(Input.GetKeyDown(KeyCode.Alpha1) == true)
		{
			eventManager.FireEvent (EventTypes.CheckHit, new CheckHitEvent(WeaponType.Crab));
		}
		if(Input.GetKeyDown(KeyCode.Alpha2) == true)
		{
			eventManager.FireEvent (EventTypes.CheckHit, new CheckHitEvent(WeaponType.Elephant));
		}
		if(Input.GetKeyDown(KeyCode.Alpha3) == true)
		{
			eventManager.FireEvent (EventTypes.CheckHit, new CheckHitEvent(WeaponType.Mantis));
		}
	}
}
