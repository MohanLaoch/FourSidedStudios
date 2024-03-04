using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairTest : MonoBehaviour
{
    
    public bool isTaken = false;
    public bool isSittable;
    private NpcStateManager npcStateManager;
    // Start is called before the first frame update

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isSittable = false;
        }






        if (isSittable && other.CompareTag("NPC"))
        {
            
            Debug.Log("testing");
            npcStateManager = other.GetComponent<NpcStateManager>();
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
        yield return new WaitForSeconds(5);
        isTaken = true;
    }
    void Start()
    {
        isSittable = true;
    }

}
