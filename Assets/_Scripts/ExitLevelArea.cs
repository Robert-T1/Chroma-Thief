using UnityEngine;

public class ExitLevelArea : MonoBehaviour
{
    [SerializeField] private Scenes goToLevel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            LevelTransitionManager.Instance.GoToLevel(goToLevel);
        }
    }
}
