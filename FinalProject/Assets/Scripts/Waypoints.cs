using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Waypoints : MonoBehaviour
{
    public GameObject[] waypoints;
    public int patrolWP = 0;
    public NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        Patrol();
    }

    // Update is called once per frame
    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f) Patrol();
    }

    void Seek(Vector3 pos)
    {
        agent.destination = pos;
    }

    void Patrol()
    {
        patrolWP = (patrolWP + 1) % waypoints.Length;
        Seek(waypoints[patrolWP].transform.position);
    }
};
