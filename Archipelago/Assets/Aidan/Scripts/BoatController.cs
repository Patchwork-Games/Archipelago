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
	[SerializeField] private float dashImpulse = 1500f;
	[SerializeField] private float dashForce = 1000f;
	[SerializeField] private float dashTime = 3f;
	[SerializeField] private float dashFOV = 48f;
	[SerializeField] private float cameraZoomOutTime = .5f;
	[SerializeField] private float cameraZoomInTime = 1f;
	[SerializeField] private float maxSpeedInOcean = 30f;
	[SerializeField] private float maxSpeedInShallows = 5f;
	[SerializeField] private float quickTurnForce = 50f;
	[SerializeField] private ParticleSystem dashCameraParticles = null;

	private Vector2 movementInput = Vector2.zero;
	private float steeringAngle = 0f;
	private float elapsedDashTime = 0f;
	private Rigidbody rb = null;
	private Vector3 smoothDampVelocity = Vector3.zero;
	private bool applyQuickLeftForce = false;
	private bool applyQuickRightForce = false;
	private float originalBoatCameraFOV = 0f;
	private float zoomLerpTime = 0;

	// Particles
	private Transform particlesTransform = null;
	private ParticleSystem boatBackBubbles;

	// Audio
	[SerializeField] private float speedToStartWaterNoise = 10f;
	private AudioSource dashNoise = null;
	private AudioSource waterOnBoatNoise = null;

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

		#region Audio

		Transform audioObjectTrasform = transform.Find("Audio");
		if (audioObjectTrasform == null)
		{
			Debug.Log("Missing Audio child on object: " + gameObject);
		}
		else
		{
			// Get the dash sound
			dashNoise = audioObjectTrasform.Find("DashNoise").GetComponent<AudioSource>();
			if (dashNoise == null)
			{
				Debug.Log("Missing DashNoise child on object: " + audioObjectTrasform.gameObject);
			}

			// Get the water on boat noise
			waterOnBoatNoise = audioObjectTrasform.Find("WaterOnBoatNoise").GetComponent<AudioSource>();
			if (waterOnBoatNoise == null)
			{
				Debug.Log("Missing WaterOnBoatNoise child on object: " + audioObjectTrasform.gameObject);
			}
		}


		#endregion
	}

	private void Start()
	{
		originalBoatCameraFOV = StaticValueHolder.BoatCamera.m_Lens.FieldOfView;

		// Play the water on boat sound at a very low volume
		waterOnBoatNoise.volume = 0;
		waterOnBoatNoise.Play();
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
			rb.AddForce(transform.forward * dashImpulse, ForceMode.Impulse);

			if (!IsDashing)
			{
				zoomLerpTime = 0;
			}

			// Start the timer
			IsDashing = true;
			elapsedDashTime = dashTime;

			// Play sound
			dashNoise.Play();

			// Start emitting particle from the camera
			ParticleSystem.EmissionModule emit = dashCameraParticles.emission;
			emit.enabled = true;
			dashCameraParticles.Play();
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
		rb.AddForce(transform.forward * impulseForce, ForceMode.Impulse);
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

	public static float EaseOutQuart(float start, float end, float value)
	{
		value--;
		end -= start;
		return -end * (value * value * value * value - 1) + start;
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
			// Add the dash force to the boat
			rb.AddForce(transform.forward * dashForce, ForceMode.Force);

			// Change the camera's FOV
			if (zoomLerpTime < 1)
			{
				zoomLerpTime += Time.deltaTime / cameraZoomOutTime;
				StaticValueHolder.BoatCamera.m_Lens.FieldOfView = Mathf.Lerp(originalBoatCameraFOV, dashFOV, zoomLerpTime);
			}

			elapsedDashTime -= Time.deltaTime;
			if (elapsedDashTime <= 0)
			{
				IsDashing = false;
				elapsedDashTime = 0f;
				zoomLerpTime = 0f;

				// Stop emitting particle from the camera
				ParticleSystem.EmissionModule emit = dashCameraParticles.emission;
				emit.enabled = false;
				dashCameraParticles.Stop();
			}
		}
		else if (zoomLerpTime < 1)
		{
			// Change the camera's FOV
			zoomLerpTime += Time.deltaTime / cameraZoomInTime;
			StaticValueHolder.BoatCamera.m_Lens.FieldOfView = Mathf.Lerp(dashFOV, originalBoatCameraFOV, zoomLerpTime);
		}

		Speed = Vector3.Magnitude(rb.velocity);

		// Set the volume of the water on boat sound
		waterOnBoatNoise.volume = Speed / maxSpeedInOcean;
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
