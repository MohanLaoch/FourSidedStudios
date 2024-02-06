using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class NPCFlailTest : MonoBehaviour
{
    public LayerMask layermask;
    public Animator Anim;
    public Transform NpcTransform;

    public void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.layer == LayerMask.NameToLayer("Floor"))
        {
            StartCoroutine(NPCFlailing());
            GetComponentInParent<NavMeshAgent>().enabled = false;
            GetComponentInParent<NpcWander>().enabled = false;



        }
    }

    public IEnumerator NPCFlailing()
    {
        Anim.SetBool("Fallen", true);

        yield return new WaitForSeconds(5);

        transform.parent.rotation = Quaternion.Euler(0, 0, 0);
        transform.parent.position = new Vector3(transform.position.x, 2f, transform.position.z);
        Anim.SetBool("Fallen", false);
        GetComponentInParent<NavMeshAgent>().enabled = true;
        GetComponentInParent<NpcWander>().enabled = true;




    }


}
