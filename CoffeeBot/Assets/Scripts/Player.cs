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
    public Transform RayZone;
    public BoxCollider boxCollider;

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

        Debug.DrawRay(RayZone.transform.position, moveDir, Color.green);
        if (Physics.Raycast(RayZone.transform.position, moveDir, out RaycastHit raycastHit, interactDistance, interactablesLayerMask))
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
       /* float interactDistance = 1.5f;

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
        if (context.performed && IsGrounded())
        {
            Debug.Log("ermwhattheflip" + context.phase);
            rb.AddForce(Vector3.up * FlipForce, ForceMode.Impulse);
            rb.AddTorque(FlipDir * FlipForceRot, ForceMode.Impulse);
        }

    }

    private bool IsGrounded()
    {
        
        float extraHeight = 0.1f;
        RaycastHit raycastHit;
        Ray ray = new Ray(boxCollider.bounds.center, Vector3.down);

        Physics.Raycast(boxCollider.bounds.center, Vector3.down, boxCollider.bounds.extents.y + extraHeight);

        Color rayColor;

        if (Physics.Raycast(ray, out raycastHit, boxCollider.bounds.extents.y + extraHeight))
        {
            Debug.DrawRay(boxCollider.bounds.center, Vector2.down * (boxCollider.bounds.extents.y + extraHeight));
            rayColor = Color.green;
            return true;
        }
        else
        {
            Debug.DrawRay(boxCollider.bounds.center, Vector2.down * (boxCollider.bounds.extents.y + extraHeight));
            rayColor = Color.red;
            return false;
        }

     

        
        
    }


}
