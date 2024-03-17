using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class NpcLeavingState : NpcBaseState
{
    public Animator NpcAnim;
    public float FlipForce = 1f;
    public float FlipForceRot = 1f;
    public override void EnterState(NpcStateManager npc)
    {
        NpcAnim = npc.GetComponentInChildren<Animator>();
    }

    public override void UpdateState(NpcStateManager npc)
    {
        NpcAnim.SetBool("IsWalking", true);
        NpcAnim.SetBool("IsSitting", false);

        NavMeshAgent navMeshAgent = npc.GetComponent<NavMeshAgent>();
        Vector3 newTarget = npc.furnitureManager.door.transform.position;
        navMeshAgent.SetDestination(newTarget);

    }

    public override void OnCollisionEnter(NpcStateManager npc, Collision collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            npc.SwitchState(npc.injuredState);
            npc.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

        }

        if (collision.gameObject.CompareTag("Door"))
        {
            //object.Destroy(this.gameObject);
            npc.hasLeft = true;
            Debug.Log("die");
        }
        if (collision.gameObject.CompareTag("SlipperyFloor"))
        {
            Debug.Log("slipped");
            npc.GetComponent<NavMeshAgent>().enabled = false;

            Vector3 FlipDir = npc.transform.TransformDirection(Vector3.forward);

            npc.GetComponent<Rigidbody>().AddForce(Vector3.up * FlipForce, ForceMode.Impulse);
            npc.GetComponent<Rigidbody>().AddForce(Vector3.left * FlipForce, ForceMode.Impulse);
            npc.GetComponent<Rigidbody>().AddTorque(FlipDir * FlipForceRot, ForceMode.Impulse);
            npc.SwitchState(npc.injuredState);
        }
    }
}
