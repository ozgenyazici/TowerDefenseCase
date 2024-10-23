using UnityEngine;
using TowerDefense.Utils;
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
        private void OnCollisionEnter(Collision col)
        {
            if (col.gameObject.CompareTag(Define.GameplayTags.MainBase.ToString()))
            {
                Debug.Log("GameOver");
            }
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


        public override void TakeDamage(int damage)
        {
            _stat.HP -= damage;
        }

        public override void Dead()
        {
            Destroy(this.gameObject);
        }
    }
}