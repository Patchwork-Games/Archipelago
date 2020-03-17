using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterflyController : MonoBehaviour
{
    [SerializeField] private float ID = 0.0f;
    private Vector3 target;
    private Vector3 startPos = Vector3.zero;
    private float timer;
    private float sec;
    private float moveTime = 1.0f;

    void Start()
    {
        startPos = transform.position;
        target = ResetTarget();
        sec = ResetSec();
        sec = ID;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > sec)
        {
            target = ResetTarget();
            transform.LookAt(target);
            sec = ResetSec();
            moveTime = 0;
        }

        moveTime = (timer / sec) / 4;
        transform.position = new Vector3(Mathf.Lerp(transform.position.x, target.x, moveTime), Mathf.Lerp(transform.position.y, target.y, moveTime), Mathf.Lerp(transform.position.z, target.z, moveTime));
    }

    Vector3 ResetTarget()
    {
        //return to start point if too far away
        if ((transform.position - startPos).sqrMagnitude > 5 * 5) return startPos;
        else return transform.position + new Vector3(Random.Range(-2, 2), Random.Range(-2, 2), Random.Range(-2, 2));
    }

    int ResetSec()
    {
        timer = 0;
        return Random.Range(1, 3);
    }
}
