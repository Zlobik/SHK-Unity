using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour
{
    [SerializeField] private float _speed = 2;
    [SerializeField] private float _movementRadius = 4;

    private Vector3 _target;

    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.GetComponent<Player>())
            gameObject.SetActive(false);
    }

    private void Start ()
    {
        CreateNewTarget();
    }

    private void Update ()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target, _speed * Time.deltaTime);

        if (transform.position == _target)
            CreateNewTarget();
    }

    protected void CreateNewTarget ()
    {
        _target = Random.insideUnitCircle * _movementRadius;
    }
}
