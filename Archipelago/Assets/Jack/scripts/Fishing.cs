using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fishing : MonoBehaviour
{
    public Vector3 direction = new Vector3(0,0,0);
    private GameObject poleTip = null;
    LineRenderer lr;

    public Material ropeMat;


    private void Start()
    {
        poleTip = GameObject.FindGameObjectWithTag("FishingPole");
        lr = gameObject.AddComponent<LineRenderer>();

        GetComponent<Rigidbody>().AddForce((direction + new Vector3(0,1,0)) * 100);
    }


    void Update()
    {
        lr.SetPosition(0, gameObject.transform.position);
        lr.SetPosition(1, poleTip.transform.position);

        lr.startWidth = .2f;
        lr.endWidth = .2f;
        
    }
}
