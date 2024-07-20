using UnityEngine;

namespace TestCode
{

    [RequireComponent(typeof(SpriteRenderer))]
    public class ObjectColor : MonoBehaviour
    {
        [SerializeField] private GemColors colorType;
        [SerializeField] private Color Oncolor;
        [SerializeField] private Color Offcolor;
        private SpriteRenderer spriteRenderer;
        protected BoxCollider2D boxCollider;

        private void Start()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            boxCollider = GetComponent<BoxCollider2D>();
            ColorManager.Instance.onColorChange += OnColorChange;
        }

        private void OnDestroy()
        {
            ColorManager.Instance.onColorChange -= OnColorChange;
        }

        private void OnColorChange(GemColors newColor)
        {
            if (newColor == colorType)
            {
                boxCollider.enabled = true;
                spriteRenderer.color = Oncolor;
            }
            else
            {
                boxCollider.enabled = false;
                spriteRenderer.color = Offcolor;
            }
            OtherChanges(newColor);
        }

        protected virtual void OtherChanges(GemColors color)
        {

        }
    }
}
