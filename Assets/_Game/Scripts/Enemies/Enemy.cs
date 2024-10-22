using UnityEngine;
namespace TowerDefense
{
    public class Enemy : BaseEnemy, IDamageable
    {
        public float health { get; set; }

        private bool _isLive = true;
        protected override void Init()
        {
            _rigid = GetComponent<Rigidbody>();
            _stat = GetComponent<EnemyStat>();


        }
        private void OnEnable()
        {
            _isLive = true;
        }
        private void FixedUpdate()
        {
            if (!_isLive)
                return;
        }
    }
}