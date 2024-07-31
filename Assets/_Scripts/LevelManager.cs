using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }
    public Player player;
    public CameraController camController;
    public GameObject chaseSystemObject;
    public IChase chaseSystem;

    private bool colorCollected = false;

    private void Awake()
    {
        if(chaseSystemObject != null)
        {
            chaseSystem = chaseSystemObject.GetComponent<IChase>();
        }
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
}
