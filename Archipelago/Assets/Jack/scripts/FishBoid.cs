using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishBoid : MonoBehaviour
{
    public float speed = 1.0f;
    float rotationSpeed = 4.0f;
    float neighbourDistance = 4.0f;
    float maxSpeed = 1.5f;
    bool turningBack = false;

    FishBoidManager manager = null;


    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(0.8f, 1.3f);
        manager = transform.parent.GetComponent<FishBoidManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //keep fish in range unless being chased by player
        if ((transform.position - manager.pos).sqrMagnitude >= manager.tankWidth * manager.tankWidth && (transform.position - StaticValueHolder.PlayerObject.transform.position).sqrMagnitude > 6 * 6)
        {
            turningBack = true;
        }
        else turningBack = false;

        if (turningBack)
        {
            Vector3 dir = manager.pos - transform.position;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), rotationSpeed * Time.deltaTime);
            speed = Random.Range(0.8f, 1.3f);
        }
        else if (Random.Range(0, 10) < 1) ApplyRules();

        if (speed > maxSpeed) speed = maxSpeed;
        if (speed < 0.8f) speed = 0.8f;
        transform.Translate(0, 0, speed * Time.deltaTime);
    }


    void ApplyRules()
    {
        GameObject[] gos;
        gos = manager.allFish;

        Vector3 vCentre = manager.goalPos;
        Vector3 vAvoid = manager.goalPos;
        float gSpeed = 0.1f;

        Vector3 goalPos = manager.goalPos;

        float dist;
        int groupSize = 0;

        foreach (GameObject go in gos)
        {
            if (go != gameObject)
            {
                dist = Vector3.Distance(go.transform.position, transform.position);
                if (dist <= neighbourDistance)
                {
                    vCentre += go.transform.position;
                    groupSize++;

                    //avoid close neighbours
                    if (groupSize > 5) vAvoid += (transform.position - go.transform.position);
                    else if (dist < 3.0f) vAvoid += (transform.position - go.transform.position);

                    FishBoid newGroup = go.GetComponent<FishBoid>();
                    gSpeed += newGroup.speed;

                }
            }
        }

        if ((transform.position - StaticValueHolder.PlayerObject.transform.position).sqrMagnitude < 6 * 6)
        {
            Vector3 awayFromPlayer = transform.position - StaticValueHolder.PlayerObject.transform.position;
            awayFromPlayer.y = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(awayFromPlayer), rotationSpeed * 2 * Time.deltaTime);
            speed = 5.0f;
            maxSpeed = 5.0f;
        }
        else if (manager.goToGoal) //bool for following goal position
        {
            maxSpeed = 1.5f;
            if ((transform.position - goalPos).sqrMagnitude > manager.tankWidth * manager.tankWidth)
            {
                goalPos = manager.pos;
            }


            if (groupSize > 0)
            {
                vCentre = vCentre / groupSize + (goalPos - transform.position);
                speed = gSpeed / groupSize;

                //Vector3 dir = (vCentre + vAvoid) - transform.position;
                Vector3 dir = goalPos - transform.position;
                if (dir != Vector3.zero)
                {
                    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), rotationSpeed * Time.deltaTime);
                }
            }
        }
    }
}
