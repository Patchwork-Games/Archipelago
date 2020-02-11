using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaiseSkimRocks : MonoBehaviour
{
    Animator anim = null;

    private void Start()
    {
        anim = transform.GetChild(0).GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            anim.SetBool("RaiseRocks", true);
        } 
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            anim.SetBool("RaiseRocks", false);
        }
    }


    //get the next set of stones, called from the hit of the last rock if rocks hit in correct order
    public void NextSet()
    {

    }
}
