using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TowerDefense.Data;
namespace TowerDefense
{
    public abstract class BaseTower : MonoBehaviour
    {
        public int Damage { get; set; }
        public float Range { get; set; }

        public float FireRate { get; set; }
        public float ProjectileSpeed { get; set; }

        private const int towerLevel = 1;

        Dictionary<int, Data.Tower> _towerData;

        private void Awake()
        {
            _towerData = DataManager.TowerData;
            Debug.Log($"TowerData {_towerData.Count}");

            SetTowerStat();
        }
        public virtual void SetTowerStat()
        {

            Damage = _towerData[towerLevel].damage;
            Range = _towerData[towerLevel].range;
            FireRate = _towerData[towerLevel].fireRate;
            ProjectileSpeed = _towerData[towerLevel].projectileSpeed;

        }
        public T Load<T>(string path) where T : Object
        {

            return Resources.Load<T>(path);
        }

        public GameObject Instantiate(string path, Transform parent = null)
        {
            GameObject original = Load<GameObject>($"Prefabs/{path}");
            if (original == null)
            {
                Debug.Log($"Faild to load prefab : {path}");
                return null;
            }

            GameObject go = Object.Instantiate(original, parent);
            go.name = original.name;

            return go;
        }
    }
}
