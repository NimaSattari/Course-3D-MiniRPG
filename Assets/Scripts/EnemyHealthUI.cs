using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthUI : MonoBehaviour
{
    [SerializeField] Slider healthSlider;
    EnemyHealth enemyHealth;

    private void Start()
    {
        enemyHealth = GetComponent<EnemyHealth>();
        enemyHealth.OnHealthChange += HealthChanged;
        enemyHealth.DieEvent += Die;
    }

    private void HealthChanged()
    {
        healthSlider.value = (float)enemyHealth.CurrentHealth / (float)enemyHealth.MaxHealth;
    }

    private void Die()
    {
        healthSlider.gameObject.SetActive(false);
    }
}
