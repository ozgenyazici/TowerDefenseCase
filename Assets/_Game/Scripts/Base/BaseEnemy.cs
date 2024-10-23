using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TowerDefense.Utils;
using UnityEngine.UI;

namespace TowerDefense
{
    public abstract class BaseEnemy : MonoBehaviour
    {

        public Rigidbody _rigid;

        public Define.EnemyStyle _type = Define.EnemyStyle.Unknown;

        protected EnemyStat _stat;


        private void Awake()
        {
            Init();
        }

        protected abstract void Init();

        public abstract void TakeDamage(int damage);
        public abstract void Dead();


    }

}