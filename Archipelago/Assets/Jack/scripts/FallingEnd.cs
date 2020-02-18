using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingEnd : StateMachineBehaviour
{


    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        StaticValueHolder.PlayerMovementScript.jumpParticle.transform.position = StaticValueHolder.PlayerMovementScript.transform.position - new Vector3(0, .9f, 0);
        StaticValueHolder.PlayerMovementScript.jumpParticle.Play();
    }
    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
