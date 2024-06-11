using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamagable
{
    [SerializeField] int maxHealth;
    [SerializeField] float timeBetweenAttack;
    public event Action DieEvent, OnHealthChange;
    private int currentHealth;
    private float timer;

    public int CurrentHealth {
        get { return currentHealth; }
        private set { currentHealth = value; }
    }

    public int MaxHealth
    {
        get { return maxHealth; }
        private set { maxHealth = value; }
    }

    private void Start()
    {
        CurrentHealth = maxHealth;
    }

    private void Update()
    {
        timer += Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Weapon"))
        {
            TakeDamage();
        }
    }

    public void TakeDamage()
    {
        if(timer > timeBetweenAttack)
        {
            CurrentHealth -= 25;
            OnHealthChange?.Invoke();
            if (CurrentHealth <= 0)
            {
                Die();
            }
            timer = 0;
            print(CurrentHealth);
        }
    }

    public void Die()
    {
        DieEvent?.Invoke();
    }
}
