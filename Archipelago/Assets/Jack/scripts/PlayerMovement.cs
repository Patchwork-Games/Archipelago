using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    public enum ItemEquipped
    {
        SKIMMINGROCK,
        FISHINGPOLE
    }
    public ItemEquipped currentItem;


    public Animator anim = null;

    //camera variables
    private Camera mainCam = null;
    //public GameObject poolCam = null;
    Vector3 camForward = Vector3.zero;
    Vector3 camRight = Vector3.zero;
    Vector2 camMoveDirection = Vector2.zero;
    [HideInInspector] public Vector3 beginTalkCamPos = Vector3.zero;
    [HideInInspector] public bool BoatButtonGuide = false;
    [SerializeField] private Canvas BoatButtonImage = null;


    //movement variables
    [HideInInspector] public CharacterController controller = null;
    [SerializeField] private float walkSpeed = 8f;
    [SerializeField] private float runSpeed = 16f;
    Vector2 moveDirection = Vector2.zero;
    Vector3 velocity = Vector3.zero;
    //private bool inWater = false;




    //button variables
    [HideInInspector] public InputMaster controls = null;
    [HideInInspector] public bool interact = false;
    [HideInInspector] public bool jump = false;
    [HideInInspector] public bool YHeld = false;
    [HideInInspector] public bool inTalkDistance = false;
    [SerializeField] private Canvas CollectableUI = null;
    private bool run = false;


    //jumping variables
    private int jumps = 0;
    private int jumpsMax = 1;
    private float distanceGround;
    [HideInInspector] public bool isGrounded;
    [SerializeField] private float groundDistance = 0.5f;
    [SerializeField] private float gravity = -55.81f;
    [SerializeField] private LayerMask groundMask = ~0;



    //particles
    private ParticleSystem RunParticle = null;
    private ParticleSystem InWaterWalkingParticle = null;
    [HideInInspector] public ParticleSystem jumpParticle = null;
    private bool jumpParticlePlayed = false;



    private void Awake()
    {
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

    void StopThrowButton()
    {
        GetComponent<SkimmingController>().heldThrow = false;
    }


    void YButton()
    {
        YHeld = true;
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
        YHeld = false;
        if (CollectableUI)
        {
            CollectableUI.GetComponent<Animator>().Play("FadeOutCollectableUI");
            StartCoroutine("DisableCollectableUI");
        }
        else Debug.Log("Collectable UI not attached to player");
    }



    private void Start()
    {
        currentItem = ItemEquipped.SKIMMINGROCK;
        mainCam = Camera.main;
        controller = GetComponent<CharacterController>();
        anim.SetBool("Walking", false);
        isGrounded = true;
        distanceGround = GetComponent<CharacterController>().bounds.extents.y;
        inTalkDistance = false;

        Transform particlesObject = transform.Find("Particles").gameObject.transform;
        jumpParticle = particlesObject.Find("JumpParticle").GetComponent<ParticleSystem>();
        RunParticle = particlesObject.Find("RunParticle").GetComponent<ParticleSystem>();
        InWaterWalkingParticle = transform.parent.Find("InWaterWalkingParticle").GetComponent<ParticleSystem>();


    }



    private void Update()
    {
        //show water ripple
        if (transform.position.y < 33.3f)
        {
            //have to manally set position as the y stays the same so that it appears on the water
            InWaterWalkingParticle.transform.SetPositionAndRotation(new Vector3(transform.position.x, InWaterWalkingParticle.transform.position.y, transform.position.z), InWaterWalkingParticle.transform.rotation);
            if (!InWaterWalkingParticle.isPlaying) InWaterWalkingParticle.Play();

        }
        else if(InWaterWalkingParticle.isPlaying) InWaterWalkingParticle.Stop();

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
            BoatButtonImage.transform.rotation = mainCam.transform.rotation;
        }
    }


    public void Move()
    {
        //get camera forward
        camForward = Vector3.Normalize(transform.position - StaticValueHolder.PlayerCharacterCamera.transform.position);
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

    public void Gravity()
    {
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }


    public void MoveCamera()
    {
        //move camera
        if (camMoveDirection.x != 0)
        {
            StaticValueHolder.PlayerCharacterCamera.m_XAxis.m_InputAxisName = "CameraMovement";
            StaticValueHolder.PlayerCharacterCamera.m_XAxis.m_MaxSpeed = 300;
        }
        else
        {
            StaticValueHolder.PlayerCharacterCamera.m_XAxis.m_InputAxisName = "Mouse X";
            StaticValueHolder.PlayerCharacterCamera.m_XAxis.m_MaxSpeed = 300;
        }

        StaticValueHolder.PlayerCharacterCamera.m_XAxis.m_InputAxisValue = camMoveDirection.x;
    }


    //this is for throwing because you hold B it makes sense to move the left stick instead of the right
    public void MoveCameraWLeft()
    {
        //move camera
        if (moveDirection.x != 0)
        {
            StaticValueHolder.PlayerCharacterCamera.m_XAxis.m_InputAxisName = "CameraMovement1";
            StaticValueHolder.PlayerCharacterCamera.m_XAxis.m_MaxSpeed = 50;
        }
        else
        {
            StaticValueHolder.PlayerCharacterCamera.m_XAxis.m_InputAxisName = "Mouse X";
            StaticValueHolder.PlayerCharacterCamera.m_XAxis.m_MaxSpeed = 300;
        }

        StaticValueHolder.PlayerCharacterCamera.m_XAxis.m_InputAxisValue = moveDirection.x;
    }




    public void Run()
    {
        //get camera forward
        camForward = Vector3.Normalize(transform.position - StaticValueHolder.PlayerCharacterCamera.transform.position);
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
            cam.Priority = StaticValueHolder.PlayerCharacterCamera.Priority + 1;
        }
        else
        {
            cam.Priority = StaticValueHolder.PlayerCharacterCamera.Priority - 1;
        }
        
    }

    public void ChangeCamera(CinemachineVirtualCamera cam, bool raise)
    {
        if (raise)
        {
            cam.Priority = StaticValueHolder.PlayerCharacterCamera.Priority + 1;
        }
        else
        {
            cam.Priority = StaticValueHolder.PlayerCharacterCamera.Priority - 1;
        }

    }








    public void CheckGround()
    {
        //check if on ground
        if (Physics.Raycast(transform.position, -Vector3.up, distanceGround + groundDistance, groundMask))
        {
            isGrounded = true;
            if (!jumpParticlePlayed)
            {
                jumpParticle.transform.position = transform.position - new Vector3(0, 6, 0);
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
            velocity.y = -4f;
        }
    }



    public void CheckRun()
    {
        //get energy from other script
        //if (energyBar) energy = energyBar.GetComponent<DashMeter>().currentCharge;

        //check conditions to run and run if possible
        if (run && (moveDirection.x > 0.01 || moveDirection.x < -0.01 || moveDirection.y > 0.01 || moveDirection.y < -0.01))
        {
            Run();
            if (isGrounded)
            {
                anim.SetBool("Running", true);
                //RunParticle.transform.SetPositionAndRotation(transform.position - new Vector3(0, 2, 0), Quaternion.identity);
                if (!RunParticle.isPlaying) RunParticle.Play();
                //if (energyBar) energyBar.GetComponent<DashMeter>().Discharge();
            }


        }
        else
        {
            if (RunParticle.isPlaying) RunParticle.Stop();
            anim.SetBool("Running", false);
            //if (energyBar) energyBar.GetComponent<DashMeter>().Recharge();

        }

        //stop trying to run when out of energy
        //if (energy == 0) run = false;
    }


    public void CheckJump()
    {
        //make player jump if enough jumps
        if (jumps > 0 && jump && !inTalkDistance)
        {
            if (RunParticle.isPlaying) RunParticle.Stop();
            velocity.y = 20f;
            jumps -= 1;
            anim.SetBool("Jumping", true);
        }
    }




    public void CheckThrowing()
    {
        if (isGrounded)
        {
            if (RunParticle.isPlaying) RunParticle.Stop();
            anim.SetBool("Walking", false);
            anim.SetBool("Running", false);
            anim.SetBool("Jumping", false);
            anim.SetBool("Falling", false);
            MoveCameraWLeft();
        }
        else
        {
            PlayerStateMachine.Instance.state = PlayerStateMachine.PlayerState.MOVING;
        }
    }



    public void CheckFishing()
    {
        if (isGrounded)
        {
            if (RunParticle.isPlaying) RunParticle.Stop();
            anim.SetBool("Walking", false);
            anim.SetBool("Running", false);
            anim.SetBool("Jumping", false);
            anim.SetBool("Falling", false);
            MoveCamera();
        }
        else
        {
            PlayerStateMachine.Instance.state = PlayerStateMachine.PlayerState.MOVING;
        }
    }




    public void CheckTalking()
    {
        //CMCamera.GetComponent<CinemachineFreeLook>().m_XAxis.m_InputAxisValue = 0;
        beginTalkCamPos = StaticValueHolder.PlayerCharacterCamera.transform.position;
        if (RunParticle.isPlaying) RunParticle.Stop();
        anim.SetBool("Walking", false);
        anim.SetBool("Running", false);
        anim.SetBool("Jumping", false);
        anim.SetBool("Falling", false);
        anim.SetBool("ChargingThrow", false);
        Gravity();
    }



    public void CheckBoat()
    {
        if (RunParticle.isPlaying) RunParticle.Stop();
        if (InWaterWalkingParticle.isPlaying) InWaterWalkingParticle.Stop();
        controller.enabled = false;
        anim.SetBool("InBoat", true);
        anim.SetBool("Walking", false);
        anim.SetBool("Running", false);
        anim.SetBool("Jumping", false);
        anim.SetBool("Falling", false);
        anim.SetBool("ChargingThrow", false);

        BoatButtonGuide = false;
        if (BoatButtonImage) BoatButtonImage.enabled = false;
    }


    

}
