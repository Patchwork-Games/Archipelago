using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CampfireQuest : MonoBehaviour
{
    private bool litFire = false;
    [SerializeField] int requiredSticks = 3;
    [SerializeField] float talkRadius = 5.0f;
    private Canvas ButtonGuide = null;
    private bool hiddenButtonGuide = false;
    private Camera cam = null;
    TextMeshProUGUI reqText = null;
    private GameObject flame = null;
    private GameObject smoke = null;
    private GameObject smoke2 = null;
    private GameObject flameLight = null;
    private GameObject flameSparks = null;

    private void Awake()
    {
        ButtonGuide = transform.GetChild(0).gameObject.GetComponent<Canvas>();
        cam = Camera.main;
        reqText = transform.GetChild(0).transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>();
        flame = transform.GetChild(1).gameObject;
        smoke = transform.GetChild(2).gameObject;
        smoke2 = transform.GetChild(3).gameObject;
        flameLight = transform.GetChild(4).gameObject;
        flameSparks = transform.GetChild(5).gameObject;
        litFire = false;
    }

    private void Update()
    {
        //check if player is close enough to pick up
        if (Vector3.Distance(transform.position, StaticValueHolder.PlayerMovementScript.transform.position) < talkRadius && !litFire)
        {
            //show button needed to pick up
            if (ButtonGuide)
            {
                //move UI to above fire
                ButtonGuide.transform.position = transform.position + new Vector3(0, 5, 0);
                ButtonGuide.transform.rotation = cam.transform.rotation;
                ButtonGuide.enabled = true;
                hiddenButtonGuide = false;
                StaticValueHolder.PlayerMovementScript.inTalkDistance = true;
                reqText.text = StaticValueHolder.Collectable2 + "/" + requiredSticks;
            }

            //light fire with interact
            if (StaticValueHolder.PlayerMovementScript.interact && StaticValueHolder.Collectable2 >= requiredSticks)   
            {
                StaticValueHolder.PlayerMovementScript.interact = false;
                StaticValueHolder.PlayerMovementScript.jump = false;
                StaticValueHolder.Collectable2 -= requiredSticks;
                flame.SetActive(true);
                smoke.SetActive(true);
                smoke2.SetActive(true);
                flameLight.SetActive(true);
                flameSparks.SetActive(true);
                litFire = true;
                HideButton();


                //give reward here

            }
        }
        else if (!hiddenButtonGuide) //if this is in the normal else then the talk button is always disabled for any npc other than the first
        {
            HideButton();
        }

        //billboard flame once lit
        if (flame.activeSelf)
        {
            //make flame billboard only on y axis
            Vector3 v = cam.transform.position - transform.position;
            v.x = v.z = 0.0f;
            flame.transform.LookAt(cam.transform.position - v);
        }
    }


    void HideButton()
    {
        hiddenButtonGuide = true;
        ButtonGuide.enabled = false;
        StaticValueHolder.PlayerMovementScript.inTalkDistance = false;
    }
}
