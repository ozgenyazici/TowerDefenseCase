using UnityEngine;
namespace TowerDefense
{
    public class Stat : MonoBehaviour
    {

        [SerializeField] protected int _hp;
        [SerializeField] protected int _maxHp;
        [SerializeField] protected float _movespeed;
        [SerializeField] protected int _damage;

        public virtual int HP { get { return _hp; } set { _hp = value; if (_hp > _maxHp) _hp = _maxHp; } }
        public virtual int MaxHP { get { return _maxHp; } set { _maxHp = value; } }
        public virtual float MoveSpeed { get { return _movespeed; } set { _movespeed = value; } }
        public virtual int Damage { get { return _damage; } set { _damage = value; } }
    }

}