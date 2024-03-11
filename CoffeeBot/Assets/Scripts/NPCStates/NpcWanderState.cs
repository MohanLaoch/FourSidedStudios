using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NpcWanderState : NpcBaseState
{
    public float wanderRadius = 3f;
    public float wanderTimer = 3f;

    private Transform target;
    private NavMeshAgent agent;
    private float timer;
    public Animator NpcAnim;
    public override void EnterState(NpcStateManager npc)
    {
        NpcAnim = npc.GetComponentInChildren<Animator>();
        agent = npc.GetComponent<NavMeshAgent>();
        timer = wanderTimer;
        agent.isStopped = false;

    }

    public override void UpdateState(NpcStateManager npc)
    {
        Debug.Log("wandering");
        timer += Time.deltaTime;

        if (timer >= wanderTimer)
        {
            Vector3 newPos = RandomNavSphere(npc.transform.position, wanderRadius, -1);
            agent.SetDestination(newPos);
            timer = 0;
        }

        if (agent.remainingDistance < 0.5)
        {
            NpcAnim.SetBool("IsWalking", false);
        }
        else
        {
            NpcAnim.SetBool("IsWalking", true);

        }
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        
        Vector3 randDirection = Random.insideUnitSphere * dist;

        randDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;
    }

    public override void OnCollisionEnter(NpcStateManager npc, Collision collision)
    {
        /*if (collision.gameObject.layer == LayerMask.NameToLayer("Floor"))
        {
            npc.SwitchState(npc.injuredState);
            
        }*/

        if(collision.gameObject.CompareTag("Player"))
        {
            npc.SwitchState(npc.injuredState);
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("Interactables") && collision.gameObject.GetComponent<InteractableTest>().isMoving == true)
        {
            Debug.Log("boomtown");
            npc.SwitchState(npc.injuredState);
        }
    }
}
