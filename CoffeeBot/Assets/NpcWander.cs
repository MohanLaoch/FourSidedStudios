using UnityEngine;
using System.Collections;
using UnityEngine.AI;
public class NpcWander : MonoBehaviour
{

    public float wanderRadius;
    public float wanderTimer;

    private Transform target;
    private NavMeshAgent agent;
    private float timer;
    public Animator NpcAnim;

    // Use this for initialization
    void OnEnable()
    {
        agent = GetComponent<NavMeshAgent>();
        timer = wanderTimer;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        
        if (timer >= wanderTimer)
        {
            Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
            agent.SetDestination(newPos);
            timer = 0;
        }
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;

        randDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;
    }
    /*Current issues: 
      npc freaks out when player hits them
      need to create two states, wander state and falling state
      npc should wander as normal until they come into contact with the player 
      then, normal rigidbody physics should occur, putting the npc into flailing state.
      flailing animation starts, they struggle for a few seconds, then get up and return to their wander state.*/
     
}