using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class NpcLeavingState : NpcBaseState
{
    public Animator NpcAnim;

    public override void EnterState(NpcStateManager npc)
    {
        NpcAnim = npc.GetComponentInChildren<Animator>();
    }

    public override void UpdateState(NpcStateManager npc)
    {
        NpcAnim.SetBool("IsWalking", true);
        NpcAnim.SetBool("IsSitting", true);

        NavMeshAgent navMeshAgent = npc.GetComponent<NavMeshAgent>();
        Vector3 newTarget = npc.furnitureManager.door.transform.position;
        navMeshAgent.SetDestination(newTarget);

    }

    public override void OnCollisionEnter(NpcStateManager npc, Collision collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            npc.SwitchState(npc.injuredState);
        }

        if (collision.gameObject.CompareTag("Door"))
        {
            //object.Destroy(this.gameObject);
            npc.hasLeft = true;
            Debug.Log("die");
        }
    }
}
