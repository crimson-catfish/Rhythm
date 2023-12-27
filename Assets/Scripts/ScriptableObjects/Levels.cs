using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Levels", menuName = "ScriptableObjects/Levels")]
public class Levels : ScriptableObject
{
    public List<LevelData> levelsList = new List<LevelData>();

    [Serializable]
    public struct LevelData
    {
        public AudioClip track;
        public float bpm;
    }
}
