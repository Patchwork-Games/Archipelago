using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindManager : MonoBehaviour
{
	[HideInInspector] public Vector3 windDirection = Vector3.zero;
	[HideInInspector] public Vector3 windDirectionRight = Vector3.zero;
	public float windForce = 10f;

	private void Start()
	{
		windDirection = transform.forward;
		windDirectionRight = Vector3.Cross(windDirection, new Vector3(0,1,0));
	}
}
