using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterflyBoidManager : MonoBehaviour
{
    [SerializeField] private GameObject goalObj = null;
    [SerializeField] private GameObject butteflyPrefab;
    public static int tankWidth = 12;
    public static int tankHeight = 6;
    static int numButterflies = 30;
    public static GameObject[] allButterflies = new GameObject[numButterflies];
    public static Vector3 pos = Vector3.zero;


    public static Vector3 goalPos = Vector3.zero;

    private void Awake()
    {
        pos = transform.position;
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numButterflies; i++)
        {
            Vector3 pos = new Vector3(Random.Range(0, tankWidth), Random.Range(0, tankHeight), Random.Range(0, tankWidth)) + transform.position;
            allButterflies[i] = Instantiate(butteflyPrefab, pos, Quaternion.identity);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Random.Range(0, 100000) < 50)
        {
            goalPos = new Vector3(Random.Range(0, tankWidth), Random.Range(0, tankHeight), Random.Range(0, tankWidth)) + transform.position;
            goalObj.transform.position = goalPos;

            Debug.Log("GoalPos: " + goalPos);
        }



    }
}
