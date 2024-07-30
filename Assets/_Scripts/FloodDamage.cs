using System.Collections;
using UnityEngine;

public class FloodDamage : MonoBehaviour
{
    [SerializeField] private int damageRate = 10;
    private bool isDamaging;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isDamaging = true;
            StartCoroutine(DamagePlayerLoop());
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isDamaging = false;
        }
    }

    private IEnumerator DamagePlayerLoop()
    {
        while(isDamaging)
        {
            LevelManager.Instance.player.health.Damage(damageRate);
            yield return new WaitForSeconds(1);
        }
    }
}
