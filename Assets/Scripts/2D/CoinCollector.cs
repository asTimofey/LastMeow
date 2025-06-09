using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _coinTextMeshPro;
    private int _totalCoins;
    void Start()
    {
        _totalCoins = 0;
        _coinTextMeshPro.text = _totalCoins.ToString();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            UpdateCoins(collision);
        }
    }
    private void UpdateCoins(Collider2D collision)
    {
        GetComponent<PlayerSoundManager>().PlayCoinSound();
        _totalCoins++;
        _coinTextMeshPro.text = _totalCoins.ToString();
        Destroy(collision.gameObject);
    }
}
