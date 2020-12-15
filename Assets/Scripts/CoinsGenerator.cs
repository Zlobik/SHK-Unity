using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsGenerator : ObjectPool
{
    [SerializeField] private GameObject _coinLine;
    [SerializeField] private float _secondsBetweenSpawn = 1f;

    private float _elapsedTime = 0;
    private Vector3 _currentOffset;

    private void Start ()
    {
        Initialize(_coinLine);
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
                Vector3 spawnPoint = new Vector3(transform.position.x + Random.Range(1, 12), transform.position.y, transform.position.z);
                let.SetActive(true);
                let.transform.position = spawnPoint;
            }
        }
    }
}
