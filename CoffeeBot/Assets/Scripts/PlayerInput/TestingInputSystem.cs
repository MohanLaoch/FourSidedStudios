using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestingInputSystem : MonoBehaviour
{
    
    public float FlipForce = 2.5f;
    public float FlipForceRot = 5f;
    private Vector3 lastInteractionDir;

    public event EventHandler OnInteractAction;
    public PlayerInput playerInput;
    private PlayerInputActions playerInputActions;

    public Transform Arms;
    public Transform StartArms;
    public Transform EndArms;
    public float Speed;
    public float moveSpeed = 5f;
    private float startTime;
    private float journeyLength;

    [SerializeField] private LayerMask interactablesLayerMask;

    private bool isMoving;
    void Start()
    {
        startTime = Time.time;
        journeyLength = Vector3.Distance(StartArms.position, EndArms.position);
        

    }



    public Transform HoldArea;
    public bool ArmsRaised = false;


    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();

        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
        playerInputActions.Player.Interact.performed += Interact_performed;
        playerInputActions.Player.ArmRaise.performed += ArmRaise;


    }


    public float GetMovementFloat()
    {
        float MoveFloat = playerInputActions.Player.Movement.ReadValue<float>();

        return MoveFloat;
    }

    public Vector2 GetRotVector()
    {
        Vector2 RotDirection = playerInputActions.Player.Rotate.ReadValue<Vector2>();

        return RotDirection;
    }

  
    public bool IsMoving()
    {
        return isMoving;
    }

   

    public void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnInteractAction?.Invoke(this, EventArgs.Empty);
        

    }
 
   void ArmRising()
    {
        float distCovered = (Time.time - startTime) * Speed;
        float fractionOfJourney = distCovered / journeyLength;
        Arms.transform.position = Vector3.Slerp(StartArms.position, EndArms.position, fractionOfJourney);

    }

    void ArmLowering()
    {
        float distCovered = (Time.time - startTime) * Speed;
        float fractionOfJourney = distCovered / journeyLength;
        Arms.transform.position = Vector3.Slerp(EndArms.position, StartArms.position, fractionOfJourney);

    }


    public void ArmRaise(InputAction.CallbackContext context)
    {
       

        if (context.performed && !ArmsRaised)
        {
            Debug.Log("Armraised" + context.phase);
            ArmsRaised = true;
            ArmRising();

        }
        else if (context.performed && ArmsRaised)
        {
            ArmsRaised = false;
            ArmLowering();
        }

    }
}
