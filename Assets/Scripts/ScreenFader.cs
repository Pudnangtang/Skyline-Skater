using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class ScreenFader : MonoBehaviour
{
    public float fadeDuration = 2f;
    private Image panelImage;
    public Action OnFadeComplete; // Callback for when fade is complete

    void Awake()
    {
        panelImage = GetComponent<Image>();
        StartCoroutine(FadeFromBlack());
    }

    public IEnumerator FadeFromBlack()
    {
        float elapsedTime = 0f;
        Color color = panelImage.color;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            color.a = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            panelImage.color = color;
            yield return null;
        }

        OnFadeComplete?.Invoke(); // Invoke the callback
    }
}
