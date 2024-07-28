using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }
    public Player player;
    public CameraController camController;
    public ChaseSystem chaseSystem;

    private bool colorCollected = false;

    private void Awake()
    {
        CreateSingleton();
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
    }

    public void ColorCollected()
    {
        colorCollected = true;
    }
    public bool IsColorCollected()
    {
        return colorCollected;
    }
}
