using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationOffset : MonoBehaviour
{
    private Animator animator = null;

    private void OnEnable()
    {
        // Get the animator component
        animator = GetComponent<Animator>();
        if (animator == null)
        {
            Debug.Log("Missing Animator component on object: " + gameObject);
        }

        // Set the random offset for the animation
        animator.SetFloat("Offset", Random.Range(0.0f, 1.0f));
    }
}
