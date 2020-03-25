using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuoyGateTrigger : MonoBehaviour
{
	[SerializeField] private Transform firstBuoy = null, secondBuoy = null;
	[SerializeField] private LayerMask layerMask = 0;
	[SerializeField] private float resetTime = 3f;
	[SerializeField] private float dashForce = 1500f;
	private Material originalFirstBuoyMat = null;
	private Material originalSecondBuoyMat = null;
	private float elapsedResetTime = 0f;
	private bool boatHasCrossedLine = false;
	public bool BoatHasCrossedLine { get { return boatHasCrossedLine; } set { boatHasCrossedLine = value; } }

	private void Awake()
	{
		originalFirstBuoyMat = firstBuoy.GetComponent<MeshRenderer>().material;
		originalSecondBuoyMat = secondBuoy.GetComponent<MeshRenderer>().material;
	}

	private void Update()
	{
		// If the boat hasn't crossed the line yet ray cast between the bouys
		if (!boatHasCrossedLine)
		{
			// Cast a ray between the two bouys and check if the boat intersects that ray
			RaycastHit hit;
			if (Physics.Linecast(firstBuoy.transform.position, secondBuoy.transform.position, out hit, layerMask))
			{
				if (hit.transform.CompareTag("Boat"))
				{
					Debug.Log("Boat has crossed the line!");
					boatHasCrossedLine = true;
					elapsedResetTime = resetTime;
					StaticValueHolder.BoatObject.GetComponent<BoatController>().AddImpulse(dashForce);
				}
			}
		}
		else
		{
			// Count down for reset
			if (elapsedResetTime > 0)
			{
				elapsedResetTime -= Time.deltaTime;
				if (elapsedResetTime <= 0)
				{
					boatHasCrossedLine = false;
				}
			}
		}

	}

	public void SetBouyMaterial(Material mat)
	{
		firstBuoy.GetComponent<MeshRenderer>().material = mat;
		secondBuoy.GetComponent<MeshRenderer>().material = mat;
	}

	public void ResetMaterials()
	{
		firstBuoy.GetComponent<MeshRenderer>().material = originalFirstBuoyMat;
		secondBuoy.GetComponent<MeshRenderer>().material = originalSecondBuoyMat;
	}
}
