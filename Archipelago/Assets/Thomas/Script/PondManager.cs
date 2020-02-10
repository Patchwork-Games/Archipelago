using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PondManager : MonoBehaviour
{
    public Animator anim = null;
    public ParticleSystem particleYellow = null;
    float targetTime = 4f;
    bool timerEnded = false;
    bool startTimer = true;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(startTimer)
        {
            targetTime -= Time.deltaTime;
        }


        if (targetTime <= 0.0f)
        {

            timerEnded = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            anim.SetBool("raiseRocks", true);
            PlayerMovement.Instance.CMCamera.GetComponent<CameraShake>().ShakeCamera(2f, 2f,1f);
            startTimer = true;
            if (other.CompareTag("Player"))
            {
                if (timerEnded)
                {
                    particleYellow.Play();
                }
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
     
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            anim.SetBool("raiseRocks", false);
            PlayerMovement.Instance.CMCamera.GetComponent<CameraShake>().ShakeCamera(2f, 2f, 1f);
            startTimer = false;
        }
    }
}
