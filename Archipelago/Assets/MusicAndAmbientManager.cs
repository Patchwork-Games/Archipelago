using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicAndAmbientManager : MonoBehaviour
{
    public static MusicAndAmbientManager Instance;

    public enum MusicTrack
    {
        RIDGE_PEAK_ISLAND = 0,
        BUTTERFLY_ISLAND = 1,
        BANANA_COVE = 2,
        FLIPPER_ISLE = 3,
        GULL_SHORES = 4,
        WINDY_SHORES = 5,
        SAILING_1 = 6,
        SAILING_2 = 7,
        SAILING_3 = 8
    }

    public enum AmbientTrack
    {
        BEACH = 0,
        OCEAN = 1,
        FOREST = 2
    }

    // Fading
    [SerializeField] private float fadeOutTimeMusic = 3f;
    [SerializeField] private float fadeInTimeMusic = 3f;
    [SerializeField] private float fadeOutTimeAmbient = 3f;
    [SerializeField] private float fadeInTimeAmbient = 3f;
    private float elapsedMusicFadeInTime = 0f;
    private float elapsedMusicFadeOutTime = 0f;
    private float elapsedAmbientFadeInTime = 0f;
    private float elapsedAmbientFadeOutTime = 0f;

    // Music Tracks
    [SerializeField] private MusicTrack currentMusicTrack = MusicTrack.RIDGE_PEAK_ISLAND;
    private MusicTrack lastMusicTrack = MusicTrack.RIDGE_PEAK_ISLAND;
    private List<AudioSource> musicTracks = new List<AudioSource>();

    // Island themes
    private AudioSource ridgePeakIslandTheme = null;
    private AudioSource butterflyIslandTheme = null;
    private AudioSource bananaCoveTheme = null;
    private AudioSource flipperIsleTheme = null;
    private AudioSource gullShoresTheme = null;
    private AudioSource windyShoresTheme = null;

    // Ambient Tracks
    [SerializeField] private AmbientTrack currentAmbientTrack = AmbientTrack.BEACH;
    private AmbientTrack lastAmbientTrack = AmbientTrack.BEACH;
    private List<AudioSource> ambientTracks = new List<AudioSource>();

    // Ambient tracks
    private AudioSource beachAmbientTrack = null;
    private AudioSource oceanAmbientTrack = null;
    private AudioSource forestAmbientTrack = null;

    // Sailing tracks
    private List<AudioSource> sailingTracks = new List<AudioSource>();

    void Awake()
    {
        // Make this script a singleton
        if (Instance != null)
        {
            if (Instance != this)
            {
                Destroy(this.gameObject);
            }
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }

        // Get the music object transform
        Transform musicTransform = transform.Find("Music");
        if (musicTransform == null)
        {
            Debug.Log("Missing Music child on object: " + musicTransform);
        }
        else
        {
			#region Island Themes ----------------------------------------------------------------------------

			// Get RidgePeakIslandTheme
			ridgePeakIslandTheme = musicTransform.Find("RidgePeakIslandTheme").GetComponent<AudioSource>();
            if (ridgePeakIslandTheme == null)
            {
                Debug.Log(" Missing RidgePeakIslandTheme child on object: " + musicTransform);
            }

            // Get ButterflyIslandTheme
            butterflyIslandTheme = musicTransform.Find("ButterflyIslandTheme").GetComponent<AudioSource>();
            if (butterflyIslandTheme == null)
            {
                Debug.Log(" Missing ButterflyIslandTheme child on object: " + musicTransform);
            }

            // Get BananaCoveTheme
            bananaCoveTheme = musicTransform.Find("BananaCoveTheme").GetComponent<AudioSource>();
            if (bananaCoveTheme == null)
            {
                Debug.Log(" Missing BananaCoveTheme child on object: " + musicTransform);
            }

            // Get FlipperIsleTheme
            flipperIsleTheme = musicTransform.Find("FlipperIsleTheme").GetComponent<AudioSource>();
            if (flipperIsleTheme == null)
            {
                Debug.Log(" Missing FlipperIsleTheme child on object: " + musicTransform);
            }

            // Get GullShoresTheme
            gullShoresTheme = musicTransform.Find("GullShoresTheme").GetComponent<AudioSource>();
            if (gullShoresTheme == null)
            {
                Debug.Log(" Missing GullShoresTheme child on object: " + musicTransform);
            }

            // Get WindyShoresTheme
            windyShoresTheme = musicTransform.Find("WindyShoresTheme").GetComponent<AudioSource>();
            if (windyShoresTheme == null)
            {
                Debug.Log(" Missing WindyShoresTheme child on object: " + musicTransform);
            }

            #endregion --------------------------------------------------------------------------------------

            #region Sailing tracks ---------------------------------------------------------------------------

            // Get sailing track 1
            sailingTracks.Add(musicTransform.Find("SailingTrack1").GetComponent<AudioSource>());
            if (sailingTracks[0] == null)
            {
                Debug.Log(" Missing SailingTrack1 child on object: " + musicTransform);
            }

            // Get sailing track 2
            sailingTracks.Add(musicTransform.Find("SailingTrack2").GetComponent<AudioSource>());
            if (sailingTracks[1] == null)
            {
                Debug.Log(" Missing SailingTrack2 child on object: " + musicTransform);
            }

            // Get sailing track 3
            sailingTracks.Add(musicTransform.Find("SailingTrack3").GetComponent<AudioSource>());
            if (sailingTracks[2] == null)
            {
                Debug.Log(" Missing SailingTrack3 child on object: " + musicTransform);
            }

			#endregion ---------------------------------------------------------------------------------------

			// Add the tracks to the music track list
			musicTracks.Add(ridgePeakIslandTheme);
            musicTracks.Add(butterflyIslandTheme);
            musicTracks.Add(bananaCoveTheme);
            musicTracks.Add(flipperIsleTheme);
            musicTracks.Add(gullShoresTheme);
            musicTracks.Add(windyShoresTheme);
            musicTracks.Add(sailingTracks[0]);
            musicTracks.Add(sailingTracks[1]);
            musicTracks.Add(sailingTracks[2]);
        }

        // Get the ambient object transform
        Transform ambientTransform = transform.Find("Ambient");
        if (ambientTransform == null)
        {
            Debug.Log("Missing Ambient child on object: " + ambientTransform);
        }
        else
        {
            #region AmbientTracks ----------------------------------------------------------------------------

            // Get the Beach ambient track
            beachAmbientTrack = ambientTransform.Find("Beach").GetComponent<AudioSource>();
            if (beachAmbientTrack == null)
            {
                Debug.Log("Missing Beach child on object: " + ambientTransform.gameObject + gameObject);
            }

            // Get the Ocean ambient track
            oceanAmbientTrack = ambientTransform.Find("Ocean").GetComponent<AudioSource>();
            if (oceanAmbientTrack == null)
            {
                Debug.Log("Missing Ocean child on object: " + ambientTransform.gameObject + gameObject);
            }

            // Get the Forest ambient track
            forestAmbientTrack = ambientTransform.Find("Forest").GetComponent<AudioSource>();
            if (forestAmbientTrack == null)
            {
                Debug.Log("Missing Forest child on object: " + ambientTransform.gameObject + gameObject);
            }

            #endregion ---------------------------------------------------------------------------------------

            // Add the tracks to the ambient tracks list
            ambientTracks.Add(beachAmbientTrack);
            ambientTracks.Add(oceanAmbientTrack);
            ambientTracks.Add(forestAmbientTrack);
        }
    }

    private void Start()
    {
        // Set the volume for the music and ambient tracks to zero when the game starts
        foreach (var item in musicTracks)
        {
            item.volume = 0;
        }
        foreach (var item in ambientTracks)
        {
            item.volume = 0;
        }

        // Set the volume for the starting tracks to one
        musicTracks[(int)currentMusicTrack].volume = 1;
        ambientTracks[(int)currentAmbientTrack].volume = 1;
    }

    private void Update()
    {
		#region Music Fading

		// If elapsed fade in time is greater than 0, then start fading in the current track
		if (elapsedMusicFadeInTime > 0)
        {
            elapsedMusicFadeInTime -= Time.deltaTime;

            if (elapsedMusicFadeInTime <= 0)
            {
                elapsedMusicFadeInTime = 0;
                musicTracks[(int)currentMusicTrack].volume = 1;
            }
            musicTracks[(int)currentMusicTrack].volume = Mathf.Lerp(musicTracks[(int)currentMusicTrack].volume, 1, 1 - (elapsedMusicFadeInTime / fadeInTimeMusic));
        }

        // If elapsed fade out time is greater than 0, then start fading out the last track
        if (elapsedMusicFadeOutTime > 0)
        {
            elapsedMusicFadeOutTime -= Time.deltaTime;

            if (elapsedMusicFadeOutTime <= 0)
            {
                elapsedMusicFadeOutTime = 0;
                musicTracks[(int)lastMusicTrack].volume = 0;
                musicTracks[(int)lastMusicTrack].Stop();
            }
            musicTracks[(int)lastMusicTrack].volume = Mathf.Lerp(musicTracks[(int)lastMusicTrack].volume, 0, 1 - (elapsedMusicFadeOutTime / fadeOutTimeMusic));
        }

        #endregion

        #region Ambient Fading

        // If elapsed fade in time is greater than 0, then start fading in the current track
        if (elapsedAmbientFadeInTime > 0)
        {
            elapsedAmbientFadeInTime -= Time.deltaTime;
            if (elapsedAmbientFadeInTime <= 0)
            {
                elapsedAmbientFadeInTime = 0;
                ambientTracks[(int)currentAmbientTrack].volume = 1;
            }
            ambientTracks[(int)currentAmbientTrack].volume = Mathf.Lerp(ambientTracks[(int)currentAmbientTrack].volume, 1, 1 - (elapsedAmbientFadeInTime / fadeInTimeAmbient));
        }

        // If elapsed fade out time is greater than 0, then start fading out the last track
        if (elapsedAmbientFadeOutTime > 0)
        {
            elapsedAmbientFadeOutTime -= Time.deltaTime;
            if (elapsedAmbientFadeOutTime <= 0)
            {
                elapsedAmbientFadeOutTime = 0;
                ambientTracks[(int)lastAmbientTrack].volume = 0;
                ambientTracks[(int)lastAmbientTrack].Stop();
            }
            ambientTracks[(int)lastAmbientTrack].volume = Mathf.Lerp(ambientTracks[(int)lastAmbientTrack].volume, 0, 1 - (elapsedAmbientFadeOutTime / fadeOutTimeAmbient));
        }

        #endregion
    }

	public void ChangeMusicTrack(MusicTrack track)
    {
        // Set the last track to be the current track the change the current track to the new one
        lastMusicTrack = currentMusicTrack;
        currentMusicTrack = track;

        // Start the new track
        musicTracks[(int)currentMusicTrack].Play();

        // Set the timers up for fading in the new track and fading out the new track
        elapsedMusicFadeInTime = fadeInTimeMusic;
        elapsedMusicFadeOutTime = fadeOutTimeMusic;
    }

    public void ChangeAmbientTrack(AmbientTrack track)
    {
        // Set the last track to be the current track the change the current track to the new one
        lastAmbientTrack = currentAmbientTrack;
        currentAmbientTrack = track;

        // Set the timers up for fading in the new track and fading out the new track
        elapsedAmbientFadeInTime = fadeInTimeAmbient;
        elapsedAmbientFadeOutTime = fadeOutTimeAmbient;
    }
}
