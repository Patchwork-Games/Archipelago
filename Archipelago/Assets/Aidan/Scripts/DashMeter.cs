using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DashMeter : MonoBehaviour
{
	[SerializeField] private GameObject iconPrefab = null;
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
	private Color iconColour = Color.white;
	private float elapsedRechargeTime = 0f;
	private float elapsedTimeBetweenUseAndRecharge = 0f;
	private bool isRecharging = false;
	private float dashRechargeTimeDecrement = 0f;

	// Public variables
	public bool DashBarIsEmpty { get; private set; } = false;

	private void Start()
	{
		// Set the icon colour
		iconColour = iconPrefab.GetComponent<Image>().color;

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
				Debug.Log("Recharging");
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
			GameObject newEnergy = GameObject.Instantiate(iconPrefab, this.transform);
			if (newEnergy)
			{
				newEnergy.transform.localPosition = lastDashPos + offsetBetweenEnergyIcons;
				dashesTotal.Add(newEnergy);
			}
			else
			{
				Debug.Log("Failed to spawn new dash slot!");
			}

			// Set the last dash position to the new dash we just spawned
			lastDashPos = newEnergy.transform.localPosition;
		}

		// Set the current number of dashes to the max
		ResetDashMeter();
	}

	public void AddTemporaryDashes(int amount)
	{
		// Initialise the new energies and put them onto the list
		for (int i = 0; i < amount; i++)
		{
			GameObject newEnergy = GameObject.Instantiate(iconPrefab, this.transform);
			if (newEnergy)
			{
				newEnergy.transform.localPosition = lastDashPos + offsetBetweenEnergyIcons;
				dashesTotal.Add(newEnergy);
			}
			else
			{
				Debug.Log("Failed to spawn new dash slot!");
			}

			// Set the last dash position to the new dash we just spawned
			lastDashPos = newEnergy.transform.localPosition;
		}

		// Set the current number of dashes to the max
		ResetDashMeter();
	}

	public void UseDash()
	{
		// If the dash bar isn't empty then decrease the dashes by the amount
		if (!DashBarIsEmpty)
		{
			// Use the currentNumOfDashes to find out which dash should be depleted
			Color newColour = iconColour;
			newColour.a = alphaValueOfUsedDashes;
			Debug.Log("Num of Dashes: " + currentNumOfDashes);
			Debug.Log("Max Dashes: " + maxNumOfDashes);
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
