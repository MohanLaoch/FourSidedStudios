using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class NpcSittingState : NpcBaseState
{
    public Animator NpcAnim;

    public override void EnterState(NpcStateManager npc)
    {

        NpcAnim = npc.GetComponentInChildren<Animator>();
        npc.furnitureManager.SetChairs();
        NpcAnim.SetBool("IsWalking", true);
        
        NavMeshAgent navMeshAgent = npc.GetComponent<NavMeshAgent>();
        Vector3 newTarget = npc.furnitureManager.chairs[Random.Range(1, 12)].transform.position;
        navMeshAgent.SetDestination(newTarget);



    }

    public override void UpdateState(NpcStateManager npc)
    {
        Debug.Log("hello from the sitting state");
        NavMeshAgent navMeshAgent = npc.GetComponent<NavMeshAgent>();

        if (npc.furnitureManager.isSittable == false)
        {
            npc.SwitchState(npc.wanderState);
            Debug.Log("wandering");
        }

        if (navMeshAgent.remainingDistance < 1f)
        {
            NpcAnim.SetBool("IsWalking", false);
            //navMeshAgent.isStopped = true;
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
    }
}
