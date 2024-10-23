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
        Dictionary<int, Data.Enemy> enemyStat = new Dictionary<int, Data.Enemy>();

        //Wave Variables
        [SerializeField] private int _currentWave = 0;
        private int _waveEnemies = 0;
        private bool isReady = false;
        private float _enemiesPerSecond = 5;
        private float _timeSinceLastSpawn;
        [SerializeField] private int _enemiesLeftToNextWave;

        [SerializeField] private int _totalWave;
        [SerializeField] private int _currentEnemyIndex;
        [SerializeField] private int _currentEnemyCount;
        private void Awake()
        {
            PrepareWave();

            _waveData = Managers.Data.WaveData;
            enemyStat = Managers.Data.EnemyData;

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
            _currentWave = 0;
            _totalWave = _readWave.Count;
            for (int i = 0; i < _readWave[0].enemies.Count; i++)
                _enemiesLeftToNextWave += _waveEnemies = _readWave[0].enemies[i].count;

            _currentEnemyCount = _readWave[_currentWave].enemies[0].count;
            _enemiesPerSecond = _readWave[_currentWave].waveSpawnPerSec;
        }

        private void FixedUpdate()
        {
            if (!isReady)
                return;

            _timeSinceLastSpawn += Time.deltaTime;

            if (_enemiesLeftToNextWave == 0 && _currentWave != _totalWave - 1)
                UpdateWave();

            if (_timeSinceLastSpawn >= (1f / _enemiesPerSecond) && _enemiesLeftToNextWave > 0)
            {

                SpawnEnemy();
                _currentEnemyCount--;
                _enemiesLeftToNextWave--;
                _timeSinceLastSpawn = 0f;
            }

        }
        private void SpawnEnemy()
        {
            if (_currentEnemyCount <= 0)
                UpdateEnemy();

            GameObject enemy = Managers.Resource.Instantiate("Enemies/" + _readWave[_currentWave].enemies[_currentEnemyIndex].id.ToString(), transform.position);
            enemy.GetComponent<Enemy>().Init(enemyStat[(int)_readWave[_currentWave].enemies[_currentEnemyIndex].id]);

        }

        private void UpdateEnemy()
        {

            _currentEnemyCount = _readWave[_currentWave].enemies[_currentEnemyIndex].count;
            if (_currentEnemyIndex < _readWave[_currentWave].enemies.Count - 1)
                _currentEnemyIndex++;
        }
        private void UpdateWave()
        {
            isReady = false;
            _currentEnemyIndex = 0;
            _currentWave++;
            _currentEnemyCount = _readWave[_currentWave].enemies[_currentEnemyIndex].count;

            for (int i = 0; i < _readWave[_currentWave].enemies.Count; i++)
                _enemiesLeftToNextWave += _waveEnemies = _readWave[_currentWave].enemies[i].count;

            _enemiesPerSecond = _readWave[_currentWave].waveSpawnPerSec;

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