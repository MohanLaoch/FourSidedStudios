using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcStateManager : MonoBehaviour
{

    NpcBaseState currentState;
    public NpcWanderState wanderState = new NpcWanderState();
    public NpcLeavingState leavingState = new NpcLeavingState();   
    public NpcSittingState sittingState = new NpcSittingState();
    public NpcInjuredState injuredState = new NpcInjuredState();
    void Start()
    {
        currentState = sittingState;

        currentState.EnterState(this);
    }

    void Update()
    {
        currentState.UpdateState(this); 
    }

   public void SwitchState(NpcBaseState state)
    {
        currentState = state;
        state.EnterState(this); 
    }
}
