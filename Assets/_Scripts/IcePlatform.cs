using System.Collections;
using UnityEngine;

public class IcePlatform : MonoBehaviour
{
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Animator animator;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Entity>(out Entity entity))
        {
            StartCoroutine(Crack());
        }
    }
    private IEnumerator Crack()
    {
        float breakLength = GetClipLength("Break");
        animator.SetBool("break", true);

        yield return new WaitForSeconds(breakLength);

        animator.SetBool("break", false);
        spriteRenderer.enabled = false;
        boxCollider.enabled = false;

        yield return new WaitForSeconds(3);
        StartCoroutine(Respawn());
    }

    private IEnumerator Respawn()
    {
        spriteRenderer.enabled = true;
        animator.SetBool("respawn", true);

        float clipLength = GetClipLength("Respawn");

        yield return new WaitForSeconds(clipLength);
           
        boxCollider.enabled = true;
        animator.SetBool("respawn", false);
    }
    private float GetClipLength(string clipName)
    {
        float clipLength = 0;
        if (animator != null)
        {
            RuntimeAnimatorController runtimeAnimatorController = animator.runtimeAnimatorController;

            foreach (AnimationClip clip in runtimeAnimatorController.animationClips)
            {
                if (clip.name == clipName)
                {
                    clipLength = clip.length;
                    break;
                }
            }
        }
        else
        {
            Debug.LogError("Animator component not found!");
        }

        return clipLength;
    }
}
