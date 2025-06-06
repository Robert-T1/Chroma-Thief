using UnityEngine;

public class Door : MonoBehaviour, IInteraction
{
    [SerializeField] private Scenes goToLevel;
    public string GetInteractionName()
    {
        return "Open Door " + goToLevel;
    }

    public void Interact()
    {
        // play door sound
        LevelTransitionManager.Instance.GoToLevel(goToLevel);
    }
}
