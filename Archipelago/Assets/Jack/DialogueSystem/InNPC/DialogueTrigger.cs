using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public GameObject player;
    public Canvas talkButtonGuide;

    //settings
    public int talkRadius = 5;
    public bool displayOnStart = false;


    private bool startedTalking = false;



    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }


    private void Start()
    {
        //init
        talkButtonGuide.enabled = false;
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
                        talkButtonGuide.transform.position = transform.position + new Vector3(0, 2, 0);
                        talkButtonGuide.enabled = true;
                    }
                    else if (talkButtonGuide) talkButtonGuide.enabled = false;

                    //FINDME replace with new input system to handle controllers
                    if (Input.GetKeyDown(KeyCode.E) && !startedTalking)
                    {

                        startedTalking = true;
                        TriggerDialogue();
                    }
                }
                else
                {
                    talkButtonGuide.enabled = false;
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

    //move button guide to above npc
    private void LateUpdate()
    {
        if(talkButtonGuide) talkButtonGuide.transform.rotation = Camera.main.transform.rotation;
    }

    //draw radius around npc that player has to be in to talk
    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, talkRadius);
    }
}

