using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBooster : Enemy
{
    [SerializeField] private float _boosterForce;
    [SerializeField] private float _boosterTime;

    public float BoosterForce => _boosterForce;
    public float BoosterTime => _boosterTime;

}
