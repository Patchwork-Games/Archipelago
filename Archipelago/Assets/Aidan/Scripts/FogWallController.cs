using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogWallController : MonoBehaviour
{
	//[SerializeField] float rangeToStartParticleSystem = 200f;
 	private ParticleSystem cloudParticles = null;

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Boat"))
		{
			cloudParticles.gameObject.SetActive(true);
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Boat"))
		{
			cloudParticles.gameObject.SetActive(false);
		}
	}

	private void Awake()
	{
		// Get the cloud particle system
		cloudParticles = transform.Find("CloudParticles").GetComponent<ParticleSystem>();
		if (cloudParticles == null)
		{
			Debug.Log("Cloud particles not found on object: " + this.gameObject);
		}

		cloudParticles.gameObject.SetActive(false);
	}
}
