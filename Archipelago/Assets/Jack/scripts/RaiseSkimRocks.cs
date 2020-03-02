using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaiseSkimRocks : MonoBehaviour
{
    [SerializeField] ParticleSystem[] particles = new ParticleSystem[3];
    private bool rocksUp = true;
    public float rockHeight = 0.0f;
    private float rockHeightMax = 0.0f;
    private float rockHeightMin = 0.0f;
    public float targetHeight = 0.0f;
    private GameObject rockPos = null;
    private bool particlesOnEnd = false;


    private void Start()
    {
        for (int i = 0; i < particles.Length; i++)
        {
            particles[i].Stop();
        }


        rockHeightMax = transform.GetChild(0).transform.position.y;
        rockHeightMin = transform.GetChild(1).transform.position.y;
        rockPos = transform.GetChild(1).gameObject;
    }


    private void Update()
    {
        //get ID from controller, if ID is same as current set then lower rocks
        if (GetComponent<SkimPuzzleController>().ID != transform.parent.GetComponent<SkimPuzzleMaster>().currentSet)
        {
            //lower rocks
            rocksUp = false;
        }

        //raise rocks and play particle
        if (GetComponent<SkimPuzzleController>().ID == transform.parent.GetComponent<SkimPuzzleMaster>().currentSet)
        {
            if (!rocksUp)
            {
                PlayParticles();
                rocksUp = true; //ensure rocks are only raised once instead of all the time
                particlesOnEnd = false;
            }
            if (rockHeight != targetHeight)
            {

                //move rock by percentage
                if (targetHeight == 1)
                {
                    if (rockHeight < 1) rockHeight += Time.deltaTime / 2;
                    var y = rockPos.transform.position.y;
                    y = Mathf.Lerp(rockHeightMin, rockHeightMax, rockHeight);
                    rockPos.transform.position = new Vector3(rockPos.transform.position.x, y, rockPos.transform.position.z);
                }
                else
                {
                    if (rockHeight > 0) rockHeight -= Time.deltaTime / 2;
                    var y = rockPos.transform.position.y;
                    y = Mathf.Lerp(rockHeightMin, rockHeightMax, rockHeight);
                    rockPos.transform.position = new Vector3(rockPos.transform.position.x, y, rockPos.transform.position.z);
                }
            }

        }
        else if (rockHeight > 0)
        {
            if (!particlesOnEnd)
            {
                PlayParticles();
                particlesOnEnd = true;
            }
            rockHeight -= Time.deltaTime / 2;
            var y = rockPos.transform.position.y;
            y = Mathf.Lerp(rockHeightMin, rockHeightMax, rockHeight);
            rockPos.transform.position = new Vector3(rockPos.transform.position.x, y, rockPos.transform.position.z);
        }
    }




    private void OnTriggerEnter(Collider other)
    {
        //raise the correct rocks if player enters area
        if (other.CompareTag("Player") && GetComponent<SkimPuzzleController>().ID == transform.parent.GetComponent<SkimPuzzleMaster>().currentSet)
        {
            //raise rocks and play particle
            targetHeight = 1.0f;
            PlayParticles();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //lower the correct rocks if player enters area
        if (other.CompareTag("Player") && GetComponent<SkimPuzzleController>().ID == transform.parent.GetComponent<SkimPuzzleMaster>().currentSet)
        {
            //lower rocks and play particle 
            targetHeight = 0.0f;
            PlayParticles();
        }
    }


    void PlayParticles()
    {
        for (int i = 0; i < particles.Length; i++)
        {
            particles[i].Play();
        }
    }

}