using UnityEngine;
using UnityEngine.InputSystem;

public class GuiManager : MonoBehaviour
{
    [SerializeField]
    private PauseMenu pauseMenu;

    void Start()
    {
    }

    public void OnPause(InputAction.CallbackContext context)
    {
        TogglePauseMenu();
    }

    public void TogglePauseMenu()
    {
        var gameObject = pauseMenu.gameObject;
        if(gameObject.activeSelf)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }
}