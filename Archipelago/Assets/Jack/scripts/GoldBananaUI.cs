using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldBananaUI : MonoBehaviour
{
    void Update()
    {
        //show gold banana on UI if player has picked it up
        if (StaticValueHolder.GoldBanana) GetComponent<Image>().enabled = true;
        else GetComponent<Image>().enabled = false;
    }
}
