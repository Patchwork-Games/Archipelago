﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatController : MonoBehaviour
{
	private InputMaster controls = null;

	public enum BoatState
	{
		IN_OCEAN,
		IN_SHALLOW_WATER,
		PLAYER_NOT_IN_BOAT
	}
	public BoatState State { get; set; } = BoatState.PLAYER_NOT_IN_BOAT;

	[SerializeField] private GameObject anchorObject = null;
	[SerializeField] private WheelCollider frontLeftW = null, frontRightW = null;
	[SerializeField] private WheelCollider sideLeftW = null, sideRightW = null;
	[SerializeField] private float maxSteerAngle = 30f;
	[SerializeField] private float motorForce = 50f;
	[SerializeField] private float dashForce = 20f;
	[SerializeField] private float dashTime = 3f;
	[SerializeField] private float maxSpeedInOcean = 30f;
	[SerializeField] private float maxSpeedInShallows = 5f;

	private Vector2 movementInput = Vector2.zero;
	private float steeringAngle = 0f;
	private bool isDashing = false;
	private float elapsedDashTime = 0f;
	private Rigidbody rb = null;
	private float originalMotorForce = 0f;

	private void Awake()
	{
		// Make new controls object so the script can recieve input
		controls = new InputMaster();

		// Get the rigid body component from this game object
		rb = GetComponent<Rigidbody>();
		if (rb == null)
		{
			Debug.Log("Missing Rigidbody component on BoatController script!");
		}

		originalMotorForce = motorForce;
	}

	private void Dash()
	{
		// Check if the in ocean state is active, if not return from this function
		if (State == BoatState.PLAYER_NOT_IN_BOAT)
			return;

		// Return from the function is there is no energy left
		if (!StaticValueHolder.DashMeterObject.EnergyBarIsEmpty)
		{
			// Use one of the dash meters energies
			StaticValueHolder.DashMeterObject.UseEnergies(1);

			// Add the dash force to the boat
			rb.AddForce(transform.forward * dashForce * Time.deltaTime, ForceMode.Impulse);
		}

	}

	public void AddGustForce(float gustForce)
	{
		rb.AddForce(transform.forward * gustForce * Time.deltaTime);
	}

	public void AddImpulse(float impulseForce)
	{
		rb.AddForce(transform.forward * impulseForce * Time.deltaTime, ForceMode.Impulse);
	}

	private void CapVelocity(float cap)
	{
		rb.velocity = new Vector3(Mathf.Clamp(rb.velocity.x, -cap, cap), Mathf.Clamp(rb.velocity.y, -cap, cap), Mathf.Clamp(rb.velocity.z, -cap, cap));
	}

	private void Steer()
	{
		// Calculate the steering angle
		if (movementInput.x > 0.1 || movementInput.x < -0.1)
		{
			steeringAngle = maxSteerAngle * movementInput.x;
		}
		else
		{
			steeringAngle = 0;
		}

		frontLeftW.steerAngle = steeringAngle;
		frontRightW.steerAngle = steeringAngle;
		sideLeftW.steerAngle = steeringAngle;
		sideRightW.steerAngle = steeringAngle;
	}

	private void Accelerate()
	{
		frontLeftW.motorTorque = motorForce;
		frontRightW.motorTorque = motorForce;
	}

	private void Update()
	{
		// Change the state to the player not in boat state if the player isn't in the boat
		if (PlayerStateMachine.Instance.state != PlayerStateMachine.PlayerState.BOAT)
		{
			State = BoatState.PLAYER_NOT_IN_BOAT;
		}

		// Change what happens depending on the state
		switch (State)
		{
			case BoatState.IN_OCEAN:
				break;
			case BoatState.IN_SHALLOW_WATER:
				break;
			case BoatState.PLAYER_NOT_IN_BOAT:
				UpdatePlayerNotInBoatState();
				break;
			default:
				break;
		}

		
	}

	private void FixedUpdate()
	{
		// Change what happens depending on the state
		switch (State)
		{
			case BoatState.IN_OCEAN:
				Steer();
				Accelerate();
				CapVelocity(maxSpeedInOcean);
				break;
			case BoatState.IN_SHALLOW_WATER:
				Steer();
				Accelerate();
				CapVelocity(maxSpeedInShallows);
				break;
			case BoatState.PLAYER_NOT_IN_BOAT:
				CapVelocity(maxSpeedInShallows);
				break;
			default:
				break;
		}
	}

	private void UpdatePlayerNotInBoatState()
	{
		// Set the anchor to be active
		if (!anchorObject.activeSelf)
		{
			anchorObject.SetActive(true);
		}

		if (PlayerStateMachine.Instance.state == PlayerStateMachine.PlayerState.BOAT)
		{
			anchorObject.GetComponent<AnchorManager>().TakeInAnchor();
			anchorObject.SetActive(false);
			State = BoatState.IN_SHALLOW_WATER;
		}
	}

	private void OnEnable()
	{
		// Steering
		controls.Boat.Steering.performed += ctx => movementInput = ctx.ReadValue<Vector2>();
		controls.Boat.Steering.canceled += ctx => movementInput = ctx.ReadValue<Vector2>();
		controls.Boat.Steering.Enable();

		// Dashing
		controls.Boat.Dash.performed += ctx => Dash();
		controls.Boat.Dash.Enable();
	}

	private void OnDisable()
	{
		// Steering
		controls.Boat.Steering.performed -= ctx => movementInput = ctx.ReadValue<Vector2>();
		controls.Boat.Steering.canceled -= ctx => movementInput = ctx.ReadValue<Vector2>();
		controls.Boat.Steering.Disable();

		// Dashing
		controls.Boat.Dash.performed -= ctx => Dash();
		controls.Boat.Dash.Disable();
	}
}
