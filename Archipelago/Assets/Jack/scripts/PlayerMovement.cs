using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public enum PlayerState
    {
        MOVING,
        THROWING
    }
    public PlayerState state;

    public Animator anim;
    public GameObject stone;

    [SerializeField] private GameObject currentThrowSpot;
    [SerializeField] private CharacterController controller;
    [SerializeField] private float speed = 6f;
    [SerializeField] private float gravity = -55.81f;
    [SerializeField] private float maxThrowPower = 1000;

    [SerializeField] public Transform groundCheck;
    [SerializeField] private float groundDistance = 0.4f;
    [SerializeField] private LayerMask groundMask;

    Vector3 velocity;
    private bool isGrounded;
    private bool chargingThrow;
    private bool throwing;
    private bool justChangedThrowSpot;

    public bool throwReady;
    public bool doingThrow;

    private float angleClamp;
    private float throwPower;


    private void Start()
    {
        state = PlayerState.MOVING;

        controller = GetComponent<CharacterController>();
        anim.SetBool("Walking", false);
        anim.SetBool("ChargingThrow", false);
        anim.SetBool("Throwing", false);


        isGrounded = false;
        chargingThrow = false;
        throwing = false;
        throwReady = true;
        doingThrow = false;
        justChangedThrowSpot = false;
    }


    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");


        //state machine
        switch (state)
        {





            //normal movement
            case PlayerState.MOVING:
                {
                    isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

                    if (isGrounded && velocity.y < 0)
                    {
                        velocity.y = -2f;
                    }





                    //move character acording to input
                    Vector3 move = new Vector3(moveHorizontal, 0f, moveVertical);

                    controller.Move(move * speed * Time.deltaTime);
                    transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(move), .2f);


                    //gravity
                    velocity.y += gravity * Time.deltaTime;
                    controller.Move(velocity * Time.deltaTime);

                    //make character walk if getting input
                    if (moveHorizontal > 0.01 || moveHorizontal < -0.01 || moveVertical > 0.01 || moveVertical < -0.01)
                    {
                        anim.SetBool("Walking", true);
                    }
                    else
                    {
                        anim.SetBool("Walking", false);
                    }


                    break;
                }





            //throwing stone
            case PlayerState.THROWING:
                {
                    if (Input.GetMouseButtonDown(0) && throwReady)
                    {
                        chargingThrow = true;
                        throwing = false;
                        throwPower = 0;
                    }


                    if (Input.GetMouseButtonUp(0) && throwReady)
                    {

                        chargingThrow = false;
                        throwing = true;
                    }



                    if (chargingThrow)
                    {
                        anim.SetBool("ChargingThrow", true);
                        anim.SetBool("Throwing", false);


                        LookAtMouse();
                        chargeThrow();
                    }

                    if (throwing)
                    {
                        anim.SetBool("Throwing", true);
                        anim.SetBool("ChargingThrow", false);
                    }



                    break;
                }
            default:
                break;
        }




        

        


    }





    //attach throwing spot that was stepped on
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ThrowSpot"))
        {
            currentThrowSpot = other.gameObject;
        }
    }

    //remove throwing spot that was left
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("ThrowSpot"))
        {
            currentThrowSpot = null;
        }
    }


    //switch state to throwing on throwing point
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("ThrowSpot") && state == PlayerState.MOVING && Input.GetKeyDown(KeyCode.E) && !justChangedThrowSpot)
        {
            //get clamp for throwing angle
            angleClamp = currentThrowSpot.GetComponent<ThrowSpotAngleShow>().totalFOV/2;

            //move player to middle of throwing platform and enter throwing state
            transform.position = currentThrowSpot.transform.GetChild(2).transform.position;
            anim.SetBool("Walking", false);
            state = PlayerState.THROWING;
            justChangedThrowSpot = true;
        }


        if (other.gameObject.CompareTag("ThrowSpot") && state == PlayerState.THROWING && Input.GetKeyDown(KeyCode.E) && !justChangedThrowSpot)
        {
            //move player to middle of throwing platform and enter throwing state
            state = PlayerState.MOVING;
            justChangedThrowSpot = true;
        }
        justChangedThrowSpot = false;
    }




    //aim player at mouse
    void LookAtMouse()
    {
        Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.AngleAxis(Mathf.Clamp(-angle + 90, -angleClamp, angleClamp), new Vector3(0, 1, 0));
    }

    //launch a stone
    public void throwStone()
    {
        GameObject currentStone = Instantiate(stone, transform.position, transform.rotation);
        currentStone.GetComponent<StoneMovement>().throwPower = throwPower;
        currentStone.GetComponent<StoneMovement>().direction = transform.forward;
    }
    

    //charge power of throw
    void chargeThrow()
    {
        throwPower += Time.deltaTime;
        if (throwPower > maxThrowPower) throwPower = maxThrowPower;


       // transform.position
    }
    

}
