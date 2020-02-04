using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouyGateTrigger : MonoBehaviour
{
	[SerializeField] private Transform firstBouy = null, secondBouy = null;
	[SerializeField] private LayerMask layerMask;

	private void Update()
	{
		// Cast a ray between the two bouys and check if the boat intersects that ray
		RaycastHit hit;
		if (Physics.Linecast(firstBouy.transform.position, secondBouy.transform.position, out hit, layerMask))
		{
			if (hit.transform.CompareTag("Boat"))
			{
				Debug.Log("Boat has crossed the line!");
			}
		}
	}
}
