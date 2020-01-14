using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowSpotAngleShow : MonoBehaviour
{

    [SerializeField]
    public float totalFOV = 120.0f;



    private void OnDrawGizmosSelected()
    {


        float rayRange = 10.0f;
        float halfFOV = totalFOV / 2.0f;
        Quaternion leftRayRotation = Quaternion.AngleAxis(-halfFOV, Vector3.up);
        Quaternion rightRayRotation = Quaternion.AngleAxis(halfFOV, Vector3.up);
        Vector3 leftRayDirection = leftRayRotation * transform.forward;
        Vector3 rightRayDirection = rightRayRotation * transform.forward;
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(transform.position, leftRayDirection* rayRange);
        Gizmos.DrawRay(transform.position, rightRayDirection* rayRange);
    }
}
