using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatController : MonoBehaviour
{
	private InputMaster controls = null;
	private Vector2 movementInput = Vector2.zero;
	private float steeringAngle = 0f;

	[SerializeField] private WheelCollider frontLeftW = null, frontRightW = null;
	[SerializeField] private WheelCollider rearLeftW = null, rearRightW = null;
	[SerializeField] private WheelCollider sideLeftW = null, sideRightW = null;
	[SerializeField] private Transform frontLeftT = null, frontRightT = null;
	[SerializeField] private Transform rearLeftT = null, rearRightT = null;
	[SerializeField] private float maxSteerAngle = 30f;
	[SerializeField] private float motorForce = 50f;

	private void Awake()
	{
		controls = new InputMaster();
	}

	private void OnEnable()
	{
		controls.Boat.Steering.performed += ctx => movementInput = ctx.ReadValue<Vector2>();
		controls.Boat.Steering.canceled += ctx => movementInput = ctx.ReadValue<Vector2>();
		controls.Boat.Steering.Enable();
	}

	private void OnDisable()
	{
		controls.Boat.Steering.performed -= ctx => movementInput = ctx.ReadValue<Vector2>();
		controls.Boat.Steering.canceled -= ctx => movementInput = ctx.ReadValue<Vector2>();
		controls.Boat.Steering.Disable();
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
		frontLeftW.motorTorque = movementInput.y * motorForce;
		frontRightW.motorTorque = movementInput.y * motorForce;
	}

	private void UpdateWheelPoses()
	{
		// Updates how the wheels look
		UpdateWheelPose(frontLeftW, frontLeftT);
		UpdateWheelPose(frontRightW, frontRightT);
		UpdateWheelPose(rearLeftW, rearLeftT);
		UpdateWheelPose(rearRightW, rearRightT);
	}

	private void UpdateWheelPose(WheelCollider _collider, Transform _transform)
	{
		Vector3 pos = _transform.position;
		Quaternion quat = _transform.rotation;

		_collider.GetWorldPose(out pos, out quat);

		_transform.position = pos;
		_transform.rotation = quat;
	}

	private void FixedUpdate()
	{
		Steer();
		Accelerate();
		//UpdateWheelPoses();
	}
}
