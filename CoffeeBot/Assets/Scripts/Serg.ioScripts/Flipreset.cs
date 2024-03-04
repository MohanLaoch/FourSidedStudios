using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipreset : MonoBehaviour
{
    public LayerMask layermask;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            transform.parent.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
