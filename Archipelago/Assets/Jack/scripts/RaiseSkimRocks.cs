using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaiseSkimRocks : MonoBehaviour
{
    Animator anim = null;
    [SerializeField] ParticleSystem[] particles = new ParticleSystem[3];

    private void Start()
    {
        anim = transform.GetChild(0).GetComponent<Animator>();
        for (int i = 0; i < particles.Length; i++)
        {
            particles[i].Stop();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //switch (GetComponent<SkimPuzzleController>().currentSet)
            //{
            //    case 0:
            //        {

            //            break;
            //        }
            //    default:
            //        Debug.Log("Wrong number of sets, see raise skim rocks script");
            //        break;
            //}
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
        if (other.CompareTag("Player"))
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
