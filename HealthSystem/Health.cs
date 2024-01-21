using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace HealthSystem
{
    public class Health : MonoBehaviour
    {
        [SerializeField] float maxHealth;
        [SerializeField] float currentHealth;
        [SerializeField] GameObject deathVFX;

        private void Start()
        {
            currentHealth = maxHealth;
        }

        public void SetHealth(float health) => currentHealth = health;
        public void AddHealth(float health) => currentHealth += health;

        public void TakeDamage(float damage)
        {
            currentHealth -= damage;
            if(currentHealth < 0) 
            {
                GameObject vfx = Instantiate(deathVFX, transform.position, transform.rotation);
                ParticleSystem pS = vfx.GetComponent<ParticleSystem>();
                Destroy(vfx, pS.main.duration);

                EventsManager.OnEnemyDeath?.Invoke();

                Destroy(gameObject);
            }
        }
    }
}