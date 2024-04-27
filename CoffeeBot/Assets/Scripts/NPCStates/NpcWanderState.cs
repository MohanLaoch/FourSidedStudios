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

    public float FlipForce = 1f;
    public float FlipForceRot = 1f;

    private GameObject gumballMachine;
    //private GameObject SlipperyFloor;

    public override void EnterState(NpcStateManager npc)
    {
        gumballMachine = GameObject.FindGameObjectWithTag("GumballMachine");
        NpcAnim = npc.GetComponentInChildren<Animator>();
        agent = npc.GetComponent<NavMeshAgent>();
        timer = wanderTimer;
        agent.enabled = true;
        agent.isStopped = false;

        if(agent.height < 1.5f)
        {
            wanderRadius = 10f;
            wanderTimer = 1f;
        }
        
    }

    public override void UpdateState(NpcStateManager npc)
    {
        
        
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


        if (gumballMachine == null)
        {
            return;
        }
        else if(agent.height < 1.5f && gumballMachine.GetComponent<GumballMachine>().GumballTime)
        {
            target = gumballMachine.transform;
            agent.SetDestination(target.position);
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

        if (collision.gameObject.layer == LayerMask.NameToLayer("Interactables") && collision.gameObject.GetComponent<Interactable>().isMoving == true)
        {
            Debug.Log("boomtown");
            npc.SwitchState(npc.injuredState);
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
