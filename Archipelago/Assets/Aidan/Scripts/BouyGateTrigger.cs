using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouyGateTrigger : MonoBehaviour
{
	[SerializeField] private Transform firstBouy = null, secondBouy = null;
	[SerializeField] private LayerMask layerMask = 0;
	[SerializeField] private float resetTime = 3f;
	[SerializeField] private float dashForce = 20f;
	private Material originalFirstBouyMat = null;
	private Material originalSecondBouyMat = null;
	private float elapsedResetTime = 0f;
	private bool boatHasCrossedLine = false;
	public bool BoatHasCrossedLine { get { return boatHasCrossedLine; } set { boatHasCrossedLine = value; } }

	private void Awake()
	{
		originalFirstBouyMat = firstBouy.GetChild(0).GetComponent<MeshRenderer>().material;
		originalSecondBouyMat = secondBouy.GetChild(0).GetComponent<MeshRenderer>().material;
	}

	private void Update()
	{
		// If the boat hasn't crossed the line yet ray cast between the bouys
		if (!boatHasCrossedLine)
		{
			// Cast a ray between the two bouys and check if the boat intersects that ray
			RaycastHit hit;
			if (Physics.Linecast(firstBouy.transform.position, secondBouy.transform.position, out hit, layerMask))
			{
				if (hit.transform.CompareTag("Boat"))
				{
					Debug.Log("Boat has crossed the line!");
					boatHasCrossedLine = true;
					elapsedResetTime = resetTime;
					hit.transform.gameObject.GetComponent<BoatController>().AddImpulse(dashForce);
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
		firstBouy.GetChild(0).GetComponent<MeshRenderer>().material = mat;
		secondBouy.GetChild(0).GetComponent<MeshRenderer>().material = mat;
	}

	public void ResetMaterials()
	{
		firstBouy.GetChild(0).GetComponent<MeshRenderer>().material = originalFirstBouyMat;
		secondBouy.GetChild(0).GetComponent<MeshRenderer>().material = originalSecondBouyMat;
	}
}
