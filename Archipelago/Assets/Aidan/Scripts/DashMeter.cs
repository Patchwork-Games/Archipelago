using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DashMeter : MonoBehaviour
{
	[SerializeField] private GameObject iconPrefab = null;
	[SerializeField] private Vector3 offsetBetweenEnergyIcons = Vector3.zero;
	[SerializeField] private Vector3 iconBarStartPos = Vector3.zero;
	[SerializeField] private int numOfEnergiesToStartWith = 1;
	[SerializeField] private float energyRechargeTime = 1f;
	[SerializeField] private float minEnergyRechargeTime = .1f;
	[SerializeField] private float timeBetweenUseAndRecharge = 2f;
	[SerializeField] private float alphaValueOfUsedEnergies = .3f;
	private List<GameObject> energiesTotal = new List<GameObject>();
	private int maxNumOfEnergies = 0;
	private int currentNumOfEnergies = 0;
	private Vector3 lastEnergyPos = Vector3.zero;
	private bool energyBarHasUpdated = false;
	private Color iconColour = Color.white;
	private float elapsedRechargeTime = 0f;
	private float elapsedTimeBetweenUseAndRecharge = 0f;
	private bool isRecharging = false;
	private float energyRechargeTimeDecrement = 0f;

	// Public variables
	public bool EnergyBarIsEmpty { get; private set; } = false;

	private void Start()
	{
		// Set the icon colour
		iconColour = iconPrefab.GetComponent<Image>().color;

		// Set up the first position to spawn at
		lastEnergyPos = iconBarStartPos - offsetBetweenEnergyIcons;

		// Initialise the starting amount of energies
		AddEnergies(numOfEnergiesToStartWith);

		energyRechargeTimeDecrement = energyRechargeTime;
	}

	private void Update()
	{
		// TEST CODE:
		{
			if (Input.GetKeyDown(KeyCode.G))
			{
				AddEnergies(1);
			}

			if (Input.GetKeyDown(KeyCode.F))
			{
				UseEnergies(1);
			}
		}

		// Check if the bar has been updated at all
		if (energyBarHasUpdated)
		{
			energyBarHasUpdated = false;

			for (int i = 0; i < maxNumOfEnergies; i++)
			{
				Color newColor = iconColour;
				newColor.a = alphaValueOfUsedEnergies;
				energiesTotal[i].GetComponent<Image>().color = newColor;
			}

			for (int i = 0; i < currentNumOfEnergies; i++)
			{
				energiesTotal[i].GetComponent<Image>().color = iconColour;
			}
		}

		// Countdown to start recharging
		if (elapsedTimeBetweenUseAndRecharge > 0)
		{
			elapsedTimeBetweenUseAndRecharge -= Time.deltaTime;
			if (elapsedTimeBetweenUseAndRecharge <= 0)
			{
				isRecharging = true;
				currentNumOfEnergies++;
				elapsedRechargeTime = energyRechargeTime;
				energyRechargeTimeDecrement = energyRechargeTime;
			}
		}

		// Recharge an energy every x amount of seconds
		if (isRecharging && currentNumOfEnergies < maxNumOfEnergies)
		{
			if (elapsedRechargeTime > 0)
			{
				// Update the alpha value of the energy
				Color newColour = iconColour;
				newColour.a = 1 - (elapsedRechargeTime / energyRechargeTime);
				energiesTotal[currentNumOfEnergies - 1].GetComponent<Image>().color = newColour;   // This is using the currentNumOfEnergies istead of currentNumOfEnergies + 1 as the list starts at 0.

				elapsedRechargeTime -= Time.deltaTime;
				if (elapsedRechargeTime <= 0)
				{
					elapsedRechargeTime = energyRechargeTimeDecrement;
					energyRechargeTimeDecrement -= .05f;
					if (energyRechargeTimeDecrement <= minEnergyRechargeTime)
					{
						energyRechargeTimeDecrement = minEnergyRechargeTime;
					}

					// Update the alpha value of the energy
					newColour.a = 1;
					energiesTotal[currentNumOfEnergies].GetComponent<Image>().color = newColour;   // This is using the currentNumOfEnergies istead of currentNumOfEnergies + 1 as the list starts at 0.

					currentNumOfEnergies++;
				}

			}
		}

		// If the number of energies is greater than 0 then the energy bar isn't empty
		if (currentNumOfEnergies > 0)
		{
			EnergyBarIsEmpty = false;
		}
	}

	public void AddEnergies(int amount)
	{
		// Increase the max number of energies
		maxNumOfEnergies += amount;

		// Set the current number of energies to the max
		currentNumOfEnergies = maxNumOfEnergies;

		// Initialise the new energies and put them onto the list
		for (int i = 0; i < amount; i++)
		{
			GameObject newEnergy = GameObject.Instantiate(iconPrefab, this.transform);
			if (newEnergy)
			{
				newEnergy.transform.localPosition = lastEnergyPos + offsetBetweenEnergyIcons;
				energiesTotal.Add(newEnergy);
			}
			else
			{
				Debug.Log("Failed to spawn new enegy slot!");
			}

			// Set the last energy position to the new energy we just spawned
			lastEnergyPos = newEnergy.transform.localPosition;
		}

		energyBarHasUpdated = true;
	}

	public void UseEnergies(int amount)
	{
		// If the energy bar isn't empty then decrease the energies by the amount
		if (!EnergyBarIsEmpty)
		{
			// Use the current number of energies to find out which energy should be depleted
			Color newColour = iconColour;
			newColour.a = alphaValueOfUsedEnergies;
			energiesTotal[currentNumOfEnergies - 1].GetComponent<Image>().color = newColour;

			// Decrement the number of energies active
			currentNumOfEnergies -= amount;
			if (currentNumOfEnergies <= 0)
			{
				EnergyBarIsEmpty = true;
			}

			// Update the energy bar set recharging back to false and reset the time between use and recharge
			energyBarHasUpdated = true;
			isRecharging = false;
			elapsedTimeBetweenUseAndRecharge = timeBetweenUseAndRecharge;
		}

	}
}
