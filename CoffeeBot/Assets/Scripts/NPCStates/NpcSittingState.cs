using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class NpcSittingState : NpcBaseState
{
    public Animator NpcAnim;
    private GameObject currentChair;
    bool isSitting = false;
    public override void EnterState(NpcStateManager npc)
    {
        
        NpcAnim = npc.GetComponentInChildren<Animator>();
        npc.furnitureManager.SetChairs();
        NpcAnim.SetBool("IsWalking", true);
        
        NavMeshAgent navMeshAgent = npc.GetComponent<NavMeshAgent>();
        currentChair = npc.furnitureManager.chairs[Random.Range(1, 12)];
        Vector3 newTarget = currentChair.transform.position;
        navMeshAgent.SetDestination(newTarget);

        

    }

    public override void UpdateState(NpcStateManager npc)
    {
        
        NavMeshAgent navMeshAgent = npc.GetComponent<NavMeshAgent>();
        
        if (currentChair.GetComponent<ChairTest>().isSittable == false)
        {
            npc.SwitchState(npc.wanderState);
            
        }

        if (navMeshAgent.remainingDistance < 1f)
        {
            
            
            //navMeshAgent.isStopped = true;
            if(currentChair.GetComponent<ChairTest>().isTaken == false)
            {
                isSitting = true;
                NpcAnim.SetBool("IsWalking", false);
            }
            else if(currentChair.GetComponent<ChairTest>().isTaken == true && isSitting == false)
            {
                 currentChair = npc.furnitureManager.chairs[Random.Range(1, 12)];
                 Vector3 newTarget = currentChair.transform.position;
                 navMeshAgent.SetDestination(newTarget);
                //if chair is taken, find new chair
            }
            
        }
        else
        {
            NpcAnim.SetBool("IsWalking", true);
            //navMeshAgent.isStopped = false;
            

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
            npc.SwitchState(npc.injuredState);
        }
        if(collision.gameObject.CompareTag("NPC"))
        {
            
        }

   
    }
}
