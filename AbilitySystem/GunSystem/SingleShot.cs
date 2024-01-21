using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Pool;

namespace GunSystem
{
    [CreateAssetMenu(fileName = "SingleShot", menuName = "GunSystem/GunTypes/SingleShot")]
    public class SingleShot : WeaponCharactaristics
    {
        public override void Fire(Transform firePoint)
        {
            var projectile = LeanPool.Spawn(projectilePrefab, firePoint.position, firePoint.rotation);
            projectile.transform.SetParent(firePoint);

            var projectileComponent = projectile.GetComponent<Projectile>();
            projectileComponent.SetSpeed(projectileSpeed);

            LeanPool.Despawn(projectile, projectileLifetime);
        }

        public override void ApplyFireRateMods(float value)
        {
            finalFireRate = value;
        }

        public override void ApplyDamageMods(float value)
        {
            finalDamage = value;
        }
    }
}