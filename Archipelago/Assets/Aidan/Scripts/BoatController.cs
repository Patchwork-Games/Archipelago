using System.Collections;
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

	[SerializeField] private WheelCollider frontLeftW = null, frontRightW = null;
	[SerializeField] private WheelCollider rearLeftW = null, rearRightW = null;
	[SerializeField] private float maxSteerAngle = 30f;
	[SerializeField] private float motorForce = 50f;
	[SerializeField] private float dashForce = 20f;
	[SerializeField] private float dashTime = 3f;
	[SerializeField] private float maxSpeed = 30f;

	private Vector2 movementInput = Vector2.zero;
	private float steeringAngle = 0f;
	private bool isDashing = false;
	private float elapsedDashTime = 0f;
	private Rigidbody rb = null;

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
	}

	private void Dash()
	{
		// Check if the in ocean state is active, if not return from this function
		if (State != BoatState.IN_OCEAN)
			return;

		if (!isDashing)
		{
			isDashing = true;
			elapsedDashTime = dashTime;
		}
	}

	public void AddGustForce(float gustForce)
	{
		rb.AddForce(transform.forward * gustForce);
	}

	private void CapVelocity()
	{
		rb.velocity = new Vector3(Mathf.Clamp(rb.velocity.x, -maxSpeed, maxSpeed), Mathf.Clamp(rb.velocity.y, -maxSpeed, maxSpeed), Mathf.Clamp(rb.velocity.z, -maxSpeed, maxSpeed));
	}

	private void Steer()
	{
		// Calculate the steering angle
		steeringAngle = Mathf.Lerp(steeringAngle, maxSteerAngle * movementInput.x, .01f);
		//steeringAngle = maxSteerAngle * movementInput.x;


		frontLeftW.steerAngle = steeringAngle;
		frontRightW.steerAngle = steeringAngle;
	}

	private void Accelerate()
	{
		frontLeftW.motorTorque = motorForce;
		frontRightW.motorTorque = motorForce;
	}

	private void Update()
	{
		// Change the state to the player not in boat state if the player isn't in the boat
		if (PlayerMovement.Instance.state != PlayerMovement.PlayerState.BOAT)
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

	private void FixedUpdate()
	{
		// Change what happens depending on the state
		switch (State)
		{
			case BoatState.IN_OCEAN:
				Steer();
				Accelerate();
				break;
			case BoatState.IN_SHALLOW_WATER:
				Steer();
				Accelerate();
				break;
			case BoatState.PLAYER_NOT_IN_BOAT:
				break;
			default:
				break;
		}

		CapVelocity();
	}

	private void UpdateInOceanState()
	{
		// Dash count down
		if (elapsedDashTime > 0 && isDashing)
		{
			elapsedDashTime -= Time.deltaTime;
			if (elapsedDashTime <= 0)
			{
				// Reset the motor force when 
				isDashing = false;
			}
			else
			{
				rb.AddForce(transform.forward * dashForce, ForceMode.Impulse);
			}
		}
	}


	private void UpdateInShallowWaterState()
	{
		
	}

	private void UpdatePlayerNotInBoatState()
	{
		if (PlayerMovement.Instance.state == PlayerMovement.PlayerState.BOAT)
		{
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
