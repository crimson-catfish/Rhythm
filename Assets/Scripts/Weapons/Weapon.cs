using System;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private InputCenter inputCenter;

    protected abstract void HandlePrimalFire();
    protected abstract void HandleAltFire();

    protected void OnEnable()
    {
        inputCenter.OnPrimalFire += HandlePrimalFire;
        inputCenter.OnAltFire += HandleAltFire;
    }

    protected void OnDisable()
    {
        inputCenter.OnPrimalFire -= HandlePrimalFire;
        inputCenter.OnAltFire -= HandleAltFire;
    }
}