using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class RoboMop : MonoBehaviour
{
    public GameObject SlipperyFloor;
    public NavMeshAgent MopAgent;
    public bool SpillDetected;
    public Vector3 startingPos;
    void Start()
    {
        
        MopAgent = GetComponent<NavMeshAgent>();
        startingPos = transform.position;



    }

    
    void Update()
    {
        if (SlipperyFloor == null)
        {
            MopAgent.SetDestination(startingPos);
            SpillDetected = false;
        }

        if (MopAgent.enabled == false)
        {
            return;
        }
        else 
        {
            
            Debug.Log(MopAgent.remainingDistance);
            if (SpillDetected)
            {
                MopAgent.isStopped = false;
                SlipperyFloor = GameObject.FindGameObjectWithTag("SlipperyFloor");
                MopAgent.SetDestination(SlipperyFloor.transform.position);
            }
            else
            {
                MopAgent.SetDestination(startingPos);
            }


            if (MopAgent.destination == SlipperyFloor.transform.position && SpillDetected)
            {
                SpillDetected = false;

            
            }
            else if (MopAgent.remainingDistance < 0.9f && MopAgent.destination == startingPos)
            {
                MopAgent.isStopped = true;
            }

        }




    }
}
