
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 2;
    [SerializeField] private bool _isGiveSpeed;
    [SerializeField] private float _boosterForce;
    [SerializeField] private float _boosterTime;

    private Vector3 _target;

    public bool IsGiveSpeed => _isGiveSpeed;
    public float BoosterForce => _boosterForce;
    public float BoosterTime => _boosterTime;

    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.GetComponent<Player>())
            gameObject.SetActive(false);
    }

    private void Start ()
    {
        _target = Random.insideUnitCircle * 4;
    }

    private void Update ()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target, _speed * Time.deltaTime);

        if (transform.position == _target)
            _target = Random.insideUnitCircle * 4;
    }
}
