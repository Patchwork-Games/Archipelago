using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterFollow : MonoBehaviour
{
	[SerializeField] private GameObject boatObject = null;
	[SerializeField] private Vector2 offsetFromPlayer = Vector2.zero;
	private GameObject playerObject = null;

	private void Start()
	{
		// Get the player game object
		playerObject = PlayerMovement.Instance.gameObject;
	}

	private void Update()
	{
		if (PlayerMovement.Instance.state != PlayerMovement.PlayerState.BOAT)
		{
			transform.position = new Vector3(playerObject.transform.position.x + offsetFromPlayer.x, transform.position.y, playerObject.transform.position.z + offsetFromPlayer.y);
		}
		else
		{
			transform.position = new Vector3(boatObject.transform.position.x + offsetFromPlayer.x, transform.position.y, boatObject.transform.position.z + offsetFromPlayer.y);
		}
	}
}
