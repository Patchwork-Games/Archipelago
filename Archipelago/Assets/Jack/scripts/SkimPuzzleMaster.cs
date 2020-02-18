using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkimPuzzleMaster : MonoBehaviour
{
    [HideInInspector] public int currentSet = 0;

    //materials
    public Material gold = null;
    public Material[] glowMats = new Material[4];

    //puzzles
    [SerializeField] GameObject[] puzzles = new GameObject[2];



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
        if (puzzles[currentSet].GetComponent<SkimPuzzleController>().complete)
        {
            //move to next puzzle after completing one
            currentSet++;
            ActivateOnePuzzle();
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
