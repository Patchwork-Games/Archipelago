using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    public static PlayerMovement Instance { get; private set; }



    public enum PlayerState
    {
        MOVING,
        THROWING,
        TALKING,
        BOAT
    }
    public PlayerState state;

    public Animator anim = null;

    //camera variables
    public GameObject mainCamera = null;
    public ParticleSystem jumpParticle = null;
    Vector3 camForward = Vector3.zero;
    Vector3 camRight = Vector3.zero;
    Vector2 camMoveDirection = Vector2.zero;
    public Vector3 beginTalkCamPos = Vector3.zero;

    //movement variables
    [SerializeField] private float walkSpeed = 8f;
    [SerializeField] private float runSpeed = 16f;
    [SerializeField] private float energy = 0;
    public GameObject energyBar = null;
    Vector2 moveDirection = Vector2.zero;
    Vector3 velocity = Vector3.zero;


    //button variables
    public InputMaster controls = null;
    [SerializeField] private CharacterController controller = null;
    public bool interact = false;
    private bool jump = false;
    private bool run = false;
    public bool inTalkDistance = false;


    //jumping variables
    private int jumps = 0;
    private int jumpsMax = 1;
    public bool isGrounded;
    private float distanceGround;
    [SerializeField] private float groundDistance = 0.4f;
    [SerializeField] private float gravity = -55.81f;
    [SerializeField] private LayerMask groundMask = ~0;




    private void Awake()
    {
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



        controls = new InputMaster();
        controls.Player.Movement.performed += context => moveDirection = context.ReadValue<Vector2>();
        controls.Player.Movement.canceled += context => moveDirection = context.ReadValue<Vector2>();
        controls.Player.CameraMovement.performed += context => camMoveDirection = context.ReadValue<Vector2>();
        controls.Player.CameraMovement.canceled += context => camMoveDirection = context.ReadValue<Vector2>();
        controls.Player.Jump.performed += context => JumpButton();
        controls.Player.Interact.performed += context => InteractButton();
        controls.Player.XButton.performed += context => RunButton();
        controls.Player.XButton.canceled += context => StopRunButton();
        controls.Player.BButton.performed += context => ThrowButton();
        controls.Player.BButton.canceled += context => StopThrowButton();
    }


    void InteractButton()
    {
        interact = true;
    }

    void JumpButton()
    {
        jump = true;
    }


    void RunButton()
    {
        run = true;
    }

    void StopRunButton()
    {
        run = false;
    }

    void ThrowButton()
    {
        GetComponent<SkimmingController>().heldThrow = true;
    }

    void StopThrowButton()
    {
        GetComponent<SkimmingController>().heldThrow = false;
    }




    private void OnEnable()
    {
        controls.Enable();
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
        isGrounded = true;
        distanceGround = GetComponent<CharacterController>().bounds.extents.y;
        inTalkDistance = false;
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
                    

                    //check if on ground
                    if (!Physics.Raycast(transform.position, -Vector3.up, distanceGround + groundDistance))
                    {
                        isGrounded = false;
                        jumps = 0;
                        anim.SetBool("Falling", true);
                        StopCoroutine("JumpCooldown");
                    }
                    else isGrounded = true;

                    if (isGrounded && velocity.y < 0)
                    {
                        StartCoroutine("JumpCooldown");

                        anim.SetBool("Jumping", false);
                        anim.SetBool("Falling", false);
                        velocity.y = -2f;
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


                    
                    //make player jump if enough jumps
                    if (jumps > 0 && jump && !inTalkDistance)
                    {
                        velocity.y = 20f;
                        jumps -= 1;
                        anim.SetBool("Jumping", true);
                    }
                    

                    


                    Move();
                    Gravity();
                    MoveCamera();
                    break;
                }





            //throwing stone
            case PlayerState.THROWING:
                {
                    if (isGrounded)
                    {
                        anim.SetBool("Walking", false);
                        anim.SetBool("Running", false);
                        anim.SetBool("Jumping", false);
                        anim.SetBool("Falling", false);
                        MoveCameraWLeft();
                    }
                    else
                    {
                        state = PlayerState.MOVING;
                    }
                    break;
                }





            //throwing stone
            case PlayerState.TALKING:
                {
                    //mainCamera.GetComponent<CinemachineFreeLook>().m_XAxis.m_InputAxisValue = 0;
                    beginTalkCamPos = mainCamera.transform.position;
                    mainCamera.SetActive(false);
                    anim.SetBool("Walking", false);
                    anim.SetBool("Running", false);
                    anim.SetBool("Jumping", false);
                    anim.SetBool("Falling", false);
                    anim.SetBool("Throwing", false);
                    anim.SetBool("ChargingThrow", false);
                    Gravity();

                    break;
                }
            case PlayerState.BOAT:
                {
                    break;
                }

            default:
                break;
        }
        //stop holding A
        interact = false;
        jump = false;
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
            mainCamera.GetComponent<CinemachineFreeLook>().m_XAxis.m_MaxSpeed = 300;
        }
        else
        {
            mainCamera.GetComponent<CinemachineFreeLook>().m_XAxis.m_InputAxisName = "Mouse X";
            mainCamera.GetComponent<CinemachineFreeLook>().m_XAxis.m_MaxSpeed = 300;
        }

        mainCamera.GetComponent<CinemachineFreeLook>().m_XAxis.m_InputAxisValue = camMoveDirection.x;
    }


    //this is for throwing because you hold B it makes sense to move the left stick instead of the right
    void MoveCameraWLeft()
    {
        //move camera
        if (moveDirection.x != 0)
        {
            mainCamera.GetComponent<CinemachineFreeLook>().m_XAxis.m_InputAxisName = "CameraMovement1";
            mainCamera.GetComponent<CinemachineFreeLook>().m_XAxis.m_MaxSpeed = 100;
        }
        else
        {
            mainCamera.GetComponent<CinemachineFreeLook>().m_XAxis.m_InputAxisName = "Mouse X";
            mainCamera.GetComponent<CinemachineFreeLook>().m_XAxis.m_MaxSpeed = 300;
        }

        mainCamera.GetComponent<CinemachineFreeLook>().m_XAxis.m_InputAxisValue = moveDirection.x;
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




    IEnumerator JumpCooldown()
    {
        yield return new WaitForSeconds(.3f);
        jumps = jumpsMax;

    }


    public void ChangeCamera(CinemachineFreeLook cam, bool above)
    {
        if (above)
        {
            cam.Priority = mainCamera.GetComponent<CinemachineFreeLook>().Priority + 1;
        }
        else
        {
            cam.Priority = mainCamera.GetComponent<CinemachineFreeLook>().Priority - 1;
        }
        
    }



}
