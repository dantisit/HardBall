using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeIn : MonoBehaviour
{
    public float duration; // время проявления в секундах
    private Graphic uiGraphic;
    private Color originalColor;
    private bool isFading = false;

    void Start()
    {
        uiGraphic = GetComponent<Graphic>();
        if (uiGraphic != null)
        {
            originalColor = uiGraphic.color;
            // Начинаем с прозрачного цвета
            Color transparentColor = originalColor;
            transparentColor.a = 0f;
            uiGraphic.color = transparentColor;
        }
        else
        {
            Debug.LogError("Объект не содержит компонент Graphic (Image, Text и т.д.)");
        }
    }

    public void StartFadeIn()
    {
        if (!isFading)
            StartCoroutine(FadeInCoroutine());
    }

    private IEnumerator FadeInCoroutine()
    {
        isFading = true;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Clamp01(elapsedTime / duration);
            Color newColor = originalColor;
            newColor.a = alpha;
            uiGraphic.color = newColor;
            yield return null;
        }

        // Обеспечиваем, что альфа точно равна 1 в конце
        Color finalColor = originalColor;
        finalColor.a = 1f;
        uiGraphic.color = finalColor;

        isFading = false;
    }
}