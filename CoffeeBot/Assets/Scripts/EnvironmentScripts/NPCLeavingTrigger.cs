using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCLeavingTrigger : MonoBehaviour
{

    private void Awake()
    {
       
    }
    public void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("NPC") &&  other.GetComponent<NpcStateManager>().hasLeft == true)
        {
            Destroy(other.gameObject);
        }
    }
}
