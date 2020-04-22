using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class FishingController : MonoBehaviour
{
    private Animator anim = null;
    GameObject collectableUI = null;
    [HideInInspector] public bool heldB = false;
    [HideInInspector] public GameObject net = null;
    [HideInInspector] public bool canSeeNet = false;

    private bool caughtFish = false;
    private bool caughtButterfly = false;

    // Start is called before the first frame update
    void Start()
    {
        collectableUI = GameObject.FindGameObjectWithTag("CollectableUI");
        anim = GetComponent<Animator>();
        net = GameObject.FindGameObjectWithTag("Net");
    }

    // Update is called once per frame
    void Update()
    {
        //check if player can swing net and is trying to
        if (heldB && PlayerStateMachine.Instance.state == PlayerStateMachine.PlayerState.MOVING && transform.position.y > StaticValueHolder.PlayerMovementScript.waterHeight)
        {
            heldB = false;
            PlayerStateMachine.Instance.state = PlayerStateMachine.PlayerState.CASTING;
            anim.SetTrigger("SwingNet");
            net.GetComponent<SphereCollider>().enabled = true;
        }


        //enable/disable net, set in player movement
        if (canSeeNet && transform.position.y > StaticValueHolder.PlayerMovementScript.waterHeight)
        {
            net.SetActive(true);
        }
        else
        {
            net.SetActive(false);
        }


        //Story triggers ================================================================================================================================================

        //story section 1, catch 5 fish
        if (StaticValueHolder.Collectable0 >= 5 && !caughtFish)
        {
            caughtFish = true;
            StaticValueHolder.DialogueManagerObject.GetComponent<ConversationManager>().ChangeToConversation(1, 2);

        }

        //story section 2, catch 5 butterflies
        if (StaticValueHolder.Collectable1 >= 5 && !caughtButterfly)
        {
            caughtButterfly = true;
            StaticValueHolder.DialogueManagerObject.GetComponent<ConversationManager>().ChangeToConversation(2, 2);
        }

        //Story triggers end ============================================================================================================================================

    }


    //pop up when caught fish, called in FishCatch script attached to net under player arm
    public void CaughtFish()
    {
        StaticValueHolder.Collectable0 += 1;
        GameObject newIcon = Instantiate(collectableUI.GetComponent<CollectableUIUpdate>().PickupIcon, StaticValueHolder.PlayerObject.transform.position + new Vector3(0, 5, 0), Quaternion.identity);
        newIcon.transform.GetChild(0).GetComponent<Image>().sprite = collectableUI.GetComponent<CollectableUIUpdate>().fishSprite;
    }

    public void CaughtButterfly()
    {
        StaticValueHolder.Collectable1 += 1;
        GameObject newIcon = Instantiate(collectableUI.GetComponent<CollectableUIUpdate>().PickupIcon, StaticValueHolder.PlayerObject.transform.position + new Vector3(0, 5, 0), Quaternion.identity);
        newIcon.transform.GetChild(0).GetComponent<Image>().sprite = collectableUI.GetComponent<CollectableUIUpdate>().butterflySprite;
    }





}
