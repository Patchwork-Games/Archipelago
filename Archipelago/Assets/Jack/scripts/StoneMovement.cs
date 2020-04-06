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
    private ParticleSystem bounceParticle = null;

    // Audio
    private AudioSource bounceNoise = null;


    private void Awake()
    {
        // Get the bounce particle
        bounceParticle = transform.Find("SkimWaterParticle").GetComponent<ParticleSystem>();
        if (bounceParticle == null)
        {
            Debug.Log("Missing BounceParticle child on object: " + gameObject);
        }

        // Get Audio transform
        Transform audioTransform = transform.Find("Audio");
        if (audioTransform == null)
        {
            Debug.Log("Missing Audio child on object: " + audioTransform);
        }
        else
        {
            // Get the bounce noise
            bounceNoise = audioTransform.Find("BounceNoise").GetComponent<AudioSource>();
            if (bounceNoise == null)
            {
                Debug.Log("Missing BounceNoise child on object: " + audioTransform.gameObject);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (throwPower < 200) throwPower = 200;
        rb.AddForce(Vector3.Normalize(new Vector3(direction.x, 0, direction.z)) * throwPower * 1.5f);
        rb.AddForce(new Vector3(0, 100, 0));

    }

    private void Update()
    {
        if (rb.velocity.magnitude < 1) StartCoroutine("DestroyStone");    
    }


    //stop the stone bouncing on land
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bouncey") || collision.gameObject.CompareTag("Water") || collision.gameObject.CompareTag("Player"))
        {
            MakeBouncey();
            if (collision.gameObject.CompareTag("Water"))
            {
                bounceParticle.Play();
                bounceNoise.Play();
            }
        }
        else
        {
            MakeStiff();
            rb.velocity = new Vector3(0,0,0);
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


    //destroy stone after time
    IEnumerator DestroyStone()
    {
        GetComponent<SphereCollider>().enabled = false;

        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }



}
