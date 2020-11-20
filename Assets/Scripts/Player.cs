using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private Text _coinsCountText;

    private int _coinsCount;

    private void Awake()
    {
        _coinsCount = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Coin coin))
        {
            TakeCoin();

            Destroy(coin.gameObject);
        }
    }

    private void TakeCoin()
    {
        _coinsCount++;
        _coinsCountText.text = _coinsCount.ToString();
    }
}
