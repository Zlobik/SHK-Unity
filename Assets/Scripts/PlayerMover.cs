using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private float _boosterTime = 0;
    private float _boosterForce = 0;
    private float _defaultSpeed;

    private void Start ()
    {
        _defaultSpeed = _speed;
    }

    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.TryGetComponent(out SquareBooster squareBooster))
        {
            _boosterForce = squareBooster.BoosterForce;
            _boosterTime = squareBooster.BoosterTime;

            StartCoroutine(Booster());
        }
    }

    private IEnumerator Booster ()
    {
        var waitForSeconds = new WaitForSeconds(_boosterTime);
        ChangeSpeed(_speed + _boosterForce);

        for (int i = 0; i < 1; i++)
        {
            yield return waitForSeconds;
        }

        ChangeSpeed(_defaultSpeed);
        StopCoroutine(Booster());
    }

    private void ChangeSpeed (float speed)
    {
        _speed = speed;
    }

    private void Update ()
    {
        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);

        transform.Translate(moveDirection * _speed * Time.deltaTime);
    }
}
