using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GunSystem
{
    public class ModsManager : MonoBehaviour
    {
        [SerializeField] List<Modifier> pistolsFireRatsMods;
        [SerializeField] List<Modifier> pistolsDamageMods;

        [SerializeField] List<Modifier> machineGunsFireRatsMods;
        [SerializeField] List<Modifier> machineGunsDamageMods;

        [SerializeField] List<Modifier> shotGunsFireRatsMods;
        [SerializeField] List<Modifier> shotGunsDamageMods;

        private void Awake()
        {
            EventsManager.OnAddMod += AddMod;
        }

        public float CalculateFireRate(float fireRate, WeaponCategory wCateg)
        {
            switch (wCateg)
            {
                case WeaponCategory.MachineGun:
                    if (!(machineGunsFireRatsMods.Count > 0)) return fireRate;

                    for (int i = 0; i < machineGunsFireRatsMods.Count; i++)
                    {
                        fireRate += machineGunsFireRatsMods[i].ModValue;
                    }
                    return fireRate;
                case WeaponCategory.Pistol:
                    if (!(pistolsFireRatsMods.Count > 0)) return fireRate;

                    for (int i = 0; i < pistolsFireRatsMods.Count; i++)
                    {
                        fireRate += pistolsFireRatsMods[i].ModValue;
                    }
                    return fireRate;
                case WeaponCategory.ShotGun:
                    if (!(shotGunsFireRatsMods.Count > 0)) return fireRate;

                    for (int i = 0; i < shotGunsFireRatsMods.Count; i++)
                    {
                        fireRate += shotGunsFireRatsMods[i].ModValue;
                    }
                    return fireRate;
                default:
                    break;
            }

            return fireRate;
        }

        public float CalculateDamage(float damage)
        {
            if (!(pistolsDamageMods.Count > 0)) return damage;

            for (int i = 0; i < pistolsDamageMods.Count; i++)
            {
                damage += pistolsDamageMods[i].ModValue;
            }

            return damage;
        }

        void AddMod(Modifier mod, WeaponCategory wCateg)
        {
            switch (wCateg)
            {
                case WeaponCategory.MachineGun:
                    if (mod.ModType == GunModifierType.FireRateMod)
                        machineGunsFireRatsMods.Add(mod);

                    if (mod.ModType == GunModifierType.DamageMod)
                        machineGunsDamageMods.Add(mod);
                    break;
                case WeaponCategory.Pistol:
                    if (mod.ModType == GunModifierType.FireRateMod)
                        pistolsFireRatsMods.Add(mod);

                    if (mod.ModType == GunModifierType.DamageMod)
                        pistolsDamageMods.Add(mod);
                    break;
                case WeaponCategory.ShotGun:
                    if (mod.ModType == GunModifierType.FireRateMod)
                        shotGunsFireRatsMods.Add(mod);

                    if (mod.ModType == GunModifierType.DamageMod)
                        shotGunsDamageMods.Add(mod);
                    break;
                default:
                    break;
            }

           
        }
    }
}