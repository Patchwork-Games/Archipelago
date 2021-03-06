﻿using System.Collections;
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
        CASTING,
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
                    StaticValueHolder.PlayerMovementScript.CheckGround();
                    StaticValueHolder.PlayerMovementScript.CheckRun();
                    StaticValueHolder.PlayerMovementScript.CheckJump();
                    StaticValueHolder.PlayerMovementScript.CheckWater();
                    //StaticValueHolder.PlayerMovementScript.Move();
                    StaticValueHolder.PlayerMovementScript.Gravity();
                    StaticValueHolder.PlayerMovementScript.MoveCamera();
                    StaticValueHolder.PlayerMovementScript.anim.SetBool("InBoat", false);
                    StaticValueHolder.PlayerMovementScript.controller.enabled = true;
                    break;
                }


            //throwing stone
            case PlayerState.THROWING:
                {
                    StaticValueHolder.PlayerMovementScript.CheckThrowing();
                    break;

                    
                }


            //fishing
            case PlayerState.FISHING:
                {
                    StaticValueHolder.PlayerMovementScript.CheckFishing();
                    break;
                }



            //throwing stone
            case PlayerState.TALKING:
                {
                    StaticValueHolder.PlayerMovementScript.CheckTalking();
                    StaticValueHolder.PlayerCharacterCamera.m_XAxis.m_MaxSpeed = 0;
                    break;
                }


            //In boat
            case PlayerState.BOAT:
                {
                    StaticValueHolder.PlayerMovementScript.CheckBoat();
                    break;
                }


            default:
                break;
        }
        //stop holding A or jumping
        StaticValueHolder.PlayerMovementScript.interact = false;
        StaticValueHolder.PlayerMovementScript.jump = false;
    }

}
