using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TowerDefense.Data;
using TowerDefense.Utils;
using TowerDefense.UI;

namespace TowerDefense
{
    public class Managers : MonoBehaviour
    {
        static Managers s_instance;
        public static Managers Instance { get { Init(); return s_instance; } }

        #region core
        DataManager _data = new DataManager();
        SceneManagerEx _scene = new SceneManagerEx();
        ResourceManager _resource = new ResourceManager();
        PoolManager _pool = new PoolManager();
        public static DataManager Data { get { return Instance._data; } }
        public static ResourceManager Resource { get { return Instance._resource; } }

        public static SceneManagerEx Scene { get { return Instance._scene; } }
        public static PoolManager Pool { get { return Instance._pool; } }

        #endregion


        public static float GameTime { get; set; } = 0;

        void Awake()
        {

            Init();
        }

        private void Start()
        {
            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = 60;
        }

        private void Update()
        {
            GameTime += Time.deltaTime;
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
                s_instance._pool.Init();
                s_instance._data.Init();
            }
        }


    }
}