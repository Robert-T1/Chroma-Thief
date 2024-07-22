using System.Collections;
using TestCode;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private int maxHealth = 50;
    [SerializeField] private float speed;
    [SerializeField] private float chaseSpeed;
    [SerializeField] private float attackDistance;
    [SerializeField] private Transform[] basePath;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Rigidbody2D rigidbody2d;
    [SerializeField] private Animator animator;
    [SerializeField] private string attackAnimationClipName = "SpiderAttack";
    [SerializeField] private float attackDuration = 0.5f;
    [SerializeField] private GameObject attackBox;
    [SerializeField] private Vector2 attackBoxLeft, attackBoxRight;

    private float defaultSpeed;
    private int health;
    private bool isFollowingPath = true;
    private bool isBacktracking = false;
    private bool isAttacking = false;
    private int currentTrackIndex = 0;
    private Transform nextPoint;
    private Vector2 lastPos;
    private Player player;

    private void Start()
    {
        defaultSpeed = speed;
        transform.position = basePath[currentTrackIndex].position;
        health = maxHealth;
        nextPoint = GetNextPathPoint();
    }

    private void Update()
    {
        if(isFollowingPath)
        {
            speed = defaultSpeed;
            transform.position = Vector2.MoveTowards(transform.position, nextPoint.position, speed * Time.deltaTime);

            if (Vector2.Distance(transform.position, nextPoint.position) <= 0.1f)
            {
                nextPoint = GetNextPathPoint();
            }
        }
        else
        {
            speed = chaseSpeed;
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            if(Vector2.Distance(transform.position, player.transform.position) < 1 && !isAttacking)
            {
                StartCoroutine(Attack());
            }
        }

        CalculateSpriteFlip();
    }

    private void FixedUpdate()
    {
        CheckForPlayer();
    }

    public void DamageEnemy(int damage)
    {

    }

    private IEnumerator Attack()
    {
        isAttacking = true;
        animator.SetBool("attacking", true);
        attackBox.SetActive(true);

        yield return new WaitForSeconds(attackDuration);

        isAttacking = false;
        animator.SetBool("attacking", false);
        attackBox.SetActive(false);
    }

    private Transform GetNextPathPoint()
    {
        int next = currentTrackIndex;

        if (currentTrackIndex == 0 && isBacktracking)
        {
            isBacktracking = false;
        }

        if (isBacktracking)
        {
            next = currentTrackIndex - 1;
        }
        else
        {
            next = currentTrackIndex + 1;
        }

        if (next >= basePath.Length)
        {
            isBacktracking = !isBacktracking;

            if (isBacktracking)
            {
                currentTrackIndex = currentTrackIndex - 1;
                return basePath[currentTrackIndex];
            }
            else
            {
                currentTrackIndex = currentTrackIndex + 1;
                return basePath[currentTrackIndex];
            }
          
        }
        else
        {
            currentTrackIndex = next;
            return basePath[next];
        }
    }

    private void CalculateSpriteFlip()
    {
        if ((transform.position.x - lastPos.x) < 0)
        {
            spriteRenderer.flipX = true;
            attackBox.transform.localPosition = attackBoxLeft;
        }
        else
        {
            spriteRenderer.flipX = false;
            attackBox.transform.localPosition = attackBoxRight;
        }
        lastPos = transform.position;
    }

    private void CheckForPlayer()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, attackDistance);
        bool playerNear = false;

        foreach (Collider2D collider in colliders)
        {
            if(collider.gameObject.CompareTag("Player"))
            {
                playerNear = true;
                if (player == null) { player = collider.gameObject.GetComponent<Player>();  }
                break;
            }
        }

        isFollowingPath = !playerNear;
    }

}
