using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour
{
    public static ColorManager Instance { get; private set; }

    [SerializeField] private float fadeSpeed = 0.5f;
    [SerializeField] private Material red_Mat, green_Mat, blue_Mat;

    private List<ColorType> restoreColors = new List<ColorType>();

    public delegate void OnColorChange(ColorType type);
    public OnColorChange colorChange;

    private void Awake()
    {
        CreateSingleton();
    }

    private void CreateSingleton()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public bool IsColorRestored(ColorType color)
    {
        return restoreColors.Contains(color);
    }

    public void ToggleColor(ColorType type, float fadeToo)
    {
        switch(type)
        {
            case ColorType.Red:
                StartCoroutine(FadeColor(fadeToo, red_Mat));
                break;
            case ColorType.Green:
                StartCoroutine(FadeColor(fadeToo, green_Mat));
                break;
            case ColorType.Blue:
                StartCoroutine(FadeColor(fadeToo, blue_Mat));
                break;
        }

        if(fadeToo == 1) {
            restoreColors.Add(type);
        } else
        {
            restoreColors.Remove(type);
        }
        colorChange?.Invoke(type);
    }

    private IEnumerator FadeColor(float fadeToo, Material mat)
    {
        float value = mat.GetFloat("_EffectAmount");
        while (fadeToo != value)
        {
            value = Mathf.Lerp(value, fadeToo, fadeSpeed * Time.deltaTime);
            if(Mathf.Abs(value - fadeToo) <= 0.05f)
            {
                value = fadeToo;
            }
           
            mat.SetFloat("_EffectAmount", value);

            yield return null;
        }
    }

    private void OnApplicationQuit()
    {
        red_Mat.SetFloat("_EffectAmount", 0);
        green_Mat.SetFloat("_EffectAmount", 0);
        blue_Mat.SetFloat("_EffectAmount", 0);
    }

    public void ResetColorManager()
    {
        red_Mat.SetFloat("_EffectAmount", 0);
        green_Mat.SetFloat("_EffectAmount", 0);
        blue_Mat.SetFloat("_EffectAmount", 0);

        Destroy(gameObject);
    }
}

