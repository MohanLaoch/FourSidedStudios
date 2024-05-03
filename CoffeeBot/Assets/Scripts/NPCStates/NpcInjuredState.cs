using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using FMOD.Studio;

public class NpcInjuredState : NpcBaseState
{
    public float maxTime = 8;
    public float currentTime;
    private bool countDown = true;
    private bool timerActive = true;

    private bool hasLimit = true;
    public float timerLimit;

    public int InjuryCounter = 0;

    private EventInstance fallingSound;

    public LayerMask layermask;
    public Animator Anim;
    public Transform NpcTransform;
    public Rigidbody Npcrb;
    public Interactable interactable;
    public SlipperyFloor slipperyFloor;
    public Player player;
    public TotalInjuryCounter totalInjuryCounter;
    public NavMeshAgent agent;


    public override void EnterState(NpcStateManager npc)
    {
        fallingSound = AudioManager.instance.CreateInstance(FMODEvents.instance.NPCFalling);


        Anim = npc.GetComponent<Animator>();
        agent = npc.GetComponent<NavMeshAgent>();
        /*if (agent.height < 1.5)
        {
            Anim = npc.GetComponent<Animator>();
        }*/
        npc.injureEffect.Play();
        totalInjuryCounter = GameObject.Find("InjuryManager").GetComponent<TotalInjuryCounter>();
        if(agent.height > 1.5f)
        {
            InjuryCounter++;
            totalInjuryCounter.totalInjuryCounter++;
        }

        totalInjuryCounter.Warning(); // this line was added by James
        //Debug.Log(totalInjuryCounter.totalInjuryCounter);
        NpcTransform = npc.GetComponent<Transform>();
        npc.GetComponent<NavMeshAgent>().enabled = false;
        //Anim = npc.GetComponentInChildren<Animator>();


        npc.GetComponent<Rigidbody>().AddForce(Vector3.forward * 0.5f, ForceMode.Impulse);
        currentTime = maxTime;

        if (agent.height > 1.5f)
        {
            UpdateNpcSound();
        }
    }

    public override void UpdateState(NpcStateManager npc)
    {
        NPCFlailing(npc);
    }

    public override void OnCollisionEnter(NpcStateManager npc, Collision collision)
    {
       /* if(collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            npc.injureEffect.Play();
        }*/
    }

    public void NPCFlailing(NpcStateManager npc)
    {
        Anim = npc.GetComponent<Animator>();

        NpcTransform = npc.GetComponent<Transform>();
        Npcrb = npc.GetComponent<Rigidbody>();
        Anim.SetBool("Fallen", true);
        Anim.SetBool("IsSitting", false);

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        interactable = npc.gameObject.GetComponent<Interactable>();

        if(player.Holding == true)
        {
            Npcrb.transform.rotation = interactable.rb.transform.rotation;
        }
       


        if (timerActive)
        {
            currentTime = countDown ? currentTime -= Time.deltaTime : currentTime += Time.deltaTime;
        }

        if (hasLimit && ((countDown && currentTime <= timerLimit) || (!countDown && currentTime >= timerLimit)))
        {
            currentTime = timerLimit;           
        }
        if (currentTime <= 0 && npc.player.Holding == true && player.HoldingNPC == true)
        {
            currentTime = maxTime;
        }
        if (currentTime <= 3 && npc.player.HoldingNPC == false)
        {
            Anim.SetBool("Fallen", false);
            Anim.SetBool("IsWalking", false);


            NpcTransform.rotation = Quaternion.Euler(0, 0, 0);
            NpcTransform.position = new Vector3(NpcTransform.position.x, NpcTransform.position.y, NpcTransform.position.z);
        }
        if(currentTime <= 0 && npc.player.HoldingNPC == false)
        {
            npc.GetComponent<NavMeshAgent>().enabled = true;
            if (npc.GetComponent<NpcStateManager>().isLeaving)
            {
                npc.SwitchState(npc.leavingState);
            }
            else if (InjuryCounter >= 3)
            {
                npc.SwitchState(npc.leavingState);
            }
            else
            {
                npc.SwitchState(npc.wanderState);

            }
        }
            
            
            
            

    }

    public void UpdateNpcSound()
    {
        PLAYBACK_STATE playbackState;
        fallingSound.getPlaybackState(out playbackState);

        if (playbackState.Equals(PLAYBACK_STATE.STOPPED))
        {
            fallingSound.start();
        }
        /*if (agent.height < 1.5)
        {
            //return;
            //add srk injured sound here?
        }
        else
        {

        }*/

    }

      

            
        

    
}
