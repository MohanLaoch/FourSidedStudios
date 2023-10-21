using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableTest : MonoBehaviour
{

    public Transform CounterObj;
    public Transform HoldArea;

    private Player player;


    public void Interact()
    {
        transform.position = HoldArea.transform.position;
        transform.parent = HoldArea.transform;
        
        
    }

    public void Drop()
    {

        transform.parent = null;
        
        Debug.Log("dropping item");
    }

}
