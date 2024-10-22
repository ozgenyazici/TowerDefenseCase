using System;
using UnityEngine;
using System.Collections.Generic;
namespace TowerDefense.Data
{

    #region Enemies
    [Serializable]
    public class Enemy
    {
        public int id;
        public string name;
        public int maxHp;
        public int damage;
        public float moveSpeed;
    }

    [Serializable]
    public class EnemyData : ILoader<int, Enemy>
    {
        public List<Enemy> enemies = new List<Enemy>();
        public Dictionary<int, Enemy> MakeDict()
        {
            Dictionary<int, Enemy> dict = new Dictionary<int, Enemy>();
            foreach (Enemy enemy in enemies)
                dict.Add(enemy.id, enemy);

            return dict;
        }
    }
    #endregion

    #region Wave

    [Serializable]
    public class Enemies
    {
        public string name;
        public int count;
    }

    [Serializable]
    public class Wave
    {
        public int id;
        public float enemySpawnPerSec;
        public List<Enemies> enemies;
    }
    [Serializable]
    public class WaveData : ILoader<int, Wave>
    {
        public List<Wave> waves = new List<Wave>();
        public Dictionary<int, Wave> MakeDict()
        {
            Dictionary<int, Wave> dict = new Dictionary<int, Wave>();
            foreach (Wave wave in waves)
                dict.Add(wave.id, wave);

            return dict;
        }
    }

    #endregion

}