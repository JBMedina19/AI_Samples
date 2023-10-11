using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public GameObject playerPosition,playerPositionStored;
    public NavMeshAgent agent;
    public Transform Waypoints;
    public List<Transform> targetWaypoint;
    public int wayPointNumber;
    public bool isMoving;
    public float radius;
    public float distance;
    public float chaseDuration, chaseDurationStored;
    // Start is called before the first frame update
    void Start()
    {
        playerPositionStored = playerPosition;
        chaseDurationStored = chaseDuration;
        agent = GetComponent<NavMeshAgent>();
        foreach (Transform tr in Waypoints.GetComponentsInChildren<Transform>())
        {
            targetWaypoint.Add(tr.gameObject.transform);
        }
        //MoveToRandomWaypoint();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(agent.transform.position, playerPosition.transform.position);
        //returns true or false, if AI has next destination.
        if (!agent.pathPending)
        {
            //returns the distance of agent, if it is the same of stoping distance
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                //if agent has no path or agent is standing still
                if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                {
                    // Done
                    //MoveToRandomWaypoint();
                }


            }
        }
    }
    public void MoveToRandomWaypoint()
    {
        if (targetWaypoint.Count == 0)
        {
            Debug.LogWarning("No waypoints available.");
            return;
        }

        int newWaypointIndex = GetRandomWaypointIndex();

        //4 != 4
        if (newWaypointIndex != wayPointNumber)
        {
            //we make this equal to random way point
            wayPointNumber = newWaypointIndex;
            //Setting the agent new destination
            agent.SetDestination(targetWaypoint[wayPointNumber].position);
        }
        else
        {
            // If the random waypoint is the same as the current one, find another waypoint
            MoveToRandomWaypoint();
        }
    }
    //CONCATINATION
    private int GetRandomWaypointIndex()
    {
        //0 - 4
        return Random.Range(0, targetWaypoint.Count);
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
