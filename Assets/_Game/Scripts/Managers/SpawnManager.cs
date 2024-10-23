using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TowerDefense.Data;
using TowerDefense.Utils;
namespace TowerDefense
{
    public class SpawnManager : MonoBehaviour
    {
        //Data
        [SerializeField] List<ReadWave> _readWave;

        private Dictionary<int, Wave> _waveData = new Dictionary<int, Wave>();


        //Wave Variables
        [SerializeField] private int _waveID = 0;
        private int _waveEnemies = 0;
        private bool isReady = false;
        [SerializeField] private float _enemiesPerSecond = 5;
        private float _timeSinceLastSpawn;
        [SerializeField] private int _enemiesLeftToSpawn;
        private int _enemiesAlive;
        [SerializeField] private int _totalWave;
        [SerializeField] private int _currentEnemyIndex;
        private void Awake()
        {
            PrepareWave();

            _waveData = Managers.Data.WaveData;

            Init();
        }

        private void Init()
        {
            for (int i = 1; i <= _waveData.Count; i++)
            {
                ReadWave read = new ReadWave();
                _readWave.Add(read);

                for (int b = 0; b < _waveData[i].enemies.Count; b++)
                {
                    if (Enum.TryParse<Define.EnemyStyle>(_waveData[i].enemies[b].name, out Define.EnemyStyle enemyStyle))
                    {
                        SpawnEnemies enemies = new SpawnEnemies();
                        enemies.id = enemyStyle;
                        enemies.count = _waveData[i].enemies[b].count;
                        read.waveSpawnPerSec = _waveData[i].enemySpawnPerSec;
                        read.enemies.Add(enemies);

                    }
                }
            }

            _currentEnemyIndex = 0;
            _waveID = 0;
            _totalWave = _readWave.Count;
            for (int i = 0; i < _readWave[0].enemies.Count; i++)
                _enemiesLeftToSpawn += _waveEnemies = _readWave[0].enemies[i].count;

            _enemiesPerSecond = _readWave[_waveID].waveSpawnPerSec;
        }

        private void FixedUpdate()
        {
            if (!isReady)
                return;

            _timeSinceLastSpawn += Time.deltaTime;

            if (_enemiesLeftToSpawn == 0 && _waveID != _totalWave)
                UpdateWave();

            if (_timeSinceLastSpawn >= (1f / _enemiesPerSecond) && _enemiesLeftToSpawn > 0)
            {

                SpawnEnemy();
                _enemiesLeftToSpawn--;
                _enemiesAlive++;
                _timeSinceLastSpawn = 0f;
            }

        }
        private void SpawnEnemy()
        {
            GameObject enemy = Managers.Resource.Instantiate("Enemies/" + _readWave[_waveID].enemies[_currentEnemyIndex].id.ToString(), transform.position);
        }
        private void UpdateWave()
        {
            isReady = false;

            _waveID++;

            for (int i = 0; i < _readWave[0].enemies.Count; i++)
                _enemiesLeftToSpawn += _waveEnemies = _readWave[0].enemies[i].count;

            _enemiesPerSecond = _readWave[_waveID].waveSpawnPerSec;

            isReady = true;
        }
        private void PrepareWave()
        {
            foreach (var wave in _waveData)
            {
                Debug.Log($"Wave {wave}");
            }

            isReady = true;
        }
    }
    [Serializable]
    public class ReadWave
    {
        public float waveSpawnPerSec;

        public List<SpawnEnemies> enemies = new List<SpawnEnemies>();

    }

    [Serializable]
    public class SpawnEnemies
    {

        public Define.EnemyStyle id;
        public int count;


    }
}