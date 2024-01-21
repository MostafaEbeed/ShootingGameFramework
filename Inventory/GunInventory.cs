using GunSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory
{
    public class GunInventory : MonoBehaviour
    {
        [SerializeField] List<WeaponCharactaristics> Guns;
        [SerializeField] List<WeaponCharactaristics> Grenades;
        [SerializeField] WeaponCharactaristics currentWeapon;
        [SerializeField] PlayerWeapon playerWeapon;
        [SerializeField] Transform gunSocket;
        int cyclingIndex = -1;


        private void Awake()
        {
            EventsManager.OnGunsCycledForward += CycleForwardThrouhCarriedGuns;
            EventsManager.OnGunsCycledBackward += CycleBackwardThrouhCarriedGuns;
            EventsManager.OnAddWeaponToInventory += AddGun;
        }

        private void Start()
        {
            cyclingIndex = 0;
            EventsManager.OnGunsCycledForward?.Invoke();
        }

        public void CycleForwardThrouhCarriedGuns()
        {
            cyclingIndex++;
            if (cyclingIndex >= Guns.Count) cyclingIndex = 0;

            if(Guns.Count > 0)
            {
                currentWeapon = Guns[cyclingIndex];
                currentWeapon.SetupWeaponGraphics(gunSocket);           //for future
                playerWeapon.SetWeaponCharactaristics(currentWeapon);
            }
        }

        public void CycleBackwardThrouhCarriedGuns()
        {
            cyclingIndex--;
            if (cyclingIndex < 0) cyclingIndex = Guns.Count - 1;

            if (Guns.Count > 0)
            {
                currentWeapon = Guns[cyclingIndex];
                currentWeapon.SetupWeaponGraphics(gunSocket);           //for future
                playerWeapon.SetWeaponCharactaristics(currentWeapon);
            }
        }

        public void AddGun(WeaponCharactaristics _weapon)
        {
            if(Guns.Contains(_weapon)) return;

            if(_weapon.Category == WeaponCategory.Throwable)
            {
                Throwable throwable = (Throwable) _weapon;
                if(throwable.ThrowableType == ThrowableType.Grenade)
                {
                    Grenades.Add(_weapon);
                }
            }
            else
            {
                Guns.Add(_weapon);
            }
        }

        public void RemoveGun(WeaponCharactaristics gun)
        {
            
        }

        private void OnDestroy()
        {
            EventsManager.OnGunsCycledForward -= CycleForwardThrouhCarriedGuns;
            EventsManager.OnGunsCycledBackward -= CycleBackwardThrouhCarriedGuns;
            EventsManager.OnAddWeaponToInventory -= AddGun;
        }
    }
}