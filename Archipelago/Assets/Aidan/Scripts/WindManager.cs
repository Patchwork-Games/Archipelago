using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindManager : MonoBehaviour
{
	public Vector3 windDirection = Vector3.zero;
	public Vector3 windDirectionRight = Vector3.zero;
	public float windForce = 10f;

	private void Start()
	{
		windDirectionRight = Vector3.Cross(windDirection, new Vector3(0,1,0));
	}
}
