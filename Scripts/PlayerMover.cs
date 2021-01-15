using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _addBoostingForceStep = 3f;
    [SerializeField] private float _boostingWaitForSeconds = 0.15f;

    private float _boosterTime = 0;
    private float _boosterForce = 0;
    private float _speedWithoutBoosters;
    private Vector3 _moveDirection;
    private float _elapsedTime = 0;
    private int _boosterTimerWaitingSeconds = 1;

    private void Start ()
    {
        _speedWithoutBoosters = _speed;
    }

    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.TryGetComponent(out EnemyBooster enemyBooster))
        {
            _boosterForce = enemyBooster.BoosterForce;
            _boosterTime = enemyBooster.BoosterTime;

            StartCoroutine(Booster());
        }
    }

    private IEnumerator Booster ()
    {
        var waitForSeconds = new WaitForSeconds(_boostingWaitForSeconds);

        while (_speed < _speedWithoutBoosters + _boosterForce)
        {
            ChangeSpeed(_speed + _addBoostingForceStep);
            yield return waitForSeconds;
        }

        StartCoroutine(BoosterTimer());
        StopCoroutine(Booster());
    }

    private IEnumerator BoosterTimer ()
    {
        var waitForSeconds = new WaitForSeconds(_boosterTimerWaitingSeconds);
        _elapsedTime = 0;

        while (_elapsedTime < _boosterTime)
        {
            _elapsedTime += _boosterTimerWaitingSeconds;
            yield return waitForSeconds;
        }

        ChangeSpeed(_speedWithoutBoosters);
        StopCoroutine(BoosterTimer());
    }

    private void ChangeSpeed (float speed)
    {
        _speed = speed;
    }

    private void Update ()
    {
        _moveDirection = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        transform.position = transform.position + _moveDirection * _speed * Time.deltaTime;
    }
}
