using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnchorManager : MonoBehaviour
{
	[SerializeField]private Vector3 offsetFromBoat = Vector3.zero;
	private Transform originalParent = null;
	private bool isPosSet = false;

	private void Awake()
	{
		originalParent = transform.parent;
	}

	private void OnEnable()
	{
		transform.parent = originalParent;
		isPosSet = false;
		transform.rotation = Quaternion.identity;
	}

	public void TakeInAnchor()
	{
		transform.parent = StaticValueHolder.BoatObject.transform;
		transform.localPosition = offsetFromBoat;
		isPosSet = false;
	}

	private void Update()
	{
		if (!isPosSet)
		{
			isPosSet = true;
			transform.position = StaticValueHolder.BoatObject.transform.position + offsetFromBoat;
		}
	}
}
