using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;


public class SkimmingController : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject mainCamera;
    [SerializeField] private GameObject throwCamera;
    [SerializeField] private GameObject stone;
    [SerializeField] private GameObject currentThrowSpot;
    [SerializeField] private float maxThrowPower = 1000;
    [HideInInspector] public bool throwReady;
    [HideInInspector] public bool doingThrow;
    [HideInInspector] public bool heldThrow;
    private bool justChangedThrowSpot;
    private bool chargingThrow;
    private bool throwing;
    private float throwPower;
    private float angleClamp;
    private Vector3 originalPos;


    private void Start()
    {
        anim.SetBool("ChargingThrow", false);
        anim.SetBool("Throwing", false);
        chargingThrow = false;
        throwing = false;
        throwReady = true;
        doingThrow = false;
        justChangedThrowSpot = false;
        heldThrow = false;
    }

    private void Update()
    {
        testThrow();
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
        if (other.gameObject.CompareTag("ThrowSpot") && Input.GetKeyDown(KeyCode.E) && !justChangedThrowSpot)
        {
            //get clamp for throwing angle
            angleClamp = currentThrowSpot.GetComponent<ThrowSpotAngleShow>().totalFOV / 2;

            //move player to middle of throwing platform and enter throwing state
            //transform.position = currentThrowSpot.transform.GetChild(0).transform.position;
            //anim.SetBool("Walking", false);
            //state = PlayerState.THROWING;
            //justChangedThrowSpot = true;
        }


        if (other.gameObject.CompareTag("ThrowSpot") && Input.GetKeyDown(KeyCode.E) && !justChangedThrowSpot)
        {
            //move player to middle of throwing platform and enter throwing state
            //state = PlayerState.MOVING;
            //justChangedThrowSpot = true;
        }
        justChangedThrowSpot = false;
    }




    //aim player at mouse
    public void LookAtMouse()
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
    public void chargeThrow()
    {
        throwPower += Time.deltaTime * 300;
        if (throwPower > maxThrowPower)
        {
            throwPower = maxThrowPower;
            //could show sparkle here to show that max power reached
        }

        //stop charging when release button
        if (!heldThrow)
        { 
            chargingThrow = false;
            throwing = true;
        }
    }





    public void LaunchShake()
    {
        StartCoroutine("ShakeCharacter");
    }




    //shake character while charging
    IEnumerator ShakeCharacter()
    {
        while (chargingThrow)
        {
            transform.position += Random.insideUnitSphere * (Time.deltaTime * throwPower / 300);

            yield return new WaitForSeconds(0.02f);
            transform.position = originalPos;
        }
    }







    public void testThrow()
    {
        if (heldThrow && throwReady)
        {
            Debug.Log("THROWING");
            chargingThrow = true;
            throwing = false;
            throwPower = 0;
            originalPos = transform.position;
            GetComponent<SkimmingController>().LaunchShake();
            throwReady = false;
        }
        else if (heldThrow)
        {
            throwing = false;
        }


        

        if (chargingThrow)
        {
            anim.SetBool("ChargingThrow", true);
            anim.SetBool("Throwing", false);

            Vector3 camForward = Vector3.Normalize(transform.position - mainCamera.transform.position);
            camForward.y = 0;
            

            //LookAtMouse();
            chargeThrow();
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(camForward), 9f * Time.deltaTime);
        }

        if (throwing)
        {
            anim.SetBool("Throwing", true);
            anim.SetBool("ChargingThrow", false);
        }
    }




}
