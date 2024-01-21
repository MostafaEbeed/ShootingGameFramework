using Lean.Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GunSystem
{
    public enum ThrowableType
    {
        Grenade,
        Molotov
    }

    [CreateAssetMenu(fileName = "SingleShot", menuName = "GunSystem/Throwables/Throwable")]
    public class Throwable : WeaponCharactaristics
    {
        [SerializeField] ThrowableType type;


        public ThrowableType ThrowableType => type;

        public override void SetupWeaponGraphics(Transform socket)
        {
            base.SetupWeaponGraphics(socket);
        }

        public override void ApplyDamageMods(float value)
        {
        }

        public override void ApplyFireRateMods(float value)
        {
        }

        public override void Fire(Transform firePoint)
        {
            Debug.Log("Fireeeeeeee");
            GameObject grnd = LeanPool.Spawn(projectilePrefab, firePoint);
            grnd.transform.SetParent(null);
            grnd.GetComponent<Rigidbody>().useGravity = true;
            grnd.GetComponent<Rigidbody>().AddForce(firePoint.up * 8f, ForceMode.Impulse);
            grnd.GetComponent<Rigidbody>().AddForce(firePoint.forward * 12f, ForceMode.Impulse);
        }
    }
}