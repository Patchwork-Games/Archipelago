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


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        objectToFollow = player;
    }


    void Update()
    {
        FollowObject();
    }





    void FollowObject()
    {
        float interpolation = speed * Time.deltaTime;

        Vector3 position = transform.position;
        position.z = Mathf.Lerp(transform.position.z, objectToFollow.transform.position.z + Zoffset, interpolation);
        position.x = Mathf.Lerp(transform.position.x, objectToFollow.transform.position.x, interpolation);
        position.y = Mathf.Lerp(transform.position.y, objectToFollow.transform.position.y + Yoffset, interpolation);
        this.transform.position = position;
    }


    public void FollowNewObject(GameObject newObjectToFollow)
    {
        objectToFollow = newObjectToFollow;
    }


}
