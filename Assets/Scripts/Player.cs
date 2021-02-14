using UnityEngine;
using System.Collections;
using System.Linq;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public event UnityAction OnEnemyKill;

    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.GetComponent<Square>())
        {
            OnEnemyKill?.Invoke();
        }
    }
}
