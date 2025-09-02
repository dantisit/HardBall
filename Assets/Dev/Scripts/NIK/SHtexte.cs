using UnityEngine;
using UnityEngine.EventSystems; // ƒл€ работы с курсором

public class SHtexte : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // ѕараметры дрожани€
    public float shakeAmplitude = 2f; // амплитуда дрожани€ в пиксел€х
    public float shakeFrequency = 10f; // частота дрожани€

    // ѕараметры прозрачности
    public float minAlpha = 0.5f; // минимальна€ прозрачность
    public float maxAlpha = 1f;   // максимальна€ прозрачность
    public float fadeSpeed = 5f;  // скорость изменени€ прозрачности

    private CanvasGroup canvasGroup;
    private Vector3 originalPosition;
    private bool isPointerOver = false;

    void Start()
    {
        // ѕолучаем или добавл€ем CanvasGroup дл€ управлени€ прозрачностью
        canvasGroup = GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = gameObject.AddComponent<CanvasGroup>();
        }

        originalPosition = transform.localPosition;
    }

    void FixedUpdate()
    {
        // ѕосто€нное дрожание
        float shakeOffsetX = Mathf.Sin(Time.time * shakeFrequency) * shakeAmplitude;
        float shakeOffsetY = Mathf.Cos(Time.time * shakeFrequency) * shakeAmplitude;
        transform.localPosition = originalPosition + new Vector3(shakeOffsetX, shakeOffsetY, 0);

        // »зменение прозрачности при наведении
        float targetAlpha = isPointerOver ? minAlpha : maxAlpha;
        canvasGroup.alpha = Mathf.Lerp(canvasGroup.alpha, targetAlpha, Time.fixedDeltaTime * fadeSpeed);
    }

    // ќбработчик наведени€ курсора
    public void OnPointerEnter(PointerEventData eventData)
    {
        isPointerOver = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isPointerOver = false;
    }
}