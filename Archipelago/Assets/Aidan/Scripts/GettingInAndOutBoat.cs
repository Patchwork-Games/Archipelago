using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GettingInAndOutBoat : MonoBehaviour
{
	[SerializeField] private Transform playerPosWhenComingOutOfBoat = null;
	[SerializeField] private Transform playerPosWhenInBoat = null;
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
		}

		// Check if the boat has collided with shallow water
		if (other.CompareTag("ShallowWater"))
		{
			boatHasEnteredShallowWater = true;
			transform.parent.GetComponent<BoatController>().State = BoatController.BoatState.IN_SHALLOW_WATER;
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
			transform.parent.GetComponent<BoatController>().State = BoatController.BoatState.IN_OCEAN;
		}
	}

	private void GetInOrOutOfBoat()
	{
		// If the boat hasn't entered shallow water
		if (!boatHasEnteredShallowWater)
			return;

		// Change what happens depending on the state
		switch (PlayerStateMachine.Instance.state)
		{
			case PlayerStateMachine.PlayerState.MOVING:
				GetInBoat();
				break;
			case PlayerStateMachine.PlayerState.BOAT:
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

        StaticValueHolder.DashMeterObject.gameObject.GetComponent<Canvas>().enabled = true;

		// Change the state to the boat state and change the camera to follow the boat
		PlayerStateMachine.Instance.state = PlayerStateMachine.PlayerState.BOAT;
		StaticValueHolder.PlayerMovementScript.ChangeCamera(StaticValueHolder.BoatCamera, true);
		playerInBoat = true;

		// Teleport the player to the boat, positon them and make the boat their parent (Also disable the players collision box)
		StaticValueHolder.PlayerObject.transform.parent = transform.parent;
		StaticValueHolder.PlayerObject.transform.localPosition = playerPosWhenInBoat.localPosition;
		StaticValueHolder.PlayerObject.transform.localRotation = playerPosWhenInBoat.localRotation;
		StaticValueHolder.PlayerObject.GetComponent<CharacterController>().enabled = false;

		// TO DO: ADD ANIMATION
		Debug.Log("Getting in boat animation missing!");
	}

	private void GetOutBoat()
	{
		// If the player isn't in the boat then they can't get out, so return from the function
		if (!playerInBoat || StaticValueHolder.DialogueManagerObject.boatIntroTextOpen)
			return;

        StaticValueHolder.DashMeterObject.gameObject.GetComponent<Canvas>().enabled = false;
        StaticValueHolder.PlayerMovementScript.interact = false;

		// TO DO: ADD ANIMATION 
		Debug.Log("Getting out boat animation missing!");

        // Change the state to the moving state and change the camera to follow the player
        PlayerStateMachine.Instance.state = PlayerStateMachine.PlayerState.MOVING;
		StaticValueHolder.PlayerMovementScript.ChangeCamera(StaticValueHolder.BoatCamera, false);
		playerInBoat = false;

		// // Teleport the player to the boat, positon them and make the boat their parent (Also disable the players collision box)
		StaticValueHolder.PlayerObject.transform.parent = null;
		StaticValueHolder.PlayerObject.transform.position = new Vector3(playerPosWhenComingOutOfBoat.position.x, playerPosWhenComingOutOfBoat.position.y, playerPosWhenComingOutOfBoat.position.z);
		StaticValueHolder.PlayerObject.GetComponent<CharacterController>().enabled = true;

		playerInsideTriggerBox = false;
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
