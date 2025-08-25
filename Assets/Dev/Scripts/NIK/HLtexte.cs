using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HLtexte : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Text buttonText;
    public Color normalColor = Color.white;
    public Color highlightColor = Color.yellow;

    void Start()
    {
        if (buttonText == null)
            buttonText = GetComponent<Text>();
        buttonText.color = normalColor;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonText.color = highlightColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buttonText.color = normalColor;
    }
}