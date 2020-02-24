using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }



    private void Update()
    {
        Vector3 newPos = StaticValueHolder.PlayerObject.transform.position;
        newPos.y = transform.position.y;
        transform.position = newPos;
    }



    // Update is called once per frame
    void FixedUpdate()
    {

    }




















    //// Start is called before the first frame update
    //void Start()
    //{
    //    mapWorldPos = new Matrix4x4
    //    (
    //    new Vector4(1, 0, 0, -(transform.position.x - transform.root.position.x)),
    //    new Vector4(0, 1, 0, -(transform.position.z - transform.root.position.z)),
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
    //    new Vector4(1, 0, 0, (StaticValueHolder.PlayerObject.transform.position.x - StaticValueHolder.PlayerObject.transform.root.position.x)),
    //    new Vector4(0, 1, 0, (StaticValueHolder.PlayerObject.transform.position.z - StaticValueHolder.PlayerObject.transform.root.position.z)),
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
