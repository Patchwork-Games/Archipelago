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

	// Public variables
	public BoatState State { get; set; } = BoatState.PLAYER_NOT_IN_BOAT;
	public bool IsDashing { get; private set; } = false;
	public float Speed { get; private set; } = 0f;

	[SerializeField] private GameObject anchorObject = null;
	[SerializeField] private WheelCollider frontLeftW = null, frontRightW = null;
	[SerializeField] private WheelCollider sideLeftW = null, sideRightW = null;
	[SerializeField] private float maxSteerAngle = 30f;
	[SerializeField] private float motorForce = 50f;
	[SerializeField] private float dashForce = 20f;
	[SerializeField] private float dashTime = 3f;
	[SerializeField] private float maxSpeedInOcean = 30f;
	[SerializeField] private float maxSpeedInShallows = 5f;
	[SerializeField] private float quickTurnForce = 50f;

	private Vector2 movementInput = Vector2.zero;
	private float steeringAngle = 0f;
	private float elapsedDashTime = 0f;
	private Rigidbody rb = null;
	private Vector3 smoothDampVelocity = Vector3.zero;
	private bool applyQuickLeftForce = false;
	private bool applyQuickRightForce = false;

	// Particles
	private Transform particlesTransform = null;
	private ParticleSystem boatBackBubbles;

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

		// Get the particles object
		particlesTransform = transform.Find("Particles");
		if (particlesTransform == null)
		{
			Debug.Log("Particles child object missing from object: " + this.gameObject);
		}
	}

	private void Dash()
	{
		// Check if the in ocean state is active, if not return from this function
		if (State == BoatState.PLAYER_NOT_IN_BOAT)
			return;

		// Return from the function is there is no energy left
		if (!StaticValueHolder.DashMeterObject.DashBarIsEmpty)
		{
			// Use one of the dash meters energies
			StaticValueHolder.DashMeterObject.UseDash();

			// Add the dash force to the boat
			rb.AddForce(transform.forward * dashForce * Time.deltaTime, ForceMode.Impulse);

			// Start the timer
			IsDashing = true;
			elapsedDashTime = dashTime;
		}

	}

	private void QuickLeft()
	{
		Debug.Log("Quick left");

		Vector3 rotatedVector = Vector3.Normalize(Quaternion.Euler(0, 45, 0) * transform.forward);
		Debug.DrawRay(transform.position - (transform.forward * 5), rotatedVector, Color.red, 10);
		//rb.AddForce(rotatedVector * 1000 * Time.deltaTime, ForceMode.Impulse);
		rb.AddForceAtPosition(rotatedVector * quickTurnForce, transform.position - (transform.forward * 5), ForceMode.Force);
	}

	private void QuickRight()
	{
		Debug.Log("Quick right");

		Vector3 rotatedVector = Vector3.Normalize(Quaternion.Euler(0, -45, 0) * transform.forward);
		Debug.DrawRay(transform.position - (transform.forward * 5), rotatedVector, Color.red, 10);
		//rb.AddForce(rotatedVector * 1000 * Time.deltaTime, ForceMode.Impulse);
		rb.AddForceAtPosition(rotatedVector * quickTurnForce, transform.position - (transform.forward * 5), ForceMode.Force);
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

	private void Accelerate(float force)
	{
		frontLeftW.motorTorque = force;
		frontRightW.motorTorque = force;
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

		// Dashing timer
		if (elapsedDashTime > 0)
		{
			elapsedDashTime -= Time.deltaTime;
			if (elapsedDashTime <= 0)
			{
				IsDashing = false;
				elapsedDashTime = 0;
			}
		}

		Speed = Vector3.Magnitude(rb.velocity);
	}

	private void FixedUpdate()
	{
		// Change what happens depending on the state
		switch (State)
		{
			case BoatState.IN_OCEAN:
				Steer();
				Accelerate(motorForce);
				CapVelocity(maxSpeedInOcean);
				break;
			case BoatState.IN_SHALLOW_WATER:
				Steer();
				Accelerate(motorForce/2);
				CapVelocity(maxSpeedInOcean);
				if (rb.velocity.magnitude > maxSpeedInShallows)
				{
					Vector3 newVel = Vector3.SmoothDamp(rb.velocity,new Vector3(0,0, maxSpeedInShallows), ref smoothDampVelocity, 1f);
					rb.velocity = newVel;
				}
				break;
			case BoatState.PLAYER_NOT_IN_BOAT:
				CapVelocity(maxSpeedInShallows);
				break;
			default:
				break;
		}

		if (applyQuickLeftForce)
		{
			QuickLeft();
		}

		if (applyQuickRightForce)
		{
			QuickRight();
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

		// Quick turning
		controls.Boat.QuickLeft.performed += ctx => applyQuickLeftForce = true;//QuickLeft();
		controls.Boat.QuickLeft.canceled += ctx => applyQuickLeftForce = false;
		controls.Boat.QuickLeft.Enable();
		controls.Boat.QuickRight.performed += ctx => applyQuickRightForce = true;//QuickRight();
		controls.Boat.QuickRight.canceled += ctx => applyQuickRightForce = false;
		controls.Boat.QuickRight.Enable();
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

		// Quick turning
		controls.Boat.QuickLeft.performed -= ctx => applyQuickLeftForce = true;//QuickLeft();
		controls.Boat.QuickLeft.canceled -= ctx => applyQuickLeftForce = false;
		controls.Boat.QuickLeft.Disable();
		controls.Boat.QuickRight.performed -= ctx => applyQuickRightForce = true;//QuickRight();
		controls.Boat.QuickRight.canceled -= ctx => applyQuickRightForce = false;
		controls.Boat.QuickRight.Disable();
	}
}
