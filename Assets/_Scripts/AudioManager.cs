using UnityEngine;
using FMODUnity;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }
    [SerializeField] private EventReference music;

    private void Awake()
    {
        CreateSingleton();
    }

    private void Start()
    {
        StartMusic(music);
    }

    private void CreateSingleton()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void StartMusic(EventReference sound)
    {
        RuntimeManager.PlayOneShot(sound);
    }
}
