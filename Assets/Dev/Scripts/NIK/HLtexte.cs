using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HLtexte : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Text buttonText;
    public Color normalColor = Color.white;
    public Color highlightColor = Color.yellow;
    public float colorChangeSpeed = 5f; // скорость плавного изменения цвета

    private Color targetColor;
    private Color currentColor;

    void Start()
    {
        if (buttonText == null)
            buttonText = GetComponent<Text>();
        currentColor = buttonText.color;
        targetColor = normalColor;
        buttonText.color = currentColor;
    }

    void FixedUpdate()
    {
        // Плавно интерполируем текущий цвет к целевому
        currentColor = Color.Lerp(currentColor, targetColor, Time.fixedDeltaTime * colorChangeSpeed);
        buttonText.color = currentColor;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        targetColor = highlightColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        targetColor = normalColor;
    }
}