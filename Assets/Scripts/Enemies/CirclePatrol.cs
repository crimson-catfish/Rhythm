using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

class CirclePatrol : Enemy
{
    [SerializeField] private float patrolRadius;

    private Vector3 spawnPosition;
    

    private void Start()
    {
        spawnPosition = transform.position;
    }

    void FixedUpdate()
    {
        Move();
    }


    private void Move()
    {
        transform.position = spawnPosition + new Vector3
        (
            patrolRadius * Mathf.Sin(Time.time * stats.speed),
            0.0f,
            patrolRadius * Mathf.Cos(Time.time * stats.speed)
        );
    }
}