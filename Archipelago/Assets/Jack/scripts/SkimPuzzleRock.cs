using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkimPuzzleRock : MonoBehaviour
{
    public bool rockHit = false;
    public Material originalMaterial = null;


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
        }
    }
}
