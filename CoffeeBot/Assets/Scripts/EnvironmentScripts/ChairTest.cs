using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairTest : MonoBehaviour
{
    
    public bool isTaken = false;
    public bool isSittable;
    

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isSittable = false;
        }






        if (isSittable && other.CompareTag("NPC"))
        {                       
            StartCoroutine(ChairCheck());           
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("NPC"))
        {
            isTaken = false;
        }
    }

    public IEnumerator ChairCheck()
    {
        yield return new WaitForSeconds(5f);
        isTaken = true;
    }
    void Start()
    {
        isSittable = true;
    }

}
