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
        MopAgent.isStopped = true;
    }

    
    void Update()
    {
        Debug.Log(MopAgent.remainingDistance);
        if(SpillDetected)
        {
            MopAgent.isStopped = false;
            SlipperyFloor = GameObject.FindGameObjectWithTag("SlipperyFloor");
            MopAgent.SetDestination(SlipperyFloor.transform.position);
        }
        else
        {
            MopAgent.SetDestination(startingPos);
        }


        if(MopAgent.remainingDistance < 0.9f && SpillDetected)
        {
            SpillDetected = false;
            MopAgent.SetDestination(startingPos);
        }
        else if(MopAgent.remainingDistance < 0.9f && !SpillDetected)
        {
            MopAgent.isStopped = true;
        }




    }
}
