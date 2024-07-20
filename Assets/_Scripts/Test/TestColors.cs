using System.Collections;
using UnityEngine;

namespace TestCode
{
    public class TestColors : MonoBehaviour
    {
        public Material Red, Green, Blue;
        public bool red, green, blue;
        public float fadeTime = 1f;

        public void ToggleColor(int id)
        {
            switch (id)
            {
                case 0:
                    if (red)
                    {
                        StartCoroutine(ToggleColorLerpOff(Red));
                    }
                    else
                    {
                        StartCoroutine(ToggleColorLerpOn(Red));
                    }
                    red = !red;
                    break;
                case 1:
                    if (green)
                    {
                        StartCoroutine(ToggleColorLerpOff(Green));
                    }
                    else
                    {
                        StartCoroutine(ToggleColorLerpOn(Green));
                    }
                    green = !green;
                    break;
                case 2:
                    if (blue)
                    {
                        StartCoroutine(ToggleColorLerpOff(Blue));
                    }
                    else
                    {
                        StartCoroutine(ToggleColorLerpOn(Blue));
                    }
                    blue = !blue;
                    break;
            }
        }

        private IEnumerator ToggleColorLerpOn(Material mat)
        {
            Debug.Log("Here On");
            float count = 1f;
            while (count <= 100)
            {
                yield return new WaitForSeconds(fadeTime);
                mat.SetFloat("_EffectAmount", Mathf.Clamp01(count / 100));
                count++;
            }
        }

        private IEnumerator ToggleColorLerpOff(Material mat)
        {
            float count = 100f;
            while (count > 0)
            {
                yield return new WaitForSeconds(fadeTime);
                mat.SetFloat("_EffectAmount", Mathf.Clamp01(count / 100));

                count--;
            }
        }
    }
}
