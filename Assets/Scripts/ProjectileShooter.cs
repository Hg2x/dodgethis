using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class ProjectileShooter : MonoBehaviour
    {
        [SerializeField] private Transform objectToPan;
        [SerializeField] private ParticleSystem projectileParticle;
        [SerializeField] private Transform projectileTarget;
        [SerializeField] private float attackRange = 20f;
        [SerializeField] private bool looksAtPlayer = true;

        // todo make particle interact with different hit objects differently
        void Update()
        {
            if (projectileTarget)
            {
                if (looksAtPlayer) // todo maybe do smth about this when false and target is out of range
                    objectToPan.LookAt(projectileTarget);
                FireAtEnemy();
            }
            else
            {
                Shoot(false);
            }
        }

        private void FireAtEnemy()
        {
            float distanceToEnemy = Vector3.Distance(projectileTarget.transform.position, gameObject.transform.position);
            if (distanceToEnemy <= attackRange)
            {
                Shoot(true);
            }
            else
            {
                Shoot(false);
            }
        }

        private void Shoot(bool isActive)
        {
            var emissionModule = projectileParticle.emission;
            emissionModule.enabled = isActive;
        }
    }
}
