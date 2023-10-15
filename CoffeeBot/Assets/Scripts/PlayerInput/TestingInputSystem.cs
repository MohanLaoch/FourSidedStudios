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
    public float NewArmpos = 0.4f;
    public float OldArmPos = 0.1f;


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

    private void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
     
    }
    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("pickup");
        }
        float Move = playerInputActions.Player.Movement.ReadValue<float>();

        float RotDirection = playerInputActions.Player.Rotate.ReadValue<float>();
        float Speed = 5f;
        float RotSpeed = 200f;


        transform.Translate(0, 0, Speed * Move * Time.deltaTime);
        transform.Rotate(Vector3.up * Time.deltaTime * RotSpeed * RotDirection);
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
 
   
   

    public void ArmRaise(InputAction.CallbackContext context)
    {
       

        if (context.performed && !ArmsRaised)
        {
            Debug.Log("Armraised" + context.phase);
            Arms.position = new Vector3(Arms.transform.position.x, 0.8f, Arms.transform.position.z);
            ArmsRaised = true;
        }
        else if (context.performed && ArmsRaised)
        {
            Arms.position = new Vector3(Arms.transform.position.x, 0.2f, Arms.transform.position.z);
            ArmsRaised = false;
        }

    }
}
