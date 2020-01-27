using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GustStreamManager : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			// Add a force to the players forward vector

			// OPTIONAL - Add torque to the player in the direction of the wind
		}
	}

	private void Update()
	{
		// Rotate the gust towards the wind direction
		Vector3 newDirection = Vector3.RotateTowards(transform.forward, WindManager.Instance.windDirection, 1f, 0.0f);
		transform.rotation = Quaternion.LookRotation(newDirection);
	}
}
