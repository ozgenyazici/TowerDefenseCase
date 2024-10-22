using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public abstract class BaseTower : MonoBehaviour
    {
        public float Damage { get; set; }
        public float Range { get; set; }

        public float FireRate { get; set; }
        public float ProjectileSpeed { get; set; }

        private const int towerLevel = 0;

        Dictionary<int, Data.Tower> _towerData;

        private void Start()
        {
            SetTowerStat();
        }
        protected virtual void SetTowerStat()
        {
            Damage = _towerData[towerLevel].damage;
            Range = _towerData[towerLevel].range;
            FireRate = _towerData[towerLevel].fireRate;
            ProjectileSpeed = _towerData[towerLevel].projectileSpeed;
        }

    }
}
