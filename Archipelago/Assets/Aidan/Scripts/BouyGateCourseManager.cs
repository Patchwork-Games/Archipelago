﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouyGateCourseManager : MonoBehaviour
{
	[SerializeField] private Material goldBouyMat = null;
	[SerializeField] private DashMeter dashMeter = null;
	[SerializeField] private Transform boatTransform = null;
	[SerializeField] private float distanceToResetCourseAt = 100f;
	private GameObject startingLine = null;
	private bool isMiniGameActive = false;
	private bool isStateSet = false;
	private int numOfCheckpoints = 0;
	private int nextCheckPoint = 0;
	private bool onLastCheckpoint = false;

	enum BouyGateCourseState
	{
		ANTI_CLOCKWISE = 0,
		CLOCKWISE = 1,
		NOT_ACTIVE = 2,
		COMPLETE = 3,
		NUM_STATES = 4
	}
	private BouyGateCourseState state = BouyGateCourseState.NOT_ACTIVE;

	private void Awake()
	{
		// Get the starting line
		startingLine = transform.GetChild(0).gameObject;
		if (startingLine == null)
		{
			Debug.Log("StartingLine is null in BoatGateCourseManagerScript!");
		}

		// Get the number of checkpoints on the course
		numOfCheckpoints = transform.childCount;
	}

	private void Update()
	{
		// Check if the boat has crossed the starting line
		if (startingLine.GetComponent<BouyGateTrigger>().BoatHasCrossedLine && !isMiniGameActive && state != BouyGateCourseState.COMPLETE)
		{
			startingLine.GetComponent<BouyGateTrigger>().BoatHasCrossedLine = false;

			// Start the minigame
			isMiniGameActive = true;

			// Reset all bouy triggers
			foreach(Transform t in transform)
			{
				t.GetComponent<BouyGateTrigger>().BoatHasCrossedLine = false;
			}

			// Set the starting bouy to have a gold material
			startingLine.GetComponent<BouyGateTrigger>().SetBouyMaterial(goldBouyMat);

		}

		// If the mini game has started next we need to check if the player is going clockwise or anti-clockwise
		if (isMiniGameActive && !isStateSet)
		{
			if (transform.GetChild(1).GetComponent<BouyGateTrigger>().BoatHasCrossedLine)
			{
				transform.GetChild(1).GetComponent<BouyGateTrigger>().SetBouyMaterial(goldBouyMat);
				state = BouyGateCourseState.CLOCKWISE;
				nextCheckPoint = 2;
				isStateSet = true;
			}
			else if(transform.GetChild(numOfCheckpoints - 1).GetComponent<BouyGateTrigger>().BoatHasCrossedLine)
			{
				transform.GetChild(numOfCheckpoints - 1).GetComponent<BouyGateTrigger>().SetBouyMaterial(goldBouyMat);
				state = BouyGateCourseState.ANTI_CLOCKWISE;
				nextCheckPoint = numOfCheckpoints - 2;
				isStateSet = true;
			}
		}

		// If the state is set work out which checkpoint is next
		if (isStateSet)
		{
			// If the distance between the next bouy gate and the boat is too great reset the course
			if (state == BouyGateCourseState.ANTI_CLOCKWISE || state == BouyGateCourseState.CLOCKWISE)
			{
				if (nextCheckPoint > 0 && nextCheckPoint < numOfCheckpoints)
				{
					if (Vector3.Distance(boatTransform.position, transform.GetChild(nextCheckPoint).transform.position) >= distanceToResetCourseAt)
					{
						ResetCourse();
					}
				}
			}

			switch (state)
			{
				case BouyGateCourseState.ANTI_CLOCKWISE:
					{
						if (nextCheckPoint > 0 && !onLastCheckpoint)
						{
							if (transform.GetChild(nextCheckPoint).GetComponent<BouyGateTrigger>().BoatHasCrossedLine)
							{
								transform.GetChild(nextCheckPoint).GetComponent<BouyGateTrigger>().SetBouyMaterial(goldBouyMat);
								nextCheckPoint--;

								if (nextCheckPoint == 0)
								{
									onLastCheckpoint = true;
								}
							}

						}
						else
						{
							nextCheckPoint = 0;
							if (transform.GetChild(nextCheckPoint).GetComponent<BouyGateTrigger>().BoatHasCrossedLine)
							{
								// Course has been complete
								state = BouyGateCourseState.COMPLETE;
							}
						
						}
					}
					break;
				case BouyGateCourseState.CLOCKWISE:
					{
						if (nextCheckPoint < numOfCheckpoints && !onLastCheckpoint)
						{
							if (transform.GetChild(nextCheckPoint).GetComponent<BouyGateTrigger>().BoatHasCrossedLine)
							{
								transform.GetChild(nextCheckPoint).GetComponent<BouyGateTrigger>().SetBouyMaterial(goldBouyMat);
								nextCheckPoint++;

								if (nextCheckPoint == numOfCheckpoints)
								{
									onLastCheckpoint = true;
								}
							}

						}
						else
						{
							nextCheckPoint = 0;
							if (transform.GetChild(nextCheckPoint).GetComponent<BouyGateTrigger>().BoatHasCrossedLine)
							{
								Debug.Log("Course Complete!");
								// Course has been complete
								state = BouyGateCourseState.COMPLETE;
							}
						}
					}
					break;
				case BouyGateCourseState.NOT_ACTIVE:
					{
						isStateSet = false;
					}
					break;
				case BouyGateCourseState.COMPLETE:
					{
						// Give the player another energy node on their energy bar and set the state set and minigame active to false
						dashMeter.AddEnergies(1);
						isStateSet = false;
						isMiniGameActive = false;
						onLastCheckpoint = false;

						// Reset all the materials of the bouys
						foreach (Transform t in transform)
						{
							t.GetComponent<BouyGateTrigger>().ResetMaterials();
						}
					}
					break;
				default:
					isStateSet = false;
					break;
			}
		}
	}

	private void ResetCourse()
	{
		// Reset all the materials of the bouys
		foreach (Transform t in transform)
		{
			t.GetComponent<BouyGateTrigger>().ResetMaterials();
		}

		isStateSet = false;
		isMiniGameActive = false;
		onLastCheckpoint = false;
	}

}