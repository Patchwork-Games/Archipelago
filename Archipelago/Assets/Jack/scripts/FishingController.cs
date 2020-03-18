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
        if (heldB && PlayerStateMachine.Instance.state == PlayerStateMachine.PlayerState.MOVING)
        {
            heldB = false;
            PlayerStateMachine.Instance.state = PlayerStateMachine.PlayerState.CASTING;
            anim.SetTrigger("SwingNet");
            net.GetComponent<SphereCollider>().enabled = true;
        }


        //enable/disable net, set in player movement
        if (canSeeNet)
        {
            net.SetActive(true);
        }
        else
        {
            net.SetActive(false);
        }

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
        StaticValueHolder.Collectable0 += 1;
        GameObject newIcon = Instantiate(collectableUI.GetComponent<CollectableUIUpdate>().PickupIcon, StaticValueHolder.PlayerObject.transform.position + new Vector3(0, 5, 0), Quaternion.identity);
        newIcon.transform.GetChild(0).GetComponent<Image>().sprite = collectableUI.GetComponent<CollectableUIUpdate>().fishSprite;
    }


}
