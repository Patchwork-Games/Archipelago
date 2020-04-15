using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushingTheBoat : MonoBehaviour
{
	[SerializeField] private float pushForce = 0f;
	private GameObject playerObject = null;
	private Vector3 dirFromPlayerToBoat = Vector3.zero;

	private void OnCollisionEnter(Collision collision)
	{
		// Set the player if they have collided
		if (collision.gameObject.CompareTag("Player"))
		{
			playerObject = collision.gameObject;
			dirFromPlayerToBoat = StaticValueHolder.BoatObject.transform.position - playerObject.transform.position;
			StaticValueHolder.BoatObject.GetComponent<Rigidbody>().AddForce(dirFromPlayerToBoat * pushForce);
		}
	}
}
