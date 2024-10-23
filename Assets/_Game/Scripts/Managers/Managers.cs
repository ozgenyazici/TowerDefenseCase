using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TowerDefense.Data;
namespace TowerDefense
{
    public class Managers : MonoBehaviour
    {
        static Managers s_instance;

        #region Core
        DataManager _data = new DataManager();
        #endregion
        public static Managers Instance { get { Init(); return s_instance; } }
        public static DataManager Data { get { return Instance._data; } }

        void Awake()
        {
        }
        static void Init()
        {
            if (s_instance == null)
            {
                GameObject go = GameObject.Find("@Managers");
                if (go == null)
                {
                    go = new GameObject { name = "@Managers" };
                    go.AddComponent<Managers>();
                }
                DontDestroyOnLoad(go);
                s_instance = go.GetComponent<Managers>();

            }
        }
    }
}