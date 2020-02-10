using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouyGateTrigger : MonoBehaviour
{
	[SerializeField] private Transform firstBouy = null, secondBouy = null;
	[SerializeField] private LayerMask layerMask = 0;
	[SerializeField] private float resetTime = 3f;
	[SerializeField] private float dashForce = 20f;
	private bool boatHasCrossedLine = false;
	private float elapsedResetTime = 0f;

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
}
