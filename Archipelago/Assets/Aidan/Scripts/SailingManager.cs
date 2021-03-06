﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SailingManager : MonoBehaviour
{
    private InputMaster controls = null;
    [SerializeField] private float maxSpeed = 10f;
    [SerializeField] private float steeringForce = 10f;
	[SerializeField] private float forceMultiplier = 0f;
	[SerializeField] private float shallowWaterBoatForce = 100f;
    private Rigidbody rb = null;

	public enum BoatState
	{
		IN_OCEAN,
		IN_SHALLOW_WATER,
		PLAYER_NOT_IN_BOAT
	}
	public BoatState State { get; set; }

    // Steering variables
    private bool isSteering = false;
    private Vector2 moveDirection = Vector2.zero;

    // Dashing variables
    [SerializeField] private float dashingTime = 2f;
    [SerializeField] private float dashForce = 30f;
    private bool isDashing = false;
    private float elapsedDashTime = 0f;

    private void Awake()
    {
        // Setup the controls
        controls = new InputMaster();

        // Assign components to variables
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.Log("No Rigidbody found in SailingManager script!");
        }
    }

    // Update is called once per frame
    void Update()
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
				UpdateInOceanState();
				break;
			case BoatState.IN_SHALLOW_WATER:
				UpdateInShallowWaterState();
				break;
			case BoatState.PLAYER_NOT_IN_BOAT:
				UpdatePlayerNotInBoatState();
				break;
			default:
				break;
		}
    }

    private void SteerBoat(Vector2 movementAxis)
    {
		// Only do this update if the player is in the boat
		if (PlayerStateMachine.Instance.state != PlayerStateMachine.PlayerState.BOAT)
			return;

		isSteering = true;
        moveDirection = movementAxis;
    }

    private void Dash()
    {
		// Only do this update if the player is in the boat and in the ocean
		if (PlayerStateMachine.Instance.state != PlayerStateMachine.PlayerState.BOAT || State == BoatState.IN_SHALLOW_WATER)
			return;

		// For a certain amount of time, add a greater force forward
		isDashing = true;
        elapsedDashTime = dashingTime;
    }

	public void AddGustForce(float forceToAdd)
	{
		rb.AddForce(transform.forward * forceToAdd * forceMultiplier * Time.deltaTime);
		Debug.Log("Gust force added!");
	}

	private void UpdateInOceanState()
	{
		// The boat should have the wind force applied to the forward vector to make the boat move
		rb.AddForce(transform.forward * StaticValueHolder.WindManagerObject.windForce * forceMultiplier * Time.deltaTime);

		// Steering
		{
			if (isSteering)
			{
				// Add a torque force in the direction the player wants to move
				rb.AddTorque(new Vector3(0, moveDirection.x * steeringForce * forceMultiplier * Time.deltaTime, 0));
			}
		}

		// Dashing
		{
			if (isDashing)
			{
				// Make a count down for how long the boat should be dashing
				if (elapsedDashTime > 0)
				{
					// Add the dash force onto the boat
					rb.AddForce(transform.forward * dashForce * forceMultiplier * Time.deltaTime);

					// Decrement the counter and check if the time is up
					elapsedDashTime -= Time.deltaTime;
					if (elapsedDashTime <= 0)
					{
						isDashing = false;
					}

				}
			}
		}

		KillLateralVelocity();
		CapVelocity();
	}


	private void UpdateInShallowWaterState()
	{
		isDashing = false;

		// The boat should have the wind force applied to the forward vector to make the boat move
		rb.AddForce(transform.forward * shallowWaterBoatForce * forceMultiplier * Time.deltaTime);

		// Steering
		{
			if (isSteering)
			{
				// Add a torque force in the direction the player wants to move
				rb.AddTorque(new Vector3(0, moveDirection.x * steeringForce * forceMultiplier * Time.deltaTime, 0));
			}
		}

		KillLateralVelocity();
		CapVelocity();
	}

	private void UpdatePlayerNotInBoatState()
	{
		if (PlayerStateMachine.Instance.state == PlayerStateMachine.PlayerState.BOAT)
		{
			State = BoatState.IN_SHALLOW_WATER;
		}
	}

	private Vector3 GetLateralVelocity()
	{
		return Vector3.Dot(transform.right, rb.velocity) * transform.right;
	}

	private void KillLateralVelocity()
	{
		Vector3 impulse = rb.mass * -GetLateralVelocity();
		rb.AddForce(impulse * 100 * Time.deltaTime);
		rb.angularVelocity = Vector3.zero;
	}

	private void CapVelocity()
	{
		rb.velocity = new Vector3(Mathf.Clamp(rb.velocity.x, -maxSpeed, maxSpeed), Mathf.Clamp(rb.velocity.y, -maxSpeed, maxSpeed), Mathf.Clamp(rb.velocity.z, -maxSpeed, maxSpeed));
	}

    private void OnEnable()
    {
        // Steering
        controls.Boat.Steering.performed += ctx => SteerBoat(ctx.ReadValue<Vector2>());
        controls.Boat.Steering.canceled += ctx => isSteering = false;
        controls.Boat.Steering.Enable();

        // Dashing
        controls.Boat.Dash.performed += ctx => Dash();
        controls.Boat.Dash.Enable();
    }

    private void OnDisable()
    {
        // Steering
        controls.Boat.Steering.performed -= ctx => SteerBoat(ctx.ReadValue<Vector2>());
        controls.Boat.Steering.canceled -= ctx => isSteering = false;
        controls.Boat.Steering.Disable();

        // Dashing
        controls.Boat.Dash.performed -= ctx => Dash();
        controls.Boat.Dash.Disable();
    }
}
