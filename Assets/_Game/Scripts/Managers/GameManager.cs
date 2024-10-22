using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using TowerDefense.Data;
using TowerDefense.Utils;
namespace TowerDefense
{
    public class GameManager : MonoBehaviour
    {
        //Data
        [Inject] DataManager _dataManager;

        void Awake()
        {

            Init();
        }

        private void Start()
        {
            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = 60;
        }

        private void Init()
        {
            DontDestroyOnLoad(this.gameObject);


            //Init Managers
            _dataManager.Init();
        }


    }
}