using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Dialogue
{
    [System.Serializable]
    public struct ChatBoxes
    {
        public string name;

        [TextArea(3, 10)]
        public string sentences;
        
    }


    [System.Serializable]
    public struct CharactersTalking
    {
        public string name;
        public Sprite dialogueBoxImg;
        public Transform NPCLocation;
       
    }

    public string name;
    public CharactersTalking[] charactersTalking;
    public ChatBoxes[] chatBoxes;

}
