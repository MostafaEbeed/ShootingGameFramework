using Lean.Pool;
using System.Net.Sockets;
using UnityEngine;

namespace GunSystem
{
    public enum WeaponCategory
    {
        MachineGun,
        Pistol,
        ShotGun,
        Throwable
    }

    public abstract class WeaponCharactaristics : ScriptableObject
    {
        [SerializeField] WeaponCategory category;
        [SerializeField] float startDamage = 10;
        [SerializeField] float startFireRate = 0.5f;
        
        [SerializeField] SFX sfx;
        [SerializeField] protected float projectileSpeed = 10f;
        [SerializeField] protected float projectileLifetime = 4f;
        [SerializeField] protected GameObject weaponPrefab;
        [SerializeField] protected GameObject projectilePrefab;

        protected Transform firePoint;
        protected float finalDamage;
        protected float finalFireRate;
        protected Rigidbody rb;

        public GameObject WeaponPrefab => weaponPrefab;
        public Transform FirePoint => firePoint;
        public WeaponCategory Category => category;
        public Rigidbody Rb => rb;

        public float FinalDamage => finalDamage;
        public float StartDamage => startDamage;
        public SFX SFX => sfx;
        public float StartFireRate => startFireRate;
        public float FinalFireRate => finalFireRate;

        public virtual void Initialize()
        {
            
        }

        public virtual void SetupWeaponGraphics(Transform socket)
        {
            if(socket.childCount> 0)
            {
                for(int i = 0; i < socket.childCount; i++) 
                {
                    LeanPool.Despawn(socket.GetChild(i));
                }
            }

            GameObject gun = LeanPool.Spawn(weaponPrefab, socket.position, socket.rotation);
            gun.transform.SetParent(socket.transform);
            if(gun.transform.childCount > 0)
            {
                firePoint = gun.transform.GetChild(1).transform;
            }
        }

        public abstract void Fire(Transform firePoint);

        public abstract void ApplyFireRateMods(float value);

        public abstract void ApplyDamageMods(float value);
    }
}