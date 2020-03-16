using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootPrintDelete : MonoBehaviour
{

    float fadeTime = 1.0f;
    Material footMat = null;

    private void Awake()
    {
        footMat = GetComponent<Projector>().material = Instantiate<Material>(GetComponent<Projector>().material);
    }


    private void OnEnable()
    {
        fadeTime = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (fadeTime > 0)
        {

            fadeTime -= Time.deltaTime / 2;
            Debug.Log("FadeTime: " + fadeTime);
            footMat.SetFloat("_Fade", fadeTime);
        }
        else gameObject.SetActive(false);

    }
}
