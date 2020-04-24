using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fish"))
        {
            // Hide the fish
            other.transform.Find("FishModel").gameObject.SetActive(false);
            other.transform.GetComponent<BoxCollider>().enabled = false;

            // Play caught noise
            AudioSource caughtNoise = other.transform.Find("Audio").Find("FishCaughtNoise").GetComponent<AudioSource>();
            if (caughtNoise == null)
            {
                Debug.Log("Missing FishCaughtNoise child on object: " + other.transform.Find("Audio").gameObject + other.gameObject);
            }
            else
            {
                caughtNoise.Play();
            }

            // Add a fish to the counter
            StaticValueHolder.PlayerObject.GetComponent<FishingController>().CaughtFish();
        }

        if (other.CompareTag("Butterfly") && GameManager.GotFishPatch)
        {
            // Hide the butterfly
            other.transform.GetChild(0).gameObject.SetActive(false);
            other.GetComponent<BoxCollider>().enabled = false;

            // Play caught noise
            AudioSource caughtNoise = other.transform.Find("Audio").Find("ButterflyCaughtNoise").GetComponent<AudioSource>();
            if (caughtNoise == null)
            {
                Debug.Log("Missing ButterflyCaughtNoise child on object: " + other.transform.Find("Audio").gameObject + other.gameObject);
            }
            else
            {
                caughtNoise.Play();
            }

            // Add a butterfly to the counter
            StaticValueHolder.PlayerObject.GetComponent<FishingController>().CaughtButterfly();
        }
    }
}
