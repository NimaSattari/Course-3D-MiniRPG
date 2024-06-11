using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{
    [SerializeField] Slider healthSlider;
    PlayerHealth playerHealth;

    private void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
        playerHealth.OnHealthChange += HealthChanged;
    }

    private void HealthChanged()
    {
        healthSlider.value = (float)playerHealth.CurrentHealth / (float)playerHealth.MaxHealth;
    }
}
