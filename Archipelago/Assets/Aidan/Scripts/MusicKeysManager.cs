using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicKeysManager : MonoBehaviour
{
	private InputMaster controls = null;

	// Particles
	private ParticleSystem blueNote = null;
	private ParticleSystem redNote = null;
	private ParticleSystem yellowNote = null;
	private ParticleSystem greenNote = null;

	private void Awake()
	{
		// Setup a new input object
		controls = new InputMaster();
	}

	private void Start()
	{
		// Get the particles
		{
			Transform particlesObject = StaticValueHolder.PlayerObject.transform.Find("Particles").gameObject.transform;
			blueNote = particlesObject.Find("BlueNote").GetComponent<ParticleSystem>();
			redNote = particlesObject.Find("RedNote").GetComponent<ParticleSystem>();
			yellowNote = particlesObject.Find("YellowNote").GetComponent<ParticleSystem>();
			greenNote = particlesObject.Find("GreenNote").GetComponent<ParticleSystem>();
		}
	}

	private void OnEnable()
	{
		// Input for music keys
		controls.MusicKeys.PlaySound.performed += ctx => PlaySound(ctx.ReadValue<Vector2>());
		controls.MusicKeys.PlaySound.canceled += ctx => StopSound(ctx.ReadValue<Vector2>());
		controls.MusicKeys.PlaySound.Enable();
	}

	private void OnDisable()
	{
		// Input for music keys
		controls.MusicKeys.PlaySound.performed -= ctx => PlaySound(ctx.ReadValue<Vector2>());
		controls.MusicKeys.PlaySound.Disable();
	}

	private void PlaySound(Vector2 soundValue)
	{
		if (soundValue.x > 0)
		{
			// Play the sound and the particle effect
			AudioManager.instance.PlaySound("MusicKey2");
			redNote.Play();
		}
		else if (soundValue.x < 0)
		{
			// Play the sound and the particle effect
			AudioManager.instance.PlaySound("MusicKey4");
			greenNote.Play();
		}

		if (soundValue.y > 0)
		{
			// Play the sound and the particle effect
			AudioManager.instance.PlaySound("MusicKey1");
			blueNote.Play();
		}
		else if (soundValue.y < 0)
		{
			// Play the sound and the particle effect
			AudioManager.instance.PlaySound("MusicKey3");
			yellowNote.Play();
		}
	}

	private void StopSound(Vector2 soundValue)
	{
		if (soundValue.x == 0)
		{
			// Stop the sound
			AudioManager.instance.StopSound("MusicKey2");
			AudioManager.instance.StopSound("MusicKey4");
		}

		if (soundValue.y == 0)
		{
			// Stop the sound
			AudioManager.instance.StopSound("MusicKey1");
			AudioManager.instance.StopSound("MusicKey3");
		}
	}
}
