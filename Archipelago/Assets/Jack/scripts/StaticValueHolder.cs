using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Rendering.PostProcessing;

public static class StaticValueHolder
{
    private static int collectable0, collectable1, collectable2;
    private static bool goldBanana;


    //fish
    public static int Collectable0
    {
        get
        {
            return collectable0;
        }
        set
        {
            collectable0 = value;
        }
    }

    //butterflies
    public static int Collectable1
    {
        get
        {
            return collectable1;
        }
        set
        {
            collectable1 = value;
        }
    }

    //sticks
    public static int Collectable2
    {
        get
        {
            return collectable2;
        }
        set
        {
            collectable2 = value;
        }
    }

    //used to show gold banana on UI if player has picked it up
    public static bool GoldBanana
    {
        get
        {
            return goldBanana;
        }
        set
        {
            goldBanana = value;
        }
    }

    public static GameObject BoatObject
	{
		get;
		set;
	}

	public static GameObject PlayerObject
	{
		get;
		set;
	}

    public static PlayerMovement PlayerMovementScript
    {
        get;
        set;
    }

    public static DashMeter DashMeterObject
	{
		get;
		set;
	}

	public static CinemachineFreeLook PlayerCharacterCamera
	{
		get;
		set;
	}

	public static CinemachineFreeLook BoatCamera
	{
		get;
		set;
	}

	public static WindManager WindManagerObject
	{
		get;
		set;
	}

    public static CollectableUIUpdate CollectableUIUpdateObject
    {
        get;
        set;
    }

    public static PostProcessVolume PostProcessVolumeObject
    {
        get;
        set;
    }

    public static DialogueManager DialogueManagerObject
    {
        get;
        set;
    }

}
