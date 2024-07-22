using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public string GameSceneName;

    public Button startButton;
    public Button settingsButton;
    public Button creditsButton;
    public Button exitButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (!string.IsNullOrEmpty(GameSceneName))
        {
            startButton.onClick.AddListener(LaunchGame);
        }
        exitButton.onClick.AddListener(Exit);
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
