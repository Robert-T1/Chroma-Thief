using UnityEngine;

public class ColorItem : MonoBehaviour, IInteraction
{
    [SerializeField] private ColorType type;
    [SerializeField] GameObject chaseSystemObject;
    private IChase chaseSystem;

    private void Start()
    {
        chaseSystem = chaseSystemObject.GetComponent<IChase>();
    }
    public string GetInteractionName()
    {
        return "Destroy machine";
    }

    public void Interact()
    {
        LevelManager.Instance.ColorCollected();
        ColorManager.Instance.ToggleColor(type, 1);
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
