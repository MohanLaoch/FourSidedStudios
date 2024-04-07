using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spill : MonoBehaviour
{
    public GameObject spiltCoffee;
    private GameObject mop;

    [SerializeField]
    private int layerNumber = 9; // Ground is currently 9

    private void Awake()
    {
        mop = GameObject.FindGameObjectWithTag("Mop");
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            return;
        }
        if (other.gameObject.layer == layerNumber)
        {
            mop.GetComponent<RoboMop>().SpillDetected = true;
            mop.GetComponent<RoboMop>().SlipperyFloor = spiltCoffee;
            Instantiate(spiltCoffee, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            Destroy(gameObject);
            
            Debug.Log(" SPILL DETECTED ");
            //send signal to robomop!!
        }
    }
}
