using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CollectableUIUpdate : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI[] collectables = new TextMeshProUGUI[3];
    [SerializeField] private int[] totalCollectables = new int[3];
    public DashMeter dashMeter = null;
    public GameObject PickupIcon = null;
    public Canvas pickupButtonGuide = null;
    public Sprite fishSprite = null;
    public Sprite shellSprite = null;
    public Sprite stickSprite = null;

    private void Start()
    {
        StaticValueHolder.Collectable0 = 0;
        StaticValueHolder.Collectable1 = 0;
        StaticValueHolder.Collectable2 = 0;

    }


    // Update is called once per frame
    void Update()
    {
        if (PlayerMovement.Instance.YHeld)
        {
            collectables[0].text = StaticValueHolder.Collectable0 + " / " + totalCollectables[0];
            collectables[1].text = StaticValueHolder.Collectable1 + " / " + totalCollectables[1];
            collectables[2].text = StaticValueHolder.Collectable2 + " / " + totalCollectables[2];
        }
    }

    private void LateUpdate()
    {
        if (pickupButtonGuide) pickupButtonGuide.transform.rotation = Camera.main.transform.rotation;
    }
}
