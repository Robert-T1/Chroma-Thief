using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public string GameSceneName;

    public Button startButton;
    public Button settingsButton;
    public Button creditsButton;
    public Button creditsCloseButton;
    public Button exitButton;

    public GameObject creditsPanel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (!string.IsNullOrEmpty(GameSceneName))
        {
            startButton.onClick.AddListener(LaunchGame);
        }
        exitButton.onClick.AddListener(Exit);
        creditsButton.onClick.AddListener(() =>
        {
            creditsPanel.SetActive(true);
        });
        creditsCloseButton.onClick.AddListener(() =>
        {
            creditsPanel.SetActive(false);
        });
    }

    void LaunchGame()
    {
        SceneManager.LoadScene(GameSceneName);
    }

    void Exit()
    {
        Application.Quit();
    }
}
