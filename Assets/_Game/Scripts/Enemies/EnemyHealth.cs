using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace TowerDefense
{
    public class EnemyHealth : MonoBehaviour
    {
        [SerializeField] Slider healthSlider;
        [SerializeField] Enemy enemy;

        private void Start()
        {
            enemy.HealthChanged += UpdateHealth;
        }
        private void UpdateHealth(int health, int maxHealth)
        {

            healthSlider.value = (float)health / (float)maxHealth;


        }
    }
}
