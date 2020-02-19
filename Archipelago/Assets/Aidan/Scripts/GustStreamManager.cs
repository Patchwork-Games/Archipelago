using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GustStreamManager : MonoBehaviour
{
	[SerializeField] private float gustForce = 10f;
	[SerializeField] private float distanceToDespawnAt = 100f;	// Distance on the X, Z plane
	[SerializeField] private ParticleSystem windParticles = null;
	public GameObject gustStreamSpawnerObject = null;
	private Rigidbody rb = null;
	private bool boatHasEnteredGust = false;
	[SerializeField] private float aliveTime = 10f;
	private float elapsedAliveTime = 0f;


	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Boat"))
		{
			boatHasEnteredGust = true;
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

		// Set the alive time initially
		elapsedAliveTime = aliveTime;
	}

	private void Update()
	{
		// Rotate the gust towards the wind direction
		Vector3 newDirection = Vector3.RotateTowards(transform.forward, StaticValueHolder.WindManagerObject.windDirection, .01f, 0.0f);
		transform.rotation = Quaternion.LookRotation(newDirection);

		// Move the gust stream forwards
		rb.AddForce(transform.forward * (StaticValueHolder.WindManagerObject.windForce + gustForce) * Time.deltaTime);

		// If the boat has entered the gust, add on the gust force to the boat
		if (boatHasEnteredGust)
		{
			// Add a force to the players forward vector
			StaticValueHolder.BoatObject.GetComponent<BoatController>().AddGustForce(gustForce);

			// OPTIONAL - Add torque to the player in the direction of the wind
		}

		// Check the distance between the gust stream and the gust stream spawner. If the gust stream is too far away, despawn it.
		Vector2 spawnerPos = new Vector2(gustStreamSpawnerObject.transform.position.x, gustStreamSpawnerObject.transform.position.z);
		Vector2 gustPosition = new Vector2(transform.position.x, transform.position.z);
		if (Vector2.Distance(spawnerPos, gustPosition) >= distanceToDespawnAt)
		{
			Despawn();
		}

		// Despawn the gust stream if it has been alive too long
		if (elapsedAliveTime > 0)
		{
			elapsedAliveTime -= Time.deltaTime;
			if (elapsedAliveTime <= 0)
			{
				Despawn();
			}
			else if (elapsedAliveTime <= 2)
			{
				//windParticles.Stop();
				ParticleSystem.EmissionModule em = windParticles.emission;
				em.enabled = false;
			}
		}
		
	}

	
	private void Despawn()
	{
		// Despawn the gust stream
		elapsedAliveTime = aliveTime;
		ParticleSystem.EmissionModule em = windParticles.emission;
		em.enabled = true;
		gameObject.SetActive(false);
	}
}
