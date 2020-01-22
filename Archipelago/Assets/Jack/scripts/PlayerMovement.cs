using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public enum PlayerState
    {
        MOVING,
        THROWING
    }
    public PlayerState state;

    public Animator anim;
    
    //camera variables
    public GameObject mainCamera;
    Vector3 camForward;
    Vector3 camRight;
    Vector2 camMoveDirection;

    //movement variables
    [SerializeField] private float walkSpeed = 4f;
    [SerializeField] private float runSpeed = 8f;
    [SerializeField] private float energy = 0;
    public GameObject energyBar;
    Vector2 moveDirection;
    Vector3 velocity;


    //button variables
    public InputMaster controls;
    [SerializeField] private CharacterController controller;
    private bool interact = false;
    private bool run = false;



    //jumping variables
    private int jumps = 0;
    private int jumpsMax = 1;
    private bool isGrounded;
    [SerializeField] private float groundDistance = 0.4f;
    [SerializeField] private float gravity = -55.81f;
    [SerializeField] public Transform groundCheck;
    [SerializeField] private LayerMask groundMask;


   

    private void Awake()
    {
        controls = new InputMaster();
        controls.Player.Movement.performed += context => moveDirection = context.ReadValue<Vector2>();
        controls.Player.Movement.canceled += context => moveDirection = context.ReadValue<Vector2>();
        controls.Player.CameraMovement.performed += context => camMoveDirection = context.ReadValue<Vector2>();
        controls.Player.CameraMovement.canceled += context => camMoveDirection = context.ReadValue<Vector2>();
        controls.Player.AButton.performed += context => InteractButton();
        controls.Player.XButton.performed += context => RunButton();
        controls.Player.XButton.canceled += context => StopRunButton();
    }


    void InteractButton()
    {
        if (interact)
        {
            //make player jump if enough jumps
            if (jumps > 0 && interact)
            {
                velocity.y = 20f;
                jumps -= 1;
            }
        }
       
    }


    void RunButton()
    {
        run = true;
    }

    void StopRunButton()
    {
        run = false;
    }







    private void OnEnable()
    {
        controls.Enable();
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void OnDisable()
    {
        controls.Disable();
    }


    private void Start()
    {
        state = PlayerState.MOVING;

        controller = GetComponent<CharacterController>();
        anim.SetBool("Walking", false);
        isGrounded = false;
        
    }


    // Update is called once per frame
    void Update()
    {
        interact = false;
        //state machine
        switch (state)
        {


            //http://www.alanzucconi.com/2015/06/17/surface-shaders-in-unity3d/


            //normal movement
            case PlayerState.MOVING:
                {
                    isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

                    if (isGrounded && velocity.y < 0)
                    {
                        velocity.y = -2f;
                        jumps = jumpsMax;
                    }

                    //get energy from other script
                    energy = energyBar.GetComponent<DashMeter>().currentCharge;

                    //check conditions to run and run if possible
                    if (run && energy > 0f && (moveDirection.x > 0.01 || moveDirection.x < -0.01 || moveDirection.y > 0.01 || moveDirection.y < -0.01))
                    {
                        Run();
                        anim.SetBool("Running", true);
                        energyBar.GetComponent<DashMeter>().Discharge();
                    }
                    else
                    {
                        anim.SetBool("Running", false);
                        energyBar.GetComponent<DashMeter>().Recharge();
                        
                    }

                    //stop trying to run when out of energy
                    if (energy == 0) run = false;


                    


                    Move();
                    Gravity();
                    MoveCamera();

                    //let the player interact, is reset at start of update
                    interact = true;

                    break;
                }





            //throwing stone
            case PlayerState.THROWING:
                {
                    GetComponent<SkimmingController>().testThrow();
                    break;
                }
            default:
                break;
        }
    }



    void Move()
    {
        //get camera forward
        camForward = Vector3.Normalize(transform.position - mainCamera.transform.position);
        camForward.y = 0;
        camRight = Vector3.Cross(new Vector3(0, 1, 0), camForward);


        //move character acording to input
        Vector3 move = camRight * moveDirection.x + camForward * moveDirection.y;

        controller.Move(move * walkSpeed * Time.deltaTime);
        if (move.x != 0 || move.z != 0) transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(move), 7f * Time.deltaTime);



        //make character walk if getting input
        if (moveDirection.x > 0.01 || moveDirection.x < -0.01 || moveDirection.y > 0.01 || moveDirection.y < -0.01)
        {
            anim.SetBool("Walking", true);
        }
        else
        {
            anim.SetBool("Walking", false);
        }
    }

    void Gravity()
    {
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }


    void MoveCamera()
    {
        //move camera
        if (camMoveDirection.x != 0)
        {
            mainCamera.GetComponent<CinemachineFreeLook>().m_XAxis.m_InputAxisName = "CameraMovement";           
        }
        else
        {
            mainCamera.GetComponent<CinemachineFreeLook>().m_XAxis.m_InputAxisName = "Mouse X";
        }

        mainCamera.GetComponent<CinemachineFreeLook>().m_XAxis.m_InputAxisValue = camMoveDirection.x;
        
    }


    void Run()
    {
        //get camera forward
        camForward = Vector3.Normalize(transform.position - mainCamera.transform.position);
        camForward.y = 0;
        camRight = Vector3.Cross(new Vector3(0, 1, 0), camForward);


        //move character acording to input
        Vector3 move = camRight * moveDirection.x + camForward * moveDirection.y;

        controller.Move(move * runSpeed * Time.deltaTime);
        if (move.x != 0 || move.z != 0) transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(move), 7f * Time.deltaTime);
        
    }
}
