using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Rendering.PostProcessing;

public class GameManager : MonoBehaviour
{
	[SerializeField] private GameObject boatObject = null;
	[SerializeField] private GameObject playerCharacterObject = null;
	[SerializeField] private DashMeter dashMeter = null;
	[SerializeField] private CinemachineFreeLook playerCharacterCamera = null;
	[SerializeField] private CinemachineFreeLook boatCamera = null;
	[SerializeField] private WindManager windManager = null;
	[SerializeField] private GameObject staticCoroutinePrefab = null;
	[SerializeField] private CollectableUIUpdate collectableUIUpdate = null;
	[SerializeField] private PostProcessVolume postProcessVolumeObject = null;
	[SerializeField] private DialogueManager dialogueManagerObject = null;
	private PlayerMovement playerMovement = null;

	// Events
	public static bool SailingEnabled { get; set; } = false;
	public static bool GotFishPatch { get; set; } = false;
	public static bool GotButterflyPatch { get; set; } = false;
	public static bool GotBananaPatch { get; set; } = false;

	private void Awake()
	{
		#region Set the static value holder to have references to gameobjects

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

			// Player movement
			if (playerCharacterObject != null)
			{
				playerMovement = playerCharacterObject.GetComponent<PlayerMovement>();
				if (playerMovement != null)
				{
					StaticValueHolder.PlayerMovementScript = playerMovement;
				}
			}
			else
				Debug.LogError("PlayerMovement missing from game manager script on object: " + this.gameObject);

			// Wind manager
			if (windManager != null)
				StaticValueHolder.WindManagerObject = windManager;
			else
				Debug.LogError("WindManager missing from game manager script on object: " + this.gameObject);

			// CollectableUIUpdate
			if (collectableUIUpdate != null)
				StaticValueHolder.CollectableUIUpdateObject = collectableUIUpdate;
			else
				Debug.LogError("CollectableUIUpdate missing from game manager script on object: " + this.gameObject);

			// PostProcessVolume
			if (postProcessVolumeObject != null)
				StaticValueHolder.PostProcessVolumeObject = postProcessVolumeObject;
			else
				Debug.LogError("PostProcessVolumeObject missing from game manager script on object: " + this.gameObject);

			// Dialogue manager
			if (dialogueManagerObject != null)
				StaticValueHolder.DialogueManagerObject = dialogueManagerObject;
			else
				Debug.LogError("DialogueManagerObject missing from game manager script on object: " + this.gameObject);

		#endregion

		// Instatiate the static coroutine object in the scene
		Instantiate(staticCoroutinePrefab, Vector3.zero, Quaternion.identity);
	}
}
