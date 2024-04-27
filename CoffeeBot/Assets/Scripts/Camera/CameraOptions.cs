using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using Cinemachine;

public class CameraOptions : MonoBehaviour, IDataPersistence
{
    [SerializeField]
    private InputAction action;

    public CinemachineVirtualCamera followCamera;

    bool locked = true;

    [Header("Slider")]
    
    public int hSense/* = 125*/;
    public int vSense/* = 125*/;

    public Slider hSenseSlider;
    public Slider vSenseSlider;


    void Start()
    {
        //Set Cursor to not be visible
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.lockState = CursorLockMode.Confined;

        action.performed += ctx => LockVerticalAxis();

        followCamera.GetCinemachineComponent<CinemachinePOV>().m_VerticalAxis.m_MaxValue = 40;
        followCamera.GetCinemachineComponent<CinemachinePOV>().m_VerticalAxis.m_MinValue = 40;

        SetSlider();
    }

    void SetSlider()
    {
        hSenseSlider.maxValue = 250;
        hSenseSlider.minValue = 50;

        vSenseSlider.maxValue = 250;
        vSenseSlider.minValue = 50;

        hSenseSlider.value = hSense;
        vSenseSlider.value = vSense;
    }

    private void OnEnable()
    {
        action.Enable();
    }

    private void OnDisable()
    {
        action.Disable();
    }

    public void LockVerticalAxis()
    {
        if (locked)
        {
            followCamera.GetCinemachineComponent<CinemachinePOV>().m_VerticalAxis.m_MaxValue = 90;
            followCamera.GetCinemachineComponent<CinemachinePOV>().m_VerticalAxis.m_MinValue = 10;
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

        followCamera.GetCinemachineComponent<CinemachinePOV>().m_HorizontalAxis.m_MaxSpeed = hSenseSlider.value;
        followCamera.GetCinemachineComponent<CinemachinePOV>().m_VerticalAxis.m_MaxSpeed = vSenseSlider.value;

    }
    public void SaveData(GameData data)
    {
        data.hSense = hSenseSlider.value;
        data.vSense = vSenseSlider.value;
    }

    public void LoadData(GameData data)
    {
        hSenseSlider.value = data.hSense;
        vSenseSlider.value = data.vSense;
    }


}
