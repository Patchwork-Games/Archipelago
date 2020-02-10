using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushingTheBoat : MonoBehaviour
{
	[SerializeField] private float pushForce = 0f;
	private GameObject boatObject = null;
	private GameObject playerObject = null;
	private Vector3 dirFromPlayerToBoat = Vector3.zero;

	private void Awake()
	{
		// Get the parent object
		boatObject = transform.parent.gameObject;
	}

	private void OnTriggerEnter(Collider other)
	{
		// Set the player if they have collided
		if (other.CompareTag("Player"))
		{
			playerObject = other.gameObject;
			dirFromPlayerToBoat = boatObject.transform.position - playerObject.transform.position;
			boatObject.GetComponent<Rigidbody>().AddForce(dirFromPlayerToBoat * pushForce);
		}
	}
}
