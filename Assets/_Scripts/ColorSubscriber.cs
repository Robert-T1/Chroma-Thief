using UnityEngine;

public abstract class ColorSubscriber : MonoBehaviour
{
    protected abstract void OnColorChange(ColorType type);
}
