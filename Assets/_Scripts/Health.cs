using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private bool canRegenerateHealth;
    [SerializeField] private bool canRespawn;
    [SerializeField] private int maxHealth;
    [SerializeField] private int health;

    [SerializeField] private Slider healthBar;
    [SerializeField] private Image fill, backgroundFill;

    private Coroutine healthBarFade;
     private float healthBarWaitBeforeFade;
     private bool fading = false;

    public delegate void OnDeath();
    public OnDeath onDeath;

    [ContextMenu("Test")]
    private void DamageTest()
    {
        Damage(5);
    }

    private void Start()
    {
        fill.color = new Color(fill.color.r, fill.color.g, fill.color.b, 0);
        backgroundFill.color = new Color(backgroundFill.color.r, backgroundFill.color.g, backgroundFill.color.b, 0);
    }

    private void Update()
    {
        if (canRegenerateHealth && health < maxHealth)
        {

        }

        if(healthBarWaitBeforeFade > 0)
        {
            healthBarWaitBeforeFade -= 1f * Time.deltaTime;
        }
        else if(fading)
        {
            HealthBarState(false);
        }
        
    }
    public void ResetHealth()
    {
        this.health = maxHealth;
        healthBar.value = Mathf.Clamp01((float)health / (float)maxHealth);
        HealthBarState(true);
    }
    public void SetHealth(int health)
    {
        this.health = health;
        healthBar.value = Mathf.Clamp01((float)health / (float)maxHealth);

        if (health <= 0)
        {
            onDeath?.Invoke();
        }

        HealthBarState(true);
    }
    public void Damage(int damage)
    {
        health -= damage;
        healthBar.value = Mathf.Clamp01((float)health / (float)maxHealth);

        if(health <= 0)
        {
            onDeath?.Invoke();
        }

        HealthBarState(true);
    }

    private void HealthBarState(bool state)
    {
        if(healthBarFade == null && !state)
        {
           healthBarFade = StartCoroutine(FadeHealthBar());
        }
        else if (state)
        {
            if(healthBarFade != null)
            {
                StopCoroutine(healthBarFade);
                healthBarFade = null;
            }
            ActivateHealthBar();
        }
    }

    private IEnumerator FadeHealthBar()
    {
        float elapsedTime = 0f;
        float fadeSpeed = 0.5f;
        fading = false;
        while(true)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(1, 0, elapsedTime * fadeSpeed);

            Color newColorFill = new Color(fill.color.r, fill.color.g, fill.color.b, alpha);
            Color newColorBgFill = new Color(backgroundFill.color.r, backgroundFill.color.g, backgroundFill.color.b, alpha);

            fill.color = newColorFill;
            backgroundFill.color = newColorBgFill;

            if (alpha < 0.05)
            {
                fill.color = new Color(fill.color.r, fill.color.g, fill.color.b, 0);
                backgroundFill.color = new Color(backgroundFill.color.r, backgroundFill.color.g, backgroundFill.color.b, 0);
                break;
            }

            yield return null;
        }

        healthBarFade = null;
    }

    private void ActivateHealthBar()
    {
        fill.color = new Color(fill.color.r, fill.color.g, fill.color.b, 1);
        backgroundFill.color = new Color(backgroundFill.color.r, backgroundFill.color.g, backgroundFill.color.b, 1);
        
        fading = true;
        healthBarWaitBeforeFade = 5;
    }
}
