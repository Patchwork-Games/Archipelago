using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public enum CollectableTypes
    {
        FISH,
        SHELL,
        STICK,
        ENERGY
    }
    public CollectableTypes collectableType;

    Sprite fishSprite;
    Sprite shellSprite;
    Sprite stickSprite;


    [SerializeField] float pickUpRadius = 3.0f;
    private Canvas pickupButtonGuide = null;
    private bool hiddenPickupButton = false;


    private void Awake()
    {
        fishSprite = transform.parent.parent.GetChild(0).GetComponent<CollectableUIUpdate>().fishSprite;
        shellSprite = transform.parent.parent.GetChild(0).GetComponent<CollectableUIUpdate>().shellSprite;
        stickSprite = transform.parent.parent.GetChild(0).GetComponent<CollectableUIUpdate>().stickSprite;
        pickupButtonGuide = transform.parent.parent.GetChild(0).GetComponent<CollectableUIUpdate>().pickupButtonGuide;
        hiddenPickupButton = false;
    }




    private void Update()
    {
        //check if player is close enough to pick up
        if (Vector3.Distance(transform.position, StaticValueHolder.PlayerMovementScript.transform.position) < pickUpRadius && collectableType != CollectableTypes.ENERGY)
        {
            //show button needed to pick up
            if (pickupButtonGuide)
            {
                pickupButtonGuide.transform.position = transform.position + new Vector3(0, 5, 0);
                pickupButtonGuide.enabled = true;
                StaticValueHolder.PlayerMovementScript.inTalkDistance = true;
                hiddenPickupButton = false;
            }
            if (StaticValueHolder.PlayerMovementScript.interact)   //pickup object with interact
            {
                StaticValueHolder.PlayerMovementScript.jump = false;
                switch (collectableType)
                {
                    //add one to collected UI and show icon above player to indicate collection, gets the icon from the Collectable UI script
                    case CollectableTypes.FISH:
                        {
                            StaticValueHolder.Collectable0 += 1;
                            GameObject newIcon = Instantiate(transform.parent.parent.GetChild(0).GetComponent<CollectableUIUpdate>().PickupIcon, StaticValueHolder.PlayerMovementScript.transform.position + new Vector3(0, 5, 0), Quaternion.identity);
                            newIcon.transform.GetChild(0).GetComponent<Image>().sprite = fishSprite;
                            break;
                        }
                    case CollectableTypes.SHELL:
                        {
                            StaticValueHolder.Collectable1 += 1;
                            GameObject newIcon = Instantiate(transform.parent.parent.GetChild(0).GetComponent<CollectableUIUpdate>().PickupIcon, StaticValueHolder.PlayerMovementScript.transform.position + new Vector3(0, 5, 0), Quaternion.identity);
                            newIcon.transform.GetChild(0).GetComponent<Image>().sprite = shellSprite;
                            break;
                        }
                    case CollectableTypes.STICK:
                        {
                            StaticValueHolder.Collectable2 += 1;
                            GameObject newIcon = Instantiate(transform.parent.parent.GetChild(0).GetComponent<CollectableUIUpdate>().PickupIcon, StaticValueHolder.PlayerMovementScript.transform.position + new Vector3(0, 5, 0), Quaternion.identity);
                            newIcon.transform.GetChild(0).GetComponent<Image>().sprite = stickSprite;
                            break;
                        }
                    case CollectableTypes.ENERGY:
                        {
                            Debug.Log("Shouldnt happen, see Collectable script");
                           
                            break;
                        }
                    default:
                        {
                            Debug.Log("WRONG TYPE OF COLLECTABLE, SEE COLLECTABLE SCRIPT");
                            break;
                        }
                }
                HideButton();
                Destroy(gameObject);
            }
        }
        else if (!hiddenPickupButton) //if this is in the normal else then the talk button is always disabled for any npc other than the first
        {
            
            HideButton();
        }
    }




    private void OnTriggerEnter(Collider other)
    {
        //pick up the energy when running into it but not other types
        if (collectableType == CollectableTypes.ENERGY)
        {
            if (other.CompareTag("Player") || other.CompareTag("Boat"))
            {
				StaticValueHolder.DashMeterObject.gameObject.SetActive(true);
				StaticValueHolder.DashMeterObject.AddEnergies(1);
				if (PlayerStateMachine.Instance.state != PlayerStateMachine.PlayerState.BOAT)
					StaticValueHolder.DashMeterObject.gameObject.SetActive(false);
				Destroy(gameObject);
            }
        }
        
    }


    void HideButton()
    {
        hiddenPickupButton = true;
        pickupButtonGuide.enabled = false;
        //PlayerMovement.Instance.interact = false;
        StaticValueHolder.PlayerMovementScript.inTalkDistance = false;
    }

}
