using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject cam;


    private void Update()
    {
        transform.rotation = cam.transform.rotation;
    }


}
