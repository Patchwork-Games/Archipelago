using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameManager : MonoBehaviour
{
	[SerializeField] GameObject boatObject = null;
	[SerializeField] GameObject playerCharacterObject = null;
	[SerializeField] DashMeter dashMeter = null;
	[SerializeField] CinemachineFreeLook playerCharacterCamera = null;
	[SerializeField] CinemachineFreeLook boatCamera = null;

	private void Awake()
	{
		// Set the static value holder to have references to gameobjects
		{
			// Boat
			if (boatObject != null)
				StaticValueHolder.BoatObject = boatObject;
			else
				Debug.Log("BoatObject missing from game manager script on object: " + this.gameObject);

			// Player
			if (playerCharacterObject != null)
				StaticValueHolder.PlayerObject = playerCharacterObject;
			else
				Debug.Log("PlayerObject missing from game manager script on object: " + this.gameObject);

			// Dash meter
			if (dashMeter != null)
				StaticValueHolder.DashMeterObject = dashMeter;
			else
				Debug.Log("DashMeterObject missing from game manager script on object: " + this.gameObject);

			// Character camera
			if (playerCharacterCamera != null)
				StaticValueHolder.PlayerCharacterCamera = playerCharacterCamera;
			else
				Debug.Log("PlayerCharacterCamera missing from game manager script on object: " + this.gameObject);

			// Boat Camera
			if (boatCamera != null)
				StaticValueHolder.BoatCamera = boatCamera;
			else
				Debug.Log("BoatCamera missing from game manager script on object: " + this.gameObject);
		}
	}
}
