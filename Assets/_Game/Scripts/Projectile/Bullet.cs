using UnityEngine;
using TowerDefense.Utils;
namespace TowerDefense
{
    public class Bullet : MonoBehaviour
    {
        private Vector3 dir = new Vector3(1, 0, 0);

        public void SetBulletDir(Vector3 value) { dir = value; }
        public int _damage;
        public float _movSpeed;
        public int _penetrate;
        public float _force;
        private int piercing = 0;
        private float _lifeTime = 0.3f;
        private float _createTime = 0f;

        private Transform target;
        private void OnTriggerEnter(Collider other)
        {
            GameObject go = other.gameObject;

            if (go.CompareTag(Define.GameplayTags.Enemy.ToString()))
            {
                go.GetComponent<BaseEnemy>().TakeDamage(_damage);

                Destroy(this.gameObject);

            }
        }

       
        private void OnEnable()
        {
            _createTime = Managers.GameTime;
        }
        public void Seek(Transform _target)
        {
            target = _target;
        }
        void FixedUpdate()
        {
            if (target == null)
            {
                Destroy(gameObject);
                return;
            }

            Vector3 dir = target.position - transform.position;
            float distanceThisFrame = _movSpeed * Time.deltaTime;

            if (dir.magnitude <= distanceThisFrame)
            {
                return;
            }

            transform.Translate(dir.normalized * distanceThisFrame, Space.World);
            transform.LookAt(target);
            //OnMove();
        }
        void OnMove()
        {
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle - 90);
            transform.position += dir * (_movSpeed * Time.fixedDeltaTime);
        }
    }

}
