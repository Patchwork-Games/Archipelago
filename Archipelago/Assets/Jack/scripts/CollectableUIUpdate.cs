using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CollectableUIUpdate : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI[] collectables = new TextMeshProUGUI[3];
    [SerializeField] private int[] totalCollectables = new int[3];
    public GameObject PickupIcon = null;
    public Canvas pickupButtonGuide = null;
    public Sprite fishSprite = null;
    public Sprite butterflySprite = null;
    public Sprite stickSprite = null;
    private Camera cam = null;

    // Audio
    private AudioSource showCollectablesNoise = null;
    private AudioSource hideCollectablesNoise = null;
    private bool showCollectablesSoundPlayed = false;

    private void Awake()
    {
        // Get the audio object transform
        Transform audioObjectTransform = transform.Find("Audio");
        if (audioObjectTransform == null)
        {
            Debug.Log("Missing Audio child on object: " + gameObject);
        }
        else
        {
            // Get the show collectables noise
            showCollectablesNoise = audioObjectTransform.Find("ShowCollectablesNoise").GetComponent<AudioSource>();
            if (showCollectablesNoise == null)
            {
                Debug.Log("Missing ShowCollectablesNoise child on object: " + audioObjectTransform.gameObject);
            }

            // Get the hide collectables noise
            hideCollectablesNoise = audioObjectTransform.Find("HideCollectablesNoise").GetComponent<AudioSource>();
            if (hideCollectablesNoise == null)
            {
                Debug.Log("Missing HideCollectablesNoise child on object: " + audioObjectTransform.gameObject);
            }
        }
    }

    private void Start()
    {
        StaticValueHolder.Collectable0 = 0;
        StaticValueHolder.Collectable1 = 0;
        StaticValueHolder.Collectable2 = 0;
        cam = Camera.main;
    }


    // Update is called once per frame
    void Update()
    {
        if (StaticValueHolder.PlayerMovementScript.YHeld)
        {
            // If the show collectables sound hasn't been played, play it
            if (!showCollectablesSoundPlayed)
            {
                showCollectablesSoundPlayed = true;
                showCollectablesNoise.Play();
            }

            collectables[0].text = StaticValueHolder.Collectable0 + ""; /*+ " / " + totalCollectables[0];*/
            collectables[1].text = StaticValueHolder.Collectable1 + ""; /*+ " / " + totalCollectables[1];*/
            collectables[2].text = StaticValueHolder.Collectable2 + ""; /*+ " / " + totalCollectables[2];*/
        }
        else
        {
            // If the show collectables sound has been played, set the bool to false and play the hide sound
            if (showCollectablesSoundPlayed)
            {
                showCollectablesSoundPlayed = false;
                hideCollectablesNoise.Play();
            }
        }
    }

    private void LateUpdate()
    {
        if (pickupButtonGuide) pickupButtonGuide.transform.rotation = cam.transform.rotation;
    }
}
