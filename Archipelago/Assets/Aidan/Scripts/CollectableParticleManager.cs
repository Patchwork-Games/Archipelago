using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableParticleManager : MonoBehaviour
{
    private Collectable collectable = null;
    private MeshRenderer meshRenderer = null;
    private BoxCollider boxCollider = null;

    // particles
    private ParticleSystem glowyParticles = null;
    private ParticleSystem sparkleParticles = null;
    private bool activateParticles = true;

    private void Awake()
    {
        // Get the collectible object
        collectable = GetComponent<Collectable>();
        if (collectable == null)
        {
            Debug.Log("Collectable script missing from object: " + this.gameObject);
        }

        // Get the box collider
        boxCollider = GetComponent<BoxCollider>();
        if (boxCollider == null)
        {
            Debug.Log("BoxCollider component missing on object: " + this.gameObject);
        }

        // Get the mesh renderer
        meshRenderer = transform.Find("Graphics").GetComponent<MeshRenderer>();
        if (meshRenderer == null)
        {
            Debug.Log("MeshRenderer component missing on object: " + transform.Find("Graphics").gameObject);
        }

        #region Particles

        // Get the particles transform
        Transform particlesTransform = transform.Find("Particles");
        if (particlesTransform == null)
        {
            Debug.Log("Missing Particles child on object: " + this.gameObject);
        }
        else
        {
            // Get the glowy particles
            glowyParticles = particlesTransform.Find("GlowyParticles").GetComponent<ParticleSystem>();
            if (glowyParticles == null)
            {
                Debug.Log("Missing GlowyParticles child on object:" + particlesTransform.gameObject);
            }

            // Get the sparkle particles
            sparkleParticles = particlesTransform.Find("Sparkles").GetComponent<ParticleSystem>();
            if (sparkleParticles == null)
            {
                Debug.Log("Missing Sparkles child on object: " + particlesTransform.gameObject);
            }
        }


		#endregion
	}

    // Update is called once per frame
    void Update()
    {
        // Check if the collectable has been collected
        if (collectable.Collected && activateParticles)
        {
            activateParticles = false;

            // Play the particle system once
            glowyParticles.Play();

            // Deactivate the objects collision box and 
            boxCollider.enabled = false;
            meshRenderer.enabled = false;

            // Stop the emission of the sparkles
            ParticleTools.StopEmission(sparkleParticles);
        }
    }
}
