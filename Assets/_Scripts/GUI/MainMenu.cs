using System;
using FMOD.Studio;
using FMODUnity;
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
    public Button settingsBackButton;
    public Slider volumeSlider;
    public Toggle shadowsToggle;

    public GameObject mainPanel;
    public GameObject creditsPanel;
    public GameObject settingsPanel;

    private Bus audioBus;

    void onAwake()
    {
        audioBus = RuntimeManager.GetBus("bus:/");
        var volume = PlayerPrefs.GetFloat("settings.audio.master.volume", 100.0f);
        audioBus.setVolume(volume * 0.6f);
        volumeSlider.value = volume;
    }

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
            mainPanel.SetActive(false);
            creditsPanel.SetActive(true);
        });
        creditsCloseButton.onClick.AddListener(() =>
        {
            mainPanel.SetActive(true);
            creditsPanel.SetActive(false);
        });
        settingsButton.onClick.AddListener(() => {
            mainPanel.SetActive(false);
            settingsPanel.SetActive(true);
        });
        settingsBackButton.onClick.AddListener(() => {
            mainPanel.SetActive(true);
            settingsPanel.SetActive(false);
        });
        volumeSlider.onValueChanged.AddListener((value) => ChangeVolume(value));
        shadowsToggle.onValueChanged.AddListener((value) => PlayerPrefs.SetInt("settings.graphics.shadows", value? 1 : 0));
    }

    void LaunchGame()
    {
        SceneManager.LoadScene(GameSceneName);
    }

    void Exit()
    {
        Application.Quit();
    }

    void ChangeVolume(float value)
    {
        RuntimeManager.GetBus("bus:/");

        audioBus.setVolume(value * 0.6f);
        // Support for audio buses
        PlayerPrefs.SetFloat("settings.audio.master.volume", value);
        PlayerPrefs.Save();
    }
}
