using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance;

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

    // Fading
    [SerializeField] private float fadeOutTime = 1f;
    [SerializeField] private float fadeInTime = 1f;
    private float elapsedFadeInTime = 0f;
    private float elapsedFadeOutTime = 0f;

    // Tracks
    [SerializeField] private MusicTrack currentTrack = MusicTrack.RIDGE_PEAK_ISLAND;
    private MusicTrack lastTrack = MusicTrack.RIDGE_PEAK_ISLAND;
    private List<AudioSource> musicTracks = new List<AudioSource>();

    // Island themes
    private AudioSource ridgePeakIslandTheme = null;
    private AudioSource butterflyIslandTheme = null;
    private AudioSource bananaCoveTheme = null;
    private AudioSource flipperIsleTheme = null;
    private AudioSource gullShoresTheme = null;
    private AudioSource windyShoresTheme = null;

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
    }

    private void Start()
    {
        // Set the volume for that tracks to zero when the game starts
        foreach (var item in musicTracks)
        {
            item.volume = 0;
        }

        // Set the volume for the starting track to one
        musicTracks[(int)currentTrack].volume = 1;
    }

    private void Update()
    {
        // If elapsed fade in time is greater than 0, then start fading in the current track
        if (elapsedFadeInTime > 0)
        {
            FadeTrackIn(currentTrack);
        }

        // If elapsed fade out time is greater than 0, then start fading out the last track
        if (elapsedFadeOutTime > 0)
        {
            FadeTrackOut(lastTrack);
        }
    }

    public void ChangeTrack(MusicTrack track)
    {
        // Set the last track to be the current track the change the current track to the new one
        lastTrack = currentTrack;
        currentTrack = track;

        // Set the timers up for fading in the new track and fading out the new track
        elapsedFadeInTime = fadeInTime;
        elapsedFadeOutTime = fadeOutTime;
    }

    private void FadeTrackIn(MusicTrack track)
    {
        elapsedFadeInTime -= Time.deltaTime;

        if (elapsedFadeInTime <= 0)
        {
            elapsedFadeInTime = 0;
            musicTracks[(int)track].volume = 1;
        }
        musicTracks[(int)track].volume = Mathf.Lerp(musicTracks[(int)track].volume, 1, 1 - (elapsedFadeInTime / fadeInTime));   
    }

    private void FadeTrackOut(MusicTrack track)
    {
        elapsedFadeOutTime -= Time.deltaTime;

        if (elapsedFadeOutTime <= 0)
        {
            elapsedFadeOutTime = 0;
            musicTracks[(int)track].volume = 0;
        }
        musicTracks[(int)track].volume = Mathf.Lerp(musicTracks[(int)track].volume, 0, 1 - (elapsedFadeOutTime / fadeOutTime));   
    }

    
}
