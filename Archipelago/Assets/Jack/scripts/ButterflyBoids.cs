using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterflyBoids : MonoBehaviour
{
    public float speed = 1.0f;
    float rotationSpeed = 4.0f;
    float neighbourDistance = 3.0f;

    bool turningBack = false;

    


    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(0.8f, 1.3f);
    }

    // Update is called once per frame
    void Update()
    {
        if ((transform.position - ButterflyBoidManager.pos).sqrMagnitude >= ButterflyBoidManager.tankWidth * ButterflyBoidManager.tankWidth) turningBack = true;
        else turningBack = false;

        if (turningBack)
        {
            Vector3 dir = ButterflyBoidManager.pos - transform.position;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), rotationSpeed * Time.deltaTime);
            speed = Random.Range(0.8f, 1.3f);
        }
        else if (Random.Range(0, 5) < 1) ApplyRules();


        transform.Translate(0, 0, speed * Time.deltaTime);
    }


    void ApplyRules()
    {
        GameObject[] gos;
        gos = ButterflyBoidManager.allButterflies;

        Vector3 vCentre = ButterflyBoidManager.goalPos;
        Vector3 vAvoid = ButterflyBoidManager.goalPos;
        float gSpeed = 0.1f;

        Vector3 goalPos = ButterflyBoidManager.goalPos;

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

                    if (dist < 1.0f) vAvoid += (transform.position - go.transform.position);

                    ButterflyBoids newGroup = go.GetComponent<ButterflyBoids>();
                    gSpeed += newGroup.speed;

                }
            }
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
                Debug.Log("Target dir: " + dir);
            }

            Debug.DrawRay(transform.position, dir, Color.yellow);

        }


    }







}
