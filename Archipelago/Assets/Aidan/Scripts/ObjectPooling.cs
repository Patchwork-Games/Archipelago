using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
	public GameObject prefab;
	public int poolSize;

	private GameObject[] pool;

	void Start()
	{
		pool = new GameObject[poolSize];

		for (int i = 0; i < poolSize; i++)
		{
			pool[i] = (GameObject)Instantiate(prefab, transform.position, Quaternion.identity);
			pool[i].SetActive(false);
		}
	}

	public GameObject RetrieveInstance()
	{
		foreach (GameObject go in pool)
		{
			if (!go.activeSelf)
			{
				go.SetActive(true);
				return go;
			}
		}

		return null;
	}

	public void DevolveInstance(GameObject go)
	{
		go.SetActive(false);
	}

	public void DevolveAll()
	{
		foreach (GameObject go in pool)
		{
			go.SetActive(false);
		}
	}
}
