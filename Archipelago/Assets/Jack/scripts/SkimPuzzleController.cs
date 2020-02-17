using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkimPuzzleController : MonoBehaviour
{

    [SerializeField] private GameObject[] pillars = new GameObject[1];
    public bool puzzleActive = false;
    public int currentSet = 0;
    int glowedRocks = 0;

    private void Update()
    {
        if (puzzleActive)
        {
            for (int i = 0; i < pillars.Length; i++)
            {
                if (pillars[i].GetComponent<SkimPuzzleRock>().rockHit)
                {
                    StartCoroutine("GlowOneRock");
                }

            }
        }
        
    }


    //glow all rocks for one second in order, not at the same time
    IEnumerator GlowRocks()
    {
        glowedRocks = 0;
        while (glowedRocks < pillars.Length)    
        {
            pillars[glowedRocks].GetComponent<Renderer>().material = transform.parent.GetComponent<SkimPuzzleMaster>().glowMats[glowedRocks];
            yield return new WaitForSeconds(1);
            pillars[glowedRocks].GetComponent<Renderer>().material = pillars[glowedRocks].GetComponent<SkimPuzzleRock>().originalMaterial;
        }

    }


    //glow all rocks for one second in order, not at the same time
    IEnumerator GlowOneRock()
    {
        glowedRocks = 0;
        while (glowedRocks < pillars.Length)
        {
            pillars[glowedRocks].GetComponent<Renderer>().material = transform.parent.GetComponent<SkimPuzzleMaster>().glowMats[glowedRocks];
            yield return new WaitForSeconds(1);
            pillars[glowedRocks].GetComponent<Renderer>().material = pillars[glowedRocks].GetComponent<SkimPuzzleRock>().originalMaterial;
        }

    }




    //stop every rock from glowing
    void StopAllGlow()
    {
        for (int i = 0; i < pillars.Length; i++)
        {
            pillars[i].GetComponent<Renderer>().material = pillars[i].GetComponent<SkimPuzzleRock>().originalMaterial;
        }
    }

}
