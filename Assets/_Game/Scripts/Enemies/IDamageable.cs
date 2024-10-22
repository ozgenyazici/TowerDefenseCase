
namespace TowerDefense
{

    public interface IDamageable
    {
        float health { get; set; }

        void Dead();
        void TakeDamage(int damage);
    }

}