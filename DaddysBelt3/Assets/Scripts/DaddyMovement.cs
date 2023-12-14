using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class DaddyMovement : MonoBehaviour
{
    NavMeshAgent agent;
    private SpriteRenderer renderer;
    Animator animator;
    private float angle;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        renderer = GetComponent<SpriteRenderer>();
        angle = DaddyAttack.angle;
    }

}