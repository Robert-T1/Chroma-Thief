using TestCode;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private Slider healthBar;
    [SerializeField] private Transform respawnPoint;
    [SerializeField] private int maxHealth = 100;

    private int health;
    private PlayerController controller;
    private Rigidbody2D rigidbody2d;

    private void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        controller = GetComponent<PlayerController>();
        health = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        health -= amount;

        if (health <= 0)
        {
            transform.position = respawnPoint.position;
            health = maxHealth;
        }
        healthBar.value = health;
    }

    public void EnablePlayerController(bool state)
    {
        controller.enabled = state;
        rigidbody2d.isKinematic = !state;
        rigidbody2d.velocity = Vector2.zero;
        controller.ResetVelocity();
    }
}
