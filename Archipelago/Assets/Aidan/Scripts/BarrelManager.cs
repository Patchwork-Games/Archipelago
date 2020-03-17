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
    private float elapsedRespawnTime = 0f;
    private bool broken = false;

    private void OnTriggerStay(Collider other)
    {
        // Check if the barrel has collided with the boat
        if (other.CompareTag("Boat") && !broken)
        {
            BoatController boatController = other.gameObject.GetComponent<BoatController>();
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
    }

    private void Update()
    {
        // Respawn cool down timer
        if (elapsedRespawnTime > 0)
        {
            elapsedRespawnTime -= Time.deltaTime;
            if (elapsedRespawnTime <= 0)
            {
                Respawn();
            }
        }
    }

    private void BreakBarrel()
    {
        // Set broken to true
        broken = true;

        // Play particle effect

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
                //StaticValueHolder.DashMeterObject.AddTemporaryDashes(numOfTemporaryDashesToGive);
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
        broken = false;

        // Set the object to be visable again and set up the collision
        barrelMesh.enabled = true;
        barrelCollider.enabled = true;
    }
}
