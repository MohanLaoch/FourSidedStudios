using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class SlipperyFloor : MonoBehaviour
{
    public GameObject Npc;
    public float FlipForce;
    public float FlipForceRot;
    
    private void OnTriggerEnter(Collider other)
    {
        //Vector3 FlipDir = transform.TransformDirection(Vector3.forward);
        if (other.CompareTag("NPC"))
        {
            Debug.Log("slippy");
            Npc.GetComponent<Rigidbody>().AddForce(Vector3.up * FlipForce, ForceMode.Impulse);
            Npc.GetComponent<Rigidbody>().AddForce(Vector3.left * FlipForce, ForceMode.Impulse);
            //Npc.GetComponent<Rigidbody>().AddTorque(FlipDir * FlipForceRot, ForceMode.Impulse);
            Npc.GetComponent<NavMeshAgent>().enabled = false;
            Npc.GetComponent<NpcWander>().enabled = false;

        }
    }
}
