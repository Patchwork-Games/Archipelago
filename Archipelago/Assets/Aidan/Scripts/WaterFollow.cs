using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterFollow : MonoBehaviour
{
	[SerializeField] private Vector2 offsetFromPlayer = Vector2.zero;

	private void Update()
	{
		if (PlayerStateMachine.Instance.state != PlayerStateMachine.PlayerState.BOAT)
		{
			transform.position = new Vector3(
				StaticValueHolder.PlayerObject.transform.position.x + offsetFromPlayer.x,
				transform.position.y,
				StaticValueHolder.PlayerObject.transform.position.z + offsetFromPlayer.y
				);
		}
		else
		{
			transform.position = new Vector3(
				StaticValueHolder.BoatObject.transform.position.x + offsetFromPlayer.x,
				transform.position.y,
				StaticValueHolder.BoatObject.transform.position.z + offsetFromPlayer.y
				);
		}
	}
}
