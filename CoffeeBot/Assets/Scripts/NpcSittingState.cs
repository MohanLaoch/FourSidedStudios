using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcSittingState : NpcBaseState
{
    public override void EnterState(NpcStateManager npc)
    {
        Debug.Log("hello from the sitting state");
    }

    public override void UpdateState(NpcStateManager npc)
    {

    }

    public override void OnCollisionEnter(NpcStateManager npc)
    {

    }
}
