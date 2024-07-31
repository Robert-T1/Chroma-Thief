using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class GuiManager : MonoBehaviour
{
    [SerializeField]
    private PauseMenu pauseMenu;

    public PlayerController player;

    public void Pause(InputAction.CallbackContext context)
    {
        TogglePauseMenu();
    }

    public void TogglePauseMenu()
    {
        var gameObject = pauseMenu.gameObject;
        if(gameObject.activeSelf)
        {
            pauseMenu.CloseSettings();
            gameObject.SetActive(false);
            player.isPaused = false;   
        }
        else
        {
            gameObject.SetActive(true);
            player.isPaused = true;
        }
    }
}