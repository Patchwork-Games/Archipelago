using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class DialogueTrigger : MonoBehaviour
{
    [HideInInspector]public Animator anim = null;
    [SerializeField] private int myTag = 0;
    [SerializeField] private bool living = true;
    public Dialogue[] dialogue;
    public Canvas talkButtonGuide;

    //settings
    public int talkRadius = 5;
    public bool displayOnStart = false;
    private bool startedTalking = false;
    private bool hiddenTalkButton = false;
    private float lookWeight = 0.0f;


    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue[FindObjectOfType<DialogueManager>().NPCs[myTag]], myTag);
        if (anim) anim.SetTrigger("Talk"); //if npc has animator, trigger talking animation
        if (living) StartCoroutine(TurnToPlayer());
        
        StaticValueHolder.PlayerMovementScript.interact = false;
    }

    IEnumerator TurnToPlayer()
    {
        var t = 0.0f;
        while (t < 1)
        {
            var r = new Vector3(StaticValueHolder.PlayerObject.transform.position.x, transform.position.y, StaticValueHolder.PlayerObject.transform.position.z);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(r - transform.position), t);
            t += Time.deltaTime;
            yield return null;
        }
        
    }


    private void Start()
    {
        //init
        talkButtonGuide.enabled = false;
        if (living) anim = GetComponent<Animator>();
            
    }


    private void Update()
    {
        //stop normal interactions if wanting to play automatically
        if (!displayOnStart)
        {
            //check if player is close enough to talk
            if (Vector3.Distance(transform.position, StaticValueHolder.PlayerObject.transform.position) < talkRadius)
            {
                //show button needed to talk
                if (talkButtonGuide && !startedTalking)
                {
                    talkButtonGuide.transform.position = transform.position + new Vector3(0, 5, 0);
                    talkButtonGuide.enabled = true;
                    StaticValueHolder.PlayerMovementScript.inTalkDistance = true;
                    hiddenTalkButton = false;
                }
                else if (talkButtonGuide && !hiddenTalkButton) //hide talk button without disabling it for every npc
                {
                    talkButtonGuide.enabled = false;
                    hiddenTalkButton = true;
					StaticValueHolder.PlayerMovementScript.inTalkDistance = false;
                }
                if (StaticValueHolder.PlayerMovementScript.interact && !startedTalking)
                {
                    startedTalking = true;
                    TriggerDialogue();
                }
            }
            else if (!hiddenTalkButton) //if this is in the normal else then the talk button is always disabled for any npc other than the first
            {
                hiddenTalkButton = true;
                talkButtonGuide.enabled = false;
				StaticValueHolder.PlayerMovementScript.inTalkDistance = false;
            }
            else
            {
                startedTalking = false;
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




    private void OnAnimatorIK(int layerIndex)
    {
        if (living)
        {
            var heading = StaticValueHolder.PlayerObject.transform.position - transform.position;
            var dot = Vector3.Dot(heading, transform.forward);
            //look towards target
            anim.SetLookAtPosition(new Vector3(StaticValueHolder.PlayerObject.transform.position.x, StaticValueHolder.PlayerObject.transform.position.y, StaticValueHolder.PlayerObject.transform.position.z));

            //only look if infront
            if (dot > 1 && (transform.position - StaticValueHolder.PlayerObject.transform.position).sqrMagnitude < 100)
            {
                if (lookWeight < 1) lookWeight += Time.deltaTime * 2;
            }
            else if(lookWeight > 0) lookWeight -= Time.deltaTime * 2;

            anim.SetLookAtWeight(lookWeight);

        }
        
    }
}

