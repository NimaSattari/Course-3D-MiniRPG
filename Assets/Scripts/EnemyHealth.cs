using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float maxHealth;
    [SerializeField] Animator animator;
    [SerializeField] float damage;
    [SerializeField] float timeBetweenAttacks = 1f;
    public float currentHealth;
    public event Action OnHealthChange;
    public event Action OnDie;
    private float timer;

    public float CurrentHealth
    {
        get { return currentHealth; }
        private set { currentHealth = value; }
    }

    public float MaxHealth
    {
        get { return maxHealth; }
        private set { maxHealth = value; }
    }

    private void Start()
    {
        currentHealth = MaxHealth;
        OnHealthChange?.Invoke();
    }

    private void Update()
    {
        timer += Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerWeapon"))
        {
            TakeDamage(damage);
        }
    }

    public void TakeDamage(float damage)
    {
        if (timer > timeBetweenAttacks)
        {
            timer = 0f;
            if (currentHealth > 0)
            {
                currentHealth -= damage;
                if (currentHealth <= 0)
                {
                    Die();
                }
                else
                {
                    animator.Play("Hit");
                }
            }
            if (currentHealth <= 0)
            {
                Die();
            }
            OnHealthChange?.Invoke();
        }
    }

    public void Die()
    {
        animator.Play("Die");
        OnDie?.Invoke();
    }
}
