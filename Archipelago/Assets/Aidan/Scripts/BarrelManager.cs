using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelManager : MonoBehaviour
{
    public enum BarrelType
    {
        DEFAULT,
        TEMPORARY_DASHES,
        RESET_DASHES
    }
    [SerializeField] private BarrelType type = BarrelType.DEFAULT;
    [SerializeField] private float speedOfBoatToBreak = 20f;
    [SerializeField] private float respawnTime = 10f;
    [SerializeField] private int numOfTemporaryDashesToGive = 1;

    private MeshRenderer barrelMesh = null;
    private CapsuleCollider barrelCollider = null;
    private Camera mainCamera = null;
    private ParticleSystem smokeParticles = null;
    private float elapsedRespawnTime = 0f;
    private bool broken = false;
    private Vector3 spawnPos = Vector3.zero;
    private Quaternion spawnRotation = Quaternion.identity;
    private bool readyToRespawn = false;

    // Audio
    private AudioSource breakNoise = null;

    private void OnTriggerStay(Collider other)
    {
        // Check if the barrel has collided with the boat
        if (other.CompareTag("Boat") && !broken)
        {
            BoatController boatController = StaticValueHolder.BoatObject.GetComponent<BoatController>();
            if (boatController != null)
            {
                if (boatController.IsDashing || boatController.Speed >= speedOfBoatToBreak)
                {
                    BreakBarrel();
                }
            }
        }
    }

    private void Awake()
    {
        // Get the mesh renderer for the barrel
        barrelMesh = transform.Find("Graphics").GetComponent<MeshRenderer>();
        if (barrelMesh == null)
        {
            Debug.Log("Barrel mesh not found on object: " + gameObject);
        }

        // Get the barrel collider
        barrelCollider = transform.Find("Graphics").GetComponent<CapsuleCollider>();
        if (barrelCollider == null)
        {
            Debug.Log("Barrel collider not found on object: " + gameObject);
        }

        // Get the smoke particles from the child of this object
        smokeParticles = transform.Find("Particles").Find("Smoke").GetComponent<ParticleSystem>();

        // Get the main camera
        mainCamera = Camera.main;

        #region Audio

        // Get the break noise sound
        breakNoise = transform.Find("Audio").Find("BreakNoise").GetComponent<AudioSource>();
        if (breakNoise == null)
        {
            Debug.Log("Missing BreakNoise object on object: " + transform.Find("Audio").gameObject);
        }

		#endregion
	}

	private void Start()
    {
        // Set the spawn position and rotation
        spawnPos = transform.position;
        spawnRotation = transform.rotation;
    }

    private void Update()
    {
        // Respawn cool down timer
        if (elapsedRespawnTime > 0)
        {
            elapsedRespawnTime -= Time.deltaTime;
            if (elapsedRespawnTime <= 0)
            {
                readyToRespawn = true;
            }
        }

        // If the barrel is ready to respawn, check if the camera is looking at the spawn pos, if so don't spawn
        if (readyToRespawn && Vector3.Dot(mainCamera.transform.forward, spawnPos - StaticValueHolder.BoatCamera.transform.position) < 0)
        {
            Respawn();
        }
    }

    private void BreakBarrel()
    {
        // Set broken to true
        broken = true;

        // Play particle effect
        smokeParticles.Play();

        // Play sound
        breakNoise.Play();

        // Shake the screen
        CameraShake.StopShake(StaticValueHolder.BoatCamera);
        CameraShake.ShakeFreeLookCamera(StaticValueHolder.BoatCamera, .5f, 2, 3);

        // Hide the barrel and the collsion box from the player
        barrelMesh.enabled = false;
        barrelCollider.enabled = false;

        // Setup the respawn timer
        elapsedRespawnTime = respawnTime;

        // Depending on the type of barrel smashed, the boat will get a different kind of buff
        switch (type)
        {
            case BarrelType.DEFAULT:
                // Nothing happens for default barrels
                break;
            case BarrelType.TEMPORARY_DASHES:
                // Add temporary dashes to the dash meter
                StaticValueHolder.DashMeterObject.AddTemporaryDashes(numOfTemporaryDashesToGive);
                break;
            case BarrelType.RESET_DASHES:
                // Reset the dashes on the dash meter
                StaticValueHolder.DashMeterObject.ResetDashMeter();
                break;
            default:
                break;
        }
    }

    private void Respawn()
    {
        // Reset the bool for being broken and ready to spawn
        broken = false;
        readyToRespawn = false;

        // Set the object to be visable again and set up the collision
        barrelMesh.enabled = true;
        barrelCollider.enabled = true;

        // Set barrel to be back at the spawn position with the correct rotation and velocity
        transform.position = spawnPos;
        transform.rotation = spawnRotation;
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}
