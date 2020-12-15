using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected float Speed = 2;
    [SerializeField] protected float TargetSpreed = 4;

    private Vector3 _target;

    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.GetComponent<Player>())
            gameObject.SetActive(false);
    }

    private void Start ()
    {
        SetNewTarget();
    }

    private void Update ()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target, Speed * Time.deltaTime);

        if (transform.position == _target)
            SetNewTarget();
    }

    protected void SetNewTarget ()
    {
        _target = Random.insideUnitCircle * TargetSpreed;
    }
}
