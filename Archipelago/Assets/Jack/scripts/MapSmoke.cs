using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapSmoke : MonoBehaviour
{
    float fadeValue = 1.0f;
    bool fading = false;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerMapIcon") && !fading)
        {
            fading = true;
            StartCoroutine(FadeSmoke()); 
        }
    }


    //fade this smoke cloud over 1 second after it has been touched by the players icon on the map
    IEnumerator FadeSmoke()
    {
        while (GetComponent<Image>().color.a > 0.0f)
        {
            fadeValue -= Time.deltaTime;
            GetComponent<Image>().color = new Color(1, 1, 1, fadeValue);           
            yield return null;
        }

        Destroy(gameObject);
        
    }


}
