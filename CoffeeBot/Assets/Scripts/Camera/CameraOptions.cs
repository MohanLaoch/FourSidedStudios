using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using Cinemachine;

public class CameraOptions : MonoBehaviour
{
    [SerializeField]
    private InputAction action;

    public CinemachineVirtualCamera followCamera;

    bool locked = true;

    [Header("Slider")]

    
    public int speed = 120;

    public Slider senseSlider;


    void Start()
    {
        //Set Cursor to not be visible
        Cursor.visible = false;

        action.performed += ctx => LockVerticalAxis();

        followCamera.GetCinemachineComponent<CinemachinePOV>().m_VerticalAxis.m_MaxValue = 40;
        followCamera.GetCinemachineComponent<CinemachinePOV>().m_VerticalAxis.m_MinValue = 40;

        SetSlider();
    }

    void SetSlider()
    {
        senseSlider.maxValue = 200;
        senseSlider.minValue = 10;

        senseSlider.value = speed;
    }

    private void OnEnable()
    {
        action.Enable();
    }

    private void OnDisable()
    {
        action.Disable();
    }

    private void LockVerticalAxis()
    {
        if (locked)
        {
            followCamera.GetCinemachineComponent<CinemachinePOV>().m_VerticalAxis.m_MaxValue = 80;
            followCamera.GetCinemachineComponent<CinemachinePOV>().m_VerticalAxis.m_MinValue = 15;
            locked = false;
        }
        else
        {
            followCamera.GetCinemachineComponent<CinemachinePOV>().m_VerticalAxis.m_MaxValue = 40;
            followCamera.GetCinemachineComponent<CinemachinePOV>().m_VerticalAxis.m_MinValue = 40;
            locked = true;
        }
        return; //this might not need to be here
    }

    void Update()
    {

        followCamera.GetCinemachineComponent<CinemachinePOV>().m_HorizontalAxis.m_MaxSpeed = senseSlider.value;
        followCamera.GetCinemachineComponent<CinemachinePOV>().m_VerticalAxis.m_MaxSpeed = senseSlider.value;

    }
}
