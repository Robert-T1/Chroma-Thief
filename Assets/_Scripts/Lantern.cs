using UnityEngine;

public class Lantern : MonoBehaviour
{
    [SerializeField] private GameObject lantern;
    [SerializeField] private Sprite onSprite;
    [SerializeField] private SpriteRenderer spriteRenderer;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            TurnOnLanturn();
        }
    }

    private void TurnOnLanturn()
    {
        lantern.SetActive(true);
        spriteRenderer.sprite = onSprite;
    }
}
