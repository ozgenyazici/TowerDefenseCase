using UnityEngine;
using TowerDefense.Utils;
using System;

namespace TowerDefense
{
    public class Enemy : BaseEnemy, IDamageable, IMoveable
    {
        private bool _isLive = true;

        public int wayPointIndex { get; set; }
        public Transform target { get; set; }


        public event Action<int, int> HealthChanged;

        protected override void Init()
        {
            _rigid = GetComponent<Rigidbody>();
            _stat = GetComponent<EnemyStat>();

            target = Waypoints.points[0];

        }
        public void Init(Data.Enemy enemyStat)
        {
            _stat.MaxHP = enemyStat.maxHp;
            _stat.HP = enemyStat.maxHp;
            _stat.MoveSpeed = enemyStat.moveSpeed;

        }
        private void OnTriggerEnter(Collider col)
        {
            if (col.gameObject.CompareTag(Define.GameplayTags.MainBase.ToString()))
            {

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

            Movement();
        }


        public override void TakeDamage(int damage)
        {
            _stat.HP -= damage;
            HealthChanged?.Invoke(_stat.HP, _stat.MaxHP);
            Dead();
        }

        public override void Dead()
        {
            if (_stat.HP <= 0)
            {
                _isLive = false;
                Destroy(this.gameObject);

            }
        }

        private void Movement()
        {
            Vector3 dir = target.position - transform.position;
            transform.Translate(dir.normalized * Time.deltaTime * _stat.MoveSpeed, Space.World);

            if (Vector3.Distance(transform.position, target.position) <= 0.4f)
            {
                GetNextWaypoint();
            }

            _stat.MoveSpeed = _stat.MoveSpeed;
        }

        void GetNextWaypoint()
        {
            if (wayPointIndex >= Waypoints.points.Length - 1)
            {
                return;
            }

            wayPointIndex++;
            target = Waypoints.points[wayPointIndex];
        }
    }
}