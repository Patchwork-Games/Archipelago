using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PoolCameraZoom : MonoBehaviour
{

    private float startRad = 0.0f;
    private float startHeight = 0.0f;

    [SerializeField] private float zoomedRad = 0.0f;
    [SerializeField] private float zoomedHeight = 0.0f;
    [SerializeField] private float timeToMove = 1.0f;
    private float currentTime = 0.0f;
    private bool moving = false;


    private void Start()
    {
        startRad = PlayerMovement.Instance.CMCamera.GetComponent<CinemachineFreeLook>().m_Orbits[0].m_Radius;
        startHeight = PlayerMovement.Instance.CMCamera.GetComponent<CinemachineFreeLook>().m_Orbits[0].m_Height;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            currentTime = 0f;
            moving = true;
            StopCoroutine("LerpIn");
            StartCoroutine("LerpOut");
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            currentTime = 0f;
            moving = true;
            StopCoroutine("LerpOut");
            StartCoroutine("LerpIn");
        }
    }






    IEnumerator LerpOut()
    {
        while (moving)
        {
            if (currentTime <= timeToMove)
            {
                currentTime += Time.deltaTime;

                Debug.Log("Time: " + currentTime);

                PlayerMovement.Instance.CMCamera.GetComponent<CinemachineFreeLook>().m_Orbits[0].m_Radius = Mathf.Lerp(startRad, zoomedRad, currentTime / timeToMove);
                PlayerMovement.Instance.CMCamera.GetComponent<CinemachineFreeLook>().m_Orbits[1].m_Radius = Mathf.Lerp(startRad, zoomedRad, currentTime / timeToMove);
                PlayerMovement.Instance.CMCamera.GetComponent<CinemachineFreeLook>().m_Orbits[2].m_Radius = Mathf.Lerp(startRad, zoomedRad, currentTime / timeToMove);

                PlayerMovement.Instance.CMCamera.GetComponent<CinemachineFreeLook>().m_Orbits[0].m_Height = Mathf.Lerp(startHeight, zoomedHeight, currentTime / timeToMove);
                PlayerMovement.Instance.CMCamera.GetComponent<CinemachineFreeLook>().m_Orbits[1].m_Height = Mathf.Lerp(startHeight, zoomedHeight, currentTime / timeToMove);
                PlayerMovement.Instance.CMCamera.GetComponent<CinemachineFreeLook>().m_Orbits[2].m_Height = Mathf.Lerp(startHeight, zoomedHeight, currentTime / timeToMove);
            }
            else
            {
                PlayerMovement.Instance.CMCamera.GetComponent<CinemachineFreeLook>().m_Orbits[0].m_Radius = zoomedRad;
                PlayerMovement.Instance.CMCamera.GetComponent<CinemachineFreeLook>().m_Orbits[1].m_Radius = zoomedRad;
                PlayerMovement.Instance.CMCamera.GetComponent<CinemachineFreeLook>().m_Orbits[2].m_Radius = zoomedRad;

                PlayerMovement.Instance.CMCamera.GetComponent<CinemachineFreeLook>().m_Orbits[0].m_Height = zoomedHeight;
                PlayerMovement.Instance.CMCamera.GetComponent<CinemachineFreeLook>().m_Orbits[1].m_Height = zoomedHeight;
                PlayerMovement.Instance.CMCamera.GetComponent<CinemachineFreeLook>().m_Orbits[2].m_Height = zoomedHeight;
                currentTime = 0f;
                moving = false;
            }
            yield return new WaitForSeconds(0.01f);
        }
    }



    IEnumerator LerpIn()
    {
        while (moving)
        {
            if (currentTime <= timeToMove)
            {
                currentTime += Time.deltaTime;

                PlayerMovement.Instance.CMCamera.GetComponent<CinemachineFreeLook>().m_Orbits[0].m_Radius = Mathf.Lerp(zoomedRad, startRad, currentTime / timeToMove);
                PlayerMovement.Instance.CMCamera.GetComponent<CinemachineFreeLook>().m_Orbits[1].m_Radius = Mathf.Lerp(zoomedRad, startRad, currentTime / timeToMove);
                PlayerMovement.Instance.CMCamera.GetComponent<CinemachineFreeLook>().m_Orbits[2].m_Radius = Mathf.Lerp(zoomedRad, startRad, currentTime / timeToMove);

                PlayerMovement.Instance.CMCamera.GetComponent<CinemachineFreeLook>().m_Orbits[0].m_Height = Mathf.Lerp(zoomedHeight, startHeight, currentTime / timeToMove);
                PlayerMovement.Instance.CMCamera.GetComponent<CinemachineFreeLook>().m_Orbits[1].m_Height = Mathf.Lerp(zoomedHeight, startHeight, currentTime / timeToMove);
                PlayerMovement.Instance.CMCamera.GetComponent<CinemachineFreeLook>().m_Orbits[2].m_Height = Mathf.Lerp(zoomedHeight, startHeight, currentTime / timeToMove);
            }
            else
            {
                PlayerMovement.Instance.CMCamera.GetComponent<CinemachineFreeLook>().m_Orbits[0].m_Radius = startRad;
                PlayerMovement.Instance.CMCamera.GetComponent<CinemachineFreeLook>().m_Orbits[1].m_Radius = startRad;
                PlayerMovement.Instance.CMCamera.GetComponent<CinemachineFreeLook>().m_Orbits[2].m_Radius = startRad;

                PlayerMovement.Instance.CMCamera.GetComponent<CinemachineFreeLook>().m_Orbits[0].m_Height = startHeight;
                PlayerMovement.Instance.CMCamera.GetComponent<CinemachineFreeLook>().m_Orbits[1].m_Height = startHeight;
                PlayerMovement.Instance.CMCamera.GetComponent<CinemachineFreeLook>().m_Orbits[2].m_Height = startHeight;
                currentTime = 0f;
                moving = false;
            }
            yield return new WaitForSeconds(0.01f);
        }
    }

}
