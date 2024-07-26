using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GuiManager gui;

    [SerializeField]
    private Button resumeButton;

    [SerializeField]
    private Button mainMenuButton;

    void Start()
    {
        resumeButton.onClick.AddListener(() => gui.TogglePauseMenu());
    }
}
