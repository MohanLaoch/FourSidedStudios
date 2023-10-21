using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private TestingInputSystem testingInputSystem;

    [SerializeField] private LayerMask interactablesLayerMask;
    [SerializeField] private PlayerInputActions playerInputActions;
    [SerializeField] private PlayerInput playerInput;


    public Transform Arms;
    public Transform StartArms;
    public Transform EndArms;
    public float Speed;
    public float moveSpeed = 5f;
    public float FlipForce = 5f;
    public float FlipForceRot = 5f;
    public Rigidbody rb;


    public bool Holding;
   



    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();

        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
        rb = GetComponent<Rigidbody>();
        playerInputActions.Player.Flip.performed += Flip;


    }


    void Start()
    {
        testingInputSystem.OnInteractAction += TestingInputSystem_OnInteractAction;

    }

    private void TestingInputSystem_OnInteractAction(object sender, System.EventArgs e)
    {
        float interactDistance = 1.5f;

        Vector3 moveDir = transform.TransformDirection(Vector3.forward);

        Debug.DrawRay(transform.position, moveDir, Color.green);
        if (Physics.Raycast(transform.position, moveDir, out RaycastHit raycastHit, interactDistance, interactablesLayerMask))
        {
            Debug.Log(raycastHit.transform);

            if (raycastHit.transform.TryGetComponent(out InteractableTest interactableTest) && Holding == false)
            {
                interactableTest.Interact();
                Holding = true;
            }
            else
            {
                interactableTest.Drop();
                Holding = false;
            }
        }
    }

    void Update()
    {
        HandleMovement();
        HandleInteractions();
    }

    private void HandleInteractions()
    {
        /*float interactDistance = 1.5f;

        Vector3 moveDir = transform.TransformDirection(Vector3.forward);

        Debug.DrawRay(transform.position, moveDir, Color.green);
        if (Physics.Raycast(transform.position, moveDir, out RaycastHit raycastHit, interactDistance, interactablesLayerMask))
        {
            Debug.Log(raycastHit.transform);

            if (raycastHit.transform.TryGetComponent(out InteractableTest interactableTest))
            {
                interactableTest.Interact();
            }
        }*/
    }

    private void HandleMovement()
    {
        float Move = testingInputSystem.GetMovementFloat();
        Vector2 RotDirection = testingInputSystem.GetRotVector();
        float Speed = 5f;
        float RotSpeed = 200f;

        transform.Translate(0, 0, Speed * Move * Time.deltaTime);
        transform.Rotate(Vector3.up * Time.deltaTime * RotSpeed * RotDirection);

    }

    public void Flip(InputAction.CallbackContext context)
    {
        Vector3 FlipDir = transform.TransformDirection(Vector3.forward);
        if (context.performed)
        {
            Debug.Log("ermwhattheflip" + context.phase);
            rb.AddForce(Vector3.up * FlipForce, ForceMode.Impulse);
            rb.AddTorque(FlipDir * FlipForceRot, ForceMode.Impulse);
        }

    }



}
