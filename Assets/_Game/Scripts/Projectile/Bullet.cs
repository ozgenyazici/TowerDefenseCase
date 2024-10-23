using UnityEngine;
using TowerDefense.Utils;
namespace TowerDefense
{
    public class Bullet : MonoBehaviour
    {
        public int damage;
        public float speed;

        private void OnTriggerEnter(Collider other)
        {
            GameObject go = other.gameObject;

            if (go.CompareTag(Define.GameplayTags.Enemy.ToString()))
            {
                go.GetComponent<BaseEnemy>().TakeDamage(damage);

                Destroy(this.gameObject);

            }
        }
    }

}
