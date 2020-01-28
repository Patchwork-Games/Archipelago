using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GettingInAndOutBoat : MonoBehaviour
{
	private PlayerMovement playerMovement = null;
	[SerializeField] private CinemachineFreeLook boatCamera = null;
	[SerializeField] private CinemachineFreeLook playerCamera = null;
	private bool playerInsideTriggerBox = false;
	private bool boatHasEnteredShallowWater = false;
	private bool playerInBoat = false;
	private InputMaster controls = null;

	private void Awake()
	{
		// Setup the controls
		controls = new InputMaster();
	}

	private void OnTriggerEnter(Collider other)
	{
		// If the player has collided with the trigger box then set the player movement script
		if (other.CompareTag("Player"))
		{
			playerInsideTriggerBox = true;
			playerMovement = other.GetComponent<PlayerMovement>();
		}

		// Check if the boat has collided with shallow water
		if (other.CompareTag("ShallowWater"))
		{
			boatHasEnteredShallowWater = true;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		// If the player has collided with the trigger box then set the player movement script
		if (other.CompareTag("Player"))
		{
			playerInsideTriggerBox = false;
		}

		// Check if the boat has left the shallow water
		if (other.CompareTag("ShallowWater"))
		{
			boatHasEnteredShallowWater = false;
		}
	}

	private void GetInBoat()
	{
		// Return from the function if the player is already in the boat or if the player ins't inside the trigger box
		if (!playerInsideTriggerBox || playerInBoat)
			return;

		// If the player in currently in the moving state then change them to the boat state and start getting in bot animation
		if (playerMovement.state == PlayerMovement.PlayerState.MOVING)
		{
			playerMovement.state = PlayerMovement.PlayerState.BOAT;
			playerMovement.ChangeCamera(boatCamera, true);
			playerInBoat = true;

			// TO DO: ADD ANIMATION
			Debug.Log("Getting in boat animation missing!");
		}
	}

	private void GetOutBoat()
	{
		// If the player isn't in the boat then they can't get out, so return from the function
		if (!playerInBoat)
			return;

		// Change the player state from being in the boat to it's moving state after playing an animation
		if (playerMovement.state == PlayerMovement.PlayerState.BOAT)
		{
			// TO DO: ADD ANIMATION 
			Debug.Log("Getting out boat animation missing!");

			playerMovement.state = PlayerMovement.PlayerState.MOVING;
			playerMovement.ChangeCamera(boatCamera, false);
			playerInBoat = false;
		}
	}

	private void OnEnable()
	{
		// Interation button
		controls.Player.AButton.performed += ctx => GetInBoat();
		controls.Player.AButton.Enable();
	}

	private void OnDisable()
	{
		// Interation button
		controls.Player.AButton.performed -= ctx => GetInBoat();
		controls.Player.AButton.Disable();
	}
}
