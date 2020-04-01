using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSmoke : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Hit");

        if (collision.CompareTag("PlayerMapIcon"))
        {
            Debug.Log("Player hit");
            Destroy(gameObject);
        }
    }
}
