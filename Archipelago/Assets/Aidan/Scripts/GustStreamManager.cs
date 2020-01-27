using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GustStreamManager : MonoBehaviour
{
	[SerializeField] private float gustForce = 10f;
	private Rigidbody rb = null;
	private bool boatHasEnteredGust = false;
	private GameObject boat = null;

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Boat"))
		{
			boatHasEnteredGust = true;
			boat = other.gameObject;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Boat"))
		{
			boatHasEnteredGust = false;
		}
	}

	private void Awake()
	{
		// Get the rigidbody component
		rb = GetComponent<Rigidbody>();
		if (rb == null)
		{
			Debug.Log("Missing rigidbody component on GustStreamManager object!");
		}
	}

	private void Update()
	{
		// Rotate the gust towards the wind direction
		Vector3 newDirection = Vector3.RotateTowards(transform.forward, WindManager.Instance.windDirection, .01f, 0.0f);
		transform.rotation = Quaternion.LookRotation(newDirection);

		// Move the gust stream forwards
		rb.AddForce(transform.forward * (WindManager.Instance.windForce + gustForce) * Time.deltaTime);

		// If the boat has entered the gust, add on the gust force to the boat
		if (boatHasEnteredGust)
		{
			// Add a force to the players forward vector
			boat.GetComponent<SailingManager>().AddGustForce(gustForce);

			// OPTIONAL - Add torque to the player in the direction of the wind
		}
	}
}
