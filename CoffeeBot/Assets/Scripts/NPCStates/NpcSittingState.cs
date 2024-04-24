using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class NpcSittingState : NpcBaseState
{
    public Animator NpcAnim;
    private GameObject currentChair;
    private Transform ChairSit;

    bool isSitting;


    public float FlipForce = 1f;
    public float FlipForceRot = 1f;
    private CoffeeOrder coffeeOrder;

    public override void EnterState(NpcStateManager npc)
    {
        isSitting = false;
        //assign the animator of the npc
        NpcAnim = npc.GetComponentInChildren<Animator>();

        //assign the total chairs in the room to the list of gameObjects created
        npc.furnitureManager.SetChairs();

        //trigger the animation of the Npc
        NpcAnim.SetBool("IsWalking", true);
        
        //set up the nav mesh of the Npc, and assign it a chair to move towards
        NavMeshAgent navMeshAgent = npc.GetComponent<NavMeshAgent>();
        currentChair = npc.furnitureManager.chairs[Random.Range(1, 12)]; 
        Vector3 newTarget = currentChair.transform.position;
        navMeshAgent.enabled = true;
        navMeshAgent.SetDestination(newTarget);

        //assign the transform of the center of the chair, for when the Npc sits down
        ChairSit = currentChair.transform.Find("SittingPoint");
        Debug.Log(ChairSit);

        

    }

    public override void UpdateState(NpcStateManager npc)
    {
        Component[] boxColliders = currentChair.GetComponents(typeof(BoxCollider));
        NavMeshAgent navMeshAgent = npc.GetComponent<NavMeshAgent>();
        
        if (currentChair.GetComponent<ChairTest>().isSittable == false)
        {
            NpcAnim.SetBool("IsWalking", true);
            NpcAnim.SetBool("IsSitting", false);
            npc.SwitchState(npc.wanderState);          
        }

        if (navMeshAgent.enabled == true && navMeshAgent.remainingDistance < 1f)
        {

            if (currentChair.GetComponent<ChairTest>().isTaken == false)
            {
                //if chair is available, sit down
                navMeshAgent.enabled = false;

                isSitting = true;
                NpcAnim.SetBool("IsWalking", false);
                NpcAnim.SetBool("IsSitting", true);
                SetAllCollidersStatus(false);
                npc.transform.parent = currentChair.transform;
                npc.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
                npc.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;



                npc.transform.position = new Vector3(ChairSit.position.x, npc.transform.position.y, ChairSit.position.z);
                npc.transform.rotation = currentChair.transform.rotation;
                
                currentChair.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;

                
            }
            else if(currentChair.GetComponent<ChairTest>().isTaken == true && isSitting == false && navMeshAgent.enabled == true)
            {
                //if chair is taken, find new chair
                navMeshAgent.enabled = true;
                currentChair = npc.furnitureManager.chairs[Random.Range(1, 12)];
                ChairSit = currentChair.transform.Find("SittingPoint");
                Vector3 newTarget = currentChair.transform.position;               
                navMeshAgent.SetDestination(newTarget);           
            }
            
        }
        else
        {
            //NpcAnim.SetBool("IsWalking", true);
            NpcAnim.SetBool("IsSitting", false);
            //navMeshAgent.enabled = true;

        }
    }

    public override void OnCollisionEnter(NpcStateManager npc, Collision collision)
    {
        coffeeOrder = GameObject.FindGameObjectWithTag("NPC").GetComponent<CoffeeOrder>();
        /*if (collision.gameObject.layer == LayerMask.NameToLayer("Floor"))
        {
            npc.SwitchState(npc.injuredState);
        }*/

        if (collision.gameObject.CompareTag("Player"))
        {
            npc.transform.parent = null;
            npc.SwitchState(npc.injuredState);
            currentChair.GetComponent<BoxCollider>().enabled = true;        
            currentChair.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            npc.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("Interactables") && collision.gameObject.GetComponent<Interactable>().isMoving)
        {
            npc.transform.parent = null;
            npc.SwitchState(npc.injuredState);
            currentChair.GetComponent<BoxCollider>().enabled = true;
            currentChair.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            npc.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

        }
        if (collision.gameObject.CompareTag("SlipperyFloor"))
        {
            npc.GetComponent<NavMeshAgent>().enabled = false;
            
            Vector3 FlipDir = npc.transform.TransformDirection(Vector3.forward);

            npc.GetComponent<Rigidbody>().AddForce(Vector3.up * FlipForce, ForceMode.Impulse);
            npc.GetComponent<Rigidbody>().AddForce(Vector3.left * FlipForce, ForceMode.Impulse);
            npc.GetComponent<Rigidbody>().AddTorque(FlipDir * FlipForceRot, ForceMode.Impulse);
            npc.SwitchState(npc.injuredState);
        }


    } 

    public void SetAllCollidersStatus(bool active)
    {
        foreach(BoxCollider boxCollider in currentChair.GetComponents<BoxCollider>())
        {
            boxCollider.enabled = active;
        }
    }
}
