using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemiesStats", menuName = "ScriptableObjects/EnemiesStats")]
public class EnemiesStats : ScriptableObject
{
    [SerializeField] private List<Stats> statsList = new List<Stats>();
    public Dictionary<string, Stats> statsDict = new Dictionary<string, Stats>();
    
    [Serializable]
    public struct Stats
    {
        public string name;

        public float hitPoints;
        public float damage;
        public float speed;
    }
 
    private void OnEnable()
    {
        foreach (Stats enemy in statsList)
        {
            statsDict[enemy.name] = enemy;
        }
    }
}