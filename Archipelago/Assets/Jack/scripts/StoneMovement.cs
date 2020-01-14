using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneMovement : MonoBehaviour
{
    [HideInInspector] public Vector3 direction;
    public float throwPower; 
    private Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();


        rb.AddForce(Vector3.Normalize(new Vector3(direction.x, 0, direction.z)) * 1000);
        rb.AddForce(new Vector3(0, 100, 0));

    }

}
