using UnityEngine;

public class ColorItem : MonoBehaviour
{
    [SerializeField] private ColorType type;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ColorManager.Instance.ToggleColor(type, 0);
            Destroy(gameObject);
        }
    }
}

public enum ColorType
{
    Red,
    Green,
    Blue,
} 
