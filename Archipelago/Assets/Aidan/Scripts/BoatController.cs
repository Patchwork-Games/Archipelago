using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

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
	[SerializeField] public BoatMastController MastController = null;
	
	private Vector2 movementInput = Vector2.zero;
	private float steeringAngle = 0f;
	private float elapsedDashTime = 0f;
	private Rigidbody rb = null;
	private Vector3 smoothDampVelocity = Vector3.zero;
	private bool applyQuickLeftForce = false;
	private bool applyQuickRightForce = false;
	private float originalBoatCameraFOV = 0f;
	private float zoomLerpTime = 0;
	private bool reversing = false;
	public float PercentageSpeed { get; set; } = 0f;

	// Particles
	[SerializeField] private ParticleSystem dashCameraParticles = null;
	[SerializeField] private float speedToActivateTrailParticles = 10f;
	private ParticleSystem boatSideTrailsLeft = null;
	private ParticleSystem boatSideTrailsRight = null;
	private ParticleSystem bowBubbles = null;
	private bool boatTrailParticlesEmitting = false;

	// Audio
	private AudioSource dashNoise = null;
	private AudioSource waterOnBoatNoise = null;

	// Post processing
	private PostProcessVolume postProcessVolume = null;
	private LensDistortion lensDistortion = null;

	// Animation
	private Animator boatAnimator = null;


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

		// Get the boat animator
		boatAnimator = transform.Find("Graphics").GetComponent<Animator>();
		if (boatAnimator == null)
		{
			Debug.Log("Missing Animator component on object: " + transform.Find("Graphics").gameObject);
		}

		#region Particles

		// Get the particles object
		Transform particlesTransform = transform.Find("Particles");
		if (particlesTransform == null)
		{
			Debug.Log("Particles child object missing from object: " + this.gameObject);
		}
		else
		{
			// Get the boat side trails left particles
			boatSideTrailsLeft = particlesTransform.Find("BoatSideTrailsLeft").GetComponent<ParticleSystem>();
			if (boatSideTrailsLeft == null)
			{
				Debug.Log("Missing BoatSideTrailsLeft child on object: " + particlesTransform.gameObject);
			}

			// Get the boat side trails right particles
			boatSideTrailsRight = particlesTransform.Find("BoatSideTrailsRight").GetComponent<ParticleSystem>();
			if (boatSideTrailsRight == null)
			{
				Debug.Log("Missing BoatSideTrailsRight child on object: " + particlesTransform.gameObject);
			}

			// Get Bow bubbles particles
			bowBubbles = particlesTransform.Find("BowBubbles").GetComponent<ParticleSystem>();
			if (bowBubbles == null)
			{
				Debug.Log("Missing BowBubbles child on object: " + particlesTransform.gameObject);
			}
		}

		#endregion

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
		// Get the post process volume object
		postProcessVolume = StaticValueHolder.PostProcessVolumeObject;
		postProcessVolume.profile.TryGetSettings(out lensDistortion);
		lensDistortion.enabled.Override(true);
		lensDistortion.intensity.Override(0f);

		// Set the original FOV of the boat camera
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

			// Trigger dash animation
			boatAnimator.SetTrigger("Dash");

			// Start emitting particle from the camera
			ParticleTools.StartEmission(dashCameraParticles);
		}

	}

	private void QuickLeft()
	{
		Vector3 rotatedVector = Vector3.Normalize(Quaternion.Euler(0, 45, 0) * transform.forward);
		Debug.DrawRay(transform.position - (transform.forward * 5), rotatedVector, Color.red, 10);
		rb.AddForceAtPosition(rotatedVector * quickTurnForce, transform.position - (transform.forward * 5), ForceMode.Force);
	}

	private void QuickRight()
	{
		Vector3 rotatedVector = Vector3.Normalize(Quaternion.Euler(0, -45, 0) * transform.forward);
		Debug.DrawRay(transform.position - (transform.forward * 5), rotatedVector, Color.red, 10);
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
		if (reversing)
		{
			frontLeftW.motorTorque = -force;
			frontRightW.motorTorque = -force;
		}
		else 
		{
			frontLeftW.motorTorque = force;
			frontRightW.motorTorque = force;
		}
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
				StaticValueHolder.BoatCamera.m_Lens.FieldOfView = 
					Mathf.SmoothStep(StaticValueHolder.BoatCamera.m_Lens.FieldOfView, dashFOV, zoomLerpTime);
				lensDistortion.intensity.value = Mathf.SmoothStep(lensDistortion.intensity.value, -30, zoomLerpTime);
			}

			elapsedDashTime -= Time.deltaTime;
			if (elapsedDashTime <= 0)
			{
				IsDashing = false;
				elapsedDashTime = 0f;
				zoomLerpTime = 0f;

				// Stop emitting particle from the camera
				ParticleTools.StopEmission(dashCameraParticles);
			}
		}
		else if (zoomLerpTime < 1)
		{
			// Change the camera's FOV
			zoomLerpTime += Time.deltaTime / cameraZoomInTime;
			StaticValueHolder.BoatCamera.m_Lens.FieldOfView = 
				Mathf.SmoothStep(StaticValueHolder.BoatCamera.m_Lens.FieldOfView, originalBoatCameraFOV, zoomLerpTime);
			lensDistortion.intensity.value = 
				Mathf.SmoothStep(lensDistortion.intensity.value, 0, zoomLerpTime);
		}

		Speed = Vector3.Magnitude(rb.velocity);

		// Calculate the percentage of the total speed the boat is going
		PercentageSpeed = Speed / maxSpeedInOcean;

		// Set the volume of the water on boat sound
		waterOnBoatNoise.volume = PercentageSpeed;

		// Set the emission of the boat trail and bubble particles depending on the boat speed
		if (Speed > speedToActivateTrailParticles)
		{
			if (!boatTrailParticlesEmitting)
			{
				boatTrailParticlesEmitting = true;

				// Enable particle emission
				ParticleTools.StartEmission(boatSideTrailsLeft);
				ParticleTools.StartEmission(boatSideTrailsRight);
				ParticleTools.StartEmission(bowBubbles);
			}
		}
		else
		{
			if (boatTrailParticlesEmitting)
			{
				boatTrailParticlesEmitting = false;

				// Disable particle emission
				ParticleTools.StopEmission(boatSideTrailsLeft);
				ParticleTools.StopEmission(boatSideTrailsRight);
				ParticleTools.StopEmission(bowBubbles);
			}
		}

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
				Accelerate(motorForce);
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


	private void GoUpright() 
	{
		transform.position = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);
		transform.rotation = Quaternion.identity;
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

		//reverse
		controls.Boat.Reverse.performed += ctx => reversing = true;
		controls.Boat.Reverse.canceled += ctx => reversing = false;
		controls.Boat.Reverse.Enable();

		//get upright again
		controls.Boat.Upright.performed += ctx => GoUpright();
		controls.Boat.Upright.Enable();

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

		//reverse
		controls.Boat.Reverse.performed -= ctx => reversing = true;
		controls.Boat.Reverse.canceled -= ctx => reversing = false;
		controls.Boat.Reverse.Enable();

		//get upright again
		controls.Boat.Upright.performed -= ctx => GoUpright();
		controls.Boat.Upright.Enable();

		// Quick turning
		controls.Boat.QuickLeft.performed -= ctx => applyQuickLeftForce = true;//QuickLeft();
		controls.Boat.QuickLeft.canceled -= ctx => applyQuickLeftForce = false;
		controls.Boat.QuickLeft.Disable();
		controls.Boat.QuickRight.performed -= ctx => applyQuickRightForce = true;//QuickRight();
		controls.Boat.QuickRight.canceled -= ctx => applyQuickRightForce = false;
		controls.Boat.QuickRight.Disable();
	}
}
