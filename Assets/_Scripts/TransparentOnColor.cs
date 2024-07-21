using System.Collections;
using UnityEngine;

public class TransparentOnColor : ColorSubscriber
{
    [SerializeField] private float toAlpha = 0f;
    [SerializeField] private ColorType onColorType;
    [SerializeField] private float fadeSpeed = 1.0f;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private void Start()
    {
        if (ColorManager.Instance != null)
        {
            ColorManager.Instance.colorChange += OnColorChange;
        }
    }

    protected override void OnColorChange(ColorType type)
    {
        if (type == onColorType)
        {
            StartCoroutine(FadeTransparent(toAlpha));
        }
    }

    private IEnumerator FadeTransparent(float fadeToo)
    {
        float value = spriteRenderer.color.a;
        while (fadeToo != value)
        {
            value = Mathf.Lerp(value, fadeToo, fadeSpeed * Time.deltaTime);
            if (Mathf.Abs(value - fadeToo) <= 0.05f)
            {
                value = fadeToo;
            }

            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, value);

            yield return null;
        }
    }
}
