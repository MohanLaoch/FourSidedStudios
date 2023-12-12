using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableTest : MonoBehaviour
{
    public Rigidbody rb;
    public Transform CounterObj;
    public Transform HoldArea;
    public GameObject Player;
    public Animator NPCAnim;

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

        if (gameObject.CompareTag("NPC"))
        {
            transform.parent = HoldArea.transform;
            rb.transform.position = HoldArea.transform.position;

            rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;

            NPCAnim.SetBool("Fallen", true);
            //trigger flail here 
            Debug.Log("helpme");
            rb.transform.rotation = Quaternion.Euler(rb.rotation.x - 90f, rb.rotation.y, rb.rotation.z + 90f);
        }
        else
        {
            transform.parent = HoldArea.transform;
            rb.position = HoldArea.transform.position;
            rb.constraints = RigidbodyConstraints.FreezeAll;

        }
      
        

       
    }

    public void Drop()
    {
        transform.parent = null;
        rb.constraints = RigidbodyConstraints.None;
        Debug.Log("dropping item");
    }

}
