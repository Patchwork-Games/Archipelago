using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraShake
{
	public static bool shaking = false;
	public static bool newShakeStarted = false;

	public static void ShakeFreeLookCamera(CinemachineFreeLook camera, float duration, float amplitude, float frequency)
	{
		// Cinemachine Shake
		CinemachineBasicMultiChannelPerlin[] noise = 
			{
				camera.GetRig(0).GetCinemachineComponent<Cinemachine.CinemachineBasicMultiChannelPerlin>(),
				camera.GetRig(1).GetCinemachineComponent<Cinemachine.CinemachineBasicMultiChannelPerlin>(),
				camera.GetRig(2).GetCinemachineComponent<Cinemachine.CinemachineBasicMultiChannelPerlin>() 
			};

		// Set variables at the start of the shake
		if (!shaking || newShakeStarted)
		{
			shaking = true;
			newShakeStarted = false;
			for (int i = 0; i < noise.Length; i++)
			{
				noise[i].m_AmplitudeGain = amplitude;
				noise[i].m_FrequencyGain = frequency;
			}
			StaticCoroutine.instance.DoShake(camera, duration);
		}
	}

	public static void StartFreeLookCameraShake(CinemachineFreeLook camera, float amplitude, float frequency)
	{
		// Cinemachine Shake
		CinemachineBasicMultiChannelPerlin[] noise =
			{
				camera.GetRig(0).GetCinemachineComponent<Cinemachine.CinemachineBasicMultiChannelPerlin>(),
				camera.GetRig(1).GetCinemachineComponent<Cinemachine.CinemachineBasicMultiChannelPerlin>(),
				camera.GetRig(2).GetCinemachineComponent<Cinemachine.CinemachineBasicMultiChannelPerlin>()
			};


		for (int i = 0; i < noise.Length; i++)
		{
			noise[i].m_AmplitudeGain = amplitude;
			noise[i].m_FrequencyGain = frequency;
		}
	}

	public static void StopShake(CinemachineFreeLook camera)
	{
		// Cinemachine Shake
		CinemachineBasicMultiChannelPerlin[] noise =
			{
				camera.GetRig(0).GetCinemachineComponent<Cinemachine.CinemachineBasicMultiChannelPerlin>(),
				camera.GetRig(1).GetCinemachineComponent<Cinemachine.CinemachineBasicMultiChannelPerlin>(),
				camera.GetRig(2).GetCinemachineComponent<Cinemachine.CinemachineBasicMultiChannelPerlin>()
			};
		shaking = false;
		for (int i = 0; i < noise.Length; i++)
		{
			noise[i].m_AmplitudeGain = 0;
			noise[i].m_FrequencyGain = 1;
		}
		newShakeStarted = true;
	}
}
