using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//Dit is niet mijn code! Deze code is van tim peeters voor project context. Ik heb toestemming om het te gebruiken en ik heb zelf een aantal aanpassingen gemaakt.

public class AI_Base : MonoBehaviour
{
    NavMeshAgent agent;
    GameObject Target;

    [SerializeField] float followDistance;
    [SerializeField] float distanceToTarget;
    [SerializeField] float distanceToPlayer;

    [SerializeField] bool playerInSight;
    [SerializeField] Vector3 offset;



    public enum AI_State
    {
        Patrolling,
        Following,
        Returning
    }

    public AI_State currentState;
    [SerializeField] GameObject[] patrolPoints;

    [SerializeField] int currentPoint = 0;

    bool playerVisible()
    {
        RaycastHit hit;
        Vector3 origin = new Vector3(transform.position.x + offset.x, transform.position.y + offset.y, transform.position.z + offset.z);
        Ray ray = new Ray(origin, Target.transform.position - origin);
        Debug.DrawRay(ray.origin, ray.direction, Color.red);

        Physics.Raycast(ray, out hit);
        //Debug.Log(hit.collider.tag);

        if (hit.collider.tag == "Player")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        Target = GameObject.FindGameObjectWithTag("Player");

        currentState = AI_State.Patrolling;

        if (patrolPoints.Length > 0)
            agent.destination = patrolPoints[currentPoint].transform.position;

    }

    private void Update()
    {
        playerInSight = playerVisible();

        distanceToTarget = Vector3.Distance(agent.destination, transform.position);
        distanceToPlayer = Vector3.Distance(transform.position, Target.transform.position);

        if (playerInSight && currentState != AI_State.Following && distanceToPlayer < followDistance)
        {
            currentState = AI_State.Following;
        }

        StateChanger();
    }

    void StateChanger()
    {
        if (currentState == AI_State.Following)
        {
            Follow();
        }

        if (currentState == AI_State.Patrolling)
        {
            Patrol();
        }

        if (currentState == AI_State.Returning)
        {
            Returning();
        }
    }

    void Patrol()
    {
        if (distanceToTarget < 2)
        {
            if (currentPoint <= patrolPoints.Length)
            {
                currentPoint++;

            }
            else
            {
                currentPoint = 0;
            }
        }

        if (patrolPoints.Length > 0)
            agent.destination = patrolPoints[currentPoint].transform.position;
    }

    void Follow()
    {
        agent.destination = Target.transform.position;

        if (!playerInSight && followDistance > distanceToPlayer)
        {
            currentState = AI_State.Returning;
        }
    }

    void Returning()
    {
        agent.destination = patrolPoints[0].transform.position;
        if (distanceToTarget < 2)
        {
            currentState = AI_State.Patrolling;
        }
    }

}
