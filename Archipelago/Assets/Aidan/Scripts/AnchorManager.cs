using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnchorManager : MonoBehaviour
{
	[SerializeField] private GameObject boatObject = null;
	private Transform originalParent = null;
	private Vector3 offsetFromBoat = Vector3.zero;

	private void Awake()
	{
		originalParent = transform.parent;
	}

	private void OnEnable()
	{
		transform.parent = originalParent;
		transform.position += offsetFromBoat;
	}

	private void OnDisable()
	{
		transform.parent = boatObject.transform.parent;
	}
}
