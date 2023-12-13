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
    public float Speed = 5f;
    public float OgSpeed = 2f;
    public float FlipForce = 5f;
    public float FlipForceRot = 5f;
    public float RotSpeed = 50f;
    public float MaxSpeed = 7f;
    public float Acceleration = 2f;
    public Rigidbody rb;
    public Transform RayZone;
    public BoxCollider boxCollider;

    public bool Holding;
    public bool isMoving = false;

    public Vector3 boxSize;
    public float maxDistance;
    public LayerMask layermask;


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
        
        
       // HandleInteractions();
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
        float RotDirection = testingInputSystem.GetRotFloat();

        


            rb.MovePosition(transform.position + (transform.forward * Move) * Speed * Time.fixedDeltaTime);
            if (Move != 0)
            {
                isMoving = true;
            }
            else
            {
                isMoving = false;
            }


            if (isMoving)
            {


                Speed += Acceleration * Time.fixedDeltaTime;
                if (Speed >= MaxSpeed)
                {
                    Speed = MaxSpeed;
                    Debug.Log("SLOW DOWN JACKASS");
                }
            }
            else
            {
                Speed = OgSpeed;
            }
        

            var rotationVelocity = new Vector3(0, RotSpeed * RotDirection, 0);

        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotationVelocity * Time.deltaTime));
    }

    public void Flip(InputAction.CallbackContext context)
    {
        if (Holding)
        {
            return;
        }

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

     //gonna do some outloud thinking here to see if it helps, i need to not be moving if the player is flipped on their side, but this ground check needs to be able to work when the player is on all sides
     //i could make a new ground check specifically so the player cant move, which would be a copy paste of this but idk exactly what to change about it that makes the raycast stay going straight down and not flip with the player
     //i could create an OnSide() bool that checks if the player is on any side that isnt the normal orientation          
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(transform.position -transform.up * maxDistance, boxSize);
    }
    private bool WheelsGrounded()
    {
        if (Physics.BoxCast(transform.position, boxSize, -transform.up, transform.rotation, maxDistance, layermask))
        {
            Debug.Log("wheelsonground");
            return true;

        }
        else
        {
            return false;
        }
    }

     public void UpgradeSpeed()
     {
        MaxSpeed++;
     }

    public void UpgradeHandling()
     {
        RotSpeed += 50;
     }

    public void UpgradeAcceleration()
     {
        Acceleration += 5;
     }











}
