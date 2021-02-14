using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.TryGetComponent(out SquareBooster squareBooster))
        {
            StartCoroutine(Booster(squareBooster.BoosterTime, squareBooster.BoosterForce));
        }
    }

    private IEnumerator Booster (float boosterTime, float boosterForce)
    {
        var waitForSeconds = new WaitForSeconds(boosterTime);

        _speed += boosterForce;
        yield return waitForSeconds;
        _speed -= boosterForce;
    }

    private void Update ()
    {
        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);

        transform.Translate(moveDirection * _speed * Time.deltaTime);
    }
}
