using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeIn : MonoBehaviour
{
    public float duration; // ����� ���������� � ��������
    private Graphic uiGraphic;
    private Color originalColor;
    private bool isFading = false;

    void Start()
    {
        uiGraphic = GetComponent<Graphic>();
        if (uiGraphic != null)
        {
            originalColor = uiGraphic.color;
            // �������� � ����������� �����
            Color transparentColor = originalColor;
            transparentColor.a = 0f;
            uiGraphic.color = transparentColor;
        }
        else
        {
            Debug.LogError("������ �� �������� ��������� Graphic (Image, Text � �.�.)");
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

        // ������������, ��� ����� ����� ����� 1 � �����
        Color finalColor = originalColor;
        finalColor.a = 1f;
        uiGraphic.color = finalColor;

        isFading = false;
    }
}