using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Transform player;
    [SerializeField] float maxDistance, minDistance;
    private bool isDead = false;
    private void Awake()
    {
        GetComponent<EnemyHealth>().OnDie += Die;
    }

    private void Update()
    {
        if(isDead) return;
        if(Vector3.Distance(transform.position, player.position) <= maxDistance && Vector3.Distance(transform.position,player.position) >= minDistance)
        {
            agent.enabled = true;
            animator.SetBool("Walk", true);
            agent.SetDestination(player.position);
        }
        else
        {
            agent.enabled = false;
            animator.SetBool("Walk", false);
        }
    }

    private void Die()
    {
        isDead = true;
    }
}
