using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMastController : MonoBehaviour
{
	[SerializeField] private Vector2 lockBetweenTwoRotations = Vector2.zero;
	[SerializeField] private float rotationTime = 1f;
	[SerializeField] private Cloth cloth = null;
	private float lerpTime = 0f;
	private Quaternion newRotation = Quaternion.identity;
	private Quaternion startingRotation = Quaternion.identity;

	private void Start()
	{
		startingRotation = transform.localRotation;
	}

	private void Update()
	{
		float resultOfDotProd1 = Vector3.Dot(StaticValueHolder.WindManagerObject.windDirection, StaticValueHolder.BoatObject.transform.forward);
		float resultOfDotProd2 = Vector3.Dot(StaticValueHolder.WindManagerObject.windDirectionRight, StaticValueHolder.BoatObject.transform.forward);

		// Compare the wind direction vector to the boat's forward vector to determine the rotation of the mast
		if (resultOfDotProd1 >= 0.5f)
		{
			if (resultOfDotProd2 >= 0)
			{
				SetRotation(Quaternion.Euler(0, -90, 0));
			}
			else
			{
				SetRotation(Quaternion.Euler(0, 90, 0));
			}
		}
		else if (resultOfDotProd1 <= -0.5f)
		{
			SetRotation(Quaternion.Euler(0, 0, 0));
		}
		else if (resultOfDotProd1 >= -0.5f && resultOfDotProd1 <= 0.5f)
		{
			if (resultOfDotProd2 >= 0)
			{
				SetRotation(Quaternion.Euler(0, -45, 0));
			}
			else
			{
				SetRotation(Quaternion.Euler(0, 45, 0));
			}
		}


		// Rotate towards the new rotation
		lerpTime += Time.deltaTime / rotationTime;

		if (lerpTime <= 1)
		{
			transform.localRotation = Quaternion.Lerp(startingRotation, newRotation, lerpTime);
		}

		// Add the wind force to the sail cloth
		Vector3 clothAcceleration = Vector3.RotateTowards(StaticValueHolder.WindManagerObject.windDirection, cloth.transform.right , 6.8f, 6.8f) * 100;

		//cloth.externalAcceleration = -Physics.gravity / 2;
	}

	private void SetRotation(Quaternion rotation)
	{
		startingRotation = transform.localRotation;
		newRotation = rotation;
		lerpTime = 0f;
	}
}
