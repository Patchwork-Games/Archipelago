using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapBoatRotate : MonoBehaviour
{
    // Update is called once per frame
    void LateUpdate()
    {
        transform.eulerAngles = new Vector3(0, 0, -StaticValueHolder.BoatObject.transform.eulerAngles.y);
    }
}
