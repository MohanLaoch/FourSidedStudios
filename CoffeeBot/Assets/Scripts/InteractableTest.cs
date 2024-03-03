using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class InteractableTest : MonoBehaviour
{
    public Rigidbody rb;
    public Transform CounterObj;
    public Transform HoldArea;
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
        if(gameObject.CompareTag("Chair"))
        {
            GetComponent<ChairTest>().isSittable = false;
        }

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
            rb.mass = 0;

        }

  

    }



    public void Drop()
    {
        if(gameObject.CompareTag("Storage"))
        {
            Store();
            return;
        }

        if (gameObject.CompareTag("Chair"))
        {
            GetComponent<ChairTest>().isSittable = true;
        }

        transform.parent = null;
        rb.constraints = RigidbodyConstraints.None;
        Debug.Log("dropping item");
        rb.mass = 1;

    }


    public void Store()
    {
        if(gameObject.CompareTag("Storage"))
        {           
            Debug.Log("HUSBANDISMYBELOVED");
            GetComponent<Storage>().husband = true;
        }
    }

    public void Empty()
    {

    }

}
