using UnityEngine;
using UnityEngine.UI;

namespace TestCode
{
    public class ColorManager : MonoBehaviour
    {
        public static ColorManager Instance;

        [SerializeField] private GameObject Red_button, Blue_button, Yellow_button;
        [SerializeField] private Image selectedColorGUI;
        public GemColors SelectedColor;

        private bool redSelected = false;
        private bool blueSelected = false;
        private bool yellowSelected = false;

        public delegate void ColorChange(GemColors color);
        public ColorChange onColorChange;

        private void Awake()
        {
            Instance = this;
        }

        public void OnColorChange(GemColors newColor)
        {
            onColorChange?.Invoke(newColor);
        }

        public void ToggleColor(int id)
        {
            switch (id)
            {
                case 1:
                    redSelected = !redSelected;
                    break;
                case 2:
                    blueSelected = !blueSelected;
                    break;
                case 3:
                    yellowSelected = !yellowSelected;
                    break;
            }

            UpdateColor();
        }

        private void UpdateColor()
        {
            int selectedCount = 0;
            if (redSelected) selectedCount++;
            if (blueSelected) selectedCount++;
            if (yellowSelected) selectedCount++;

            Color selectedColor = Color.black;
            SelectedColor = GemColors.None;

            if (selectedCount > 2)
            {
                redSelected = false;
                blueSelected = false;
                yellowSelected = false;
            }
            else
            {
                if (redSelected && blueSelected)
                {
                    SelectedColor = GemColors.Purple;
                    selectedColor = Color.magenta;
                }
                else if (redSelected && yellowSelected)
                {
                    SelectedColor = GemColors.Orange;
                    selectedColor = new Color(1f, 0.5f, 0f);
                }
                else if (blueSelected && yellowSelected)
                {
                    SelectedColor = GemColors.Green;
                    selectedColor = Color.green;
                }
                else if (redSelected)
                {
                    SelectedColor = GemColors.Red;
                    selectedColor = Color.red;
                }
                else if (blueSelected)
                {
                    SelectedColor = GemColors.Blue;
                    selectedColor = Color.blue;
                }
                else if (yellowSelected)
                {
                    SelectedColor = GemColors.Yellow;
                    selectedColor = Color.yellow;
                }
            }

            selectedColorGUI.color = selectedColor;
            OnColorChange(SelectedColor);
        }

        public void AddColorGem(int id)
        {
            switch (id)
            {
                case 1:
                    Red_button.SetActive(true);
                    break;
                case 2:
                    Blue_button.SetActive(true);
                    break;
                case 3:
                    Yellow_button.SetActive(true);
                    break;
            }
        }
    }

    public enum GemColors
    {
        Red, Blue, Yellow, Green, Orange, Purple, None,
    }
}
