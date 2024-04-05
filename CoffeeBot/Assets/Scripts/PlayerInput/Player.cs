using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using FMOD.Studio;
using TMPro;
using UnityEngine.AI;


public class Player : MonoBehaviour
{
    [SerializeField] private TestingInputSystem testingInputSystem;

    [SerializeField] private LayerMask interactablesLayerMask;
    [SerializeField] private PlayerInputActions playerInputActions;
    [SerializeField] private PlayerInput playerInput;


    private EventInstance Arms;
    private EventInstance Grabbing;
    private EventInstance PlayerMovement;


    public SceneInfo sceneInfo;
    public TextMeshProUGUI Daytext; 

    public Animator PlayerAnim;
    public float Speed = 5f;
    public float OgSpeed = 2f;
    public float DashForce = 15f;
    public float FlipForceRot = 5f;
    public float RotSpeed = 50f;
    public float MaxSpeed = 7f;
    public float Acceleration = 2f;
    public float dashCooldownTime;
    private float dashCooldownTimer;
    private bool dashIsCooldown = false;

    public Rigidbody rb;
    public Transform RayZone;
    public BoxCollider boxCollider;
    public MoneyTracker moneytracker;
    public TextMeshProUGUI MoneyText;

    public bool Holding;
    public bool HoldingNPC = false;
    public bool isMoving = false;

    public Vector3 boxSize;
    public float maxDistance;
    public LayerMask layermask;
    public bool ArmsRaised = false;

    public Storage storage;
    public Storage storage2;
    public Storage storage3;
    public Interactable interactable;

    public ThrowBar throwBar;
    
    public float ThrowForce = 2f;
    public float MaxThrowForce = 10f;
    public float ThrowChargeSpeed = 5f;
    public GameObject ObjectHeld;

    private WaitForEndOfFrame waitForEndOfFrame;

    public GameObject Skin1;
    public GameObject Skin2;
    public GameObject Skin3;
    public GameObject Skin4;
    public GameObject Skin5;

    public bool Highlighted = false;
    public GameObject boxUI;

    public GameObject GumballMachine;
    public GameObject Mop;
    public bool EPressed;
    private void Awake()
    {
        Time.timeScale = 1;
        playerInput = GetComponent<PlayerInput>();

        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
        rb = GetComponent<Rigidbody>();
        playerInputActions.Player.Flip.performed += Dash;
        playerInputActions.Player.ArmRaise.performed += ArmRaise;
        playerInputActions.Player.Throw.started += Throw;
        playerInputActions.Player.Throw.canceled += Throw;
        playerInputActions.Player.Storing.performed += Storing;



        waitForEndOfFrame = new WaitForEndOfFrame();

        switch (sceneInfo.SkinCounter)
        {
            case 1:
                 Skin1.SetActive(true);
                 break;
            case 2:
                Skin2.SetActive(true);
                break;
            case 3:
                Skin3.SetActive(true);
                break;
            case 4:
                Skin4.SetActive(true);
                break;
            case 5:
                Skin5.SetActive(true);
                break;

        }




    }


    void Start()
    {
        testingInputSystem.OnInteractAction += TestingInputSystem_OnInteractAction;

        Grabbing = AudioManager.instance.CreateInstance(FMODEvents.instance.grabSound);
        Arms = AudioManager.instance.CreateInstance(FMODEvents.instance.armRisingSound);
        PlayerMovement = AudioManager.instance.CreateInstance(FMODEvents.instance.Drive);

        Daytext.text = "Day:" + sceneInfo.dayCount.ToString("0");

        if(sceneInfo.gumballMachineUnlocked)
        {
            GumballMachine.gameObject.SetActive(true);
        }

        boxUI = GameObject.Find("NullBox");
      
    }

    private void TestingInputSystem_OnInteractAction(object sender, System.EventArgs e)
    {
        float interactDistance = 1.2f;

        Vector3 moveDir = transform.TransformDirection(Vector3.forward);

        Debug.DrawRay(RayZone.transform.position, moveDir, Color.green);
        if (Physics.Raycast(RayZone.transform.position, moveDir, out RaycastHit raycastHit, interactDistance, interactablesLayerMask))
        {
            if (raycastHit.transform.gameObject.CompareTag("Storage"))
            {
                return;
            }

            if (raycastHit.transform.TryGetComponent(out Interactable interactable) && Holding == false)
            {
                              
                    if (interactable.CompareTag("Storage"))
                    {
                        return;
                    }
                    if (interactable.CompareTag("NPC"))
                    {
                        HoldingNPC = true;
                    }
                    Holding = true;

                    ObjectHeld = interactable.gameObject;

                    interactable.Interact();
                    Grabbing.setParameterByNameWithLabel("Parameter 2", "Grab");
                    UpdateGrabSound();
                    //AudioManager.instance.PlayOneShot(FMODEvents.instance.grabSound, this.transform.position);
                    //setparameterbynamewithlabel("Parameter2, "grab");
            }




            /* else if (storage.atStorage && Holding == true)
             {
                 Debug.Log("storing1");
                 interactable.Store();
             }
             else if (storage2.atStorage && Holding == true)
             {
                 Debug.Log("storing2");
                 interactable.Store();
             }
             else if (storage3.atStorage && Holding == true)
             {
                 Debug.Log("storing3");
                 interactable.Store();
             }*/

            /*else if (storage.atStorage && Holding == false)
            {
                interactable.Interact();
            }
            else if (storage2.atStorage && Holding == false)
            {
                interactable.Interact();
            }
            else if (storage3.atStorage && Holding == false)
            {
                interactable.Interact();
            }*/
            else if (Holding)
            {
                interactable.Drop();
                Grabbing.setParameterByNameWithLabel("Parameter 2", "Drop");
                UpdateGrabSound();
                //AudioManager.instance.PlayOneShot(FMODEvents.instance.dropSound, this.transform.position);
                Holding = false;
                HoldingNPC = false;

            }


            
        }
    }

    void Update()
    {
        
        PlayerMovement.setParameterByName("PitchChange", Speed);

        HandleMovement();
        UpdateMovementSound();
        
        MaxSpeed = sceneInfo.playerSpeed;
        Acceleration = sceneInfo.playerAcceleration;
        RotSpeed = sceneInfo.playerRotSpeed;

        Debug.DrawRay(RayZone.transform.position, transform.TransformDirection(Vector3.forward), Color.green);
        if (Physics.Raycast(RayZone.transform.position, transform.TransformDirection(Vector3.forward), out RaycastHit raycastHit, 1.2f, interactablesLayerMask))
        {
            if (raycastHit.transform.TryGetComponent(out StorageBox storageBox))
            {
                boxUI = storageBox.gameObject.transform.GetChild(0).gameObject;
                Highlighted = true;

               
            }
        }
        else
        {
            Highlighted = false;
        }

        if (Highlighted)
        {
            boxUI.SetActive(true);
        }
        else
        {
            boxUI.SetActive(false);
        }

        if (dashIsCooldown)
        {
            ApplyDashCooldown();
        }
    }


    private void UpdateGrabSound()
    {

            PLAYBACK_STATE playbackState;
            Grabbing.getPlaybackState(out playbackState);
            if (playbackState.Equals(PLAYBACK_STATE.STOPPED))
            {
                Grabbing.start();
            }       
    }

    private void UpdateArmSound()
    {

        PLAYBACK_STATE playbackState;
        Grabbing.getPlaybackState(out playbackState);
        if (playbackState.Equals(PLAYBACK_STATE.STOPPED))
        {
            Arms.start();
        }
    }

    private void UpdateMovementSound()
    {
        if (isMoving)
        {
            PLAYBACK_STATE playbackState;
            PlayerMovement.getPlaybackState(out playbackState);
            if (playbackState.Equals(PLAYBACK_STATE.STOPPED))
            {
                PlayerMovement.start();

            }

        }
        else if (!isMoving)
        {
            PlayerMovement.stop(STOP_MODE.ALLOWFADEOUT);

        }
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

    public void Dash(InputAction.CallbackContext context)
    {
        if (sceneInfo.DashUnlocked)
        {


            if (isMoving || dashIsCooldown)
            {
                return;
            }

           
            if (context.performed && IsGrounded())
            {
                dashIsCooldown = true;
                dashCooldownTimer = dashCooldownTime;
                rb.AddForce(transform.forward * DashForce, ForceMode.Impulse);
                AudioManager.instance.PlayOneShot(FMODEvents.instance.Flip, this.transform.position);
            }
        }
        else
        {
            return;
        }

    }

    public void ApplyDashCooldown()
    {
        dashCooldownTimer -= Time.deltaTime;

        if(dashCooldownTimer < 0.0f)
        {
            dashIsCooldown = false;
            //play sound to indicate cooldown ended
        }

    }

    public void Storing(InputAction.CallbackContext context)
    {
        if(context.performed && GumballMachine.GetComponent<GumballMachine>().AtMachine)
        {
            EPressed = true;
        }


        if (Holding && storage.atStorage)
        {
            storage.gameObject.GetComponent<Interactable>().Store();
            return;
        }
        else if (Holding && storage2.atStorage)
        {
            storage2.gameObject.GetComponent<Interactable>().Store();
            return;
        }
        else if (Holding && storage3.atStorage)
        {
            storage3.gameObject.GetComponent<Interactable>().Store();
            return;
        }
    }

    public void Throw(InputAction.CallbackContext context)
    {
        Vector3 ThrowDir = transform.TransformDirection(Vector3.forward);
        if (context.started && Holding)
        {
            Debug.Log("start");
            StartCoroutine(HoldButtonRoutine());
        }

        if(context.canceled && Holding)
        {
            
            Debug.Log("Like rynn in a nuzlocke, you are throwing");
            ObjectHeld.GetComponent<Interactable>().Drop();
            ObjectHeld.GetComponent<Rigidbody>().AddForce(ThrowDir * ThrowForce, ForceMode.Impulse);
            ObjectHeld.GetComponent<Rigidbody>().AddForce(Vector3.up * (ThrowForce / 2), ForceMode.Impulse);
            ObjectHeld.GetComponent<Rigidbody>().AddTorque(transform.TransformDirection(Vector3.forward) * FlipForceRot, ForceMode.Impulse);

            ThrowForce = 0f;
            Holding = false;
            throwBar.SetThrow(ThrowForce);
            
        }
        IEnumerator HoldButtonRoutine()
        {
            yield return new WaitUntil(context.ReadValueAsButton);
            while (context.ReadValueAsButton())
            {
                ThrowForce += ThrowChargeSpeed * Time.fixedDeltaTime;
                throwBar.SetThrow(ThrowForce);
                yield return waitForEndOfFrame;
            }

            if (ThrowForce >= MaxThrowForce)
            {
                ThrowForce = MaxThrowForce;
            }


        }
    }

    







    void ArmRising()
    {

        Arms.setParameterByName("Parameter 1", 0);
        UpdateArmSound();
        
        //armies.setparamaterbyname("parameter1, 0);
        PlayerAnim.SetBool("ArmsRaised", true);
        PlayerAnim.SetBool("ArmsLowered", false);

    }

    void ArmLowering()
    {
        Arms.setParameterByName("Parameter 1", 1);
        UpdateArmSound();


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
        if(sceneInfo.money >= 20)
        {
            sceneInfo.money -= 20;
            MaxSpeed += 20;
            Acceleration += 20;
            sceneInfo.playerSpeed = MaxSpeed;
            sceneInfo.playerAcceleration = Acceleration;
            MoneyText.text = ": " + sceneInfo.money.ToString("0");
        }
        else
        {
            Debug.Log("Notenoughcash");
        }
     }

    public void UpgradeHandling()
     {
        if (sceneInfo.money >= 20)
        {
            sceneInfo.money -= 20;
            RotSpeed += 20;
            sceneInfo.playerRotSpeed = RotSpeed;
            //sceneInfo.money = moneytracker.money;
            MoneyText.text = ": " + sceneInfo.money.ToString("0");
        }
        else
        {
            Debug.Log("Notenoughcash");
        }
        
    }



    public void UpgradeMaxThrow()
    {
        if(sceneInfo.money >= 20)
        {
            sceneInfo.money -= 20;
            MaxThrowForce += 20;
            sceneInfo.playerMaxThrowForce = MaxThrowForce;
            //sceneInfo.money = moneytracker.money;
            MoneyText.text = ": " + sceneInfo.money.ToString("0");
        }
        else
        {
            Debug.Log("Notenoughcash");
        }
    }

    public void UnlockDash()
    {
        if (sceneInfo.DashUnlocked)
        {
            return;
        }
        if (sceneInfo.money >= 100)
        {
            sceneInfo.money -= 100;
            sceneInfo.DashUnlocked = true;
            MoneyText.text = ": " + sceneInfo.money.ToString("0");
        }
    
        
    }

    public void UnlockInstaStock()
    {
        if (sceneInfo.instaStockUnlocked)
        {
            return;
        }
        if (sceneInfo.money >= 100)
        {
            sceneInfo.money -= 100;
            sceneInfo.instaStockUnlocked = true;
            MoneyText.text = ": " + sceneInfo.money.ToString("0");
        }
        
    }

    public void UpgradeStorage()
    {

        if(sceneInfo.money >= 10)
        {
            sceneInfo.money -= 10;
            sceneInfo.storageMax++;
            MoneyText.text = ": " + sceneInfo.money.ToString("0");
        }
    }
    public void UnlockGumballMachine()
    {

        if (sceneInfo.money >= 100)
        {
            sceneInfo.money -= 100;
            sceneInfo.gumballMachineUnlocked = true;
            GumballMachine.gameObject.SetActive(true);
            MoneyText.text = ": " + sceneInfo.money.ToString("0");
        }
    }

    public void UnlockRoboMop()
    {
        if (sceneInfo.money >= 100)
        {
            sceneInfo.money -= 100;
            Mop.GetComponent<NavMeshAgent>().enabled = true;
            Mop.GetComponent<Interactable>().enabled = false;
        }
    }









}
