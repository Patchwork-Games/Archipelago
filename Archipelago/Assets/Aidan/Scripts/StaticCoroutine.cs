using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class StaticCoroutine : MonoBehaviour
{
    public static StaticCoroutine instance;

    void Awake()
    {
        if (instance != null)
        {
            if (instance != this)
            {
                Destroy(this.gameObject);
            }
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
    }

    public void DoShake(CinemachineFreeLook camera, float duration)
    {
        instance.StartCoroutine(Shake(camera, duration)); //this will launch the coroutine on our instance
    }

    IEnumerator Shake(CinemachineFreeLook camera, float time)
    {
        // Cinemachine Shake
        CinemachineBasicMultiChannelPerlin noise = camera.GetRig(1).GetCinemachineComponent<Cinemachine.CinemachineBasicMultiChannelPerlin>();

        yield return new WaitForSeconds(time);
        if (!CameraShake.newShakeStarted)
        {
            CameraShake.shaking = false;
            noise.m_AmplitudeGain = 0;
            noise.m_FrequencyGain = 1;
        }
    }
}
