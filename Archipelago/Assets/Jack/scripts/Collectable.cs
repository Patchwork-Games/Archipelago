using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public enum CollectableTypes
    {
        FISH,
        BUTTERFLY,
        STICK,
        BANANA,
        DASH
    }
    public CollectableTypes collectableType;
    public bool Collected { get; private set; } = false;

    Sprite fishSprite;
    Sprite butterflySprite;
    Sprite stickSprite;
    GameObject collectableUI = null;

    [SerializeField] float pickUpRadius = 3.0f;
    private Canvas pickupButtonGuide = null;
    private bool hiddenPickupButton = false;

    // Audio
    private AudioSource collectNoise = null;

    private void Awake()
    {
        #region Audio

        // Get the audio transform
        Transform audioTransform = transform.Find("Audio");
        if (audioTransform == null)
        {
            Debug.Log("Missing Audio child on object: " + audioTransform.gameObject);
        }
        else
        {
            // Get the collect noise
            collectNoise = audioTransform.Find("CollectNoise").GetComponent<AudioSource>();
            if (collectNoise == null)
            {
                Debug.Log("Missing child CollectNoise on object: " + audioTransform.gameObject);
            }
        }

		#endregion
	}

	private void Start()
    {
        // Get the sprites for the collectables
        if (collectableType != CollectableTypes.DASH)
        {
            fishSprite = StaticValueHolder.CollectableUIUpdateObject.fishSprite;
            butterflySprite = StaticValueHolder.CollectableUIUpdateObject.butterflySprite;
            stickSprite = StaticValueHolder.CollectableUIUpdateObject.stickSprite;
            pickupButtonGuide = StaticValueHolder.CollectableUIUpdateObject.pickupButtonGuide;
            collectableUI = StaticValueHolder.CollectableUIUpdateObject.gameObject;
        }
        hiddenPickupButton = false;
    }

    private void Update()
    {
        //check if player is close enough to pick up
        if (Vector3.Distance(transform.position, StaticValueHolder.PlayerMovementScript.transform.position) < pickUpRadius && collectableType != CollectableTypes.DASH)
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
                StaticValueHolder.PlayerMovementScript.interact = false;
                switch (collectableType)
                {
                    //add one to collected UI and show icon above player to indicate collection, gets the icon from the Collectable UI script
                    case CollectableTypes.FISH:
                        {
                            StaticValueHolder.Collectable0 += 1;
                            GameObject newIcon = Instantiate(collectableUI.GetComponent<CollectableUIUpdate>().PickupIcon, StaticValueHolder.PlayerObject.transform.position + new Vector3(0, 5, 0), Quaternion.identity);
                            newIcon.transform.GetChild(0).GetComponent<Image>().sprite = fishSprite;
                            collectNoise.Play();
                            break;
                        }
                    case CollectableTypes.BUTTERFLY:
                        {
                            StaticValueHolder.Collectable1 += 1;
                            GameObject newIcon = Instantiate(collectableUI.GetComponent<CollectableUIUpdate>().PickupIcon, StaticValueHolder.PlayerObject.transform.position + new Vector3(0, 5, 0), Quaternion.identity);
                            newIcon.transform.GetChild(0).GetComponent<Image>().sprite = butterflySprite;
                            collectNoise.Play();
                            break;
                        }
                    case CollectableTypes.STICK:
                        {
                            StaticValueHolder.Collectable2 += 1;
                            GameObject newIcon = Instantiate(collectableUI.GetComponent<CollectableUIUpdate>().PickupIcon, StaticValueHolder.PlayerObject.transform.position + new Vector3(0, 5, 0), Quaternion.identity);
                            newIcon.transform.GetChild(0).GetComponent<Image>().sprite = stickSprite;
                            collectNoise.Play();
                            break;
                        }
                    case CollectableTypes.BANANA:
                        {
                            //change banana man conversation to receive golden banana and show banana on UI
                            StaticValueHolder.DialogueManagerObject.GetComponent<ConversationManager>().ChangeToConversation(3, 2);
                            StaticValueHolder.GoldBanana = true;
                            collectNoise.Play();
                            break;
                        }
                    case CollectableTypes.DASH:
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
        if (collectableType == CollectableTypes.DASH)
        {
            if (other.CompareTag("Player") || other.CompareTag("Boat"))
            {
				StaticValueHolder.DashMeterObject.AddDashes(1);
                Collected = true;
                collectNoise.Play();
            }
        }
        
    }


    void HideButton()
    {
        //hide the interact button
        if (collectableType != CollectableTypes.DASH)
        {
            hiddenPickupButton = true;
            pickupButtonGuide.enabled = false;
            StaticValueHolder.PlayerMovementScript.inTalkDistance = false;
        }
            
    }

}
