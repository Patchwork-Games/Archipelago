using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{

    public static PlayerStateMachine Instance { get; private set; }



    public enum PlayerState
    {
        MOVING,
        THROWING,
        TALKING,
        BOAT,
        FISHING
    }
    public PlayerState state;


    private void Awake()
    {
        //ensure only one instance of the static object
        if (Instance != null)
        {
            if (Instance != this)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            Instance = this;
        }
    }






    // Update is called once per frame
    void FixedUpdate()
    {
        //state machine
        switch (state)
        {
            //normal movement
            case PlayerState.MOVING:
                {
                    PlayerMovement.Instance.CheckGround();
                    PlayerMovement.Instance.CheckRun();
                    PlayerMovement.Instance.CheckJump();
                    PlayerMovement.Instance.Move();
                    PlayerMovement.Instance.Gravity();
                    PlayerMovement.Instance.MoveCamera();
                    PlayerMovement.Instance.anim.SetBool("InBoat", false);
                    break;
                }


            //throwing stone
            case PlayerState.THROWING:
                {
                    PlayerMovement.Instance.CheckThrowing();
                    break;
                }


            //fishing
            case PlayerState.FISHING:
                {
                    PlayerMovement.Instance.CheckFishing();
                    break;
                }



            //throwing stone
            case PlayerState.TALKING:
                {
                    PlayerMovement.Instance.CheckTalking();
                    break;
                }


            //In boat
            case PlayerState.BOAT:
                {
                    PlayerMovement.Instance.CheckBoat();
                    break;
                }


            default:
                break;
        }
        //stop holding A or jumping
        PlayerMovement.Instance.interact = false;
        PlayerMovement.Instance.jump = false;
    }

}
