using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchInputGuides : MonoBehaviour
{

    Vector2 camMoveDirection = Vector2.zero;
    float timer = 0.0f;
    [SerializeField] Sprite controllerImage = null;
    [SerializeField] Sprite keyboardImage = null;



    private void Start()
    {
        StartCoroutine(ControllerCheck());
    }



    IEnumerator ControllerCheck()
    {
        while (true)
        {
            //only run every 2 seconds instead of every frame
            yield return new WaitForSecondsRealtime(2f);
            
            //check if there is a controller connected
            if (!string.IsNullOrEmpty(Input.GetJoystickNames()[0]))
            {
                GetComponent<Image>().sprite = controllerImage;
            }
            else
            {
                GetComponent<Image>().sprite = keyboardImage;
            }
        }
    }


}

