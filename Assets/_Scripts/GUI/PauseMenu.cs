using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GuiManager gui;

    [SerializeField]
    private Button resumeButton;

    [SerializeField]
    private Button mainMenuButton;

    [SerializeField]
    private Button settingsButton;

    [SerializeField]
    private Button backButton;

    [SerializeField]
    private GameObject rootPanel;

    [SerializeField]
    private GameObject settingsPanel;

    void Start()
    {
        resumeButton.onClick.AddListener(() => gui.TogglePauseMenu());
        settingsButton.onClick.AddListener(() => OpenSettings());
        mainMenuButton.onClick.AddListener(() => SceneManager.LoadScene("MainMenu"));
        backButton.onClick.AddListener(() => CloseSettings());
        gameObject.SetActive(false);
    }

    public void OpenSettings()
    {
        settingsPanel.SetActive(true);
        rootPanel.SetActive(false);
    }

    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
        rootPanel.SetActive(true);
    }
}
