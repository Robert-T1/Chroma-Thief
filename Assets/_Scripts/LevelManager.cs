using System;
using System.Threading;
using FMODUnity;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }
    public Player player;
    public CameraController camController;
    public GameObject chaseSystemObject;
    public StudioGlobalParameterTrigger trigger;
    public IChase chaseSystem;

    private bool colorCollected = false;

    private void Awake()
    {
        if (chaseSystemObject != null)
        {
            chaseSystem = chaseSystemObject.GetComponent<IChase>();
        }
        CreateSingleton();

        var bus = RuntimeManager.GetBus($"bus:/");
        bus.setVolume(PlayerPrefs.GetFloat("settings.audio.master.volume", 100.0f) * 0.6f);
        ToggleShadows(PlayerPrefs.GetInt("settings.graphics.shadows", 1) == 1);
    }

    private void CreateSingleton()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ColorCollected()
    {
        colorCollected = true;
    }
    public bool IsColorCollected()
    {
        return colorCollected;
    }
    public void ToggleShadows(bool value)
    {
        var lights = FindObjectsByType<Light2D>(FindObjectsSortMode.None);
        foreach(var light in lights)
        {
            light.shadowsEnabled = value;
        }
    }
}
