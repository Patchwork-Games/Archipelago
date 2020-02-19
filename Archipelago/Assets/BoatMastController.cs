using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMastController : MonoBehaviour
{
	private void Update()
	{
		// Compare the wind direction vector to the boat's forward vector to determine the rotation of the mast
		if (Vector3.Dot(StaticValueHolder.WindManagerObject.windDirection, StaticValueHolder.BoatObject.transform.forward) > 0)
		{

		}
		else
		{

		}
	}
}
