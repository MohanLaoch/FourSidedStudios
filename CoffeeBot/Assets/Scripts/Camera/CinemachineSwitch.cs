using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class CinemachineSwitch : MonoBehaviour
{
    [SerializeField]
    private InputAction action;

    [SerializeField]
    private CinemachineVirtualCamera vcam1; //follow

    [SerializeField]
    private CinemachineVirtualCamera vcam2; //overview

    private bool followCamera = true;

    public Camera camera;

    private void OnEnable()
    {
        action.Enable();
    }

    private void OnDisable()
    {
        action.Disable();
    }

    void Start()
    {
        action.performed += ctx => SwitchPriority();

    }

    private void SwitchPriority()
    {
        if (followCamera)
        {
            vcam1.Priority = 0;
            vcam2.Priority = 1;
            camera.orthographic = true;
        }
        else
        {
            vcam1.Priority = 1;
            vcam2.Priority = 0;
            camera.orthographic = false;
        }
        followCamera = !followCamera;
    }
}
