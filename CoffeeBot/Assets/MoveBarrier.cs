using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBarrier : MonoBehaviour
{
    public GameObject barrier;

    public Transform end;

    public string keyTag;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == keyTag)
        {
            barrier.transform.position = Vector3.Lerp(barrier.transform.position, end.position, Time.time);

        }
    }
}
