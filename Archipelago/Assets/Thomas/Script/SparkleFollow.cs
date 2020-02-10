﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SparkleFollow : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 newPos = PlayerMovement.Instance.transform.position;
        newPos.y = transform.position.y;
        transform.SetPositionAndRotation(newPos, transform.rotation);
    }
}