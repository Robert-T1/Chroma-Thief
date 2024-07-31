using UnityEngine;

public class DontDestroyMusic : MonoBehaviour
{
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}
