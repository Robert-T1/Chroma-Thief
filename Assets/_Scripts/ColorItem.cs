using UnityEngine;

public class ColorItem : MonoBehaviour
{
    [SerializeField] private ColorType type;
    [SerializeField] private ChaseSystem chaseSystem;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ColorManager.Instance.ToggleColor(type, 0);
            chaseSystem.StartChase();
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
