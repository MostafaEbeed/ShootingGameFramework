using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GunSystem
{
    public class PlayerWeapon : Weapon
    {
        float fireTimer;
        [SerializeField] InputReader inputReader;
        [SerializeField] float modifiedDamage;
        [SerializeField] float modifiedFireRate;
        [SerializeField] float pistolsModifiedFireRate;
        [SerializeField] float machineGunsModifiedFireRate;
        [SerializeField] float ShotGunsModifiedFireRate;

        [SerializeField] PlaySFXOnAction playSFXOnAction;
        [SerializeField] ModsManager modsManager;

        [SerializeField] CameraShake cameraShake;

        public float ModifiedDamage => modifiedDamage;

        private void Start()
        {
            EventsManager.OnGunsCycledForward += ApplyMods;
            EventsManager.OnGunsCycledBackward += ApplyMods;
        }

        private void OnDestroy()
        {
            EventsManager.OnGunsCycledForward -= ApplyMods;
            EventsManager.OnGunsCycledBackward -= ApplyMods;
        }

        void Update()
        {
            if (weaponCharactaristics == null) return;

            fireTimer += Time.deltaTime;

            if (inputReader.FireActionPerformed)
            {
                ApplyMods();
                if(fireTimer >= modifiedFireRate)
                {
                    if(weaponCharactaristics.Category == WeaponCategory.Throwable)
                    {
                        weaponCharactaristics.Fire(throwablesFirePoint);
                    }
                    else
                    {
                        weaponCharactaristics.Fire(firePoint);
                    }
                    cameraShake.PerformCameraShake();
                    playSFXOnAction.PlaySFX(weaponCharactaristics.SFX);
                    fireTimer = 0f;
                }
            }
        }

        void ApplyMods()
        {
            if (weaponCharactaristics == null) return;

            weaponCharactaristics.ApplyFireRateMods(modifiedFireRate = modsManager.CalculateFireRate(weaponCharactaristics.StartFireRate, weaponCharactaristics.Category));
            weaponCharactaristics.ApplyDamageMods(modifiedDamage = modsManager.CalculateDamage(weaponCharactaristics.StartDamage));

            /*if (weaponCharactaristics != null)
            {
                weaponCharactaristics.ApplyFireRateMods(modifiedFireRate = modsManager.CalculateFireRate(weaponCharactaristics.StartFireRate, weaponCharactaristics.Category));
                weaponCharactaristics.ApplyDamageMods(modifiedDamage = modsManager.CalculateDamage(weaponCharactaristics.StartDamage));
            } */
        }
    }
}