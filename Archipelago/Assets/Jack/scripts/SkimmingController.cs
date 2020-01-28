using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;


public class SkimmingController : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject mainCamera;
    [SerializeField] private GameObject stone;
    [SerializeField] private float maxThrowPower = 1000;
    [HideInInspector] public bool throwReady;
    [HideInInspector] public bool doingThrow;
    [HideInInspector] public bool heldThrow;
    private bool chargingThrow;
    private float throwPower;
    private float angleClamp;
    private Vector3 originalPos;


    private void Start()
    {
        anim.SetBool("ChargingThrow", false);
        anim.SetBool("Throwing", false);
        chargingThrow = false;
        throwReady = true;
        doingThrow = false;
        heldThrow = false;
    }

    private void FixedUpdate()
    {
        testThrow();
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
            chargingThrow = true;
            throwPower = 0;
            originalPos = transform.position;
            StartCoroutine("ShakeCharacter");
            throwReady = false;
        }




        if (chargingThrow)
        {
            anim.SetBool("ChargingThrow", true);

            Vector3 camForward = Vector3.Normalize(transform.position - mainCamera.transform.position);
            camForward.y = 0;
            

            //LookAtMouse();
            chargeThrow();
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(camForward), 9f * Time.deltaTime);
        }

        //stop charging when release button
        if (!heldThrow && chargingThrow)
        {
            chargingThrow = false;
            //anim.SetBool("Throwing", true);
            anim.SetBool("ChargingThrow", false);
        }
    }
}
