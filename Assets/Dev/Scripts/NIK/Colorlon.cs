using UnityEngine;

public class FillSpriteOnHold : MonoBehaviour
{
    public SpriteRenderer targetSpriteRenderer; // Объект со спрайтом
    public Color fillColor = Color.red;         // Цвет, которым заполняется спрайт
    public float fillSpeed = 1f;                // Скорость заполнения

    private Color originalColor;

    void Start()
    {
        if (targetSpriteRenderer != null)
        {
            originalColor = targetSpriteRenderer.color;
        }
    }

    void Update()
    {
        if (targetSpriteRenderer == null)
            return;

        if (Input.GetKey(KeyCode.Space))
        {
            // Постепенно увеличиваем насыщенность цвета или делаем что-то похожее
            targetSpriteRenderer.color = Color.Lerp(targetSpriteRenderer.color, fillColor, fillSpeed * Time.deltaTime);
        }
        else
        {
            // Возвращаем к исходному цвету, если пробел не удерживается
            targetSpriteRenderer.color = Color.Lerp(targetSpriteRenderer.color, originalColor, fillSpeed * Time.deltaTime);
        }
    }
}