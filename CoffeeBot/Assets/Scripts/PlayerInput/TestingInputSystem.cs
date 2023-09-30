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
}
