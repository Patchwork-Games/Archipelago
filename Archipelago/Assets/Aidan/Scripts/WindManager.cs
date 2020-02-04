using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindManager : MonoBehaviour
{
	public static WindManager Instance { get; private set; }
	public Vector3 windDirection = Vector3.zero;
	public float windForce = 10f;

	private void Awake()
	{
		// Makes sure that this is the only instance of this object in the scene
		if (Instance != null)
		{
			if (Instance != this)
			{
				Destroy(this.gameObject);
			}
		}
		else
		{
			Instance = this;
		}
	}
}
