using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private int maxHealth = 50;
    [SerializeField] private int damage = 25;
    [SerializeField] private float speed;
    [SerializeField] private float attackDistance;
    [SerializeField] private Transform[] basePath;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Rigidbody2D rigidbody2d;

    private bool isFollowingPath = true;
    private int health;

    private void Start()
    {
        health = maxHealth;
    }

    private void Update()
    {
        
    }

    public void DamageEnemy(int damage)
    {

    }

}
