using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkimPuzzleController : MonoBehaviour
{

    [SerializeField] private GameObject[] pillars = new GameObject[1];
    public bool puzzleActive = true;
    bool complete = false;
    int currentRock = 0;
    int glowedRocks = 0;

    private void Update()
    {
        //check if this is the current set active
        if (puzzleActive)
        {
            if (currentRock <= pillars.Length)
            {
                Debug.Log("current rock: " + currentRock);
                //check if the next pillar is hit
                if (pillars[currentRock].GetComponent<SkimPuzzleRock>().rockHit)
                {
                    Debug.Log("Glowing?: " + pillars[currentRock].GetComponent<SkimPuzzleRock>().glowing);
                    //check if next pillar is glowing, else make it glow and look for next pillar being hit
                    if (!pillars[currentRock].GetComponent<SkimPuzzleRock>().glowing)
                    {
                        StartCoroutine(GlowOneRock(currentRock));
                        pillars[currentRock].GetComponent<SkimPuzzleRock>().glowing = true;
                        currentRock++;
                    }
                }
                else
                {
                    //reset all rocks if wrong order hit
                    for (int i = 0; i < pillars.Length; i++)
                    {
                        if (pillars[i].GetComponent<SkimPuzzleRock>().rockHit && i > currentRock)
                        {
                            for (int j = 0; j < pillars.Length; j++)
                            {
                                pillars[j].GetComponent<SkimPuzzleRock>().rockHit = false;
                            }
                        }
                    }
                }
            }
            else
            {
                // if current rock is more than all the rocks then
                // all rocks have been hit and the set is complete
                complete = true;
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
    IEnumerator GlowOneRock(int num)
    {
        //glow rock for one second
        pillars[num].GetComponent<Renderer>().material = transform.parent.GetComponent<SkimPuzzleMaster>().glowMats[num];
        yield return new WaitForSeconds(3);
        pillars[num].GetComponent<Renderer>().material = pillars[num].GetComponent<SkimPuzzleRock>().originalMaterial;
        pillars[currentRock].GetComponent<SkimPuzzleRock>().glowing = false;
        pillars[num].GetComponent<SkimPuzzleRock>().rockHit = false;
        if (!complete) currentRock = 0;
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
