using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.SceneManagement
{
    public class Fader : MonoBehaviour
    {
        CanvasGroup canvasGroup;

        private void Awake()
        {
            canvasGroup = GetComponent<CanvasGroup>();
        }

        public void FadeOutImmediate()
        {
            canvasGroup.alpha = 1f;
        }

        public IEnumerator FadeOut(float totalDuration)
        {
            while (canvasGroup.alpha < 1f)
            {
                canvasGroup.alpha = Mathf.Min(canvasGroup.alpha + Time.deltaTime / totalDuration, 1f);
                yield return null;
            }
        }

        public IEnumerator FadeIn(float totalDuration)
        {
            while (canvasGroup.alpha > 0f)
            {
                canvasGroup.alpha = Mathf.Max(canvasGroup.alpha - Time.deltaTime / totalDuration, 0f);
                yield return null;
            }
        }
    }
}

