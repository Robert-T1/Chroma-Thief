using System.Collections;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    [SerializeField] private float fallSpeed = 0.1f;
    [SerializeField] private float stabilty = 100f;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private SpriteRenderer[] spriteRenderer;
    private float maxStablity;
    private bool isFalling = false;
    private Vector2 originalPos;

    private void Start()
    {
        maxStablity = stabilty;
        originalPos = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Entity>(out Entity entity))
        {
            entity.transform.SetParent(transform);
            isFalling = true;
            StartCoroutine(Fall());
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Entity>(out Entity entity))
        {
            entity.transform.SetParent(null);
            isFalling = false;
        }
    }

    private IEnumerator Fall()
    {
        while (isFalling)
        {
            Vector2 fallPos = new Vector2(transform.position.x, transform.position.y - 5);
            transform.position = Vector2.MoveTowards(transform.position, fallPos, fallSpeed * Time.deltaTime);
            stabilty -= fallSpeed * Time.deltaTime;

            if(stabilty <= 0)
            {
                boxCollider.enabled = false;   
            }

            UpdateSprite();
            yield return null;
        }

      

        StartCoroutine(Recover());
    }

    private IEnumerator Recover()
    {
        boxCollider.enabled = true;

        while (!isFalling || (Vector2)transform.position == originalPos)
        {
            transform.position = Vector2.MoveTowards(transform.position, originalPos, (fallSpeed / 2) * Time.deltaTime);
            stabilty += (fallSpeed / 2) * Time.deltaTime;

            if (Vector2.Distance(transform.position, originalPos) < 0.01f)
            {
                transform.position = originalPos;  
                stabilty = maxStablity;
            }
             
            UpdateSprite();
            yield return null;
        }
    }

    private void UpdateSprite()
    {
        for (int i = 0; i < spriteRenderer.Length; i++)
        {
            spriteRenderer[i].color = new Color(spriteRenderer[i].color.r, spriteRenderer[i].color.g, spriteRenderer[i].color.b, Mathf.Clamp01((stabilty / maxStablity)));
        }
    }
}
