using UnityEngine;
using System.Collections;

public class AimRotation : MonoBehaviour 
{
	public float fullTurnTime;
	float rotation;
	public float maxAngle;
	private bool _isLookingDown;

	private void Update()
	{
		float interval = Time.unscaledTime / fullTurnTime;
		bool isMovingDown = (((int) interval) % 2) == 0;
		float rotationFactor = interval - Mathf.Floor(interval);

		rotation = 
			(isMovingDown)
			? -maxAngle + ( 2f * maxAngle * rotationFactor)
			: maxAngle - ( 2f * maxAngle * rotationFactor);
		
		_isLookingDown = ((rotationFactor < 0.5) == isMovingDown); 

		// todo: rotate arrow
		this.gameObject.transform.rotation = new Quaternion(0, 0, rotation, 1);
	}

	public bool IsLookingDown{
		get{
			return _isLookingDown;
		}
	}
}
