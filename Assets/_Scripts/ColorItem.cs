using UnityEngine;

public class ColorItem : MonoBehaviour, IInteraction
{
    [SerializeField] private ColorType type;
    [SerializeField] private ChaseSystem chaseSystem;

    public string GetInteractionName()
    {
        return "Destroy machine";
    }

    public void Interact()
    {
        LevelManager.Instance.ColorCollected();
        ColorManager.Instance.ToggleColor(type, 0);
        chaseSystem.StartChase();
        Destroy(gameObject);
    }
}

public enum ColorType
{
    Red,
    Green,
    Blue,
} 
