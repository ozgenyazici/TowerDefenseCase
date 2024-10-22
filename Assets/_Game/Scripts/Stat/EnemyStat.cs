using UnityEngine;

namespace TowerDefense
{
    

    [RequireComponent(typeof(Enemy))]
    public class EnemyStat : Stat
    {

        private long _expPoint;
        public long ExpPoint
        {
            get { return _expPoint; }
            set { _expPoint = value; }
        }
        private void Start()
        {

        }

    }

}