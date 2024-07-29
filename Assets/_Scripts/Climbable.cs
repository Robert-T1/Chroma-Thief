using UnityEngine;

public class Climbable : MonoBehaviour, IInteraction
{
    [SerializeField] private Transform upLimit, downLimit;
    [SerializeField] private float climbSpeed;
    [SerializeField] private string interactionName;

    private bool isClimbing = false;
    private Player player;

    public void Interact()
    {
        isClimbing = !isClimbing;

        player = LevelManager.Instance.player;
        player.EnablePlayerController(!isClimbing);

        Vector2 newPos = new Vector2(transform.position.x, player.transform.position.y);
        player.transform.position = newPos;
    }
    public string GetInteractionName()
    {
        return interactionName;
    }

    private void Update()
    {
        if (!isClimbing)
        {
            return;
        }

        if (Input.GetKey(KeyCode.W) && Vector2.Distance(upLimit.position, player.transform.position) > 0.1f)
        {
            player.transform.position = new Vector2(player.transform.position.x, player.transform.position.y + climbSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S) && Vector2.Distance(downLimit.position, player.transform.position) > 0.1f)
        {
            player.transform.position = new Vector2(player.transform.position.x, player.transform.position.y - climbSpeed * Time.deltaTime);
        }

    }
}
