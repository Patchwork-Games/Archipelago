using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkimPuzzleMaster : MonoBehaviour
{
    [HideInInspector] public int currentSet = 0;
    [SerializeField] private GameObject energyPickup = null;

    //materials
    public Material gold = null;
    public Material[] glowMats = new Material[4];

    //puzzles
    [SerializeField] GameObject[] puzzles = new GameObject[2];
    private bool rewarded = false;

    // Audio
    private AudioSource rockRumbleNoise = null;

    private void Awake()
    {
        // Get the audio transform
        Transform audioTransform = transform.Find("Audio");
        if (audioTransform == null)
        {
            Debug.Log("Missing Audio child on object :" + gameObject);
        }
        else
        {
            // Get the rock rumble noise
            rockRumbleNoise = audioTransform.Find("RockRumbleNoise").GetComponent<AudioSource>();
            if (rockRumbleNoise == null)
            {
                Debug.Log("Missing RockRumbleNoise child on object: " + audioTransform.gameObject + gameObject);
            }
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < puzzles.Length; i++)
        {
            puzzles[i].GetComponent<SkimPuzzleController>().ID = i;
        }
        currentSet = 0;
        ActivateOnePuzzle();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentSet < puzzles.Length) // stops going out of bounds on array
        {
            if (puzzles[currentSet].GetComponent<SkimPuzzleController>().complete)
            {
                //move to next puzzle after completing one
                currentSet++;
                if (currentSet < puzzles.Length) puzzles[currentSet].GetComponent<RaiseSkimRocks>().targetHeight = 1; //raise new puzzle
                if (currentSet < puzzles.Length) ActivateOnePuzzle();    // stops going out of bounds on array

                // Play the rock rumble noise
                rockRumbleNoise.Play();
            }
        }
        else if (!rewarded)
        {
            //give player reward
            GameObject reward = Instantiate(energyPickup, new Vector3(transform.position.x, transform.position.y + 2, transform.position.z), Quaternion.identity);
            reward.transform.position = transform.position;
            rewarded = true;
        }
    }


    void ActivateOnePuzzle()
    {
        //disable all puzzles then enable the current one
        for (int i = 0; i < puzzles.Length; i++)
        {
            puzzles[i].GetComponent<SkimPuzzleController>().puzzleActive = false;
        }
        puzzles[currentSet].GetComponent<SkimPuzzleController>().puzzleActive = true;
    }
}
