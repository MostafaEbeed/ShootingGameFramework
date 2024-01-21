using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Pool;

namespace GunSystem
{
    [CreateAssetMenu(fileName = "SpreadShot", menuName = "GunSystem/GunTypes/SpreadShot")]
    public class SpreadShot : WeaponCharactaristics
    {
        [SerializeField] float spreadAngle = 15f;
        [SerializeField] int numberOfShots;

        public override void Fire(Transform firePoint)
        {
            for (int i = 0; i < numberOfShots; i++) 
            {
                var projectile = LeanPool.Spawn(projectilePrefab, firePoint.position, firePoint.rotation);
                projectile.transform.SetParent(firePoint);
                projectile.transform.Rotate(0f, spreadAngle * (i - 1), 0);

                var projectileComponent = projectile.GetComponent<Projectile>();
                projectileComponent.SetSpeed(projectileSpeed);

                LeanPool.Despawn(projectile, projectileLifetime);
            }
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