using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Transform _enemiesContainer;
    [SerializeField] private Transform _finishPanel;

    private int _enemiesOnLevel;

    private void Start ()
    {
        var enemies = _enemiesContainer.GetComponentsInChildren<Square>();
        _enemiesOnLevel = enemies.Count();
    }

    private void OnEnable ()
    {
        _player.OnEnemyKill += OnEnemyKilled;
    }

    private void OnDisable ()
    {
        _player.OnEnemyKill -= OnEnemyKilled;
    }

    private void OnEnemyKilled ()
    {
        _enemiesOnLevel--;

        if (_enemiesOnLevel == 0)
        {
            Time.timeScale = 0;
            _finishPanel.gameObject.SetActive(true);
        }
    }
}
