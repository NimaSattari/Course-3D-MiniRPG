using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] Collider attackCollider;
    Animator animator;
    PlayerController controller;
    EnemyHealth enemyHealth;

    bool isNearPlayer;
    bool isDead;

    private void Start()
    {
        controller = FindObjectOfType<PlayerController>();
        animator = GetComponent<Animator>();
        StartCoroutine(AttackCor());
        enemyHealth = GetComponent<EnemyHealth>();
        enemyHealth.DieEvent += Die;
    }

    private void Update()
    {
        if(isDead) return;
        if(Vector3.Distance(transform.position,controller.transform.position) <= 1.5f)
        {
            isNearPlayer = true;
        }
        else
        {
            isNearPlayer = false;
        }
    }

    IEnumerator AttackCor()
    {
        yield return new WaitForSeconds(Random.Range(1f, 3f));
        if (isDead) yield break;
        if(isNearPlayer)
        {
            animator.Play("Attack1");
        }
        StartCoroutine(AttackCor());
    }

    private void Die()
    {
        isDead = true;
        StopCoroutine(AttackCor());
    }

    public void Begin()
    {
        attackCollider.enabled = true;
    }

    public void End()
    {
        attackCollider.enabled = false;
    }
}
