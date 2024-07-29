
using UnityEngine;

public class ActiveOnColor : ColorSubscriber
{
    [SerializeField] private ColorType activeOnColorType;
    [SerializeField] private bool setActiveOnColor = true;
    [SerializeField] private GameObject gameObjectToSet;

    private void Start()
    {
        Debug.Log(gameObject.name);
        if(gameObjectToSet == null)
        {
            gameObjectToSet = this.gameObject;
        }

        if (ColorManager.Instance != null)
        {
            ColorManager.Instance.colorChange += OnColorChange;
        }

        gameObjectToSet.SetActive(!setActiveOnColor);

        if(ColorManager.Instance.IsColorRestored(activeOnColorType))
        {
            gameObjectToSet.SetActive(setActiveOnColor);
        }
    }

    protected override void OnColorChange(ColorType type)
    {
        if(type == activeOnColorType)
        {
            gameObjectToSet.SetActive(setActiveOnColor);
        }
    }

    private void OnDestroy()
    {
        ColorManager.Instance.colorChange -= OnColorChange;
    }
} 
