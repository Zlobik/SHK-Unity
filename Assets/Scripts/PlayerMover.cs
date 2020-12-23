﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _boosterCourutineWaitingSeconds = 0.25f;

    private float _boosterTime = 0;
    private float _boosterForce = 0;
    private float _speedWithoutBoosters;
    private Vector3 _moveDirection;

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

            ChangeSpeed(_speed * _boosterForce);
            StartCoroutine(BoosterTimer());
        }
    }

    private IEnumerator BoosterTimer ()
    {
        var waitForSeconds = new WaitForSeconds(_boosterCourutineWaitingSeconds);

        for (float i = _boosterTime; i > 0; i -= _boosterCourutineWaitingSeconds)
        {
            ChangeSpeed(_speed - _boosterCourutineWaitingSeconds * (_speed - _speedWithoutBoosters));
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
