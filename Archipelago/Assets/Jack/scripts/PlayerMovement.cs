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
        BOAT,
        FISHING
    }
    public PlayerState state;

    public enum ItemEquipped
    {
        SKIMMINGROCK,
        FISHINGPOLE
    }
    public ItemEquipped currentItem;


    public Animator anim = null;

    //camera variables
    public GameObject CMCamera = null;
    Vector3 camForward = Vector3.zero;
    Vector3 camRight = Vector3.zero;
    Vector2 camMoveDirection = Vector2.zero;
    public Vector3 beginTalkCamPos = Vector3.zero;
    public bool BoatButtonGuide = false;
    [SerializeField] private Canvas BoatButtonImage = null;


    //movement variables
    [SerializeField] private float walkSpeed = 8f;
    [SerializeField] private float runSpeed = 16f;
    [SerializeField] private float energy = 0;
    [SerializeField] private GameObject RunParticle = null;
    [SerializeField] private GameObject InWaterWalkingParticle = null;
    public GameObject energyBar = null;
    Vector2 moveDirection = Vector2.zero;
    Vector3 velocity = Vector3.zero;
    private bool inWater = false;




    //button variables
    public InputMaster controls = null;
    [SerializeField] private CharacterController controller = null;
    public bool interact = false;
    private bool jump = false;
    private bool run = false;
    public bool inTalkDistance = false;
    [SerializeField] private Canvas CollectableUI = null;


    //jumping variables
    public ParticleSystem jumpParticle = null;
    private bool jumpParticlePlayed = false;
    private int jumps = 0;
    private int jumpsMax = 1;
    public bool isGrounded;
    private float distanceGround;
    [SerializeField] private float groundDistance = 0.5f;
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
        
    }


    private void OnEnable()
    {
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
        controls.Player.YButton.performed += context => YButton();
        controls.Player.YButton.canceled += context => StopYButton();
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Player.Movement.performed -= context => moveDirection = context.ReadValue<Vector2>();
        controls.Player.Movement.canceled -= context => moveDirection = context.ReadValue<Vector2>();
        controls.Player.CameraMovement.performed -= context => camMoveDirection = context.ReadValue<Vector2>();
        controls.Player.CameraMovement.canceled -= context => camMoveDirection = context.ReadValue<Vector2>();
        controls.Player.Jump.performed -= context => JumpButton();
        controls.Player.Interact.performed -= context => InteractButton();
        controls.Player.XButton.performed -= context => RunButton();
        controls.Player.XButton.canceled -= context => StopRunButton();
        controls.Player.BButton.performed -= context => ThrowButton();
        controls.Player.BButton.canceled -= context => StopThrowButton();
        controls.Player.YButton.performed -= context => YButton();
        controls.Player.YButton.canceled -= context => StopYButton();
        controls.Disable();
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
        if (state == PlayerState.MOVING)
        {
            switch (currentItem)
            {
                case ItemEquipped.SKIMMINGROCK:
                    {
                        GetComponent<SkimmingController>().heldThrow = true;
                        break;
                    }
                case ItemEquipped.FISHINGPOLE:
                    {
                        GetComponent<FishingController>().heldCast = true;
                        break;
                    }
                default:
                    {
                        GetComponent<SkimmingController>().heldThrow = true;
                        break;
                    }
            }
            

        }
    }

    void StopThrowButton()
    {
        if (state != PlayerState.BOAT) GetComponent<SkimmingController>().heldThrow = false;
    }


    void YButton()
    {
        if (CollectableUI)
        {
            CollectableUI.GetComponent<Animator>().Play("FadeInCollectableUI");
            StopCoroutine("DisableCollectableUI");
            CollectableUI.enabled = true;
        }
        else Debug.Log("Collectable UI not attached to player");
    }

    void StopYButton()
    {
        if (CollectableUI)
        {
            CollectableUI.GetComponent<Animator>().Play("FadeOutCollectableUI");
            StartCoroutine("DisableCollectableUI");
        }
        else Debug.Log("Collectable UI not attached to player");
    }



    private void Start()
    {
        state = PlayerState.MOVING;
        currentItem = ItemEquipped.SKIMMINGROCK;

        controller = GetComponent<CharacterController>();
        anim.SetBool("Walking", false);
        isGrounded = true;
        distanceGround = GetComponent<CharacterController>().bounds.extents.y;
        inTalkDistance = false;
    }



    private void Update()
    {
        if (transform.position.y < 31)
        {
            InWaterWalkingParticle.transform.SetPositionAndRotation(new Vector3(transform.position.x, InWaterWalkingParticle.transform.position.y, transform.position.z), InWaterWalkingParticle.transform.rotation);
            if (!InWaterWalkingParticle.GetComponent<ParticleSystem>().isPlaying) InWaterWalkingParticle.GetComponent<ParticleSystem>().Play();

        }
        else if(InWaterWalkingParticle.GetComponent<ParticleSystem>().isPlaying) InWaterWalkingParticle.GetComponent<ParticleSystem>().Stop();

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
                    if (Physics.Raycast(transform.position, -Vector3.up, distanceGround + groundDistance, groundMask))
                    {
                        isGrounded = true;
                        if (!jumpParticlePlayed)
                        {
                            jumpParticle.transform.position = transform.position - new Vector3(0,6,0);
                            jumpParticle.Play();
                            jumpParticlePlayed = true;
                        }
                    }
                    else 
                    {
                        isGrounded = false;
                        jumpParticlePlayed = false;
                        jumps = 0;
                        anim.SetBool("Falling", true);
                        StopCoroutine("JumpCooldown");
                    }

                    if (isGrounded && velocity.y < 0)
                    {
                        StartCoroutine("JumpCooldown");

                        anim.SetBool("Jumping", false);
                        anim.SetBool("Falling", false);
                        velocity.y = -2f;
                    }

                    //get energy from other script
                    if(energyBar)energy = energyBar.GetComponent<DashMeter>().currentCharge;

                    //check conditions to run and run if possible
                    if (run && energy > 0f && (moveDirection.x > 0.01 || moveDirection.x < -0.01 || moveDirection.y > 0.01 || moveDirection.y < -0.01))
                    {
                        Run();
                        if (isGrounded)
                        {
                            anim.SetBool("Running", true);
                            RunParticle.transform.SetPositionAndRotation(transform.position - new Vector3(0, 2, 0), Quaternion.identity);
                            if (!RunParticle.GetComponent<ParticleSystem>().isPlaying) RunParticle.GetComponent<ParticleSystem>().Play();
                            if (energyBar) energyBar.GetComponent<DashMeter>().Discharge();
                        }

                        
                    }
                    else
                    {
                        if (RunParticle.GetComponent<ParticleSystem>().isPlaying) RunParticle.GetComponent<ParticleSystem>().Stop();
                        anim.SetBool("Running", false);
                        if (energyBar) energyBar.GetComponent<DashMeter>().Recharge();

                    }

                    //stop trying to run when out of energy
                    if (energy == 0) run = false;


                    //make player jump if enough jumps
                    if (jumps > 0 && jump && !inTalkDistance)
                    {
                        if (RunParticle.GetComponent<ParticleSystem>().isPlaying) RunParticle.GetComponent<ParticleSystem>().Stop();
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


            //fishing
            case PlayerState.FISHING:
                {
                    if (isGrounded)
                    {
                        anim.SetBool("Walking", false);
                        anim.SetBool("Running", false);
                        anim.SetBool("Jumping", false);
                        anim.SetBool("Falling", false);
                        MoveCamera();
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
                    //CMCamera.GetComponent<CinemachineFreeLook>().m_XAxis.m_InputAxisValue = 0;
                    beginTalkCamPos = CMCamera.transform.position;
                    
                    anim.SetBool("Walking", false);
                    anim.SetBool("Running", false);
                    anim.SetBool("Jumping", false);
                    anim.SetBool("Falling", false);
                    anim.SetBool("Throwing", false);
                    anim.SetBool("ChargingThrow", false);
                    Gravity();

                    break;
                }




            //In boat
            case PlayerState.BOAT:
                {
                    anim.SetBool("Walking", false);
                    anim.SetBool("Running", false);
                    anim.SetBool("Jumping", false);
                    anim.SetBool("Falling", false);
                    anim.SetBool("Throwing", false);
                    anim.SetBool("ChargingThrow", false);

                    BoatButtonGuide = false;
                    if (BoatButtonImage) BoatButtonImage.enabled = false;
                    break;
                }










            default:
                break;
        }
        //stop holding A or jumping
        interact = false;
        jump = false;
    }




    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BoatTriggerBox"))
        {
            BoatButtonGuide = true;
            if (BoatButtonImage) BoatButtonImage.enabled = true;
        }

        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("BoatTriggerBox"))
        {
            BoatButtonGuide = false;
            if (BoatButtonImage) BoatButtonImage.enabled = false;
        }

       
    }


    private void LateUpdate()
    {
        if (BoatButtonGuide && BoatButtonImage)
        {
            BoatButtonImage.transform.position = transform.position + new Vector3(0,5,0);
            BoatButtonImage.transform.rotation = Camera.main.transform.rotation;
        }
    }








    void Move()
    {
        //get camera forward
        camForward = Vector3.Normalize(transform.position - CMCamera.transform.position);
        camForward.y = 0;
        camRight = Vector3.Cross(new Vector3(0, 1, 0), camForward);


        //move character acording to input
        Vector3 move = (camRight * moveDirection.x) + (camForward * moveDirection.y);

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
            CMCamera.GetComponent<CinemachineFreeLook>().m_XAxis.m_InputAxisName = "CameraMovement";
            CMCamera.GetComponent<CinemachineFreeLook>().m_XAxis.m_MaxSpeed = 300;
        }
        else
        {
            CMCamera.GetComponent<CinemachineFreeLook>().m_XAxis.m_InputAxisName = "Mouse X";
            CMCamera.GetComponent<CinemachineFreeLook>().m_XAxis.m_MaxSpeed = 300;
        }

        CMCamera.GetComponent<CinemachineFreeLook>().m_XAxis.m_InputAxisValue = camMoveDirection.x;
    }


    //this is for throwing because you hold B it makes sense to move the left stick instead of the right
    void MoveCameraWLeft()
    {
        //move camera
        if (moveDirection.x != 0)
        {
            CMCamera.GetComponent<CinemachineFreeLook>().m_XAxis.m_InputAxisName = "CameraMovement1";
            CMCamera.GetComponent<CinemachineFreeLook>().m_XAxis.m_MaxSpeed = 100;
        }
        else
        {
            CMCamera.GetComponent<CinemachineFreeLook>().m_XAxis.m_InputAxisName = "Mouse X";
            CMCamera.GetComponent<CinemachineFreeLook>().m_XAxis.m_MaxSpeed = 300;
        }

        CMCamera.GetComponent<CinemachineFreeLook>().m_XAxis.m_InputAxisValue = moveDirection.x;
    }




    void Run()
    {
        //get camera forward
        camForward = Vector3.Normalize(transform.position - CMCamera.transform.position);
        camForward.y = 0;
        camRight = Vector3.Cross(new Vector3(0, 1, 0), camForward);


        //move character acording to input
        Vector3 move = camRight * moveDirection.x + camForward * moveDirection.y;

        controller.Move(move * runSpeed * Time.deltaTime);
        if (move.x != 0 || move.z != 0) transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(move), 7f * Time.deltaTime);

    }


    IEnumerator DisableCollectableUI()
    {

        yield return new WaitForSeconds(1f);
        CollectableUI.enabled = false;

    }


    IEnumerator JumpCooldown()
    {
        yield return new WaitForSeconds(.1f);
        jumps = jumpsMax;

    }


    public void ChangeCamera(CinemachineFreeLook cam, bool raise)
    {
        if (raise)
        {
            cam.Priority = CMCamera.GetComponent<CinemachineFreeLook>().Priority + 1;
        }
        else
        {
            cam.Priority = CMCamera.GetComponent<CinemachineFreeLook>().Priority - 1;
        }
        
    }

    public void ChangeCamera(CinemachineVirtualCamera cam, bool raise)
    {
        if (raise)
        {
            cam.Priority = CMCamera.GetComponent<CinemachineVirtualCamera>().Priority + 1;
        }
        else
        {
            cam.Priority = CMCamera.GetComponent<CinemachineVirtualCamera>().Priority - 1;
        }

    }



}
