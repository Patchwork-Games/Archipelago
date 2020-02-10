using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnchorManager : MonoBehaviour
{
	[SerializeField] private GameObject boatObject = null;
	[SerializeField]private Vector3 offsetFromBoat = Vector3.zero;
	private Transform originalParent = null;

	private void Awake()
	{
		originalParent = transform.parent;
	}

	private void OnEnable()
	{
		transform.parent = originalParent;
		transform.position = boatObject.transform.position + offsetFromBoat;
	}

	private void OnDisable()
	{
		transform.parent = boatObject.transform.parent;
	}
}
