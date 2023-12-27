using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class StraightProjectile : Bullet
{
    private Vector3 previousPosition;
    private float deltaTime;


    private void Start()
    {
        previousPosition = transform.position;
    }

    private void FixedUpdate()
    {
        previousPosition = transform.position;
        deltaTime = Time.deltaTime;
        transform.Translate(transform.forward * stats.projectileSpeed * deltaTime, Space.World);  
        RaycastDoubleCollisionCheck();
    }


    private void RaycastDoubleCollisionCheck()
    {
        Ray forwardRay = new Ray(previousPosition, (transform.position - previousPosition).normalized);
        Debug.DrawRay(previousPosition, (transform.position - previousPosition).normalized, Color.yellow, 10);
        RaycastCollisionCheck(forwardRay);
        Ray backwardRay = new Ray(transform.position, (previousPosition - transform.position).normalized);
        RaycastCollisionCheck(backwardRay);
    }

    private void RaycastCollisionCheck(Ray hitRay)
    {
        RaycastHit hit;
        Physics.Raycast(hitRay, out hit, (transform.position - previousPosition).magnitude);
        if (hit.collider != null)
        {
            if (hit.collider.gameObject.CompareTag("Enemy"))
            {
                hit.collider.gameObject.GetComponent<Enemy>().TakeDamage(stats.damage);
            }
            Destroy(this.gameObject);
        }
    }

}