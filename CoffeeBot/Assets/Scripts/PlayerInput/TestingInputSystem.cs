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

    public PlayerInput playerInput;
    private PlayerInputActions playerInputActions;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();

        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
        playerInputActions.Player.Flip.performed += Flip;
        


    }

    private void FixedUpdate()
    {
        Vector2 inputVectorMove = playerInputActions.Player.Movement.ReadValue<Vector2>();

        Vector2 inputVectorRotate = playerInputActions.Player.Rotate.ReadValue<Vector2>();
        float Speed = 10f;
        float RotSpeed = 5f;
       
        rb.AddForce(new Vector3(inputVectorMove.x, 0, inputVectorMove.y) * Speed, ForceMode.Force);
        rb.AddTorque(new Vector3(inputVectorRotate.x, 0, inputVectorRotate.y) * RotSpeed, ForceMode.Force);
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
}
