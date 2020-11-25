using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private Text _text;

    private int _coins;

    private void Awake()
    {
        _coins = 0;
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
        _coins++;
        _text.text = _coins.ToString();
    }
}
