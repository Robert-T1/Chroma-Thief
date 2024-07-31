using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransitionManager : MonoBehaviour
{
    public static LevelTransitionManager Instance { get; private set; }
    [SerializeField] private Scenes loadedScene;

    private Dictionary<Scenes, bool> lockedScenes = new Dictionary<Scenes, bool> {
        { Scenes.Forest, false },
        { Scenes.Cave, false },
        { Scenes.Volcano, false },
         { Scenes.Boss, true },
    };

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
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void GoToLevel(Scenes scene)
    {
        // call camera fade then change level 

        if(lockedScenes.ContainsKey(scene))
        {
            if (lockedScenes[scene])
            {
                return;
            }
        }
        loadedScene = scene;
        SceneManager.LoadScene((int)scene);
    }

    public void ReloadLevel()
    {
        GoToLevel(loadedScene);
    }

    public void LockStateLevel(Scenes scene, bool state)
    {
        if(!lockedScenes.ContainsKey(scene))
        {
            return;
        }
        lockedScenes[scene] = state;
    }
    
}

public enum Scenes
{
    Start,
    Hub,
    Forest,
    Cave,
    Volcano,
    Boss,
}
