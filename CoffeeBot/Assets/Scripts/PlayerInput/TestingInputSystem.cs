using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestingInputSystem : MonoBehaviour
{
    public Rigidbody rb;
    public float FlipForce = 5f;
    public float FlipForceRot = 5f;


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
        rb = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();

        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
        playerInputActions.Player.Flip.performed += Flip;
        playerInputActions.Player.Interact.performed += Interact;
        playerInputActions.Player.ArmRaise.performed += ArmRaise;
        




    }


    /*public Vector2 GetMovementVectorNormalized()
    {
        Vector2 inputVector = playerInputActions.Player.Movement.ReadValue<Vector2>();

        inputVector = inputVector.normalized;


        return inputVector;
    }*/

  

    private void Update()
    {
        HandleInteraction();
        // Vector2 inputVector = GetMovementVectorNormalized();
        // Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);
        //  transform.position += moveDir * moveSpeed * Time.deltaTime;

        //  isMoving = moveDir != Vector3.zero;


        //Vector3 MoveDir = Vector3.forward;
        float Move = playerInputActions.Player.Movement.ReadValue<float>();
        Vector2 RotDirection = playerInputActions.Player.Rotate.ReadValue<Vector2>();
        float Speed = 5f;
        float RotSpeed = 200f;

       // transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * RotSpeed);
        transform.Translate(0, 0, Speed * Move * Time.deltaTime);
        transform.Rotate(Vector3.up * Time.deltaTime * RotSpeed * RotDirection);

        float playerSize = 0.7f;
       // bool canMove = !Physics.Raycast(transform.position, MoveDir, playerSize);

        /*if(canMove)
        {
            transform.position += MoveDir * Speed * Time.deltaTime;
        }*/
    }

    private void HandleInteraction()
    {
        float interactDistance = 4f;

        Vector3 moveDir = transform.TransformDirection(Vector3.forward);

        Debug.DrawRay(transform.position, moveDir, Color.green);
        if(Physics.Raycast(transform.position, moveDir, out RaycastHit raycastHit, interactDistance))
        {
            Debug.Log(raycastHit.transform);
        }
        else
        {
            Debug.Log("-");
        }
    

    }
    public bool IsMoving()
    {
        return isMoving;
    }

    public void Flip(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("ermwhattheflip" + context.phase);
            rb.AddForce(Vector3.up * FlipForce, ForceMode.Impulse);
            rb.AddTorque(Vector3.forward * FlipForceRot, ForceMode.Impulse);
        }

    }

    public void Interact(InputAction.CallbackContext context)
    {

        OnInteractAction?.Invoke(this, EventArgs.Empty);



        if (context.performed && ArmsRaised)
        {
            Debug.Log("Interact" + context.phase);
            
        }

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
