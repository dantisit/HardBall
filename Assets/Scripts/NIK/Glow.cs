using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Glow : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image buttonImage; // ����������� ������
    public Color glowColor = Color.yellow; // ���� ��������
    private Color originalColor;

    void Start()
    {
        if (buttonImage == null)
            buttonImage = GetComponent<Image>();
        originalColor = buttonImage.color;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonImage.color = glowColor; // ��� �������� ������ ��������
        // ����� ����� �������� Outline ��� ������ ������
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buttonImage.color = originalColor;
    }
}
