using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public int KilledEnemys { get; private set; } = 0;

    private void OnTriggerEnter2D (Collider2D collision)
    {
        if(collision.TryGetComponent(out Enemy enemy))
            KilledEnemys++;
    }
}
