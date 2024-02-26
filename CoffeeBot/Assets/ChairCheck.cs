using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairCheck : MonoBehaviour
{
    public bool isSittable = true;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Floor"))
        {
            isSittable = false;
        }
    }
}
