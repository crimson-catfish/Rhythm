using System;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponsMenager : MonoBehaviour
{
    public int currentWeapon = 0;
    [SerializeField] private InputCenter inputCenter;

    
    private void OnEnable()
    {
        inputCenter.OnWeaponSwitch += HandleWeaponSwitch;
    }

    private void HandleWeaponSwitch(int newWeapon)
    {
        this.transform.GetChild(currentWeapon).gameObject.SetActive(false);
        this.transform.GetChild(newWeapon).gameObject.SetActive(true);
        currentWeapon = newWeapon;
    }
}