using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.SceneManagement
{
    public class Fader : MonoBehaviour
    {
        CanvasGroup canvasGroup;

        private void Start()
        {
            canvasGroup = GetComponent<CanvasGroup>();
        }

        public IEnumerator FadeOut(float totalDuration)
        {
            canvasGroup.alpha = 0f;
            while (canvasGroup.alpha < 1f)
            {
                canvasGroup.alpha = Mathf.Min(canvasGroup.alpha + Time.deltaTime / totalDuration, 1f);
                yield return null;
            }
        }

        public IEnumerator FadeIn(float totalDuration)
        {
            canvasGroup.alpha = 1f;
            while (canvasGroup.alpha > 0f)
            {
                canvasGroup.alpha = Mathf.Max(canvasGroup.alpha - Time.deltaTime / totalDuration, 0f);
                yield return null;
            }
        }
    }
}

