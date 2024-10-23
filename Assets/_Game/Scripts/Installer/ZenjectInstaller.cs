using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using TowerDefense.Data;
using TowerDefense;
public class ZenjectInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        #region Managers
        Container.Bind<DataManager>().AsSingle().NonLazy();
        Container.Bind<ResourceManager>().AsSingle();
        Container.Bind<ReadWave>().AsSingle();

        #endregion
    }
}
