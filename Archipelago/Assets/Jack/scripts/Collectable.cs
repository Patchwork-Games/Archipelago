using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{

    public enum CollectableTypes
    {
        FISH,
        SHELL,
        STICK
    }
    public CollectableTypes collectableType;




    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            switch (collectableType)
            {
                case CollectableTypes.FISH:
                    {
                        StaticValueHolder.Collectable0 += 1;
                        break;
                    }
                case CollectableTypes.SHELL:
                    {
                        StaticValueHolder.Collectable1 += 1;
                        break;
                    }
                case CollectableTypes.STICK:
                    {
                        StaticValueHolder.Collectable2 += 1;
                        break;
                    }
                default:
                    {
                        Debug.Log("WRONG TYPE OF COLLECTABLE, SEE COLLECTABLE SCRIPT");
                        break;
                    }
            }


            Destroy(gameObject);
        }
    }
}
