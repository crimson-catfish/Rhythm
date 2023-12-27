using System;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "InputCenter", menuName = "ScriptableObjects/InputCenter")]
public class InputCenter : ScriptableObject, ControlMap.IGameplayActions, ControlMap.IUIActions
{
    public event Action<Vector2> OnMove;
    public event Action<Vector2> OnAim;
    public event Action OnDash;

    public event Action OnPrimalFire;
    public event Action OnAltFire;

    public event Action<int> OnWeaponSwitch;

    public event Action OnGrenadeChoose;
    public event Action OnGrenadeThrow;

    public event Action OnPause;
    public event Action OnResume;
    
    private ControlMap controlMap;


    private void OnEnable()
    {
        if (controlMap != null) return;

        controlMap = new ControlMap();

        controlMap.Gameplay.SetCallbacks(this);
        controlMap.UI.SetCallbacks(this);

        //TODO: make method for changing control maps
        controlMap.Disable();
        controlMap.Gameplay.Enable();
    }

    private void OnDisable()
    {
        if (controlMap == null) return;
        controlMap.Disable();
    }


    void ControlMap.IGameplayActions.OnMove(InputAction.CallbackContext context)
    {
        OnMove?.Invoke(context.ReadValue<Vector2>());
    }

    void ControlMap.IGameplayActions.OnAim(InputAction.CallbackContext context)
    {
        OnAim?.Invoke(context.ReadValue<Vector2>());
    }

    void ControlMap.IGameplayActions.OnDash(InputAction.CallbackContext context)
    {
        if (context.performed) OnDash?.Invoke();
    }

    void ControlMap.IGameplayActions.OnPrimalFire(InputAction.CallbackContext context)
    {
        if (context.performed) OnPrimalFire?.Invoke();
    }

    void ControlMap.IGameplayActions.OnAltFire(InputAction.CallbackContext context)
    {
        if (context.performed) OnAltFire?.Invoke();
    }

    void ControlMap.IGameplayActions.OnPistolCatanaChoose(InputAction.CallbackContext context)
    {
        if (context.performed) OnWeaponSwitch?.Invoke(0);
    }

    void ControlMap.IGameplayActions.OnEnergyRifleChoose(InputAction.CallbackContext context)
    {
        if (context.performed) OnWeaponSwitch?.Invoke(1);
    }

    void ControlMap.IGameplayActions.OnShotgunChoose(InputAction.CallbackContext context)
    {
        if (context.performed) OnWeaponSwitch?.Invoke(2);
    }

    void ControlMap.IGameplayActions.OnMachineGunChoose(InputAction.CallbackContext context)
    {
        if (context.performed) OnWeaponSwitch?.Invoke(3);
    }

    void ControlMap.IGameplayActions.OnGrenade(InputAction.CallbackContext context)
    {
        if (context.performed) OnGrenadeChoose?.Invoke();
        if (context.canceled) OnGrenadeThrow?.Invoke(); 
    }

    void ControlMap.IGameplayActions.OnPause(InputAction.CallbackContext context)
    {
        OnPause?.Invoke();
    }

    void ControlMap.IUIActions.OnResume(InputAction.CallbackContext context)
    {
        OnResume?.Invoke();
    }
}