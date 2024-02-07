using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class NpcCollision : MonoBehaviour
{
    public Player player;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {       
            GetComponent<NavMeshAgent>().enabled = false;
            GetComponent<NpcWander>().enabled = false;

            if(player.Holding == false)
            {
             transform.position = new Vector3(transform.position.x, 2f, transform.position.z);
            }
            

        }
    }


}
