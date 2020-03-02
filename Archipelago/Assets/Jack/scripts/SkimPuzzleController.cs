using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkimPuzzleController : MonoBehaviour
{

    //pillars need to be entered into the array in the order in which they will be hit
    [SerializeField] private GameObject[] pillars = new GameObject[1];
    public int ID = 0;
    public bool puzzleActive = true;
    public bool complete = false;
    int currentRock = 0;
    float hintTimer = 5.0f;
    [SerializeField] private float hintFreq = 15.0f;




    private void Update()
    {
        //check if this is the current set active
        if (puzzleActive && !complete)
        {
            //show order of hit every while, set with hintFreq
            if (hintTimer < hintFreq) hintTimer += Time.deltaTime;
            else
            {
                StartCoroutine(GlowRocks());
                hintTimer = 0.0f;
            }



            if (currentRock < pillars.Length)
            {
                //check if the next pillar is hit
                if (pillars[currentRock].GetComponent<SkimPuzzleRock>().rockHit)
                {
                    //check if next pillar is glowing, else make it glow and look for next pillar being hit
                    if (!pillars[currentRock].GetComponent<SkimPuzzleRock>().glowing)
                    {
                        StartCoroutine(GlowOneRock(currentRock));
                        pillars[currentRock].GetComponent<SkimPuzzleRock>().glowing = true;
                        hintTimer = 0.0f; //reset hint so it doesnt go off during bounce
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
            else if (!complete)
            {
                // if current rock is more than all the rocks then
                // all rocks have been hit and the set is complete
                StopCoroutine("GlowOneRock");
                StopCoroutine("GlowRocks");
                complete = true;
                for (int i = 0; i < pillars.Length; i++)
                {
                    pillars[i].GetComponent<Renderer>().material = transform.parent.GetComponent<SkimPuzzleMaster>().gold;
                }
            }
        }
    }


    //glow all rocks for one second in order, not at the same time
    IEnumerator GlowRocks()
    {
        var glowedRocks = 0;
        while (glowedRocks < pillars.Length && !complete)    
        {
            pillars[glowedRocks].GetComponent<Renderer>().material = transform.parent.GetComponent<SkimPuzzleMaster>().glowMats[glowedRocks];
            yield return new WaitForSeconds(.5f);
            pillars[glowedRocks].GetComponent<Renderer>().material = pillars[glowedRocks].GetComponent<SkimPuzzleRock>().originalMaterial;
            glowedRocks++;
        }
    }


    //glow all rocks for one second in order, not at the same time
    IEnumerator GlowOneRock(int num)
    {

        //glow rock for one second
        if (!complete) pillars[num].GetComponent<Renderer>().material = transform.parent.GetComponent<SkimPuzzleMaster>().glowMats[num];

        yield return new WaitForSeconds(3); //hold glow for 3 seconds to allow skimmer to hit all rocks

        
        //has to be these ugly ifs because the value can change halfway through which would make the colour change when it shouldnt
        if (!complete) pillars[num].GetComponent<Renderer>().material = pillars[num].GetComponent<SkimPuzzleRock>().originalMaterial;
        if (!complete) pillars[num].GetComponent<SkimPuzzleRock>().glowing = false;
        if (!complete) pillars[num].GetComponent<SkimPuzzleRock>().rockHit = false;
        if (!complete) currentRock = 0;
        
    }
}
