using UnityEngine;
using UnityEngine.UI;

namespace TestCode
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private Slider healthBar;
        [SerializeField] private Transform respawnPoint;
        [SerializeField] private int maxHealth = 100;
        private int health;

        private void Start()
        {
            health = maxHealth;
        }

        public void TakeDamage(int amount)
        {
            health -= amount;

            if (health <= 0)
            {
                // died
                transform.position = respawnPoint.position;
                health = maxHealth;
            }
            healthBar.value = health;
        }
    }
}
