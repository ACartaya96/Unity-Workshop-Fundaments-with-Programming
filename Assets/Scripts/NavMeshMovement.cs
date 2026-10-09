using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshMovement : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private Animator animator;
    [SerializeField] private Mocha mocha;
    [SerializeField] private Transform targetPosition;
    [SerializeField] private float wanderRadius = 10f;
    public bool TryGetRandomPoint(Vector3 center, float maxDistance, out Vector3 result)
    {
        for (int i = 0; i < 30; i++)
        {
            Vector3 randomPoint = center + UnityEngine.Random.insideUnitSphere * maxDistance;

            NavMeshHit hit;


            if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
            {
                result = hit.position;
                return true;
            }
        }

        result = Vector3.zero;
        return false;
    }
    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        mocha = GetComponent<Mocha>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (mocha.mHungry || mocha.mSleepy || mocha.mBored)
        {
            if (mocha.mHungry)
                HandleHunger();
            if (mocha.mBored)
                HandleBoredom();
            if (mocha.mSleepy)
                HandleSleep();

        }
        else if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
        {
            if (TryGetRandomPoint(transform.position, wanderRadius, out Vector3 newDestination))
            {
                navMeshAgent.SetDestination(newDestination);
               
            }
        }

        Vector3 worldVelocity = navMeshAgent.velocity;
        Vector3 localVelocity = transform.InverseTransformDirection(worldVelocity);

        float dir_x = localVelocity.x;
        float dir_y = localVelocity.y;

        animator.SetFloat("Dir_X", dir_x);
        animator.SetFloat("Dir_Y", dir_y);
    }

    public void StopAgent()
    {
        // Stop the agent immediately
        navMeshAgent.isStopped = true;

        // Clear the current path and reset velocity to prevent sliding
        navMeshAgent.ResetPath();
        navMeshAgent.velocity = Vector3.zero;
    }

    private void HandleHunger()
    {
        Debug.Log("Mocha is Hungry.");
    }

    private void HandleBoredom()
    {
        Debug.Log("Mocha is Bored.");
    }
    
    private void HandleSleep()
    {
        Debug.Log("Mocha is Sleepy.");
    }
}
