using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationManager : MonoBehaviour
{

    public void ChangeNextConversation(int NPCTag, int conversationNumber)
    {
        FindObjectOfType<DialogueManager>().NPCs[NPCTag] += conversationNumber;
    }
    



    //FindObjectOfType<DialogueManager>().GetComponent<ConversationManager>().ChangeNextConversation(1, 2);
}
