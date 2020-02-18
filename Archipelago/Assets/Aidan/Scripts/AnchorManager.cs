using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnchorManager : MonoBehaviour
{
	[SerializeField]private Vector3 offsetFromBoat = Vector3.zero;
	private Transform originalParent = null;

	private void Awake()
	{
		originalParent = transform.parent;
	}

	private void OnEnable()
	{
		transform.parent = originalParent;
		transform.position = StaticValueHolder.BoatObject.transform.position + offsetFromBoat;
		transform.rotation = Quaternion.identity;
	}

	public void TakeInAnchor()
	{
		transform.parent = StaticValueHolder.BoatObject.transform;
		transform.localPosition = offsetFromBoat;
	}
}
