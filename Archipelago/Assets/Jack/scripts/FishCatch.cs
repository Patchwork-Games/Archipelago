using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishCatch : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fish"))
        {
            Destroy(other.gameObject);
            StaticValueHolder.PlayerObject.GetComponent<FishingController>().CaughtFish();
        }

        if (other.CompareTag("Butterfly"))
        {
            Destroy(other.gameObject);
            StaticValueHolder.PlayerObject.GetComponent<FishingController>().CaughtButterfly();
        }

        Debug.Log("Collision: " + other);
    }
}
