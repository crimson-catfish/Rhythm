using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponsStats", menuName = "ScriptableObjects/WeaponsStats")]
public class WeaponsStats : ScriptableObject
{
    [SerializeField] private List<Stats> statsList = new List<Stats>();
    public Dictionary<string, Stats> statsDict = new Dictionary<string, Stats>();

    [Serializable]
    public struct Stats
    {
        public string name;

        public float damage;
        public float projectileSpeed;

        public float altFireDamage;
        public float altFireProjectileSpeed;
        
    }

    private void OnEnable()
    {
        foreach (Stats enemy in statsList)
        {
            statsDict[enemy.name] = enemy;
        }
    }
}