using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCollect : MonoBehaviour
{
    [SerializeField] int coinsCollected;
    [SerializeField] Text coinText;

    private void Start()
    {
        UpdateUI();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            Collcet(other.gameObject);
        }
    }

    private void Collcet(GameObject coin)
    {
        coin.SetActive(false);
        coinsCollected++;
        UpdateUI();
    }

    private void UpdateUI()
    {
        coinText.text = coinsCollected.ToString();
    }
}
