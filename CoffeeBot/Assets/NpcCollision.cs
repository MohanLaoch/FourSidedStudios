using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class NpcCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {       
            GetComponent<NavMeshAgent>().enabled = false;
            GetComponent<NpcWander>().enabled = false;

        }
    }


}
