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

    public InputMaster controls;

    public Animator anim;
    public GameObject stone;

    public GameObject mainCamera;
    public GameObject throwCamera;
    public GameObject energyBar;



    [SerializeField] private GameObject currentThrowSpot;
    [SerializeField] private CharacterController controller;
    [SerializeField] private float speed = 4f;
    [SerializeField] private float runSpeed = 8f;
    [SerializeField] private float gravity = -55.81f;
    [SerializeField] private float maxThrowPower = 1000;
    [SerializeField] private float energy = 0;

    [SerializeField] public Transform groundCheck;
    [SerializeField] private float groundDistance = 0.4f;
    [SerializeField] private LayerMask groundMask;


    Vector3 camForward;
    Vector3 camRight;
    Vector3 velocity;
    private Vector3 originalPos;
    private bool isGrounded;
    private bool chargingThrow;
    private bool throwing;
    private bool justChangedThrowSpot;
    private bool interact = false;
    private bool run = false;

    [HideInInspector]public bool throwReady;
    [HideInInspector]public bool doingThrow;

    private float angleClamp;
    private float throwPower;
    private int jumps = 0;
    private int jumpsMax = 1;
    
   

    Vector2 moveDirection;
    Vector2 camMoveDirection;

    private void Awake()
    {
        controls = new InputMaster();
        controls.Player.Movement.performed += context => moveDirection = context.ReadValue<Vector2>();
        controls.Player.Movement.canceled += context => moveDirection = context.ReadValue<Vector2>();
        controls.Player.CameraMovement.performed += context => camMoveDirection = context.ReadValue<Vector2>();
        controls.Player.CameraMovement.canceled += context => camMoveDirection = context.ReadValue<Vector2>();
        controls.Player.Interact.performed += context => InteractButton();
        controls.Player.Run.performed += context => RunButton();
        controls.Player.Run.canceled += context => StopRunButton();
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
        
        Debug.Log("A");
    }


    void RunButton()
    {
        run = true;
        Debug.Log("X");
    }

    void StopRunButton()
    {
        run = false;
        Debug.Log("Stop X");
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
        interact = false;
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


                    //http://www.alanzucconi.com/2015/06/17/surface-shaders-in-unity3d/


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
                    if (Input.GetMouseButtonDown(0) && throwReady)
                    {
                        chargingThrow = true;
                        throwing = false;
                        throwPower = 0;
                        originalPos = transform.position;
                        StartCoroutine("ShakeCharacter");
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













    void Move()
    {
        //get camera forward
        camForward = Vector3.Normalize(transform.position - mainCamera.transform.position);
        camForward.y = 0;
        camRight = Vector3.Cross(new Vector3(0, 1, 0), camForward);


        //move character acording to input
        Vector3 move = camRight * moveDirection.x + camForward * moveDirection.y;

        controller.Move(move * speed * Time.deltaTime);
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
        //gravity
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









    private void OnTriggerEnter(Collider other)
    {
        //move camera and set current throwing spot
        if (other.gameObject.CompareTag("ThrowSpot"))
        {
            //set current view spot to one that is stood on
            currentThrowSpot = other.gameObject;
            throwCamera = currentThrowSpot.transform.GetChild(1).gameObject;

            throwCamera.GetComponent<CinemachineVirtualCamera>().Priority = mainCamera.GetComponent<CinemachineFreeLook>().Priority + 1;
            mainCamera.GetComponent<CinemachineFreeLook>().m_XAxis.m_MaxSpeed = 0;
        }
    }

    
    private void OnTriggerExit(Collider other)
    {

        //move camera and remove current throwing spot
        if (other.gameObject.CompareTag("ThrowSpot"))
        {
            //remove throwing spot that was left
            throwCamera.GetComponent<CinemachineVirtualCamera>().Priority = mainCamera.GetComponent<CinemachineFreeLook>().Priority - 1;
            mainCamera.GetComponent<CinemachineFreeLook>().m_XAxis.m_MaxSpeed = 500;
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
            transform.position = currentThrowSpot.transform.GetChild(0).transform.position;
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
        throwPower += Time.deltaTime * 300;
        Debug.Log("ThrowPower: " + throwPower);
        if (throwPower > maxThrowPower)
        {
            throwPower = maxThrowPower;
            //could show sparkle here to show that max power reached
        }
    }


    //shake character while charging
    IEnumerator ShakeCharacter()
    {
        while (chargingThrow)
        {
            transform.position += Random.insideUnitSphere * (Time.deltaTime * throwPower/ 300);

            yield return new WaitForSeconds(0.02f);
            transform.position = originalPos;
        }
    }

}
