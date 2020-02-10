using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;


public class SkimmingController : MonoBehaviour
{
    [SerializeField] private Animator anim = null;
    [SerializeField] private GameObject mainCamera = null;
    [SerializeField] private GameObject stone = null;
    [SerializeField] private GameObject ChargeParticle = null;
    [SerializeField] private GameObject FullChargeParticle = null;
    [SerializeField] private float maxThrowPower = 2000;
    [SerializeField] private GameObject launchPoint = null;
    public bool doingThrow = false;
    public bool heldThrow = false;
    private bool chargingThrow = false;
    private float throwPower = 0;
    private float angleClamp = 0;
    private Vector3 originalPos = Vector3.zero;


    private void Start()
    {
        anim.SetBool("ChargingThrow", false);
        chargingThrow = false;
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
        GameObject currentStone = Instantiate(stone, launchPoint.transform.position, transform.rotation);
        currentStone.GetComponent<StoneMovement>().throwPower = throwPower;
        currentStone.GetComponent<StoneMovement>().direction = transform.forward;
        CameraShake.instance.ShakeCamera(.5f, 2, 2);
        ChargeParticle.GetComponent<ParticleSystem>().Stop();
        FullChargeParticle.GetComponent<ParticleSystem>().Stop();
    }


    //charge power of throw
    public void chargeThrow()
    { 
        if (throwPower > maxThrowPower)
        {
            throwPower = maxThrowPower;
            //show sparkle here to show that max power reached
            FullChargeParticle.transform.position = PlayerMovement.Instance.transform.position;
            FullChargeParticle.GetComponent<ParticleSystem>().Play();
        }
        else if(throwPower != maxThrowPower)
        {
            throwPower += Time.deltaTime * 600;
        }
    }



    //shake character while charging
    IEnumerator ShakeCharacter()
    {
        while (chargingThrow)
        {
            transform.position += Random.insideUnitSphere * (Time.deltaTime * throwPower / 500);

            yield return new WaitForSeconds(0.02f);
            transform.position = originalPos;
        }
    }



    public void testThrow()
    {

        if (heldThrow && !chargingThrow && PlayerMovement.Instance.isGrounded)
        {
            PlayerStateMachine.Instance.state = PlayerStateMachine.PlayerState.THROWING;
            chargingThrow = true;
            anim.SetBool("ChargingThrow", true);
            throwPower = 0;
            originalPos = transform.position;
            ChargeParticle.transform.position = PlayerMovement.Instance.transform.position - new Vector3(0,1,0); //show particle while charging
            ChargeParticle.GetComponent<ParticleSystem>().Play();
            StartCoroutine("ShakeCharacter");
        }




        if (chargingThrow)
        {
            //anim.SetBool("ChargingThrow", true);

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
            anim.SetBool("ChargingThrow", false);
        }
    }
}
