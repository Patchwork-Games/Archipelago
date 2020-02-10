using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicKeysManager : MonoBehaviour
{
	private InputMaster controls = null;

	private void Awake()
	{
		controls = new InputMaster();
	}

	private void OnEnable()
	{
		controls.MusicKeys.PlaySound.performed += ctx => PlaySound(ctx.ReadValue<Vector2>());
		controls.MusicKeys.PlaySound.Enable();
	}

	private void OnDisable()
	{
		controls.MusicKeys.PlaySound.performed -= ctx => PlaySound(ctx.ReadValue<Vector2>());
		controls.MusicKeys.PlaySound.Disable();
	}

	private void PlaySound(Vector2 soundValue)
	{
		if (soundValue.x > 0)
		{
			AudioManager.instance.PlaySound("MusicKey2");
		}
		else if (soundValue.x < 0)
		{
			AudioManager.instance.PlaySound("MusicKey4");
		}

		if (soundValue.y > 0)
		{
			AudioManager.instance.PlaySound("MusicKey1");
		}
		else if (soundValue.y < 0)
		{
			AudioManager.instance.PlaySound("MusicKey3");
		}
	}
}
