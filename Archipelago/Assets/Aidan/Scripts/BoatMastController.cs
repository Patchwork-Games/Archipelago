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

	// Sail materials
	[SerializeField] private Material[] sailMaterials = null;
	private Material sailLeftMat = null;
	private Material sailRightMat = null;

	private float lerpTime = 0f;
	private Quaternion newRotation = Quaternion.identity;
	private Quaternion startingRotation = Quaternion.identity;
	private bool sailHasChangedPos = false;
	private BoatController boatController = null;

	// Stretch
	private float startingStretch = 0f;
	private float currentStretch = 0f;
	private float newSailStretch = 0f;

	// Wobble
	private float minWobble = 0f;
	private float smallWobble = 1f;
	private float maxWobble = 2f;
	private float wobbleWeight = 0f;
	private float newWobble = 0f;
	private float currentWobble = 0f;
	private float startingWobble = 0f;

	// Audio
	[Range(0f, 1f)] [SerializeField] private float randomSailCreakNoisePitch = 0f;
	private AudioSource sailCreakNoise = null;

	private void Awake()
	{
		// Get the sail materials
		sailLeftMat = sailClothLeft.GetComponent<MeshRenderer>().material;
		sailRightMat = sailClothRight.GetComponent<MeshRenderer>().material;
	}

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

		// Get the boat controller
		boatController = StaticValueHolder.BoatObject.GetComponent<BoatController>();
		if (boatController == null)
		{
			Debug.Log("Missing BoatController component on object: " + StaticValueHolder.BoatObject);
		}
	}

	private void Update()
	{
		float resultOfDotProd1 = Vector3.Dot(StaticValueHolder.WindManagerObject.windDirection, StaticValueHolder.BoatObject.transform.forward);
		float resultOfDotProd2 = Vector3.Dot(StaticValueHolder.WindManagerObject.windDirectionRight, StaticValueHolder.BoatObject.transform.forward);

		// Calculate the wobble weight
		wobbleWeight = (1 - boatController.PercentageSpeed);

		// Compare the wind direction vector to the boat's forward vector to determine the rotation of the mast
		if (resultOfDotProd1 >= 0.5f)
		{
			newWobble = minWobble * wobbleWeight;

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
			newWobble = maxWobble * wobbleWeight;
			newSailStretch = 0;
			SetRotation(Quaternion.Euler(0, 0, 0));
		}
		else if (resultOfDotProd1 >= -0.5f && resultOfDotProd1 <= 0.5f)
		{
			newWobble = smallWobble * wobbleWeight;

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
			currentWobble = Mathf.Lerp(startingWobble, newWobble, lerpTime);
		}

		// Update the current sail stretch
		sailLeftMat.SetFloat("_HeightMapScale", currentStretch);
		sailRightMat.SetFloat("_HeightMapScale", currentStretch);

		// Update the wobble on the sails
		sailLeftMat.SetFloat("_WindAmplitude", currentWobble);
		sailRightMat.SetFloat("_WindAmplitude", currentWobble);

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
		startingWobble = currentWobble;
		newRotation = rotation;
		lerpTime = 0f;
	}

	private void PlaySailCreakSound()
	{
		// Play sail creak noise
		sailCreakNoise.pitch = 1 + Random.Range(-randomSailCreakNoisePitch / 2f, randomSailCreakNoisePitch / 2f);
		sailCreakNoise.Play();
	}

	public void UpdateSailMaterial()
	{
		// Change the sail mat depending on the current events that have taken place
		if (GameManager.GotFishPatch)
		{
			if (GameManager.GotButterflyPatch)
			{
				if (GameManager.GotBananaPatch)
				{
					// Apply all patch mat
					sailClothLeft.GetComponent<MeshRenderer>().material = sailMaterials[0];
					sailClothRight.GetComponent<MeshRenderer>().material = sailMaterials[0];
				}
				else
				{
					// Apply Fish and Butterfly mat
					sailClothLeft.GetComponent<MeshRenderer>().material = sailMaterials[1];
					sailClothRight.GetComponent<MeshRenderer>().material = sailMaterials[1];
				}
			}
			else if (GameManager.GotBananaPatch)
			{
				// Apply Fish and Banana mat
				sailClothLeft.GetComponent<MeshRenderer>().material = sailMaterials[2];
				sailClothRight.GetComponent<MeshRenderer>().material = sailMaterials[2];
			}
			else
			{
				// Apply Fish mat
				sailClothLeft.GetComponent<MeshRenderer>().material = sailMaterials[3];
				sailClothRight.GetComponent<MeshRenderer>().material = sailMaterials[3];
			}
		}
		else if (GameManager.GotButterflyPatch)
		{
			if (GameManager.GotBananaPatch)
			{
				// Apply Butterfly and Banana mat
				sailClothLeft.GetComponent<MeshRenderer>().material = sailMaterials[4];
				sailClothRight.GetComponent<MeshRenderer>().material = sailMaterials[4];
			}
			else
			{
				// Apply Butterfly mat
				sailClothLeft.GetComponent<MeshRenderer>().material = sailMaterials[5];
				sailClothRight.GetComponent<MeshRenderer>().material = sailMaterials[5];
			}
		}
		else if (GameManager.GotBananaPatch)
		{
			// Apply Banana mat
			sailClothLeft.GetComponent<MeshRenderer>().material = sailMaterials[6];
			sailClothRight.GetComponent<MeshRenderer>().material = sailMaterials[6];
		}

		// Get the sail materials
		sailLeftMat = sailClothLeft.GetComponent<MeshRenderer>().material;
		sailRightMat = sailClothRight.GetComponent<MeshRenderer>().material;
	}
}
