using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthUI : MonoBehaviour
{
    [SerializeField] EnemyHealth enemyHealth;
    [SerializeField] Slider healthSlider;

    void Awake()
    {
        enemyHealth.OnHealthChange += OnHealthChange;
    }

    private void OnHealthChange()
    {
        healthSlider.value = enemyHealth.CurrentHealth / enemyHealth.MaxHealth;
    }
}
