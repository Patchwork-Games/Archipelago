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
	private Stack<GameObject> energiesTotal = null;
	private int maxNumOfEnergies = 0;
	private int currentNumOfEnergies = 0;
	private Vector3 lastEnergyPos = Vector3.zero;
	private bool energyBarHasUpdated = false;
	public bool EnergyBarIsEmpty { get; private set; } = false;

	private void Start()
	{
		// Initialise the starting amount of energies
		AddEnergies(numOfEnergiesToStartWith);
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.G))
		{
			AddEnergies(1);
		}

		// Check if the bar has been updated at all
		if (energyBarHasUpdated)
		{
			energyBarHasUpdated = false;


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
			newEnergy.transform.localPosition = lastEnergyPos + offsetBetweenEnergyIcons;

			energiesTotal.Push(newEnergy);
		}
	}

	public void UseEnergies(int amount)
	{
		// If the energy bar isn't empty then decrease the energies by the amount
		if (!EnergyBarIsEmpty)
		{
			currentNumOfEnergies -= amount;

		}
	}
}
