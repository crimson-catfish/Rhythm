using System;
using UnityEngine;

[Serializable]
public class PistolCatana : Weapon
{
    [SerializeField] GameObject straightProjectilePrefab;


    protected override void HandlePrimalFire()
    {
        Instantiate(straightProjectilePrefab, transform.position, transform.rotation);
    }

    protected override void HandleAltFire()
    {
        throw new NotImplementedException();
    }
}
