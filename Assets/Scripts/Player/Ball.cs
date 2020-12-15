using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private TMP_Text _coinCountText;

    private int _coinsCollected = 0;

    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.GetComponent<Coin>())
        {
            _coinsCollected++;
            _coinCountText.text = _coinsCollected.ToString();
        }
    }
}
