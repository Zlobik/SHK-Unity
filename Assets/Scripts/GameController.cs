using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject _finishPanel;
    [SerializeField] private Player _player;
    [SerializeField] private Transform EnemysParent;

    private int _enemysCount;
    private float _elapsedTime = 0;

    private void Start ()
    {
        _enemysCount = EnemysParent.childCount;
    }

    public void OnLevelPassed ()
    {
        _finishPanel.SetActive(true);
    }

    private void FixedUpdate ()
    {
        _elapsedTime += Time.fixedDeltaTime;

        if (_elapsedTime >= 3f)
        {
            _elapsedTime = 0;

            if (_player.KilledEnemys == _enemysCount)
            {
                OnLevelPassed();
            }
        }
    }
}
