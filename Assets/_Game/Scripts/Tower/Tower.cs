using UnityEngine;
using System;
using TowerDefense.Utils;

namespace TowerDefense
{
    public class Tower : BaseTower, ITurnable
    {

        [SerializeField] private Transform target;
        private Enemy targetEnemy;
        private string enemyTag => Define.GameplayTags.Enemy.ToString();

        public float turnSpeed { get; set; }

        [SerializeField] private Transform partToRotate;

        private bool isReady = false;
        private void Start()
        {
            InvokeRepeating(nameof(UpdateTarget), 0f, 0.5f);
            BuildingsGrid.OnBuildPlaced += Ready;
        }

        private void Ready()
        {
            isReady = true;
        }
        private void Update()
        {
            if (target == null || !isReady)
                return;

            LockOnTarget();

            if (FireRate <= 0f)
            {
                Shoot();
                FireRate = 1f / FireRate;
            }

            FireRate -= Time.deltaTime;
        }

        private void LockOnTarget()
        {
            Vector3 dir = target.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(dir);
            Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
            partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
        }
        private void UpdateTarget()
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
            float shortestDistance = Mathf.Infinity;
            GameObject nearestEnemy = null;
            foreach (GameObject enemy in enemies)
            {
                float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
                if (distanceToEnemy < shortestDistance)
                {
                    shortestDistance = distanceToEnemy;
                    nearestEnemy = enemy;
                }
            }

            if (nearestEnemy != null && shortestDistance <= Range)
            {
                target = nearestEnemy.transform;
                targetEnemy = nearestEnemy.GetComponent<Enemy>();
            }
            else
            {
                target = null;
            }
        }

        void Shoot()
        {
            GameObject bulletGO = Instantiate("Weapons/Bullet");//(GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

            SetWeapon(bulletGO);
            /*
            if (bullet != null)
                bullet.Seek(target);*/
        }
        private void SetWeapon(GameObject weapon, float angle = 0)
        {
            Bullet bullet = weapon.GetComponent<Bullet>();
            bullet.damage = Damage;
            bullet.speed = ProjectileSpeed;
        }
        void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, Range);
        }
    }
}

