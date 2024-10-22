using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TowerDefense.Utils;

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

        public void Dead()
        {

        }

        public void TakeDamage(int damage)
        {

        }



    }

}