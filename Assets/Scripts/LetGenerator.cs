using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetGenerator : ObjectPool
{
    [SerializeField] private GameObject _template;
    [SerializeField] private float _secondsBetweenSpawn = 1f;

    private float _elapsedTime = 0;
    private Vector3 _currentOffset;

    private void Start ()
    {
        Initialize(_template);
        _currentOffset = transform.position;
    }

    private void Update ()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _secondsBetweenSpawn)
        {
            if (TryGetObject(out GameObject let))
            {
                _elapsedTime = 0;
                Vector3 spawnPoint = new Vector3(transform.position.x + Random.Range(0, 10), transform.position.y, transform.position.z);
                let.SetActive(true);
                let.transform.position = spawnPoint;
            }
        }
    }
}
