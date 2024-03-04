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

        if(agent.remainingDistance < 0.1)
        {
            NpcAnim.SetBool("IsWalking", false);
        }
        else
        {
            NpcAnim.SetBool("IsWalking", true);

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

     
}