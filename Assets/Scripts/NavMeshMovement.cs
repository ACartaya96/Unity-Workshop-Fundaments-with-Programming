using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshMovement : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private Animator animator;
    [SerializeField] private Mocha mocha;
    [SerializeField] private Transform feederPosition;
    [SerializeField] private Transform bedPosition;
    [SerializeField] private float wanderRadius = 10f;
    float dir_x = 0f;
    float dir_y = 0f;
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
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        // TODO EXCERCISE 8: OPPERANDS AND CONDITONALS
        if (mocha.mHungry)
        {
            if (mocha.mSleepy)
                HandleSleep();
            else if (mocha.mHungry)
                HandleHunger();
            else if (mocha.mBored)
                HandleBoredom();
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
        
        // This allow me to store the direction of Mocha, and keep his direction facing
        // persistent between animation states.
        if (localVelocity != Vector3.zero)
        {
            dir_x = localVelocity.x;
            dir_y = localVelocity.y;
        }

        // Only place I could put the wake up animation right now might fix later
        if (NeedsManager.Instance.GetSleepValue() >= 1.0f)
            animator.SetBool("IsSleeping", false);
        // These set the animation parameters for Mocha
        animator.SetFloat("Dir_X", dir_x);
        animator.SetFloat("Dir_Y", dir_y);
        animator.SetBool("IsWalking", localVelocity != Vector3.zero);
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
        Feeder component;
        if (feederPosition.TryGetComponent<Feeder>(out component))
        {
            if (component.full)
                navMeshAgent.SetDestination(feederPosition.position);
            else
            {
                StopAgent();
                animator.Play("Hungry");
            }
        }
                
        Debug.Log("Mocha is Hungry.");
    }

    private void HandleBoredom()
    {
        StopAgent();
        animator.Play("Bored");
        Debug.Log("Mocha is Bored.");
    }
    
    private void HandleSleep()
    {

        if (bedPosition != null && animator.GetBool("IsSleeping") == false)
        {
            navMeshAgent.SetDestination(bedPosition.position);
        }    
        Debug.Log("Mocha is Sleepy.");
    }
}
