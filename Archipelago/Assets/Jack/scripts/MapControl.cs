using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapControl : MonoBehaviour
{
    //private void Update()
    //{
    //    Vector3 newPos = StaticValueHolder.PlayerObject.transform.position;
    //    newPos.y = transform.position.y;
    //    transform.position = newPos;
    //}







































    //Matrix4x4 mapWorldPos;
    //Matrix4x4 playerWorldPos;
    //Matrix4x4 playerMapPos;

    //GameObject playerMapIcon = null;
    //GameObject mapPos = null;



    //// Start is called before the first frame update
    //void Start()
    //{
    //    mapWorldPos = new Matrix4x4
    //    (
    //    new Vector4(1, 0, 0, mapPos.transform.position.x),
    //    new Vector4(0, 1, 0, mapPos.transform.position.z),
    //    new Vector4(0, 0, 1, 0),
    //    new Vector4(0, 0, 0, 1)
    //    );
    //}

    //// Update is called once per frame
    //void FixedUpdate()
    //{
    //    //get players x and z position as x and y position
    //    playerWorldPos = new Matrix4x4
    //    (
    //    new Vector4(1, 0, 0, StaticValueHolder.PlayerObject.transform.position.x),
    //    new Vector4(0, 1, 0, StaticValueHolder.PlayerObject.transform.position.z),
    //    new Vector4(0, 0, 1, 0),
    //    new Vector4(0, 0, 0, 1)
    //    );

    //    playerMapPos = playerWorldPos * mapWorldPos;


    //    Debug.Log("playerWorldPos: " + playerWorldPos);
    //    Debug.Log("playerMapPos: " + playerMapPos);


    //    Debug.Log("matrix: " + (playerWorldPos * playerMapPos));
    //    Debug.Log("row: " + (playerWorldPos * playerMapPos).GetRow(3));
    //    playerMapIcon.transform.position = transform.TransformPoint((playerWorldPos * playerMapPos).GetRow(3));
    //}
}
