using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class PickupUI : MonoBehaviour
{

    Vector3 startPos = Vector3.zero;
    float mover = 0.0f;
    bool fading = false;   

    private void Awake()
    {
        startPos = transform.position;
        mover = 0.0f;
        fading = false;
    }


    // Update is called once per frame
    void Update()
    {
        //raise icon for 2 seconds then fade out
        if (mover < 2)
        {
            transform.SetPositionAndRotation(new Vector3(startPos.x, startPos.y + mover, startPos.z), Quaternion.identity);
            mover += Time.deltaTime * 2f;
        }
        else if(!fading)
        {
            StartCoroutine("FadeOut");
            fading = true;
        }
        
    }


    private void LateUpdate()
    {
        transform.rotation = Camera.main.transform.rotation;
    }


    IEnumerator FadeOut()
    {
        //get the first colour of the image and then decrease its alpha by 0.1 every .1 seconds
        var tempColor = transform.GetChild(0).GetComponent<Image>().color;
        while (tempColor.a > 0)
        {
            tempColor.a -= 0.02f;
            transform.GetChild(0).GetComponent<Image>().color = tempColor;
            transform.GetChild(1).GetComponent<TextMeshProUGUI>().color = tempColor;

            yield return new WaitForSeconds(0.01f);
        }
    }

}
