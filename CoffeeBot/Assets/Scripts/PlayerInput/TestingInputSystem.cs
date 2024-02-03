using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestingInputSystem : MonoBehaviour
{

    public PlayerInput playerInput;
    private PlayerInputActions playerInputActions;
    public event EventHandler OnInteractAction;


    void Start()
    {
      
    }



    public Transform HoldArea;
    


    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();

        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
        playerInputActions.Player.Interact.performed += Interact_performed;
    }


    public float GetMovementFloat()
    {
        float MoveFloat = playerInputActions.Player.Movement.ReadValue<float>();

        return MoveFloat;
    }

    public float GetRotFloat()
    {
        float RotDirection = playerInputActions.Player.Rotate.ReadValue<float>();

        return RotDirection;
    }

    public void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnInteractAction?.Invoke(this, EventArgs.Empty);
        
    }
 
  
}
