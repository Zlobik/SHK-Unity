using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private bool _timer = false;
    private float _boosterTime = 0;
    private float _boosterForce = 0;

    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
        {
            if (enemy.IsGiveSpeed)
            {
                _timer = true;
                _boosterForce = enemy.BoosterForce;
                _boosterTime = enemy.BoosterTime;
                EnableBooster();
            }
        }
    }

    private void EnableBooster ()
    {
        _speed *= _boosterForce;
    }

    private void DisableBooster ()
    {
        _speed /= _boosterForce;
    }

    private void MoveY (float step)
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y + step, transform.position.z), _speed * Time.deltaTime);
    }

    private void MoveX (float step)
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x + step, transform.position.y, transform.position.z), _speed * Time.deltaTime);
    }

    private void Update ()
    {
        if (Input.GetKey(KeyCode.W))
            MoveY(1);
        if (Input.GetKey(KeyCode.S))
            MoveY(-1);
        if (Input.GetKey(KeyCode.A))
            MoveX(-1);
        if (Input.GetKey(KeyCode.D))
            MoveX(1);

        if (_timer)
        {
            _boosterTime -= Time.deltaTime;

            if (_boosterTime < 0)
            {
                _timer = false;
                DisableBooster();
            }
        }
    }
}
