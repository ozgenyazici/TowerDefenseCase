using UnityEngine.UI;
namespace TowerDefense
{

    public interface IDamageable
    {
        float health { get; set; }
        void Dead();
    }

}