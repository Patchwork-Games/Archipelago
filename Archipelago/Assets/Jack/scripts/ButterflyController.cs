using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterflyController : MonoBehaviour
{
    private Vector3 target;
    private Vector3 startPos = Vector3.zero;
    private float timer;
    private int sec;

    void Start()
    {
        startPos = transform.position;
        target = ResetTarget();
        sec = ResetSec();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > sec)
        {
            target = ResetTarget();
            sec = ResetSec();
        }
        transform.LookAt(Vector3.Normalize(target + transform.position));
     
        transform.Translate(target * Time.deltaTime);
    }

    Vector3 ResetTarget()
    {
        //get distance to start point
        if ((transform.position - startPos).sqrMagnitude > 5 * 5)
        {
            return Vector3.Normalize(startPos - transform.position);
        }
        else return new Vector3(Random.Range(-2, 2), Random.Range(-2, 2), Random.Range(-2, 2));
    }

    int ResetSec()
    {
        timer = 0;
        return Random.Range(1, 3);
    }
}
