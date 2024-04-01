using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;

public class NPCLeavingTrigger : MonoBehaviour
{
    public SceneInfo sceneInfo;
    public TextMeshProUGUI moneyText;
    private void Awake()
    {
       
    }
    public void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("NPC") &&  other.GetComponent<NpcStateManager>().hasLeft == true)
        {
            //Destroy(other.gameObject);
            other.gameObject.SetActive(false);
        }

        if (other.GetComponent<NavMeshAgent>().height < 1.5f && other.GetComponent<NpcStateManager>().currentState == other.GetComponent<NpcStateManager>().injuredState)
        {
            other.gameObject.SetActive(false);
            sceneInfo.money += 15;
            moneyText.text = ": " + sceneInfo.money.ToString("0");
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("NPC") && other.GetComponent<NpcStateManager>().hasLeft == true)
        {
            FindObjectOfType<NpcSpawnerTesting>().NpcCount--;
        }


    }
}
