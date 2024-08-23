using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{
    [SerializeField] PlayerHealth playerHealth;
    [SerializeField] Slider healthSlider;

    void Awake()
    {
        playerHealth.OnHealthChange += OnHealthChange;
    }

    private void OnHealthChange()
    {
        healthSlider.value = playerHealth.CurrentHealth / playerHealth.MaxHealth;
    }
}
