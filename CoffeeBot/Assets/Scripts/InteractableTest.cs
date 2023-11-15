using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableTest : MonoBehaviour
{
    public Rigidbody rb;
    public Transform CounterObj;
    public Transform HoldArea;
    public GameObject Player;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        HoldArea = GameObject.Find("HoldArea").GetComponent<Transform>();

    }

    public void Start()
    {
        
    }

    public void Interact()
    {
        transform.parent = HoldArea.transform;
        rb.position = HoldArea.transform.position;
        
        rb.constraints = RigidbodyConstraints.FreezeAll;
    }

    public void Drop()
    {

        transform.parent = null;

        rb.constraints = RigidbodyConstraints.None;
        Debug.Log("dropping item");
    }

}
