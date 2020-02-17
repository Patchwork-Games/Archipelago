using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compass : MonoBehaviour
{
    [SerializeField] private GameObject Camera = null;
    [SerializeField] private GameObject NorthPole = null;

    // Update is called once per frame
    void Update()
    {
        var targetPosLocal = Camera.transform.InverseTransformPoint(NorthPole.transform.position);
        var targetAngle = -Mathf.Atan2(targetPosLocal.x, targetPosLocal.z) * Mathf.Rad2Deg - 90;
        transform.eulerAngles = new Vector3(0, 0, targetAngle + 90);
    }
}
