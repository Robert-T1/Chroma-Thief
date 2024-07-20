using UnityEngine;
namespace TestCode
{
    public class DamageCollider : MonoBehaviour
    {
        [SerializeField] private int damageAmount = 50;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                collision.gameObject.GetComponent<Player>().TakeDamage(damageAmount);
            }
        }
    }
}
