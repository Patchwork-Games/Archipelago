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
    private Camera mainCamera = null;
    private Vector3 camForward = Vector3.zero;
    private Vector3 camRight = Vector3.zero;
    private bool isSteering = false;
    private Vector2 moveDirection = Vector2.zero;
    private Quaternion startRotation;
    private float lerpSpeed = 0f;
    [SerializeField] private float rotationTime = 3f;

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

        // Get the main camera in the scene
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        // The boat should have the wind force applied to the forward vector to make the boat move
        rb.AddForce(this.transform.forward * windForce *Time.deltaTime);

        // Cap the velocity of the boat
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

        // Steer the boat
        if (isSteering)
        {
            // Get the camera's forward vector
            camForward = Vector3.Normalize(transform.position - mainCamera.transform.position);
            camForward.y = 0;
            camRight = Vector3.Cross(new Vector3(0, 1, 0), camForward);

            // Calculate the move vector
            Vector3 move = (camRight * moveDirection.x) + (camForward * moveDirection.y);

            // Calculate the lerp speed based on the time
            lerpSpeed += Time.deltaTime / rotationTime;

            // Rotate the forward vector towards the desired position
            transform.rotation = Quaternion.Lerp(startRotation, Quaternion.LookRotation(move), lerpSpeed);
        }
    }

    private void SteerBoat(Vector2 movementAxis)
    {
        isSteering = true;
        moveDirection = movementAxis;
        startRotation = transform.rotation;
        lerpSpeed = 0;
        Debug.Log(movementAxis);
    }

    private void OnEnable()
    {
        controls.Boat.Steering.performed += ctx => SteerBoat(ctx.ReadValue<Vector2>());
        controls.Boat.Steering.canceled += ctx => isSteering = false;
        controls.Boat.Steering.Enable();
    }

    private void OnDisable()
    {
        controls.Boat.Steering.performed -= ctx => SteerBoat(ctx.ReadValue<Vector2>());
        controls.Boat.Steering.canceled -= ctx => isSteering = false;
        controls.Boat.Steering.Disable();
    }
}
