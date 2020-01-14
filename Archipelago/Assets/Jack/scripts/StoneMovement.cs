using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneMovement : MonoBehaviour
{
    public PhysicMaterial BounceMaterial;
    public PhysicMaterial StiffMaterial;
    [HideInInspector] public Vector3 direction;
    public float throwPower; 
    private Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (throwPower < 200) throwPower = 200;
        rb.AddForce(Vector3.Normalize(new Vector3(direction.x, 0, direction.z)) * throwPower);
        rb.AddForce(new Vector3(0, 100, 0));

    }

    private void Update()
    {
        if (rb.velocity.magnitude < 1) StartCoroutine("DestroyStone");    
    }



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bouncey") || collision.gameObject.CompareTag("Water") || collision.gameObject.CompareTag("PLayer"))
        {
            MakeBouncey();
        }
        else
        {
            MakeStiff();
        }
    }





    void MakeBouncey()
    {
        GetComponent<Collider>().material = BounceMaterial;
    }
    void MakeStiff()
    {
        GetComponent<Collider>().material = StiffMaterial;
    }

    IEnumerator DestroyStone()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }



}
