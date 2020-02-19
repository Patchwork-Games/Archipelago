using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IslandName : MonoBehaviour
{
    [SerializeField] private string islandName = "";
    [SerializeField] private GameObject IslandNameUI = null;

    private void OnTriggerEnter(Collider other)
    {
        //display the name of the island when entering shallow waters while in boat
        if (other.CompareTag("Boat") && PlayerStateMachine.Instance.state == PlayerStateMachine.PlayerState.BOAT)
        {
            IslandNameUI.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = islandName;
            IslandNameUI.SetActive(true);
        }
        
    }
}
