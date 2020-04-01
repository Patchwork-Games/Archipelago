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

	// Audio
	private AudioSource blueNoteNoise = null;
	private AudioSource redNoteNoise = null;
	private AudioSource yellowNoteNoise = null;
	private AudioSource greenNoteNoise = null;

	private void Awake()
	{
		// Setup a new input object
		controls = new InputMaster();

		#region Audio

		// Get the audio object transform
		Transform audioObjectTransform = transform.Find("Audio");
		if (audioObjectTransform == null)
		{
			Debug.Log("Missing Audio child on object: " + gameObject);
		}
		else
		{
			// Get the blue note noise
			blueNoteNoise = audioObjectTransform.Find("BlueNote").GetComponent<AudioSource>();
			if (blueNoteNoise == null)
			{
				Debug.Log("Missing BlueNote child on object: " + audioObjectTransform.gameObject);
			}

			// Get the red note noise
			redNoteNoise = audioObjectTransform.Find("RedNote").GetComponent<AudioSource>();
			if (redNoteNoise == null)
			{
				Debug.Log("Missing RedNote child on object: " + audioObjectTransform.gameObject);
			}

			// Get the yellow note noise
			yellowNoteNoise = audioObjectTransform.Find("YellowNote").GetComponent<AudioSource>();
			if (yellowNoteNoise == null)
			{
				Debug.Log("Missing YellowNote child on object: " + audioObjectTransform.gameObject);
			}

			// Get the green note noise
			greenNoteNoise = audioObjectTransform.Find("GreenNote").GetComponent<AudioSource>();
			if (greenNoteNoise == null)
			{
				Debug.Log("Missing GreenNote child on object: " + audioObjectTransform.gameObject);
			}
		}

		#endregion
	}

	private void Start()
	{
		// Get the particles
		Transform particlesObject = StaticValueHolder.PlayerObject.transform.Find("Particles").gameObject.transform;
		blueNote = particlesObject.Find("BlueNote").GetComponent<ParticleSystem>();
		redNote = particlesObject.Find("RedNote").GetComponent<ParticleSystem>();
		yellowNote = particlesObject.Find("YellowNote").GetComponent<ParticleSystem>();
		greenNote = particlesObject.Find("GreenNote").GetComponent<ParticleSystem>();
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
		// Depending on the input, change the sound that is playing
		if (soundValue.x > 0)
		{
			// Play the sound and the particle effect
			redNoteNoise.Play();
			redNote.Play();
		}
		else if (soundValue.x < 0)
		{
			// Play the sound and the particle effect
			greenNoteNoise.Play();
			greenNote.Play();
		}

		if (soundValue.y > 0)
		{
			// Play the sound and the particle effect
			blueNoteNoise.Play();
			blueNote.Play();
		}
		else if (soundValue.y < 0)
		{
			// Play the sound and the particle effect
			yellowNoteNoise.Play();
			yellowNote.Play();
		}
	}

	private void StopSound(Vector2 soundValue)
	{
		if (soundValue.x == 0)
		{
			// Stop the sound
			redNoteNoise.Stop();
			greenNoteNoise.Stop();
		}

		if (soundValue.y == 0)
		{
			// Stop the sound
			blueNoteNoise.Stop();
			yellowNoteNoise.Stop();
		}
	}
}
