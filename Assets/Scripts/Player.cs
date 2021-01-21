using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform _enemiesContainer;
    [SerializeField] private Transform _finishPanel;

    private int _enemiesOnLevel = 0;

    public int KilledEnemys { get; private set; } = 0;

    private void Start ()
    {
        for (int i = 0; i < _enemiesContainer.childCount; i++)
        {
            if (_enemiesContainer.GetChild(i).gameObject.GetComponent<Enemy>())
                _enemiesOnLevel++;
        }
    }

    private void OnTriggerEnter2D (Collider2D collision)
    {
        if(collision.TryGetComponent(out Enemy enemy))
        {
            KilledEnemys++;

            if (KilledEnemys == _enemiesOnLevel)
                OnLevelPassed();
        }
    }

    private void OnLevelPassed ()
    {
        Time.timeScale = 0;
        _finishPanel.gameObject.SetActive(true);
    }
}
