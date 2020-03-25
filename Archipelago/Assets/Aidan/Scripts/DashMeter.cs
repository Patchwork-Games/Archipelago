using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DashMeter : MonoBehaviour
{
	[SerializeField] private GameObject dashIconPrefab = null;
	[SerializeField] private GameObject temporaryDashIconPrefab = null;
	[SerializeField] private Vector3 offsetBetweenEnergyIcons = Vector3.zero;
	[SerializeField] private Vector3 iconBarStartPos = Vector3.zero;
	[SerializeField] private int numOfDashesToStartWith = 1;
	[SerializeField] private float dashRechargeTime = 1f;
	[SerializeField] private float minDashRechargeTime = .1f;
	[SerializeField] private float timeBetweenUseAndRecharge = 2f;
	[SerializeField] private float alphaValueOfUsedDashes = .3f;
	private List<GameObject> dashesTotal = new List<GameObject>();
	private List<GameObject> temporaryDashes = new List<GameObject>();
	private int maxNumOfDashes = 0;
	private int currentNumOfDashes = 0;
	private Vector3 lastDashPos = Vector3.zero;
	private Vector3 lastTempDashPos = Vector3.zero;
	private Color iconColour = Color.white;
	private float elapsedRechargeTime = 0f;
	private float elapsedTimeBetweenUseAndRecharge = 0f;
	private bool isRecharging = false;
	private float dashRechargeTimeDecrement = 0f;
	private int numOfTempDashes = 0;

	// Public variables
	public bool DashBarIsEmpty { get; private set; } = false;

	private void Start()
	{
		// Set the icon colour
		iconColour = dashIconPrefab.GetComponent<Image>().color;

		// Set up the first position to spawn at
		lastDashPos = iconBarStartPos - offsetBetweenEnergyIcons;

		// Initialise the starting amount of energies
		AddDashes(numOfDashesToStartWith);

		dashRechargeTimeDecrement = dashRechargeTime;

        GetComponent<Canvas>().enabled = false;
    }

	private void Update()
	{
		// TEST CODE:
		{
			if (Input.GetKeyDown(KeyCode.G))
			{
				AddDashes(1);
			}
		}

		// Countdown to start recharging
		if (elapsedTimeBetweenUseAndRecharge > 0)
		{
			elapsedTimeBetweenUseAndRecharge -= Time.deltaTime;
			if (elapsedTimeBetweenUseAndRecharge <= 0)
			{
				isRecharging = true;
				elapsedRechargeTime = dashRechargeTime;
				dashRechargeTimeDecrement = dashRechargeTime;


				if (currentNumOfDashes < maxNumOfDashes)
				{
					currentNumOfDashes++;
				}
			}
		}

		// Recharge an energy every x amount of seconds
		if (isRecharging && currentNumOfDashes <= maxNumOfDashes)
		{
			if (elapsedRechargeTime > 0)
			{
				// Update the alpha value of the dash icon
				Color newColour = iconColour;
				newColour.a = 1 - (elapsedRechargeTime / dashRechargeTime);
				dashesTotal[currentNumOfDashes - 1].GetComponent<Image>().color = newColour;

				elapsedRechargeTime -= Time.deltaTime;
				if (elapsedRechargeTime <= 0)
				{
					// This makes the time to recharge quicker for every dash left 
					elapsedRechargeTime = dashRechargeTimeDecrement;
					dashRechargeTimeDecrement -= .05f;
					if (dashRechargeTimeDecrement <= minDashRechargeTime)
					{
						dashRechargeTimeDecrement = minDashRechargeTime;
					}

					// Update the alpha value of the energy
					newColour.a = 1;
					dashesTotal[currentNumOfDashes - 1].GetComponent<Image>().color = newColour;

					// Check if we haven't already fully recharged
					if (currentNumOfDashes < maxNumOfDashes)
					{
						currentNumOfDashes++;
					}
					else
					{
						isRecharging = false;
					}
				}
			}
		}

		// If the number of energies is greater than 0 then the energy bar isn't empty
		if (currentNumOfDashes > 0)
		{
			DashBarIsEmpty = false;
		}
		else
		{
			DashBarIsEmpty = true;
		}
	}

	public void AddDashes(int amount)
	{
		// Increase the max number of dashes
		maxNumOfDashes += amount;

		// Initialise the new energies and put them onto the list
		for (int i = 0; i < amount; i++)
		{
			GameObject newDashIcon = GameObject.Instantiate(dashIconPrefab, this.transform);
			if (newDashIcon)
			{
				newDashIcon.transform.localPosition = lastDashPos + offsetBetweenEnergyIcons;
				dashesTotal.Add(newDashIcon);

				// Check if temporary dashes are active
				if (temporaryDashes.Count > 0)
				{
					// Move the dashes over by one
					foreach (var dash in temporaryDashes)
					{
						dash.transform.position += offsetBetweenEnergyIcons;
					}

					// Set the last position to be one over from where it was before
					lastTempDashPos = temporaryDashes[temporaryDashes.Count - 1].transform.position;
				}
			}
			else
			{
				Debug.Log("Failed to spawn new dash slot!");
			}

			// Set the last dash position to the new dash we just spawned
			lastDashPos = newDashIcon.transform.localPosition;
		}

		// Set the current number of dashes to the max
		ResetDashMeter();
	}

	public void AddTemporaryDashes(int amount)
	{
		// If there aren't any temp dashes already, then the lastTempDashPos should be equal to the last dash pos
		if (numOfTempDashes <= 0)
		{
			numOfTempDashes = 0;
			lastTempDashPos = lastDashPos;
		}

		// Increase the number of temp dashes
		numOfTempDashes += amount;

		// Initialise the new energies and put them onto the list
		for (int i = 0; i < amount; i++)
		{
			GameObject newDashIcon = GameObject.Instantiate(temporaryDashIconPrefab, this.transform);
			if (newDashIcon)
			{
				newDashIcon.transform.localPosition = lastTempDashPos + offsetBetweenEnergyIcons;
				temporaryDashes.Add(newDashIcon);
			}
			else
			{
				Debug.Log("Failed to spawn new dash slot!");
			}

			// Set the last dash position to the new dash we just spawned
			lastTempDashPos = newDashIcon.transform.localPosition;
		}

		// Set the current number of dashes to the max
		ResetDashMeter();
	}

	public void UseDash()
	{
		// Check if the meter has temp dashes to be used
		if (numOfTempDashes > 0)
		{
			Destroy(temporaryDashes[numOfTempDashes - 1]);
			temporaryDashes.RemoveAt(numOfTempDashes - 1);
			numOfTempDashes--;
		}
		else if (!DashBarIsEmpty) // If the dash bar isn't empty then decrease the dashes by the amount
		{
			// Use the currentNumOfDashes to find out which dash should be depleted
			Color newColour = iconColour;
			newColour.a = alphaValueOfUsedDashes;
			dashesTotal[currentNumOfDashes - 1].GetComponent<Image>().color = newColour;

			// Decrement the number of energies active
			currentNumOfDashes--;
			if (currentNumOfDashes <= 0)
			{
				currentNumOfDashes = 0;
				DashBarIsEmpty = true;
			}

			// Update the energy bar set recharging back to false and reset the time between use and recharge
			UpdateIcons();
			isRecharging = false;
			elapsedTimeBetweenUseAndRecharge = timeBetweenUseAndRecharge;
		}
	}

	public void ResetDashMeter()
	{
		// Set the current number of energies to the max
		isRecharging = false;
		elapsedTimeBetweenUseAndRecharge = 0f;
		elapsedRechargeTime = 0f;
		currentNumOfDashes = maxNumOfDashes;
		UpdateIcons();
	}

	private void UpdateIcons()
	{
		for (int i = 0; i < maxNumOfDashes; i++)
		{
			Color newColor = iconColour;
			newColor.a = alphaValueOfUsedDashes;
			dashesTotal[i].GetComponent<Image>().color = newColor;
		}

		for (int i = 0; i < currentNumOfDashes; i++)
		{
			dashesTotal[i].GetComponent<Image>().color = iconColour;
		}
	}
}
