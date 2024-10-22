using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TowerDefense.Data
{
    public interface ILoader<Key, Value>
    {
        Dictionary<Key, Value> MakeDict();
    }

    public class DataManager
    {
        public Dictionary<int, Enemy> EnemyData { get; private set; } = new Dictionary<int, Enemy>();
        public Dictionary<int, Wave> WaveData { get; private set; } = new Dictionary<int, Wave>();
        public Dictionary<int, Tower> TowerData { get; private set; } = new Dictionary<int, Tower>();
        public void Init()
        {
            EnemyData = LoadJson<EnemyData, int, Enemy>(nameof(EnemyData)).MakeDict();
            WaveData = LoadJson<WaveData, int, Wave>(nameof(WaveData)).MakeDict();
            TowerData = LoadJson<TowerData, int, Tower>(nameof(TowerData)).MakeDict();

        }

        Loader LoadJson<Loader, Key, Value>(string path) where Loader : ILoader<Key, Value>
        {
            TextAsset textAsset = Resources.Load<TextAsset>($"Data/{path}");
            return JsonUtility.FromJson<Loader>(textAsset.text);
        }


    }
}