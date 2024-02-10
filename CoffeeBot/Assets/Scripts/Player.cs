using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private TestingInputSystem testingInputSystem;

    [SerializeField] private LayerMask interactablesLayerMask;
    [SerializeField] private PlayerInputActions playerInputActions;
    [SerializeField] private PlayerInput playerInput;

    public Animator PlayerAnim;
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
    public MoneyTracker moneytracker;

    public bool Holding;
    public bool isMoving = false;

    public Vector3 boxSize;
    public float maxDistance;
    public LayerMask layermask;
    public bool ArmsRaised = false;

    public Storage storage;
    public Storage storage2;
    public Storage storage3;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();

        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
        rb = GetComponent<Rigidbody>();
        playerInputActions.Player.Flip.performed += Flip;
        playerInputActions.Player.ArmRaise.performed += ArmRaise;


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
                if(interactableTest.CompareTag("Storage"))
                {
                    return;
                }
                Holding = true;
                interactableTest.Interact();                
            }
            else if(storage.atStorage)
            {
                Debug.Log("storing");
                interactableTest.Store();                              
            }
            else if (storage2.atStorage)
            {
                Debug.Log("storing2");
                interactableTest.Store();
            }
            else if (storage3.atStorage)
            {
                Debug.Log("storing");
                interactableTest.Store();
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
    }



    private void HandleMovement()
    {


        
        float Move = testingInputSystem.GetMovementFloat();
        float RotDirection = testingInputSystem.GetRotFloat();

        

       // rb.MovePosition(transform.position + (transform.forward * Move) * Speed * Time.fixedDeltaTime);
       
        if (Move != 0 && IsGrounded())
        {
            isMoving = true;
            rb.velocity = (transform.forward * Move) * Speed * Time.fixedDeltaTime;
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
        if (Holding || isMoving)
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




    void ArmRising()
    {
        PlayerAnim.SetBool("ArmsRaised", true);
        PlayerAnim.SetBool("ArmsLowered", false);

    }

    void ArmLowering()
    {
        PlayerAnim.SetBool("ArmsLowered", true);
        PlayerAnim.SetBool("ArmsRaised", false);


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
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(transform.position -transform.up * maxDistance, boxSize);
    }


     public void UpgradeSpeed()
     {
        if(moneytracker.money >= 20)
        {
            moneytracker.money -= 20;
            MaxSpeed++;
        }
        else
        {
            Debug.Log("Notenoughcash");
        }
     }

    public void UpgradeHandling()
     {
        if (moneytracker.money >= 20)
        {
            moneytracker.money -= 20;
            RotSpeed += 20;
        }
        else
        {
            Debug.Log("Notenoughcash");
        }
    }

    public void UpgradeAcceleration()
     {
        if (moneytracker.money >= 20)
        {
            moneytracker.money -= 20;
            Acceleration += 5;
        }
        else
        {
            Debug.Log("Notenoughcash");
        }
    }











}
