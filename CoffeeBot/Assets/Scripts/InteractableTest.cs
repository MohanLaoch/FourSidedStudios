using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableTest : MonoBehaviour
{
    public Rigidbody rb;
    public Transform CounterObj;
    public Transform HoldArea;
    private Player player;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Interact()
    {

        transform.position = HoldArea.transform.position;
        transform.parent = HoldArea.transform;

        rb.constraints = RigidbodyConstraints.FreezeAll;
    }

    public void Drop()
    {

        transform.parent = null;

        rb.constraints = RigidbodyConstraints.None;
        Debug.Log("dropping item");
    }

}
