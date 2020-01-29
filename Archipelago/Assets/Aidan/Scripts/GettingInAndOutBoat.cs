using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GettingInAndOutBoat : MonoBehaviour
{
	private PlayerMovement playerMovement = null;
	[SerializeField] private CinemachineFreeLook boatCamera = null;
	[SerializeField] private CinemachineFreeLook playerCamera = null;
	[SerializeField] private Transform playerPosWhenComingOutOfBoat = null;
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
			transform.parent.GetComponent<SailingManager>().State = SailingManager.BoatState.IN_SHALLOW_WATER;
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
			transform.parent.GetComponent<SailingManager>().State = SailingManager.BoatState.IN_OCEAN;
		}
	}

	private void GetInOrOutOfBoat()
	{
		// If the player movement script hasn't been set, return
		if (playerMovement == null || !boatHasEnteredShallowWater)
			return;

		// Change what happens depending on the state
		switch (playerMovement.state)
		{
			case PlayerMovement.PlayerState.MOVING:
				GetInBoat();
				break;
			case PlayerMovement.PlayerState.BOAT:
				GetOutBoat();
				break;
			default:
				break;
		}
	}

	private void GetInBoat()
	{
		// Return from the function if the player is already in the boat or if the player ins't inside the trigger box
		if (!playerInsideTriggerBox || playerInBoat)
			return;

		// Change the state to the boat state and change the camera to follow the boat
		playerMovement.state = PlayerMovement.PlayerState.BOAT;
		playerMovement.ChangeCamera(boatCamera, true);
		playerInBoat = true;

		// TO DO: ADD ANIMATION
		Debug.Log("Getting in boat animation missing!");
		
	}

	private void GetOutBoat()
	{
		// If the player isn't in the boat then they can't get out, so return from the function
		if (!playerInBoat)
			return;

		// TO DO: ADD ANIMATION 
		Debug.Log("Getting out boat animation missing!");
		
		// Change the state to the moving state and change the camera to follow the player
		playerMovement.state = PlayerMovement.PlayerState.MOVING;
		Debug.Log("Poop");
		playerMovement.ChangeCamera(boatCamera, false);
		playerInBoat = false;
		playerMovement.gameObject.transform.position = new Vector3(playerPosWhenComingOutOfBoat.position.x, playerPosWhenComingOutOfBoat.position.y, playerPosWhenComingOutOfBoat.position.z);
		
	}

	private void OnEnable()
	{
		// Interation button
		controls.Player.Interact.performed += ctx => GetInOrOutOfBoat();
		controls.Player.Interact.Enable();
	}

	private void OnDisable()
	{
		// Interation button
		controls.Player.Interact.performed -= ctx => GetInOrOutOfBoat();
		controls.Player.Interact.Disable();
	}
}
