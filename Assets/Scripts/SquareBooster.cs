using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareBooster : Square
{
    [SerializeField] private float _boosterForce;
    [SerializeField] private float _boosterTime;

    public float BoosterForce => _boosterForce;
    public float BoosterTime => _boosterTime;
}
