using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GunSystem
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] protected WeaponCharactaristics weaponCharactaristics;
        [SerializeField] protected Transform firePoint;
        [SerializeField] protected Transform throwablesFirePoint;

        void Start() => weaponCharactaristics.Initialize();

        public void SetupOnEquip()
        {
            Debug.Log("WweaponEquipped!");
            firePoint = weaponCharactaristics.FirePoint;
        }

        public void SetWeaponCharactaristics(WeaponCharactaristics charactaristics)
        {
            weaponCharactaristics = charactaristics;
            weaponCharactaristics.Initialize();
            SetupOnEquip();
        }
    }
}