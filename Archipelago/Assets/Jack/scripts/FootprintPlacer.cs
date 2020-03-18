using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootprintPlacer : MonoBehaviour
{
    private GameObject footL = null;
    private GameObject footR = null;
    private ObjectPooling spawner = null;
    [SerializeField] private GameObject footCam = null;
    [SerializeField] private float sandHeight = 33.0f;
    

    private void Start()
    {
        footL = gameObject.transform.GetChild(0).GetChild(3).GetChild(0).GetChild(1).GetChild(0).GetChild(0).GetChild(0).gameObject;
        footR = gameObject.transform.GetChild(0).GetChild(3).GetChild(0).GetChild(2).GetChild(0).GetChild(0).GetChild(0).gameObject;

        spawner = GameObject.FindGameObjectWithTag("FootSpawner").GetComponent<ObjectPooling>();
    }




    public void PlaceFootprintLeft()
    {
        if (transform.position.y < sandHeight)
        {
            GameObject newFootPrint = spawner.RetrieveInstance();
            if (newFootPrint != null)
            {
                newFootPrint.transform.parent = spawner.transform;
                newFootPrint.transform.position = footL.transform.position;
                newFootPrint.transform.rotation = Quaternion.Euler(90, transform.rotation.eulerAngles.y, 0);
            }
        }
       
    }


    public void PlaceFootprintRight()
    {
        if (transform.position.y < sandHeight)
        {
            GameObject newFootPrint = spawner.RetrieveInstance();
            if (newFootPrint != null)
            {
                newFootPrint.transform.parent = spawner.transform;
                newFootPrint.transform.position = footR.transform.position;
                newFootPrint.transform.rotation = Quaternion.Euler(90, transform.rotation.eulerAngles.y, 0);
            }
        }
    }

}
