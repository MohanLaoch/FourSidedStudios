using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCFlailTest : MonoBehaviour
{
    public LayerMask layermask;
    public Animator Anim;

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Walls"))
        {
            Anim.SetBool("Fallen", true);
        }
    }
}
