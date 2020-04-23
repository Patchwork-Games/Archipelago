using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandCastle : MonoBehaviour
{
    ParticleSystem sand = null;

    // Audio
    private AudioSource breakNoise = null;

    private void Awake()
    {
        // Get the brake noise
        breakNoise = transform.Find("Audio").Find("BreakNoise").GetComponent<AudioSource>();
        if (breakNoise == null)
        {
            Debug.Log("Missing BreakNoise child on object: " + transform.Find("Audio").gameObject + gameObject);
        }
    }


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
            breakNoise.Play();
        }
    }
}
