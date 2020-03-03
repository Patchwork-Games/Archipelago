using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingController : MonoBehaviour
{
    private Animator anim = null;
    [HideInInspector] public bool heldB = false;
    private GameObject net = null;
    public bool canSeeNet = false;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        net = GameObject.FindGameObjectWithTag("Net");
    }

    // Update is called once per frame
    void Update()
    {

        if (heldB && PlayerStateMachine.Instance.state == PlayerStateMachine.PlayerState.MOVING)
        {
            heldB = false;
            PlayerStateMachine.Instance.state = PlayerStateMachine.PlayerState.CASTING;
            anim.SetTrigger("SwingNet");
        }



        if (canSeeNet)
        {
            net.SetActive(true);
        }
        else
        {
            net.SetActive(false);
        }


        
    }
}
