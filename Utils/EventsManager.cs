using GunSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventsManager 
{
    public static Action OnGunsCycledForward;

    public static Action OnGunsCycledBackward;

    public static Action<WeaponCharactaristics> OnAddWeaponToInventory;

    public static Action<Modifier, WeaponCategory> OnAddMod;

    public static Action OnEnemyDeath;

    public static Action OnRoomCleared;
}
