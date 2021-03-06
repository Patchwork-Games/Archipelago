﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootprintPlacer : MonoBehaviour
{
    private GameObject footL = null;
    private GameObject footR = null;
    private ObjectPooling spawner = null;
    [SerializeField] private float sandHeight = 33.0f;
    [SerializeField] private GameObject footPrintSpawnerPrefab = null;
    [Range(0.0f, 1f)] [SerializeField] private float randomFootStepPitch = 0f;

    public enum GroundType
    {
        SAND = 0,
        GRASS = 1
    }
    public static GroundType groundType = GroundType.SAND;

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
        //check if on ground
        RaycastHit hit;
        if (
                Physics.Raycast(transform.position, -Vector3.up, out hit, 
                StaticValueHolder.PlayerMovementScript.distanceGround + 
                StaticValueHolder.PlayerMovementScript.groundDistance, 
                StaticValueHolder.PlayerMovementScript.groundMask
            ))
        {
            // Play landing sound
            switch (hit.transform.gameObject.layer)
            {
                case 16: //Sand
                    {
                        if (transform.position.y < sandHeight)
                        {
                            // Change to beach ambient track
                            if (groundType != GroundType.SAND)
                            {
                                groundType = GroundType.SAND;
                                MusicAndAmbientManager.Instance.ChangeAmbientTrack(MusicAndAmbientManager.AmbientTrack.BEACH);
                            }

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
                            // Change to the forest track
                            if (groundType != GroundType.GRASS)
                            {
                                groundType = GroundType.GRASS;
                                MusicAndAmbientManager.Instance.ChangeAmbientTrack(MusicAndAmbientManager.AmbientTrack.FOREST);
                            }

                            // Play grass step noise
                            grassStepNoise.pitch = 1 + Random.Range(-randomFootStepPitch / 2f, randomFootStepPitch / 2f);
                            grassStepNoise.Play();
                        }
                        break;
                    }
                case 23: //rock
                    {
                        // Play rock step noise
                        grassStepNoise.pitch = 1 + Random.Range(-randomFootStepPitch / 2f, randomFootStepPitch / 2f);
                        grassStepNoise.Play();
                        break;
                    }
                default: //normal landing sound
                    {
                        break;
                    }
            }
        }
    }


    public void PlaceFootprintRight()
    {
        //check if on ground
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -Vector3.up, out hit, StaticValueHolder.PlayerMovementScript.distanceGround + StaticValueHolder.PlayerMovementScript.groundDistance, StaticValueHolder.PlayerMovementScript.groundMask))
        {
            // Play landing sound
            switch (hit.transform.gameObject.layer)
            {
                case 16: //normal ground
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
                        break;
                    }
                case 23: //rock
                    {
                        // Play rock step noise
                        grassStepNoise.pitch = 1 + Random.Range(-randomFootStepPitch / 2f, randomFootStepPitch / 2f);
                        grassStepNoise.Play();
                        break;
                    }
                default: //normal landing sound
                    {
                        break;
                    }
            }
        }
    }

}
