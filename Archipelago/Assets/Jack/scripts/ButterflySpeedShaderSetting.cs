using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterflySpeedShaderSetting : MonoBehaviour
{
    Material ButterflyMat = null;

    private void Awake()
    {
        ButterflyMat = GetComponent<Renderer>().material = Instantiate(GetComponent<Renderer>().material);
        ButterflyMat.SetFloat("_WingSpeed", Random.Range(130, 200));
    }
}
