using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GustStreamSpawner : MonoBehaviour
{
	[SerializeField] private float minTimeToSpawn = 5f;
	[SerializeField] private float maxTimeToSpawn = 10f;
	private ObjectPooling gustStreamPool = null;
	private int numOfNodes = 0;
	private bool timeSet = false;
	private float randomSpawnTime;
	private float elapsedSpawnTime;

	private void Awake()
	{
		// Get the object pooling script attached to this object
		gustStreamPool = GetComponent<ObjectPooling>();
		if (gustStreamPool == null)
		{
			Debug.Log("No ObjectPooling script found on ");
		}

		// Get the number of nodes
		foreach(Transform t in transform)
			numOfNodes++;
	}

	// Update is called once per frame
	void Update()
    {
		// Set a time for the next gust stream to spawn randomly between 2 values
		if (!timeSet)
		{
			timeSet = true;
			randomSpawnTime = Random.Range(minTimeToSpawn, maxTimeToSpawn);
			elapsedSpawnTime = randomSpawnTime;
		}

		// Count down to spawn
		if (elapsedSpawnTime > 0)
		{
			elapsedSpawnTime -= Time.deltaTime;
			if (elapsedSpawnTime <= 0)
			{
				// The timer has ran out, spawn the gust stream
				SpawnGustStream();
				timeSet = false;
			}
		}

    }

	private void SpawnGustStream()
	{
		// Pick a random node to spawn at
		int randomNodeNum = Random.Range(0, numOfNodes - 1);

		int counter = 0;
		Transform randomNode = null;
		foreach(Transform t in transform)
		{
			if (randomNodeNum == counter)
			{
				randomNode = t;
			}
			counter++;
		}

		// Retrieve a new instance from the pool and set it's position
		GameObject newGustStream = gustStreamPool.RetrieveInstance();
		newGustStream.transform.position = randomNode.position;
	}
}
