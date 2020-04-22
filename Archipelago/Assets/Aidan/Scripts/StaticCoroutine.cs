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
        CinemachineBasicMultiChannelPerlin[] noise =
             {
                camera.GetRig(0).GetCinemachineComponent<Cinemachine.CinemachineBasicMultiChannelPerlin>(),
                camera.GetRig(1).GetCinemachineComponent<Cinemachine.CinemachineBasicMultiChannelPerlin>(),
                camera.GetRig(2).GetCinemachineComponent<Cinemachine.CinemachineBasicMultiChannelPerlin>()
            };

        yield return new WaitForSeconds(time);
        if (!CameraShake.newShakeStarted)
        {
            CameraShake.shaking = false;

            for (int i = 0; i < noise.Length; i++)
            {
                noise[i].m_AmplitudeGain = 0;
                noise[i].m_FrequencyGain = 1;
            }
        }
    }
}
