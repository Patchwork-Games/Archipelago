using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject objectToFollow;
    public GameObject player;

    [SerializeField] private float speed = 2.0f;
    [SerializeField] private float Zoffset = -7f;
    [SerializeField] private float Yoffset = 10f;
    private float rotate = 0;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        objectToFollow = player;
    }


    void Update()
    {
        FollowObject();



        if (Input.GetKey(KeyCode.H))
        {
            rotate -= Time.deltaTime * 5;
        }

        if (Input.GetKey(KeyCode.J))
        {
            rotate += Time.deltaTime * 5;
        }


        if (rotate > 360) rotate -= 360;
        if (rotate < 0) rotate += 360;
        Debug.Log("Rotate: " + rotate);
    }





    void FollowObject()
    {
        float interpolation = speed * Time.deltaTime;

        Vector3 position = transform.position;
        position.z = Mathf.Lerp(transform.position.z, objectToFollow.transform.position.z + Zoffset, interpolation);
        position.x = Mathf.Lerp(transform.position.x, objectToFollow.transform.position.x, interpolation);
        position.y = Mathf.Lerp(transform.position.y, objectToFollow.transform.position.y + Yoffset, interpolation);
        this.transform.position = position;


        //transform.root.Rotate(new Vector3(0,1,0), rotate);// = new Quaternion(0, rotate, 0, 1);
    }


    public void FollowNewObject(GameObject newObjectToFollow)
    {
        objectToFollow = newObjectToFollow;
    }


}
