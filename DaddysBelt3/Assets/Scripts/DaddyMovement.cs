using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DaddyMovement : MonoBehaviour
{
    NavMeshAgent agent;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    void Update()
    {
        if (DaddyAttack.lastSeen != Vector3.zero)
        {
            agent.SetDestination(DaddyAttack.lastSeen);
        }
    }
}
