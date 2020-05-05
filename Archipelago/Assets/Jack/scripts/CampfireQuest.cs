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
    private GameObject fire = null;

    // Audio
    private AudioSource fireLitNoise = null;

    private void Awake()
    {
        ButtonGuide = transform.GetChild(0).gameObject.GetComponent<Canvas>();
        cam = Camera.main;
        reqText = transform.GetChild(0).transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>();
        fire = transform.GetChild(1).gameObject;
        litFire = false;

        // Get the fire lit noise
        fireLitNoise = transform.Find("Audio").Find("FireLit").GetComponent<AudioSource>();
        if (fireLitNoise == null)
        {
            Debug.Log("Missing FireLit child on object: " + transform.Find("Audio") + gameObject);
        }
    }

    private void Update()
    {
        //check if player is close enough to pick up
        if (Vector3.Distance(transform.position, StaticValueHolder.PlayerMovementScript.transform.position) < talkRadius && !litFire)
        {
            //show button needed to light campfire
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
                fire.SetActive(true);                
                litFire = true;
                HideButton();

                // Play fire lit noise
                fireLitNoise.Play();

                //give reward to player
                StaticValueHolder.DashMeterObject.AddDashes(1);
            }
        }
        else if (!hiddenButtonGuide) //if this is in the normal else then the talk button is always disabled for any npc other than the first
        {
            HideButton();
        }

        //billboard flame once lit
        if (fire.activeSelf)
        {
            //make flame billboard only on y axis
            Vector3 v = cam.transform.position - transform.position;
            v.x = v.z = 0.0f;
            fire.transform.GetChild(0).transform.LookAt(cam.transform.position - v);
        }
    }


    void HideButton()
    {
        hiddenButtonGuide = true;
        ButtonGuide.enabled = false;
        StaticValueHolder.PlayerMovementScript.inTalkDistance = false;
    }
}
