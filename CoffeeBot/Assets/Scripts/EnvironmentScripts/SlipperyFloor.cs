using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class SlipperyFloor : MonoBehaviour
{
    private Rigidbody NpcRB;
    private NpcStateManager npcStateManager;
    public float FlipForce;
    public float FlipForceRot;
    public bool hasSlipped = false;
    private void Start()
    {
       
    }
    private void OnTriggerEnter(Collider other)
    {
        NpcRB = other.GetComponentInParent<Rigidbody>();
        npcStateManager = other.GetComponent<NpcStateManager>();
        Vector3 FlipDir = transform.TransformDirection(Vector3.forward);
        if (other.CompareTag("NPC"))
        {
          
            

            NpcRB.AddForce(Vector3.up * FlipForce, ForceMode.Impulse);
            NpcRB.AddForce(Vector3.left * FlipForce, ForceMode.Impulse);
            NpcRB.AddTorque(FlipDir * FlipForceRot, ForceMode.Impulse);
            npcStateManager.SwitchState(npcStateManager.injuredState);
            hasSlipped = true;

    Debug.Log("slippy");

        }
        else if (other.CompareTag("Mop"))
        {
            Destroy(gameObject);
        }
    }
}
