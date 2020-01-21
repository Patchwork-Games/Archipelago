using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SailingManager : MonoBehaviour
{
    private InputMaster controls = null;

    [SerializeField] private float windForce = 10f;
    [SerializeField] private float maxSpeed = 10f;
    [SerializeField] private float steeringSpeed = 10f;
    private Rigidbody rb = null;

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

    private void Start()
    {
        // Default values
        elapsedDashTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // The boat should have the wind force applied to the forward vector to make the boat move
        rb.AddForce(transform.forward * windForce * Time.deltaTime);

        // Cap the velocity of the boat
        {
            if (rb.velocity.x > maxSpeed)
            {
                rb.velocity = new Vector3(maxSpeed, rb.velocity.y, rb.velocity.z);
            }
            if (rb.velocity.y > maxSpeed)
            {
                rb.velocity = new Vector3(rb.velocity.x, maxSpeed, rb.velocity.z);
            }
            if (rb.velocity.z > maxSpeed)
            {
                rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, maxSpeed);
            }
        }

        // Steering
        {
            if (isSteering)
            {
                // Add a torque force in the direction the player wants to move
                rb.AddTorque(new Vector3(0, moveDirection.x * steeringSpeed * Time.deltaTime, 0));
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
                    rb.AddForce(transform.forward * dashForce *Time.deltaTime);

                    // Decrement the counter and check if the time is up
                    elapsedDashTime -= Time.deltaTime;
                    if (elapsedDashTime <= 0)
                    {
                        isDashing = false;
                    }

                }
            }
        }
    }

    private void SteerBoat(Vector2 movementAxis)
    {
        isSteering = true;
        moveDirection = movementAxis;
    }

    private void Dash()
    {
        // For a certain amount of time, add a greater force forward
        isDashing = true;
        elapsedDashTime = dashingTime;
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
