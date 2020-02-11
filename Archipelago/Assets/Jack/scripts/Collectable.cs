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


    GameObject PickupIcon = null;
    Sprite fishSprite;
    Sprite shellSprite;
    Sprite stickSprite;


    [SerializeField] float pickUpRadius = 5.0f;
    private Canvas pickupButtonGuide = null;
    private bool hiddenPickupButton = false;




    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            //check if player is close enough to talk
            if (Vector3.Distance(transform.position, PlayerMovement.Instance.transform.position) < pickUpRadius)
            {
                //show button needed to talk
                if (pickupButtonGuide)
                {
                    pickupButtonGuide.transform.position = PlayerMovement.Instance.transform.position + new Vector3(0, 5, 0);
                    pickupButtonGuide.enabled = true;
                    PlayerMovement.Instance.inTalkDistance = true;
                    hiddenPickupButton = false;
                }
                else if (pickupButtonGuide && !hiddenPickupButton) //hide talk button without disabling it for every npc
                {
                    pickupButtonGuide.enabled = false;
                    hiddenPickupButton = true;
                    PlayerMovement.Instance.GetComponent<PlayerMovement>().inTalkDistance = false;
                }
                if (PlayerMovement.Instance.interact)   //pickup object with interact
                {
                    switch (collectableType)
                    {
                        //add one to collected UI and show icon above player to indicate collection, gets the icon from the Collectable UI script
                        case CollectableTypes.FISH:
                            {
                                StaticValueHolder.Collectable0 += 1;
                                GameObject newIcon = Instantiate(transform.parent.parent.GetChild(0).GetComponent<CollectableUIUpdate>().PickupIcon, PlayerMovement.Instance.transform.position + new Vector3(0, 5, 0), Quaternion.identity);
                                newIcon.transform.GetChild(0).GetComponent<Image>().sprite = transform.parent.parent.GetChild(0).GetComponent<CollectableUIUpdate>().fishSprite;
                                break;
                            }
                        case CollectableTypes.SHELL:
                            {
                                StaticValueHolder.Collectable1 += 1;
                                GameObject newIcon = Instantiate(transform.parent.parent.GetChild(0).GetComponent<CollectableUIUpdate>().PickupIcon, PlayerMovement.Instance.transform.position + new Vector3(0, 5, 0), Quaternion.identity);
                                newIcon.transform.GetChild(0).GetComponent<Image>().sprite = transform.parent.parent.GetChild(0).GetComponent<CollectableUIUpdate>().shellSprite;
                                break;
                            }
                        case CollectableTypes.STICK:
                            {
                                StaticValueHolder.Collectable2 += 1;
                                GameObject newIcon = Instantiate(transform.parent.parent.GetChild(0).GetComponent<CollectableUIUpdate>().PickupIcon, PlayerMovement.Instance.transform.position + new Vector3(0, 5, 0), Quaternion.identity);
                                newIcon.transform.GetChild(0).GetComponent<Image>().sprite = transform.parent.parent.GetChild(0).GetComponent<CollectableUIUpdate>().stickSprite;
                                break;
                            }
                        case CollectableTypes.ENERGY:
                            {
                                Debug.Log("ADD NEW METHOD, SEE COLLECTABLE SCRIPT");
                                //aidan is changing this rn so remember to update it
                                //GameObject.FindGameObjectWithTag("EnergyUI").GetComponent<DashMeter>().UpdateBarTotal();
                                break;
                            }
                        default:
                            {
                                Debug.Log("WRONG TYPE OF COLLECTABLE, SEE COLLECTABLE SCRIPT");
                                break;
                            }
                    }
                }
            }
            else if (!hiddenPickupButton) //if this is in the normal else then the talk button is always disabled for any npc other than the first
            {
                hiddenPickupButton = true;
                pickupButtonGuide.enabled = false;
                PlayerMovement.Instance.inTalkDistance = false;
            }



            


            Destroy(gameObject);
        }
    }
}
