using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Interactable : MonoBehaviour
{
    public Rigidbody rb;
    public Transform CounterObj;
    public Transform HoldArea;
    public Animator NPCAnim;
    
    private NpcStateManager npcStateManager;
    public Storage storage;
    public bool isMoving = false;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        HoldArea = GameObject.Find("HoldArea").GetComponent<Transform>();
    }

    public void Start()
    {
        
    }
    public void Update()
    {
        if(gameObject.CompareTag("Chair") || gameObject.CompareTag("Table"))
        {
            if (rb.velocity.magnitude > 0.5 && GetComponent<NavMeshObstacle>() == true)
            {
                isMoving = true;
                GetComponent<NavMeshObstacle>().enabled = false;

            }
            else
            {
                isMoving = false;
                GetComponent<NavMeshObstacle>().enabled = true;

            }
        }
       
    }
    public void Interact()
    {

     
        
        if(gameObject.CompareTag("Chair"))
        {
            GetComponent<ChairTest>().isSittable = false;
        }

        if (gameObject.CompareTag("CoffeeBeans") || gameObject.CompareTag("Milk") || gameObject.CompareTag("CocoPowder") || gameObject.CompareTag("Water") || gameObject.CompareTag("Ice") || gameObject.CompareTag("TeaBags"))
        {
            transform.parent = HoldArea.transform;
            rb.position = HoldArea.transform.position;
            rb.constraints = RigidbodyConstraints.FreezeAll;
            rb.mass = 0;
        }

        if (gameObject.CompareTag("NPC"))
        {
            //rb.transform.rotation = Quaternion.Euler(rb.rotation.x, rb.rotation.y + 90f, rb.rotation.z - 90f);
            gameObject.GetComponent<NavMeshAgent>().enabled = false;
            npcStateManager = gameObject.GetComponent<NpcStateManager>();
            npcStateManager.SwitchState(npcStateManager.injuredState);
            rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;

            

            rb.transform.parent = HoldArea.transform;
            
            //rb.transform.position = HoldArea.transform.position;
             // gameObject.transform.position = HoldArea.transform.position;
           
           //gameObject.transform.SetPositionAndRotation(HoldArea.transform.position, Quaternion.identity);

            NPCAnim.SetBool("Fallen", true);
            //trigger flail here 
       
        }
        else
        {
            transform.parent = HoldArea.transform;
            rb.position = HoldArea.transform.position;
            rb.constraints = RigidbodyConstraints.FreezeAll;
            rb.mass = 0;
        }
 



    }



    public void Drop()
    {
        if(gameObject.CompareTag("Storage"))
        {
            return;
        }

        if (gameObject.CompareTag("Chair"))
        {
            GetComponent<ChairTest>().isSittable = true;
        }

        transform.parent = null;
        rb.constraints = RigidbodyConstraints.None;
        rb.mass = 1;

    }


    public void Store()
    {
        if(gameObject.CompareTag("Storage"))
        {           
            GetComponent<Storage>().husband = true;
        }
    }

    public void Empty()
    {

    }

}
