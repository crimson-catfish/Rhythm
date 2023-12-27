using System;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected EnemiesStats enemiesStats;

    protected PistolCatana pistolCatana;
    protected EnemiesStats.Stats stats;


    private void OnEnable()
    {
        enemiesStats.statsDict.TryGetValue(this.GetType().Name.ToString(), out stats);
    }


    public void TakeDamage(float damage)
    {
        stats.hitPoints -= 1;
        if (stats.hitPoints <= 0)
            Destroy(this.gameObject);
    }
}
