using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] Collider collider;
    [SerializeField] Transform player;
    private bool isNearPlayer = false;
    private bool isDead = false;
    private void Awake()
    {
        GetComponent<EnemyHealth>().OnDie += Die;
    }

    void Start()
    {
        StartCoroutine(Attack());
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, player.position) <= 1.5f)
        {
            isNearPlayer = true;
        }
        else
        {
            isNearPlayer = false;
        }
    }

    private IEnumerator Attack()
    {
        if (isDead) yield break;
        yield return new WaitForSeconds(Random.Range(1f, 3f));
        if (isNearPlayer)
        {
            int whichAttack = Random.Range(0, 2);
            if(whichAttack == 0)
            {
                animator.Play("Attack1");
            }
            else
            {
                animator.Play("Attack2");
            }
        }
        StartCoroutine(Attack());
    }

    public void Begin()
    {
        collider.enabled = true;
    }

    public void End()
    {
        collider.enabled = false;
    }

    private void Die()
    {
        isDead = true;
        StopCoroutine(Attack());
    }
}
