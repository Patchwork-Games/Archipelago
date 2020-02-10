using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticValueHolder
{
    private static int collectable0, collectable1, collectable2;


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




}
