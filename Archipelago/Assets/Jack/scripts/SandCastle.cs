using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandCastle : MonoBehaviour
{
    ParticleSystem sand = null;


    // Start is called before the first frame update
    void Start()
    {
        sand = transform.GetChild(0).gameObject.GetComponent<ParticleSystem>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GetComponent<Renderer>().enabled = false;
            GetComponent<BoxCollider>().enabled = false;
            sand.Play();
        }
    }
}
