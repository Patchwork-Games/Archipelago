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
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public Sprite defaultSprite;
    public Image dialogueBoxImg;
    public Image arrow;
    public Animator animator;
    [Tooltip("delay on text print, smaller = faster")]
    public float textSpeed = 0.03f;
    public bool canQuitSentence;
    public int thisNPC = 0; 
    [SerializeField] private float textHeight = 3.0f;
    [HideInInspector] public Dialogue dialogue;

    private string sentence;
    private new string name;
    private Sprite sprite;
    private Queue<string> sentences;
    private Queue<string> names;
    private Queue<Sprite> sprites;
    private Animator anim = null;

    private bool specialTextChecker = false;
    private bool customTextChecker = false;
    private bool skip = false;
    private bool effectShake = false;
    private bool dontAddThisFrame = false;
    private char previousLetter;
    private string tempText = "";
    private string shakeText = "";

    private bool doEndOnce = false;

    //story packages
    [SerializeField] private GameObject packageBox = null;
    [SerializeField] private GameObject packageBox2 = null;
    [SerializeField] Image fadeScreen = null;


    public int[] NPCs;

    // Audio
    [Range(0,1)][SerializeField] private float randomTalkingPitch = 0f;
    private AudioSource talkingNoise = null;
    private AudioSource nextSentanceNoise = null;

    private BoatMastController mastController = null;

    private void Awake()
    {
        #region Audio

        // Get the audio object transform
        Transform audioTransform = transform.Find("Audio");
        if (audioTransform == null)
        {
            Debug.Log("Missing Audio child on object: " + gameObject);
        }
        else
        {
            // Get the talking noise
            talkingNoise = audioTransform.Find("TalkingNoise").GetComponent<AudioSource>();
            if (talkingNoise == null)
            {
                Debug.Log("Missing TalkingNoise child on object: " + audioTransform.gameObject + gameObject);
            }

            // Get the next sentance noise
            nextSentanceNoise = audioTransform.Find("NextSentanceNoise").GetComponent<AudioSource>();
            if (nextSentanceNoise == null)
            {
                Debug.Log("Missing NextSentanceNoise child on object: " + audioTransform.gameObject + gameObject);
            }
        }

        #endregion

    }

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

        // Get the mast controller
        mastController = StaticValueHolder.BoatObject.GetComponent<BoatController>().MastController;
        if (mastController == null)
        {
            Debug.Log("Missing BoatMastController component in script: " + StaticValueHolder.BoatObject.GetComponent<BoatController>());
        }
    }

    //initial beginning of dialogue, called by the trigger script
    public void StartDialogue(Dialogue dialogueIn, int currentNPC, Animator NPCanim)
    {
        dialogue = dialogueIn;
        thisNPC = currentNPC;
        anim = NPCanim;
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

        StaticValueHolder.PlayerMovementScript.interact = false;
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

        if (names.Count > 0) name = names.Dequeue();

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
                dialogueBoxImg.transform.position = dialogue.charactersTalking[i].NPCLocation.position + new Vector3(0, textHeight, 0);
                             
            }
        }
        //get sentences
        if(sentences.Count > 0) sentence = sentences.Dequeue();

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
            // Only play a sound if the letter is a character from the alphabet or a number
            if ((letter >= 97 && letter <= 122) || (letter >= 65 && letter <= 90) || (letter >= 48 && letter <= 57))
            {
                talkingNoise.pitch = 1 + Random.Range(-randomTalkingPitch / 2f, randomTalkingPitch / 2f);
                talkingNoise.Play();
            }

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

                if (tempText == "nextConvo")
                {
                    GetComponent<ConversationManager>().ChangeNextConversation(thisNPC, 1);
                    dontAddThisFrame = true;
                    tempText = "";

                }


                if (tempText == "enableBoat")
                {
                    GameManager.SailingEnabled = true;
                    StaticValueHolder.BugCatcher.gameObject.SetActive(false);
                    StaticValueHolder.BugCatcherNote.gameObject.SetActive(false);
                    dontAddThisFrame = true;
                    tempText = "";
                }




                if (tempText == "enablePackage")
                {
                    if (StaticValueHolder.Collectable0 >= 5)
                    {
                        StaticValueHolder.BugCatcher.gameObject.SetActive(true);
                        StaticValueHolder.BugCatcherNote.gameObject.SetActive(true);
                        packageBox.SetActive(true);
                        StaticValueHolder.Collectable0 -= 5;
                    }
                    dontAddThisFrame = true;
                    tempText = "";
                }

                

                if (tempText == "deliverPackage")
                {
                    packageBox.SetActive(false);
                    packageBox2.SetActive(true);
                    GetComponent<ConversationManager>().ChangeToConversation(1, 5);
                    dontAddThisFrame = true;
                    tempText = "";

                    // Trigger event
                    GameManager.GotFishPatch = true;
                    mastController.UpdateSailMaterial();
                }


                if (tempText == "removeButterfly")
                {
                    if (StaticValueHolder.Collectable1 >= 5) StaticValueHolder.Collectable1 -= 5;
                    dontAddThisFrame = true;
                    tempText = "";

                    // Trigger event
                    GameManager.GotButterflyPatch = true;
                    mastController.UpdateSailMaterial();
                }

                if (tempText == "removeGoldBanana")
                {
                    if (StaticValueHolder.GoldBanana) StaticValueHolder.GoldBanana = false;
                    dontAddThisFrame = true;
                    tempText = "";

                    // Trigger event
                    GameManager.GotBananaPatch = true;
                    mastController.UpdateSailMaterial();
                }



                if (tempText == "fadeOut")
                {
                    //fade out scene at end
                    StartCoroutine(FadeOut());

                    dontAddThisFrame = true;
                    tempText = "";
                }


                
                //if (tempText == "laugh")
                //{
                //    if (anim) anim.SetTrigger("Laugh");
                //    dontAddThisFrame = true;
                //    tempText = "";
                //}

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
        StaticValueHolder.PlayerMovementScript.jump = false;
        StaticValueHolder.PlayerMovementScript.interact = false;
		StaticValueHolder.PlayerCharacterCamera.gameObject.SetActive(true);
		StaticValueHolder.PlayerCharacterCamera.gameObject.transform.position = StaticValueHolder.PlayerMovementScript.beginTalkCamPos;

    }



    private void Update()
    {
        //progress dialogue with interact button
                                                                                                                 
        if (Input.GetMouseButtonDown(0) || StaticValueHolder.PlayerMovementScript.interact && PlayerStateMachine.Instance.state == PlayerStateMachine.PlayerState.TALKING)
        {
            StaticValueHolder.PlayerMovementScript.interact = false;
            if (arrow.enabled == true)
            {
                DisplayNextSentence(dialogue);
            }
            else CompleteCurrentTextBox(); 
        }

        if (canQuitSentence) //editor setting, allows player to quit sentence at any time
        {
            //quit sentence by pressing back
            if ((Input.GetKeyDown(KeyCode.Q) || StaticValueHolder.PlayerMovementScript.GetComponent<SkimmingController>().heldThrow) && PlayerStateMachine.Instance.state == PlayerStateMachine.PlayerState.TALKING)
            {
                StaticValueHolder.PlayerMovementScript.GetComponent<SkimmingController>().heldThrow = false;
                EndDialogue();
            }
        }
    }

    //fade out scene at end
    IEnumerator FadeOut()
    {
        //get the first colour of the image and then decrease its alpha by 0.1 every .1 seconds
        var tempColor = fadeScreen.GetComponent<Image>().color;
        while (tempColor.a > 0)
        {
            tempColor.a += Time.deltaTime;
            fadeScreen.GetComponent<Image>().color = tempColor;
            yield return null;
        }
    }


}
