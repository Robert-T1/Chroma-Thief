using FMODUnity;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private void Awake()
    {
        CreateSingleton();
        RuntimeManager.LoadBank("Master Bank", true);
        RuntimeManager.LoadBank("Master Bank.strings", true);

        RuntimeManager.WaitForAllSampleLoading();
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
}
