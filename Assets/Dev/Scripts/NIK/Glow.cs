using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Glow : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image buttonImage; // изображение кнопки
    public Color glowColor = Color.yellow; // цвет свечения
    private Color originalColor;

    void Start()
    {
        if (buttonImage == null)
            buttonImage = GetComponent<Image>();
        originalColor = buttonImage.color;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonImage.color = glowColor; // или добавьте эффект свечения
        // Можно также добавить Outline или другой эффект
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buttonImage.color = originalColor;
    }
}
