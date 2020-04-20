using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishBoidManager : MonoBehaviour
{
    [SerializeField] private GameObject goalObj = null;
    [SerializeField] private GameObject fishPrefab = null;
    public int tankWidth = 10;
    public int tankHeight = 2;
    static int numFish = 30;
    public GameObject[] allFish = new GameObject[numFish];
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
        for (int i = 0; i < numFish; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-tankWidth, tankWidth), Random.Range(0, tankHeight), Random.Range(-tankWidth, tankWidth)) + transform.position;
            allFish[i] = Instantiate(fishPrefab, pos, Quaternion.identity, transform);
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
