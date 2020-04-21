using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdAI : MonoBehaviour
{
    private float speed = 25.0f;
    private float rotationSpeed = 1.0f;
    private float maxSpeed = 30.0f;

    Vector3 goalPos = Vector3.zero;
    [SerializeField] GameObject[] targets = new GameObject[1];
    int targetCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(5.0f, 8.0f);
        targetCounter = 0;
        goalPos = targets[0].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        ApplyRules();

        if (speed > maxSpeed) speed = maxSpeed;
        if (speed < 5.0f) speed = 5.0f;
        transform.Translate(0, 0, speed * Time.deltaTime);
    }


    void ApplyRules()
    {
        if ((transform.position - StaticValueHolder.PlayerObject.transform.position).sqrMagnitude < 6 * 6)
        {
            Vector3 awayFromPlayer = transform.position - StaticValueHolder.PlayerObject.transform.position;
            awayFromPlayer.y = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(awayFromPlayer), rotationSpeed * 2 * Time.deltaTime);
            speed = 10.0f;
            maxSpeed = 10.0f;
        }
        else
        {
            maxSpeed = 8.0f;
            Vector3 dir = goalPos - transform.position;
            if (dir != Vector3.zero)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), rotationSpeed * Time.deltaTime);
            }


            if ((transform.position - goalPos).sqrMagnitude < 6 * 6)
            {
                if (targetCounter + 1 >= targets.Length) targetCounter = 0;
                else targetCounter++;

                goalPos = targets[targetCounter].transform.position;
            }
        }
    }
}