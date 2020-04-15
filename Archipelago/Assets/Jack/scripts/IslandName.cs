using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IslandName : MonoBehaviour
{
    private enum IslandTheme
    {
        RIDGE_PEAK_ISLAND = 0,
        BUTTERFLY_ISLAND = 1,
        BANANA_COVE = 2,
        FLIPPER_ISLE = 3,
        GULL_SHORES = 4,
        WINDY_SHORES = 5,
    }
    [SerializeField] private IslandTheme islandType = IslandTheme.RIDGE_PEAK_ISLAND;
    [SerializeField] private string islandName = "";
    [SerializeField] private GameObject IslandNameUI = null;

    private void OnTriggerEnter(Collider other)
    {
        //display the name of the island when entering shallow waters while in boat
        if (other.CompareTag("Boat") && PlayerStateMachine.Instance.state == PlayerStateMachine.PlayerState.BOAT)
        {
            IslandNameUI.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = islandName;
            IslandNameUI.SetActive(true);

            // Change music track
            switch (islandType)
            {
                case IslandTheme.RIDGE_PEAK_ISLAND:
                    MusicManager.Instance.ChangeTrack(MusicManager.MusicTrack.RIDGE_PEAK_ISLAND);
                    break;
                case IslandTheme.BUTTERFLY_ISLAND:
                    MusicManager.Instance.ChangeTrack(MusicManager.MusicTrack.BUTTERFLY_ISLAND);
                    break;
                case IslandTheme.BANANA_COVE:
                    MusicManager.Instance.ChangeTrack(MusicManager.MusicTrack.BANANA_COVE);
                    break;
                case IslandTheme.FLIPPER_ISLE:
                    MusicManager.Instance.ChangeTrack(MusicManager.MusicTrack.FLIPPER_ISLE);
                    break;
                case IslandTheme.GULL_SHORES:
                    MusicManager.Instance.ChangeTrack(MusicManager.MusicTrack.GULL_SHORES);
                    break;
                case IslandTheme.WINDY_SHORES:
                    MusicManager.Instance.ChangeTrack(MusicManager.MusicTrack.WINDY_SHORES);
                    break;
                default:
                    break;
            }
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        // If the player is in the boat and they are leaving the island
        if (other.CompareTag("Boat") && PlayerStateMachine.Instance.state == PlayerStateMachine.PlayerState.BOAT)
        {
            // Pick one of the sailing tracks to play
            int randomNum = Random.Range(0, 3);
            switch (randomNum)
            {
                case 0:
                    MusicManager.Instance.ChangeTrack(MusicManager.MusicTrack.SAILING_1);
                    break;
                case 1:
                    MusicManager.Instance.ChangeTrack(MusicManager.MusicTrack.SAILING_2);
                    break;
                case 2:
                    MusicManager.Instance.ChangeTrack(MusicManager.MusicTrack.SAILING_3);
                    break;
                default:
                    break;
            }
        }
    }
}
