using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateCollectable : MonoBehaviour
{
    private void OnEnable()
    {
        GetComponent<TextMeshProUGUI>().text = "1";
    }
}
