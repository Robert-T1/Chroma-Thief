using UnityEngine;

public class DamageCollider : MonoBehaviour
{
    [SerializeField] private int damageAmount = 50;
    [SerializeField] private bool hasknockBack = true;
    [SerializeField] private float knockBack = 2.0f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Health>(out Health health))
        {
            health.Damage(damageAmount);
            if(hasknockBack)
            {
                if(collision.gameObject.CompareTag("Player"))
                {
                    PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
                    Vector2 direction = (transform.position - collision.transform.position).normalized;
                    Vector2 knockback = direction.normalized * knockBack;

                    playerController.SetVelocity(-knockback);
                }
            }
        }
    }
}
