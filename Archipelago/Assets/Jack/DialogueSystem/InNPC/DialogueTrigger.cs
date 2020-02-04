using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private int myTag = 0;
    public Dialogue[] dialogue;
    public GameObject player;
    public Canvas talkButtonGuide;
    public CinemachineVirtualCamera talkCam;
    private Vector3 talkCamPos;

    //settings
    public int talkRadius = 5;
    public bool displayOnStart = false;
    private bool startedTalking = false;
    private bool hiddenTalkButton = false;


    public void TriggerDialogue()
    {
        talkCam.transform.position = talkCamPos;
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue[FindObjectOfType<DialogueManager>().NPCs[myTag]]);
        PlayerMovement.Instance.ChangeCamera(talkCam, true);
    }


    private void Start()
    {
        //init
        talkButtonGuide.enabled = false;
        talkCamPos = transform.GetChild(0).transform.position;
    }


    private void Update()
    {
        //stop normal interactions if wanting to play automatically
        if (!displayOnStart)
        {
            //make sure there is a player
            if (player)
            {
                //check if player is close enough to talk
                if (Vector3.Distance(transform.position, player.transform.position) < talkRadius)
                {
                    //show button needed to talk
                    if (talkButtonGuide && !startedTalking)
                    {
                        talkButtonGuide.transform.position = transform.position + new Vector3(0, 7, 0);
                        talkButtonGuide.enabled = true;
                        player.GetComponent<PlayerMovement>().inTalkDistance = true;
                        hiddenTalkButton = false;
                    }
                    else if (talkButtonGuide && !hiddenTalkButton) //hide talk button without disabling it for every npc
                    {
                        talkButtonGuide.enabled = false;
                        hiddenTalkButton = true;
                        player.GetComponent<PlayerMovement>().inTalkDistance = false;
                    }

                    //FINDME replace with new input system to handle controllers
                    if ((Input.GetKeyDown(KeyCode.E) || player.GetComponent<PlayerMovement>().interact) && !startedTalking)
                    {
                        startedTalking = true;
                        TriggerDialogue();
                    }
                }
                else if (!hiddenTalkButton) //if this is in the normal else then the talk button is always disabled for any npc other than the first
                {
                    hiddenTalkButton = true;
                    talkButtonGuide.enabled = false;
                    player.GetComponent<PlayerMovement>().inTalkDistance = false;
                }
                else
                {
                    startedTalking = false;
                }
            }
            else //if no player attached
            {
                Debug.Log("No player attached to dialogue trigger");
            }
        } 
        else if (displayOnStart && !startedTalking) //show text automatically --- cant be in start because manager wont have run its start yet
        {
            startedTalking = true;
            TriggerDialogue();
        }
    }

    //move button guide to face camrea
    private void LateUpdate()
    {
        if(talkButtonGuide) talkButtonGuide.transform.rotation = Camera.main.transform.rotation;
    }

    //draw radius around npc that player has to be in to talk
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, talkRadius);
    }
}

