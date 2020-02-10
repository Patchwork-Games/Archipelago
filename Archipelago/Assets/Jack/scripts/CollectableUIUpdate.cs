using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectableUIUpdate : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI[] collectables = new TextMeshProUGUI[3];
    [SerializeField] private int[] totalCollectables = new int[3];

    private void Start()
    {
        StaticValueHolder.Collectable0 = 0;
        StaticValueHolder.Collectable1 = 0;
        StaticValueHolder.Collectable2 = 0;

    }


    // Update is called once per frame
    void Update()
    {
        if (PlayerMovement.Instance.YHeld)
        {
            collectables[0].text = StaticValueHolder.Collectable0 + " / " + totalCollectables[0];
            collectables[1].text = StaticValueHolder.Collectable1 + " / " + totalCollectables[1];
            collectables[2].text = StaticValueHolder.Collectable2 + " / " + totalCollectables[2];
        }




        if (Input.GetKeyDown(KeyCode.V)) StaticValueHolder.Collectable0 += 1;
        if (Input.GetKeyDown(KeyCode.B)) StaticValueHolder.Collectable1 += 1;
        if (Input.GetKeyDown(KeyCode.N)) StaticValueHolder.Collectable2 += 1;
    }
}
