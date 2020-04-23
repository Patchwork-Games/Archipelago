﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fish"))
        {
            Destroy(other.gameObject);
            StaticValueHolder.PlayerObject.GetComponent<FishingController>().CaughtFish();
        }

        if (other.CompareTag("Butterfly") && GameManager.GotFishPatch)
        {
            other.transform.GetChild(0).gameObject.SetActive(false);
            other.GetComponent<BoxCollider>().enabled = false;
            StaticValueHolder.PlayerObject.GetComponent<FishingController>().CaughtButterfly();
        }
    }
}