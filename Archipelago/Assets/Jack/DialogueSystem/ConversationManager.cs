using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationManager : MonoBehaviour
{

    public void ChangeNextConversation(int NPCTag, int conversationNumber)
    {
        StaticValueHolder.DialogueManagerObject.NPCs[NPCTag] += conversationNumber;
    }


    public void ChangeToConversation(int NPCTag, int conversationNumber)
    {
        StaticValueHolder.DialogueManagerObject.NPCs[NPCTag] = conversationNumber;
    }

    //FindObjectOfType<DialogueManager>().GetComponent<ConversationManager>().ChangeNextConversation(1, 2);
}
