using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compass : MonoBehaviour
{
    private Vector3 northPole = new Vector3(0,0,50000);
    private GameObject cam = null;


    private void Start()
    {
        cam = Camera.main.gameObject;
    }


    // Update is called once per frame
    void Update()
    {
        //get the angle between the player and the north pole and rotate the compass so that it faces the north pole
        var targetPosLocal = cam.transform.InverseTransformPoint(northPole);
        var targetAngle = -Mathf.Atan2(targetPosLocal.x, targetPosLocal.z) * Mathf.Rad2Deg - 90;
        transform.eulerAngles = new Vector3(0, 0, targetAngle + 90);
    }
}
