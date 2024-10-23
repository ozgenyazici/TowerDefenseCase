using System;
namespace TowerDefense
{

    public interface IDamageable
    {
        public event Action<int, int> HealthChanged;

        void Dead();
    }
}