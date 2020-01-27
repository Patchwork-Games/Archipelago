using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class BoatCameraController : MonoBehaviour
{
    private InputMaster controls = null;
    private Vector2 camMoveDirection = Vector2.zero;

    private void Awake()
    {
        // Set up a new object for the controls
        controls = new InputMaster();
    }

    // Update is called once per frame
    void Update()
    {
        //Moving the camera
        {
            if (camMoveDirection.x != 0)
            {
                GetComponent<CinemachineFreeLook>().m_XAxis.m_InputAxisName = "CameraMovement";
            }
            else
            {
                GetComponent<CinemachineFreeLook>().m_XAxis.m_InputAxisName = "Mouse X";
            }

            GetComponent<CinemachineFreeLook>().m_XAxis.m_InputAxisValue = camMoveDirection.x;
        }
    }

    private void OnEnable()
    {
        // Camera Movement
        controls.Boat.CameraMovement.performed += context => camMoveDirection = context.ReadValue<Vector2>();
        controls.Boat.CameraMovement.canceled += context => camMoveDirection = context.ReadValue<Vector2>();
        controls.Boat.CameraMovement.Enable();
    }

    private void OnDisable()
    {
        // Camera Movement
        controls.Boat.CameraMovement.performed -= context => camMoveDirection = context.ReadValue<Vector2>();
        controls.Boat.CameraMovement.canceled -= context => camMoveDirection = context.ReadValue<Vector2>();
        controls.Boat.CameraMovement.Disable();
    }
}
