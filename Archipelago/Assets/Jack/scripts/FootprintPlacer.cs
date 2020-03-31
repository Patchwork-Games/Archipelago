using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootprintPlacer : MonoBehaviour
{
    private GameObject footL = null;
    private GameObject footR = null;
    private ObjectPooling spawner = null;
    [SerializeField] private float sandHeight = 33.0f;
    [SerializeField] private GameObject footPrintSpawnerPrefab = null;
    [Range(0.0f, 1f)]
    [SerializeField] private float randomFootStepPitch = 0f;

    // Audio
    private AudioSource sandStepNoise = null;
    private AudioSource grassStepNoise = null;

    private void Awake()
    {
        #region Audio

        // Sand step noise
        sandStepNoise = transform.Find("Audio").Find("SandStepNoise").GetComponent<AudioSource>();
        if (sandStepNoise == null)
        {
            Debug.Log("Missing SandStepNoise child on object: " + transform.Find("Audio").gameObject);
        }

        // Grass step noise
        grassStepNoise = transform.Find("Audio").Find("GrassStepNoise").GetComponent<AudioSource>();
        if (grassStepNoise == null)
        {
            Debug.Log("Missing GrassStepNoise child on object: " + transform.Find("Audio").gameObject);
        }


        #endregion
    }

	private void Start()
    {
        footL = gameObject.transform.GetChild(0).GetChild(3).GetChild(0).GetChild(1).GetChild(0).GetChild(0).GetChild(0).gameObject;
        footR = gameObject.transform.GetChild(0).GetChild(3).GetChild(0).GetChild(2).GetChild(0).GetChild(0).GetChild(0).gameObject;

        // Spawn the footprint spawner
        GameObject spawnerObject = Instantiate(footPrintSpawnerPrefab, Vector3.zero, Quaternion.identity);
        spawner = spawnerObject.GetComponent<ObjectPooling>();
    }




    public void PlaceFootprintLeft()
    {
        if (transform.position.y < sandHeight)
        {
            // Play sand step noise
            sandStepNoise.pitch = 1 + Random.Range(-randomFootStepPitch / 2f, randomFootStepPitch / 2f);
            sandStepNoise.Play();

            GameObject newFootPrint = spawner.RetrieveInstance();
            if (newFootPrint != null)
            {
                newFootPrint.transform.parent = spawner.transform;
                newFootPrint.transform.position = footL.transform.position;
                newFootPrint.transform.rotation = Quaternion.Euler(90, transform.rotation.eulerAngles.y, 0);
            }
        }
        else
        {
            // Play grass step noise
            grassStepNoise.pitch = 1 + Random.Range(-randomFootStepPitch / 2f, randomFootStepPitch / 2f);
            grassStepNoise.Play();
        }
       
    }


    public void PlaceFootprintRight()
    {
        if (transform.position.y < sandHeight)
        {
            // Play sand step noise
            sandStepNoise.pitch = 1 * (1 + Random.Range(-randomFootStepPitch / 2f, randomFootStepPitch / 2f));
            sandStepNoise.Play();

            GameObject newFootPrint = spawner.RetrieveInstance();
            if (newFootPrint != null)
            {
                newFootPrint.transform.parent = spawner.transform;
                newFootPrint.transform.position = footR.transform.position;
                newFootPrint.transform.rotation = Quaternion.Euler(90, transform.rotation.eulerAngles.y, 0);
            }
        }
        else
        {
            // Play grass step noise
            grassStepNoise.pitch = 1 + Random.Range(-randomFootStepPitch / 2f, randomFootStepPitch / 2f);
            grassStepNoise.Play();
        }
    }

}
