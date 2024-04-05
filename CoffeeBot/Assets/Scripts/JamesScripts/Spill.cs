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
        if (other.gameObject.layer == layerNumber)
        {
            Instantiate(spiltCoffee, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            Destroy(gameObject);
            mop.GetComponent<RoboMop>().SpillDetected = true;
            Debug.Log(mop);
            //send signal to robomop!!
        }
    }
}
