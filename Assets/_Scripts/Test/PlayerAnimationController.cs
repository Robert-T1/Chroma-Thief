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
    public void AttackState(bool state)
    {
        animator.SetBool("attacking", state);
    }
    public void FlipPlayerSprite(bool flip)
    {
        spriteRenderer.flipX = flip;
    }
    public bool GetPlayerSpriteFlipState()
    {
       return spriteRenderer.flipX;
    }

     void PlayRunEvent (string EventPath)
    {

        FMODUnity.RuntimeManager.PlayOneShot(EventPath);
        
    }


    public float GetAnimationClipLength(string clipName)
    {
        foreach (AnimationClip clip in animator.runtimeAnimatorController.animationClips)
        {
            if (clip.name == clipName)
            {
                return clip.length;
            }
        }
        return 0f;
    }
}
