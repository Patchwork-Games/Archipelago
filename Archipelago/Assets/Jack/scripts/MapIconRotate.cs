using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapIconRotate : MonoBehaviour
{
    Vector3 newPos = Vector3.zero;
    [SerializeField]float mapWidth = 350.0f;
    [SerializeField]float sceneWidth = 2000.0f;


    // Update is called once per frame
    void LateUpdate()
    {
        transform.eulerAngles = new Vector3(0,0, -StaticValueHolder.PlayerObject.transform.eulerAngles.y);

        newPos.x = StaticValueHolder.PlayerObject.transform.position.x * mapWidth / sceneWidth;
        newPos.y = StaticValueHolder.PlayerObject.transform.position.z * mapWidth / sceneWidth;
        newPos.z = -1;
        transform.localPosition = newPos;
    }
}
