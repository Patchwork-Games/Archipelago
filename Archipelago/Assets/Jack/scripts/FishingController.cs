using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;


public class FishingController : MonoBehaviour
{
    [SerializeField] private Animator anim = null;
    [SerializeField] private GameObject bobber = null;
    [SerializeField] private float maxCastPower = 1000;
    private GameObject fishingPole = null;

    [HideInInspector] public bool doingCast = false;
    [HideInInspector] public bool heldCast = false;
    [HideInInspector] public bool launched = false;
    private bool chargingCast = false;
    private float castPower = 0;
    private Vector3 originalPos = Vector3.zero;


    private void Start()
    {
        anim.SetBool("ChargingCast", false);
        fishingPole = GameObject.FindGameObjectWithTag("FishingPole");
        chargingCast = false;
        doingCast = false;
        heldCast = false;
    }

    private void FixedUpdate()
    {
        testCast();
    }


    //aim player at mouse
    public void LookAtMouse()
    {
        Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.AngleAxis(-angle + 90, new Vector3(0, 1, 0));
    }

    //launch a stone
    public void CastBobber()
    {       
        GameObject currentBobber = Instantiate(bobber, transform.position, transform.rotation);
        currentBobber.GetComponent<Fishing>().direction = transform.forward;
        launched = true;
    }


    //charge power of throw
    public void chargeCast()
    {
        castPower += Time.deltaTime * 300;
        if (castPower > maxCastPower)
        {
            castPower = maxCastPower;
            //could show sparkle here to show that max power reached
        }
    }



    //shake character while charging
    IEnumerator ShakeCharacter()
    {
        while (chargingCast)
        {
            transform.position += Random.insideUnitSphere * (Time.deltaTime * castPower / 300);

            yield return new WaitForSeconds(0.02f);
            transform.position = originalPos;
        }
    }



    public void testCast()
    {

        if (heldCast && !chargingCast && StaticValueHolder.PlayerMovementScript.isGrounded)
        {
            PlayerStateMachine.Instance.state = PlayerStateMachine.PlayerState.FISHING;
            fishingPole.GetComponent<MeshRenderer>().enabled = true;
            chargingCast = true;
            anim.SetBool("ChargingCast", true);
            castPower = 0;
            originalPos = transform.position;
            StartCoroutine("ShakeCharacter");
        }



        if (chargingCast)
        {
            Vector3 camForward = Vector3.Normalize(transform.position - StaticValueHolder.PlayerCharacterCamera.transform.position);
            camForward.y = 0;
            //LookAtMouse();
            chargeCast();
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(camForward), 9f * Time.deltaTime);
        }



        //stop charging when release button
        if (!heldCast && chargingCast)
        {
            chargingCast = false;
            anim.SetBool("ChargingCast", false);
        }
    }
}
