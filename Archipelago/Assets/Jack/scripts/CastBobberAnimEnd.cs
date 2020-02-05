using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastBobberAnimEnd : StateMachineBehaviour
{
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GameObject.FindGameObjectWithTag("FishingPole").GetComponent<FishingController>().CastBobber();
        GameObject.FindGameObjectWithTag("FishingPole").GetComponent<MeshRenderer>().enabled = false;
        PlayerMovement.Instance.state = PlayerMovement.PlayerState.MOVING;
    }
}
