using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaiseSkimRocks : MonoBehaviour
{
    Animator anim = null;
    [SerializeField] ParticleSystem[] particles = new ParticleSystem[3];
    private bool rocksUp = true;

    private void Start()
    {
        anim = transform.GetChild(0).GetComponent<Animator>();
        for (int i = 0; i < particles.Length; i++)
        {
            particles[i].Stop();
        }
    }


    private void Update()
    {
        //get ID from controller, if ID is same as current set then raise rocks
        if (GetComponent<SkimPuzzleController>().ID != transform.parent.GetComponent<SkimPuzzleMaster>().currentSet)
        {
            anim.SetBool("RaiseRocks", false);
            rocksUp = false;
        }

        if (GetComponent<SkimPuzzleController>().ID == transform.parent.GetComponent<SkimPuzzleMaster>().currentSet && !rocksUp)
        {
            //raise rocks and play particle
            anim.SetBool("RaiseRocks", true);
            for (int i = 0; i < particles.Length; i++)
            {
                particles[i].Play();
            }
            rocksUp = true; //ensure rocks are only raised once instead of all the time
        }
    }




    private void OnTriggerEnter(Collider other)
    {
        //raise the correct rocks if player enters area
        if (other.CompareTag("Player") && GetComponent<SkimPuzzleController>().ID == transform.parent.GetComponent<SkimPuzzleMaster>().currentSet)
        {
            //raise rocks and play particle
            anim.SetBool("RaiseRocks", true);
            for (int i = 0; i < particles.Length; i++)
            {
                particles[i].Play();
            }  
        } 
    }

    private void OnTriggerExit(Collider other)
    {
        //lower the correct rocks if player enters area
        if (other.CompareTag("Player") && GetComponent<SkimPuzzleController>().ID == transform.parent.GetComponent<SkimPuzzleMaster>().currentSet)
        {
            //lower rocks and play particle
            anim.SetBool("RaiseRocks", false);
            for (int i = 0; i < particles.Length; i++)
            {
                particles[i].Play();
            }
        }
    }
}
