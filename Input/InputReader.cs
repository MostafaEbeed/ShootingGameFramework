using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour
{
    [SerializeField] CustomInput input;
    Vector2 moveVector;
    Vector2 aimVector;
    bool fireActionPerformed;
    bool playerInteractPerformed;

    [SerializeField] public bool isGamepad;

    public Vector2 MoveVector => moveVector;
    public Vector2 AimVector => aimVector;
    public bool FireActionPerformed => fireActionPerformed;
    public bool PlayerInteractPerformed => playerInteractPerformed;

    private void Awake()
    {
        input = new CustomInput();
    }

    private void OnEnable()
    {
        input.Enable();

        input.Player.PlayerInteract.performed += OnPlayerInteractPerformed;
        input.Player.PlayerInteract.canceled += OnPlayerInteractCanceled;
        input.Player.CycleGunsBackward.performed += OnCyclingBackwardGunsPerformed;
        input.Player.CycleGunsBackward.canceled += OnCyclingBackwardGunsCanceled;
        input.Player.CycleGunsForward.performed += OnCyclingForwardGunsPerformed;
        input.Player.CycleGunsForward.canceled += OnCyclingForwardGunsCanceled;
        input.Player.Aim.performed += OnAimPerformed;
        input.Player.Aim.canceled += OnAimCanceled;
        input.Player.Movement.performed += OnMovementPerformed;
        input.Player.Movement.canceled += OnMovementCanceled;
        input.Player.FireAction.performed += OnFireActionPerformed;
        input.Player.FireAction.canceled += OnFireActionCanceled;
    }

    private void OnPlayerInteractPerformed(InputAction.CallbackContext context)
    {
        playerInteractPerformed = context.performed;
    }

    private void OnPlayerInteractCanceled(InputAction.CallbackContext context)
    {
        playerInteractPerformed = false;
    }

    private void OnCyclingBackwardGunsPerformed(InputAction.CallbackContext context)
    {
        if (context.performed)
            EventsManager.OnGunsCycledBackward?.Invoke();
    }

    private void OnCyclingBackwardGunsCanceled(InputAction.CallbackContext context)
    {
    }

    private void OnCyclingForwardGunsPerformed(InputAction.CallbackContext context)
    {
        if (context.performed)
            EventsManager.OnGunsCycledForward?.Invoke();
    }

    private void OnCyclingForwardGunsCanceled(InputAction.CallbackContext context)
    {
    }

    private void OnAimPerformed(InputAction.CallbackContext value)
    {
        aimVector = value.ReadValue<Vector2>();
    }

    private void OnAimCanceled(InputAction.CallbackContext context)
    {
        aimVector = Vector2.zero;
    }


    private void Update()
    {
        //Debug.Log(aimVector);
    }

    private void OnMovementPerformed(InputAction.CallbackContext value)
    {
        moveVector = value.ReadValue<Vector2>();
    }

    private void OnMovementCanceled(InputAction.CallbackContext value)
    {
        moveVector = Vector2.zero;
    }

    private void OnFireActionPerformed(InputAction.CallbackContext context)
    {
        fireActionPerformed = context.performed;
    }

    private void OnFireActionCanceled(InputAction.CallbackContext context)
    {
        fireActionPerformed = context.performed;
    }

    public void OnDeviceChange(PlayerInput pi)
    {
        isGamepad = pi.currentControlScheme.Equals("Controller") ? true : false;
    }

    private void OnDisable()
    {
        input?.Disable();

        input.Player.PlayerInteract.performed -= OnPlayerInteractPerformed;
        input.Player.PlayerInteract.canceled -= OnPlayerInteractCanceled;
        input.Player.CycleGunsBackward.performed -= OnCyclingBackwardGunsPerformed;
        input.Player.CycleGunsBackward.canceled -= OnCyclingBackwardGunsCanceled;
        input.Player.CycleGunsForward.performed -= OnCyclingForwardGunsPerformed;
        input.Player.CycleGunsForward.canceled -= OnCyclingForwardGunsCanceled;
        input.Player.Aim.canceled -= OnAimPerformed;
        input.Player.Aim.canceled -= OnAimCanceled;
        input.Player.Movement.performed -= OnMovementPerformed;
        input.Player.Movement.canceled -= OnMovementCanceled;
        input.Player.FireAction.performed -= OnFireActionPerformed;
        input.Player.FireAction.canceled -= OnFireActionCanceled;
    }

}
