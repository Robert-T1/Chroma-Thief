using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Vector2 lastPos;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }
    
    public void AttackingState(bool state)
    {
        animator.SetBool("attacking", state);
    }
    public void MovingState(bool state)
    {
        animator.SetBool("moving", state);
    }
    public void FlipPlayerSprite(bool flip)
    {
        spriteRenderer.flipX = flip;
    }
}
