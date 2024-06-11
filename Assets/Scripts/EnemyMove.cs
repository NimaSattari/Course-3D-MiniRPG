using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    NavMeshAgent agent;
    PlayerController controller;
    Animator animator;
    EnemyHealth enemyHealth;
    bool isDead;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        controller = FindObjectOfType<PlayerController>();
        enemyHealth = GetComponent<EnemyHealth>();
        enemyHealth.DieEvent += Die;
    }

    private void Update()
    {
        if(isDead) return;
        if(Vector3.Distance(transform.position, controller.transform.position) >= 1f)
        {
            agent.enabled = true;
            animator.SetBool("Walk", true);
            agent.SetDestination(controller.transform.position);
        }
        else
        {
            animator.SetBool("Walk", false);
            agent.enabled = false;
        }
    }

    private void Die()
    {
        isDead = true;
    }
}
