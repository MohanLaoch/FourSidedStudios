using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SrkChaos : MonoBehaviour
{
    private Rigidbody NpcRB;
    private Rigidbody PlayerRB;
    private NpcStateManager npcStateManager;
    public float FlipForce;
    public float FlipForceRot;
    public float PlayerFlipForce;
    public float PlayerFlipForceRot;
    public bool hasSlipped = false;

    
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider npc)
    {
        NpcRB = npc.GetComponent<Rigidbody>();
        npcStateManager = npc.GetComponent<NpcStateManager>();
        Vector3 FlipDir = transform.TransformDirection(Vector3.forward);
        Vector3 PlayerFlipDir = transform.TransformDirection(Vector3.right);
      
        if(npc.gameObject.layer == LayerMask.NameToLayer("Interactables"))
        {
            if(npc.gameObject.CompareTag("NPC"))
            {
                npc.GetComponent<NpcStateManager>().SwitchState(npcStateManager.injuredState);
            }
            NpcRB.AddForce(Vector3.up * FlipForce, ForceMode.Impulse);
            NpcRB.AddForce(Vector3.left * FlipForce, ForceMode.Impulse);
            NpcRB.AddTorque(FlipDir * FlipForceRot, ForceMode.Impulse);


            hasSlipped = true;
        }

        if (npc.CompareTag("Player"))
        {
            PlayerRB = npc.GetComponent<Rigidbody>();
            PlayerRB.AddForce(Vector3.up * PlayerFlipForce, ForceMode.Impulse);
            PlayerRB.AddTorque(PlayerFlipDir * PlayerFlipForceRot, ForceMode.Impulse);

        }
    }
}
