using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SailingManager : MonoBehaviour
{
    [SerializeField] private float windForce;
    [SerializeField] private float maxSpeed;
    private Rigidbody rb;

    private void Awake()
    {
        // Assign components to variables
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.Log("No Rigidbody found in SailingManager script!");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // The boat should have the wind force applied to the forward vector to make the boat move
        rb.AddForce(this.transform.forward * windForce);

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
    }
}
