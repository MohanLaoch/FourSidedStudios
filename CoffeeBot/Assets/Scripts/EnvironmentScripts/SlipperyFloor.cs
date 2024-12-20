using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class SlipperyFloor : MonoBehaviour
{
    private Rigidbody NpcRB;
    private Rigidbody PlayerRB;
    private NpcStateManager npcStateManager;
    public float FlipForce;
    public float FlipForceRot;
    public float PlayerFlipForce;
    public float PlayerFlipForceRot;
    public bool hasSlipped = false;
    public GameObject roboMop;
    public SceneInfo sceneInfo;
    private void Start()
    {
       
    }
    private void OnTriggerEnter(Collider npc)
    {
        NpcRB = npc.GetComponent<Rigidbody>();
        npcStateManager = npc.GetComponent<NpcStateManager>();
        Vector3 FlipDir = transform.TransformDirection(Vector3.forward);
        Vector3 PlayerFlipDir = transform.TransformDirection(Vector3.right);
        if (npc.gameObject.CompareTag("NPC"))
          {                     
              NpcRB.AddForce(Vector3.up * FlipForce, ForceMode.Impulse);
              NpcRB.AddForce(Vector3.left * FlipForce, ForceMode.Impulse);
              NpcRB.AddTorque(FlipDir * FlipForceRot, ForceMode.Impulse);
            

              hasSlipped = true;    
          }
          if (npc.CompareTag("Mop"))
          {

            Destroy(gameObject);
            sceneInfo.SpillsCleaned++;
            
          }
          if(npc.CompareTag("Player"))
          {
            PlayerRB = npc.GetComponent<Rigidbody>();
            PlayerRB.AddForce(Vector3.up * PlayerFlipForce, ForceMode.Impulse);
            PlayerRB.AddTorque(PlayerFlipDir * PlayerFlipForceRot, ForceMode.Impulse);
            
          }
    }
} 
