using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishAI : MonoBehaviour
{
    [SerializeField] int fishID = 1;
    float timer = 0.0f;
    float timerMax = 3.0f;
    Rigidbody rb = null;
    Vector3 angle = Vector3.zero;
    float distToPlayer = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        timerMax = fishID;
    }


    // Update is called once per frame
    void Update()
    {
        distToPlayer = Vector3.Distance(transform.position, StaticValueHolder.PlayerObject.transform.position);


        if (distToPlayer < 5)
        {
            Vector3 awayFromPlayer = transform.position - StaticValueHolder.PlayerObject.transform.position;
            awayFromPlayer.y = 0;
            angle = new Vector3(0, Random.Range(0, 359), 0);
            transform.forward = awayFromPlayer;
            angle = transform.eulerAngles;
            rb.velocity = Vector3.zero;
            rb.AddForce(transform.forward * 10000 * Time.deltaTime);
            timer = 2.9f;
        }
        else
        {
            //random forward every few seconds
            if (timer > timerMax)
            {
                timer = 0.0f;
                timerMax = Random.Range(4,12) / 2; //between 4,12 /2 so that there are floats
                angle = new Vector3(0, Random.Range(0, 359), 0);
                transform.eulerAngles = angle;
                rb.velocity = Vector3.zero;
                rb.AddForce(transform.forward * 10000 * Time.deltaTime);
            }
            else
            {
                timer += Time.deltaTime;
                transform.eulerAngles = angle;
            }



        }
    }

}
