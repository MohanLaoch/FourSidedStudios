using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class NpcInjuredState : NpcBaseState
{
    public float maxTime = 5;
    public float currentTime;
    private bool countDown = true;
    private bool timerActive = true;

    private bool hasLimit = true;
    public float timerLimit;

    public int InjuryCounter = 0;
    public LayerMask layermask;
    public Animator Anim;
    public Transform NpcTransform;
    public Rigidbody Npcrb;
    public InteractableTest interactableTest;
    
    public Player player;
    public override void EnterState(NpcStateManager npc)
    {
        InjuryCounter++;
        NpcTransform = npc.GetComponent<Transform>();
        npc.GetComponent<NavMeshAgent>().enabled = false;
        Anim = npc.GetComponentInChildren<Animator>();
        npc.GetComponent<Rigidbody>().AddForce(Vector3.forward * 0.5f, ForceMode.Impulse);
        currentTime = maxTime;

        
    }

    public override void UpdateState(NpcStateManager npc)
    {
        NPCFlailing(npc);
    }

    public override void OnCollisionEnter(NpcStateManager npc, Collision collision)
    {

    }

    public void NPCFlailing(NpcStateManager npc)
    {
        NpcTransform = npc.GetComponent<Transform>();
        Npcrb = npc.GetComponent<Rigidbody>();
        Anim.SetBool("Fallen", true);
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        interactableTest = npc.gameObject.GetComponent<InteractableTest>();
        if(player.Holding == true)
        {
            Npcrb.transform.rotation = interactableTest.rb.transform.rotation;

        }
       


        if (timerActive)
        {
            currentTime = countDown ? currentTime -= Time.deltaTime : currentTime += Time.deltaTime;
        }

        if (hasLimit && ((countDown && currentTime <= timerLimit) || (!countDown && currentTime >= timerLimit)))
        {
            currentTime = timerLimit;
            
        }
        if (currentTime <= 0 && npc.player.Holding == true)
        {
            currentTime = maxTime;
        }

        if (currentTime <= 0 && npc.player.Holding == false)
        {
            NpcTransform.rotation = Quaternion.Euler(0, 0, 0);
            NpcTransform.position = new Vector3(NpcTransform.position.x, 2f, NpcTransform.position.z);
            Anim.SetBool("Fallen", false);


            npc.GetComponent<NavMeshAgent>().enabled = true;
            if (InjuryCounter >= 3)
            {
                npc.SwitchState(npc.leavingState);
            }
            else
            {
                npc.SwitchState(npc.wanderState);

            }
            

        }

      
        
            
        

    }
}
