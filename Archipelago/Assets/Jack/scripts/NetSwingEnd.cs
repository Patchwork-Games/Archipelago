﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetSwingEnd : StateMachineBehaviour
{
    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        PlayerStateMachine.Instance.state = PlayerStateMachine.PlayerState.MOVING;
        StaticValueHolder.PlayerObject.GetComponent<FishingController>().net.GetComponent<SphereCollider>().enabled = false;
    }
}
