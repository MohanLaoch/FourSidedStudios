using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestingInputSystem : MonoBehaviour
{
    public Animator PlayerAnim;
    public float FlipForce = 2.5f;
    public float FlipForceRot = 5f;

    public event EventHandler OnInteractAction;
    
    public PlayerInput playerInput;
    private PlayerInputActions playerInputActions;




    [SerializeField] private LayerMask interactablesLayerMask;

    private bool isMoving;
    void Start()
    {

    }



    public Transform HoldArea;
    


    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
        playerInputActions.Player.Interact.started += Interact_started;
        playerInputActions.Player.Interact.performed += Interact_performed;
        
    }

    private void Interact_started(InputAction.CallbackContext obj)
    {
        
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

  
    public bool IsMoving()
    {
        return isMoving;
    }

   

    public void Interact_performed(InputAction.CallbackContext obj)
    {
        
        
       OnInteractAction?.Invoke(this, EventArgs.Empty);
        
        switch (obj.phase)
        {
         
            case InputActionPhase.Performed:
                Debug.Log(obj.interaction + " - Performed");
                break;
            case InputActionPhase.Started:
                Debug.Log(obj.interaction + " - Started");
                break;        
            case InputActionPhase.Canceled:
                Debug.Log(obj.interaction + " - Canceled");                
                break;
                
            
        }
    }

    
 
   
}
