using UnityEngine;
using System;
using TowerDefense.Utils;
namespace TowerDefense
{
    public class Tower : BaseTower, IAttackable, ITurnable
    {
        private Transform target;
        private Enemy targetEnemy;
        private string enemyTag => Define.GameplayTags.Enemy.ToString();

        public float turnSpeed { get; set; }
        public Transform partToRotate { get; set; }

        private void Start()
        {
            InvokeRepeating(nameof(UpdateTarget), 0f, 0.5f);
        }
        public void ExecuteAttack()
        {

        }

        private void Update()
        {
            if (target == null)
                return;

            LockOnTarget();
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

            if (nearestEnemy != null && shortestDistance <= range)
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
            //GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            //Bullet bullet = bulletGO.GetComponent<Bullet>();

            //if (bullet != null)
            //    bullet.Seek(target);
        }

        void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, range);
        }

    }
}
