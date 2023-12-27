using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    [SerializeField] protected WeaponsStats weaponsStats;

    protected WeaponsStats.Stats stats;


    private void OnEnable()
    {
        stats = weaponsStats.statsDict[this.GetType().Name.ToString()];
    }
}
