using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapIconRotate : MonoBehaviour
{
    private Vector3 northPole = new Vector3(0, 0, 50000);
    private GameObject cam = null;


    private void Start()
    {
        cam = Camera.main.gameObject;
    }


    // Update is called once per frame
    void LateUpdate()
    {
        transform.eulerAngles = -new Vector3(0,0,StaticValueHolder.PlayerObject.transform.eulerAngles.y);
    }
}
