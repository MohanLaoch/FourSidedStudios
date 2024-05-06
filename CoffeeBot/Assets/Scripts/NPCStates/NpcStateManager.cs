using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NpcStateManager : MonoBehaviour
{
    public FurnitureManager furnitureManager;
    public Player player;
    public bool hasLeft = false;
    public bool isLeaving = false;
    public ParticleSystem injureEffect;

    public NpcBaseState currentState;
    public NpcWanderState wanderState = new NpcWanderState();
    public NpcLeavingState leavingState = new NpcLeavingState();   
    public NpcSittingState sittingState = new NpcSittingState();
    public NpcInjuredState injuredState = new NpcInjuredState();
    public void Start()
    {
        player = FindObjectOfType<Player>();
        currentState = sittingState;

        if(gameObject.GetComponent<NavMeshAgent>().height < 1.5f)
        {
            currentState = wanderState;
        }

        currentState.EnterState(this);
    }

    private void OnCollisionEnter(Collision collision)
    {
        currentState.OnCollisionEnter(this, collision);
    }
    public void Update()
    {
        currentState.UpdateState(this); 
    }

   public void SwitchState(NpcBaseState state)
    {
        currentState = state;
        state.EnterState(this); 
    }
}
