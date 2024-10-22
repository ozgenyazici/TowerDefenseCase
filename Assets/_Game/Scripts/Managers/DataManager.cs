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
        public Dictionary<int, Data.Enemy> EnemyData { get; private set; } = new Dictionary<int, Data.Enemy>();
        public Dictionary<int, Data.Wave> WaveData { get; private set; } = new Dictionary<int, Data.Wave>();

        public void Init()
        {
            EnemyData = LoadJson<Data.EnemyData, int, Data.Enemy>("EnemyData").MakeDict();
            WaveData = LoadJson<Data.WaveData, int, Data.Wave>("WaveData").MakeDict();

            Debug.Log($"Init");
        }

        Loader LoadJson<Loader, Key, Value>(string path) where Loader : ILoader<Key, Value>
        {
            TextAsset textAsset = Resources.Load<TextAsset>($"Data/{path}");
            return JsonUtility.FromJson<Loader>(textAsset.text);
        }


    }
}