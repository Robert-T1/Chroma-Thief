using TestCode;
using UnityEngine;
using UnityEngine.UI;

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
    }

    public void EnablePlayerController(bool state)
    {
        controller.enabled = state;
        rigidbody2d.isKinematic = !state;
        rigidbody2d.velocity = Vector2.zero;
        controller.ResetVelocity();
    }
}
