using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkimPuzzleRock : MonoBehaviour
{
    public bool rockHit = false;
    [HideInInspector] public bool glowing = false;
    [HideInInspector] public Material originalMaterial = null;

    // Audio
    private AudioSource rockHitNoise = null;

    private void Awake()
    {
        // Get the rock hit noise
        rockHitNoise = transform.Find("Audio").Find("RockHitNoise").GetComponent<AudioSource>();
        if (rockHitNoise == null)
        {
            Debug.Log("Missing RockHitNoise child on object: " + transform.Find("Audio").gameObject + gameObject);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        originalMaterial = GetComponent<Renderer>().material;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("SkimStone"))
        {
            rockHit = true;

            // Play hit noise
            rockHitNoise.Play();
        }
    }
}
