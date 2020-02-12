using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using TMPro;



/*
 ===================================    INSTRUCTIONS    ===================================


 when adding text to text box, typing a '<' will start a separate dialogue print which will
 only display text once it reaches a '>'
 This is to remove the custome TMPro functions from the in game text

Typing '/#' will also remove any text until '#/' is typed, this is to use my own custom
effects for the text
The removed text here will be put into another string and used to apply effects like shake

when checking custom commands, ensure that the first words of the command are not the same
eg: 'read and 'readstop' should be 'read' and 'stopread'
this is because the checker checks in order and so will execute the first maching string
so 'readstop' would get to the 'd' in 'read' and then execute the 'read' command


 ===================================    INSTRUCTIONS    ===================================
 */





public class DialogueManager : MonoBehaviour
{
    public AnimationCurve VertexCurve = new AnimationCurve(new Keyframe(0, 0), new Keyframe(0.25f, 2.0f), new Keyframe(0.5f, 0), new Keyframe(0.75f, 2.0f), new Keyframe(1, 0f));
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public Sprite defaultSprite;
    public Image dialogueBoxImg;
    public Image arrow;
    public Animator animator;
    public float textSpeed = 0.03f;
    public bool canQuitSentence;
    public float CurveScale = 1.0f;
    [HideInInspector] public Dialogue dialogue;

    private string sentence;
    private new string name;
    private Sprite sprite;
    private Queue<string> sentences;
    private Queue<string> names;
    private Queue<Sprite> sprites;

    private bool specialTextChecker = false;
    private bool customTextChecker = false;
    private bool skip = false;
    private bool effectShake = false;
    private bool dontAddThisFrame = false;
    private char previousLetter;
    private string tempText = "";
    private string shakeText = "";
    //private int numCharacters = 0;

    private bool doEndOnce = false;

    public int[] NPCs;

    // Start is called before the first frame update
    void Start()
    {
        names = new Queue<string>();
        sentences = new Queue<string>();
        sprites = new Queue<Sprite>();
        sprite = defaultSprite;
        arrow.enabled = false;
        sentence = "";
        canQuitSentence = true;
        specialTextChecker = false;
        animator.SetBool("IsOpen", false);
        doEndOnce = false;
    }

    //initial beginning of dialogue, called by the trigger script
    public void StartDialogue(Dialogue dialogueIn)
    {
        dialogue = dialogueIn;
        //open textbox and change name displayed and stop player moving around or moving camera
        animator.SetBool("IsOpen", true);
        PlayerStateMachine.Instance.state = PlayerStateMachine.PlayerState.TALKING;

        //load in text for queues
        names.Clear();
        sentences.Clear();
        doEndOnce = false;
        foreach (Dialogue.ChatBoxes chatbox in dialogue.chatBoxes)
        {
            names.Enqueue(chatbox.name);            //queue names
            sentences.Enqueue(chatbox.sentences);   //queue sentences
        }

        DisplayNextSentence(dialogue);
    }





    //starts writing the next sentence in the queue
    public void DisplayNextSentence(Dialogue dialogue)
    {
        if (sentences.Count == 0 && !doEndOnce)
        {
            EndDialogue();
            doEndOnce = true;
            return;
        }

        StopAllCoroutines();
        arrow.enabled = false;

        //set name
        name = names.Dequeue();
        nameText.text = name;


        //get specific settings for each character
        for (int i = 0; i < dialogue.charactersTalking.Length; i++)
        {
            if (name == dialogue.charactersTalking[i].name)
            {
                //change the background of the box
                Sprite tempSprite;
                tempSprite = dialogue.charactersTalking[i].dialogueBoxImg;
                if (tempSprite != null) dialogueBoxImg.sprite = tempSprite;



                //move box above talking npc
                dialogueBoxImg.transform.position = dialogue.charactersTalking[i].NPCLocation.position + new Vector3(0,7,0);
                             
            }
        }
        //get sentences
        sentence = sentences.Dequeue();

        //type out new sentence letter by letter
        StartCoroutine(TypeSentence(sentence));
    }


    private void LateUpdate()
    {
        dialogueBoxImg.transform.rotation = Camera.main.transform.rotation;
    }

    //if player presses interact button before whole sentence is displayed
    //whole sentence will be written out in one frame
    //this is to keep checking for special characters
    public void CompleteCurrentTextBox()
    {
        skip = true;
    }


    //while sentence is being displayed
    //will display text one character at a time
    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        previousLetter = ' ';

        foreach (char letter in sentence.ToCharArray())
        {
            //stop special effects from showing up, the ones built into tmpro
            if (letter == '<')
            {
                specialTextChecker = true;
            }
            //end special character checking
            if (letter == '>')
            {
                specialTextChecker = false;
            }


            //stop custom effects from showing up, my own ones like shake
            if (previousLetter == '/' && letter == '#')
            {
                dialogueText.text = dialogueText.text.Substring(0, dialogueText.text.Length - 1); //remove '/' from sentence
                //Debug.Log("Text: " + dialogueText.text);
                tempText = "";
                customTextChecker = true;
                dontAddThisFrame = true; //dont add '#' to sentence
            }
            //end custom effect checking
            if (previousLetter == '#' && letter == '/')
            {
                if (tempText.Length > 1) tempText = tempText.Substring(0, tempText.Length - 1); //remove '#'
                //Debug.Log("TempText: " + tempText);
                customTextChecker = false;
                dontAddThisFrame = true; //dont add '/' to sentence

            }




            //take out custom effect command and do it before drawing text
            if (customTextChecker)
            {
                //only take command string
                if (!dontAddThisFrame) tempText += letter;


                //check custom text commands

                if (tempText == "shake")
                {
                    effectShake = true;
                    //numCharacters = 0;
                    dontAddThisFrame = true;
                    tempText = "";

                }
                if (tempText == "stopShake")
                {
                    effectShake = false;
                    dontAddThisFrame = true;
                    tempText = "";
                }
            }
            else if (!dontAddThisFrame)//dont add custom command indicator to visible text
            {
                //add TMPro commands included in text without waiting so they are instantly applied
                if (specialTextChecker)
                {
                    dialogueText.text += letter;
                }
                else //display text as normal, typing out line by line unless skipped
                {
                    dialogueText.text += letter;
                    if (!skip) yield return new WaitForSeconds(textSpeed);
                }
            }


            //Debug.Log("TempText: " + tempText);

            //do custom effects

            if (effectShake)
            {
                if (!dontAddThisFrame)
                {
                    shakeText += letter;
                    Debug.Log("shakeText: " + shakeText);
                }
            }

            //hold previous letter to check for custom effects
            previousLetter = letter;
            dontAddThisFrame = false;
        }
        arrow.enabled = true;
        skip = false;
    }



    //called once all dialogue in queue has been used
    void EndDialogue()
    {
        //closing animation
        animator.SetBool("IsOpen", false);
        PlayerStateMachine.Instance.state = PlayerStateMachine.PlayerState.MOVING;
		PlayerMovement.Instance.interact = false;
		PlayerMovement.Instance.CMCamera.SetActive(true);
		PlayerMovement.Instance.CMCamera.transform.position = PlayerMovement.Instance.beginTalkCamPos;

    }



    private void Update()
    {
        //progress dialogue with interact button
                                                                                                                 
        if (Input.GetMouseButtonDown(0) || PlayerMovement.Instance.interact)
        {
            if (arrow.enabled == true)
            {
                DisplayNextSentence(dialogue);
            }
            else CompleteCurrentTextBox(); 
        }

        if (canQuitSentence) //editor setting, allows player to quit sentence at any time
        {
            //quit sentence by pressing back
            if (Input.GetKeyDown(KeyCode.Q) || (PlayerMovement.Instance.GetComponent<SkimmingController>().heldThrow && PlayerStateMachine.Instance.state == PlayerStateMachine.PlayerState.TALKING))
            {
                EndDialogue();
            }
        }
    }

    IEnumerator AnimateVertexPositions()
    {
        //VertexCurve.preWrapMode = WrapMode.Loop;
        //VertexCurve.postWrapMode = WrapMode.Loop;

        //Vector3[] newVertexPositions;
        ////Matrix4x4 matrix;

        //int loopCount = 0;

        //while (true)
        //{
        //    dialogueText.renderMode = TextRenderFlags.DontRender; // Instructing TextMesh Pro not to upload the mesh as we will be modifying it.
        //    dialogueText.ForceMeshUpdate(); // Generate the mesh and populate the textInfo with data we can use and manipulate.

        //    TMP_TextInfo textInfo = dialogueText.textInfo;
        //    int characterCount = textInfo.characterCount;


        //    newVertexPositions = textInfo.meshInfo.vertices;

        //    for (int i = 0; i < characterCount; i++)
        //    {
        //        if (!textInfo.characterInfo[i].isVisible)
        //            continue;

        //        int vertexIndex = textInfo.characterInfo[i].vertexIndex;

        //        float offsetY = VertexCurve.Evaluate((float)i / characterCount + loopCount / 50f) * CurveScale; // Random.Range(-0.25f, 0.25f);                    

        //        newVertexPositions[vertexIndex + 0].y += offsetY;
        //        newVertexPositions[vertexIndex + 1].y += offsetY;
        //        newVertexPositions[vertexIndex + 2].y += offsetY;
        //        newVertexPositions[vertexIndex + 3].y += offsetY;

        //    }

        //    loopCount += 1;

        //    // Upload the mesh with the revised information
        //    dialogueText.mesh.vertices = newVertexPositions;
        //    dialogueText.mesh.uv = dialogueText.textInfo.meshInfo.uv0s;
        //    dialogueText.mesh.uv2 = dialogueText.textInfo.meshInfo.uv2s;
        //    dialogueText.mesh.colors32 = dialogueText.textInfo.meshInfo.vertexColors;

        //    yield return new WaitForSeconds(0.025f);
        //}
        yield return new WaitForSeconds(0.0f);
    }




}
