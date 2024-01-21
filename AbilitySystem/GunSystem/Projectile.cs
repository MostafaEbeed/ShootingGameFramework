using System;
using UnityEngine;
using HealthSystem;


namespace GunSystem
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] float speed;
        [SerializeField] float damage;
        [SerializeField] GameObject muzzlePrefab;
        [SerializeField] GameObject hitPrefab;

        Transform parent;
        PlayerWeapon playerWeapon;

        public void SetSpeed(float speed) => this.speed = speed;
        public void SetParent(Transform parent) => this.parent = parent;

        public Action Callback;

        private void Start()
        {
            playerWeapon = FindObjectOfType<PlayerWeapon>();

            if (muzzlePrefab != null)
            {
                var muzzleVFX = Instantiate(muzzlePrefab, transform.position, Quaternion.identity);
                muzzleVFX.transform.forward = gameObject.transform.forward;
                muzzleVFX.transform.SetParent(parent);

                DestroyParticleSystem(muzzleVFX);
            }
        }

        private void Update()
        {
            transform.SetParent(null);
            transform.position += transform.forward * (speed * Time.deltaTime);

            Callback?.Invoke();
        }


        private void DestroyParticleSystem(GameObject vfx)
        {
            var ps = vfx.GetComponent<ParticleSystem>();
            if (ps == null)
            {
                ps = vfx.GetComponentInChildren<ParticleSystem>();
            }
            Destroy(vfx, ps.main.duration);
        }


        private void OnTriggerEnter(Collider other)
        {
            Health health = other.gameObject.GetComponent<Health>();
            if(health != null)
            {
                health.TakeDamage(playerWeapon.ModifiedDamage);
                Destroy(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }    
        }

        void OnCollisionEnter(Collision collision)
        {
            if (hitPrefab != null)
            {
                ContactPoint contact = collision.contacts[0];
                var hitVFX = Instantiate(hitPrefab, contact.point, Quaternion.identity);

                DestroyParticleSystem(hitVFX);
            }

            

            /*var plane = collision.gameObject.GetComponent<Plane>();
            if (plane != null)
            {
                plane.TakeDamage(10);
            }   */

            Destroy(gameObject);
        }
    }
}