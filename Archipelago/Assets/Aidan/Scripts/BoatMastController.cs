using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMastController : MonoBehaviour
{
	[SerializeField] private Vector2 lockBetweenTwoRotations = Vector2.zero;
	[SerializeField] private float rotationTime = 1f;
	[SerializeField] private GameObject sailClothLeft = null;
	[SerializeField] private GameObject sailClothRight = null;
	[SerializeField] private float maxSailStretch = 20;
	private float lerpTime = 0f;
	private Quaternion newRotation = Quaternion.identity;
	private Quaternion startingRotation = Quaternion.identity;
	private float startingStretch = 0f;
	private float currentStretch = 0f;
	private float newSailStretch = 0f;
	private bool sailHasChangedPos = false;

	// Audio
	[Range(0f, 1f)] [SerializeField] private float randomSailCreakNoisePitch = 0f;
	private AudioSource sailCreakNoise = null;

	private void Start()
	{
		startingRotation = transform.localRotation;

		// Get the audio transform object
		Transform audioTransform = StaticValueHolder.BoatObject.transform.Find("Audio");
		if (audioTransform == null)
		{
			Debug.Log("Missing Audio child on object: " + StaticValueHolder.BoatObject);
		}
		else
		{
			// Get the sail creak noise
			sailCreakNoise = audioTransform.Find("SailCreak").GetComponent<AudioSource>();
			if (sailCreakNoise == null)
			{
				Debug.Log("Missing SailCreak child on object: " + audioTransform.gameObject);
			}
		}
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
				newSailStretch = -maxSailStretch;
				SetRotation(Quaternion.Euler(0, -90, 0));
			}
			else
			{
				newSailStretch = maxSailStretch;
				SetRotation(Quaternion.Euler(0, 90, 0));
			}
		}
		else if (resultOfDotProd1 <= -0.5f)
		{
			newSailStretch = 0;
			SetRotation(Quaternion.Euler(0, 0, 0));
		}
		else if (resultOfDotProd1 >= -0.5f && resultOfDotProd1 <= 0.5f)
		{
			if (resultOfDotProd2 >= 0)
			{
				newSailStretch = -maxSailStretch / 2;
				SetRotation(Quaternion.Euler(0, -45, 0));
			}
			else
			{
				newSailStretch = maxSailStretch / 2;
				SetRotation(Quaternion.Euler(0, 45, 0));
			}
		}

		// Rotate towards the new rotation
		lerpTime += Time.deltaTime / rotationTime;

		if (lerpTime <= 1)
		{
			transform.localRotation = Quaternion.Lerp(startingRotation, newRotation, lerpTime);
			currentStretch = Mathf.Lerp(startingStretch, newSailStretch, lerpTime);
		}

		sailClothLeft.GetComponent<MeshRenderer>().material.SetFloat("_HeightMapScale", currentStretch);
		sailClothRight.GetComponent<MeshRenderer>().material.SetFloat("_HeightMapScale", currentStretch);

		// Check if the new rotation has been set to an important angle
		if (Vector3.Dot(newRotation * transform.forward, transform.rotation * transform.forward) <= 0)
		{
			if (!sailHasChangedPos)
			{
				sailHasChangedPos = true;
				PlaySailCreakSound();
			}
		}
		else if (sailHasChangedPos)
		{
			sailHasChangedPos = false;
		}
		
	}

	private void SetRotation(Quaternion rotation)
	{
		startingRotation = transform.localRotation;
		startingStretch = currentStretch;
		newRotation = rotation;
		lerpTime = 0f;
	}

	private void PlaySailCreakSound()
	{
		// Play sail creak noise
		sailCreakNoise.pitch = 1 + Random.Range(-randomSailCreakNoisePitch / 2f, randomSailCreakNoisePitch / 2f);
		sailCreakNoise.Play();
	}
}
