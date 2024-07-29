using UnityEngine;


public class Player : MonoBehaviour
{
    [SerializeField] private Transform respawnPoint;

    public Health health;
    private PlayerController controller;
    private Rigidbody2D rigidbody2d;

    private void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        controller = GetComponent<PlayerController>();
        health.onDeath += Death;

        ResetCharacter();
    }

    public void EnablePlayerController(bool state)
    {
        controller.enabled = state;
        rigidbody2d.isKinematic = !state;
        rigidbody2d.velocity = Vector2.zero; 
        controller.ResetVelocity();
    }

    public void ResetCharacter()
    {
        health.ResetHealth();
    }

    private void Death()
    {
        StartCoroutine(LevelManager.Instance.camController.FadeCamera(false, 0.5f));

        if(LevelManager.Instance.IsColorCollected())
        {
            LevelManager.Instance.chaseSystem.ResetChase();
            ResetCharacter();
        }
        else
        {
            LevelTransitionManager.Instance.ReloadLevel();
        }
    }

    private void OnDestroy()
    {
        health.onDeath -= Death;
    }
}
