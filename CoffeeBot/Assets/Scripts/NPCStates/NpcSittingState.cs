using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class NpcSittingState : NpcBaseState
{
    public Animator NpcAnim;
    private GameObject currentChair;

    bool isSitting;
    
    public override void EnterState(NpcStateManager npc)
    {
        isSitting = false;
        NpcAnim = npc.GetComponentInChildren<Animator>();
        npc.furnitureManager.SetChairs();
        NpcAnim.SetBool("IsWalking", true);
        
        NavMeshAgent navMeshAgent = npc.GetComponent<NavMeshAgent>();
        currentChair = npc.furnitureManager.chairs[Random.Range(1, 12)];
        Vector3 newTarget = currentChair.transform.position;
        navMeshAgent.enabled = true;
        navMeshAgent.SetDestination(newTarget);



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
                navMeshAgent.enabled = false;

                isSitting = true;
                NpcAnim.SetBool("IsWalking", false);
                NpcAnim.SetBool("IsSitting", true);
                SetAllCollidersStatus(false);
                npc.transform.parent = currentChair.transform;
                npc.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
                npc.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;



                npc.transform.position = new Vector3(currentChair.transform.position.x, npc.transform.position.y, currentChair.transform.localPosition.z);
                npc.transform.rotation = currentChair.transform.rotation;
                
                currentChair.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;

                
            }
            else if(currentChair.GetComponent<ChairTest>().isTaken == true && isSitting == false && navMeshAgent.enabled == true)
            {
                navMeshAgent.enabled = true;
                currentChair = npc.furnitureManager.chairs[Random.Range(1, 12)];
                Vector3 newTarget = currentChair.transform.position;               
                navMeshAgent.SetDestination(newTarget);
                //if chair is taken, find new chair
            }
            
        }
        else
        {
            NpcAnim.SetBool("IsWalking", true);
            NpcAnim.SetBool("IsSitting", false);
            //navMeshAgent.enabled = true;

        }
    }

    public override void OnCollisionEnter(NpcStateManager npc, Collision collision)
    {
        
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
        if (collision.gameObject.layer == LayerMask.NameToLayer("Interactables") && collision.gameObject.GetComponent<InteractableTest>().isMoving)
        {
            npc.transform.parent = null;
            npc.SwitchState(npc.injuredState);
            currentChair.GetComponent<BoxCollider>().enabled = true;
            currentChair.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            npc.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

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
