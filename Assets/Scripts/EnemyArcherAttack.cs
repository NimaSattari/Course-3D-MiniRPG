using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArcherAttack : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] Transform player;
    [SerializeField] GameObject bullet;
    [SerializeField] Transform spawnPoint;
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
        if (Vector3.Distance(transform.position, player.position) <= 10f)
        {
            RotateTowards();
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
            if (whichAttack == 0)
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
        Shoot();
    }

    public void End()
    {
        
    }

    private void Die()
    {
        isDead = true;
        StopCoroutine(Attack());
    }

    private void RotateTowards()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 10f);
    }

    private void Shoot()
    {
        GameObject bulletInstance = Instantiate(bullet, spawnPoint.position, Quaternion.identity, null);
        bulletInstance.transform.LookAt(player.position);
        bulletInstance.GetComponent<Rigidbody>().velocity = transform.forward * 25f;
    }
}
