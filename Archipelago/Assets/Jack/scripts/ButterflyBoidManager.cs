using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterflyBoidManager : MonoBehaviour
{
    [SerializeField] private GameObject goalObj = null;
    [SerializeField] private GameObject butteflyPrefab = null;
    public int tankWidth = 10;
    public int tankHeight = 6;
    static int numButterflies = 30;
    public GameObject[] allButterflies = new GameObject[numButterflies];
    public Vector3 pos = Vector3.zero;
    public Vector3 goalPos = Vector3.zero;
    public bool goToGoal = false;

    private void Awake()
    {
        pos = transform.position;
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numButterflies; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-tankWidth, tankWidth), Random.Range(0, tankHeight), Random.Range(-tankWidth, tankWidth)) + transform.position;
            allButterflies[i] = Instantiate(butteflyPrefab, pos, Quaternion.identity, transform);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Random.Range(0, 10000) < 50)
        {
            goalPos = new Vector3(Random.Range(0, tankWidth), Random.Range(0, tankHeight), Random.Range(0, tankWidth)) + transform.position;
            goalObj.transform.position = goalPos;
        }
        //goalPos = goalObj.transform.position;



    }
}
