using UnityEngine;
using System.Collections;
using System.Linq;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform _enemiesContainer;
    [SerializeField] private Transform _finishPanel;

    public int EnemiesOnLevel { get; private set; }

    public int KilledEnemys { get; private set; } = 0;

    private void Start ()
    {
        var enemies = _enemiesContainer.GetComponentsInChildren<Square>();
        EnemiesOnLevel = enemies.Count();
    }

    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.GetComponent<Square>())
        {
            EnemiesOnLevel--;

            if (EnemiesOnLevel == 0)
                OnLevelPassed();
        }
    }

    private void OnLevelPassed ()
    {
        Time.timeScale = 0;
        _finishPanel.gameObject.SetActive(true);
    }
}
