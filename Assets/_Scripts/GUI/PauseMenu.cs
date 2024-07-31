using System;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;
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

    [SerializeField]
    private Slider volumeSlider;

    [SerializeField]
    private Toggle enableShadowsToggle;

    public StudioGlobalParameterTrigger trigger;

    Bus audioBus;

    void Awake()
    {
        enableShadowsToggle.isOn = PlayerPrefs.GetInt("settings.graphics.shadows", 1) == 1;
        audioBus = RuntimeManager.GetBus($"bus:/");
        volumeSlider.value = PlayerPrefs.GetFloat("settings.audio.master.volume", 100.0f);
    }

    void Start()
    {
        resumeButton.onClick.AddListener(() => gui.TogglePauseMenu());
        settingsButton.onClick.AddListener(() => OpenSettings());
        mainMenuButton.onClick.AddListener(() => SceneManager.LoadScene("MainMenu"));
        backButton.onClick.AddListener(() => CloseSettings());
        volumeSlider.onValueChanged.AddListener((value) => ChangeVolume(value));
        enableShadowsToggle.onValueChanged.AddListener((value) => ToggleShadows(value));
    }

    void ChangeVolume(float value)
    {
        audioBus.setVolume(value * 0.6f);
        // Support for audio buses
        PlayerPrefs.SetFloat("settings.audio.master.volume", value);
        PlayerPrefs.Save();
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

    public void ToggleShadows(bool value)
    {
        var lights = FindObjectsByType<Light2D>(FindObjectsSortMode.None);
        foreach(var light in lights)
        {
            light.shadowsEnabled = value;
            PlayerPrefs.SetInt("settings.graphics.shadows", value? 1 : 0);
            PlayerPrefs.Save();
        }
    }
}
