using UnityEditor.Timeline;
using UnityEngine;

public abstract class DestroyableObjects : MonoBehaviour
{
    [SerializeField] private GameObject HealthBar;
    [SerializeField] private Transform HealthPivot;

    [SerializeField] private GameObject effectPrefab;

    public float maxHits; // количество попаданий до уничтожения

    protected float currentHits; // текущие попадания
    protected float maxWidth; // Максимальная ширина полоски здоровья

    protected void Start()
    {
        // Определяем ширину полоски здоровья

        if (HealthPivot != null)
        {
            maxWidth = HealthPivot.localScale.x;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other == null || other.gameObject == null) return;
        if (!other.gameObject.CompareTag("Player")) return;

        currentHits++;
        UpdateFill(); // Обновляем заполнение на полоске ХП

        if (currentHits >= maxHits) // Проверяем кол-во попаданий
            Destroy(); // Уничтожаем объект
    }
    protected void ParentDestroyChecker()
    {
        transform.parent?.GetComponent<ParentDestroyer>()?.CheckChildren();
    }

    protected void UpdateFill()
    {
        if (HealthBar == null || HealthPivot == null) return;

        float t = Mathf.Clamp01(currentHits / maxHits); // 0..1

        // Уменьшаем ширину пропорционально
        Vector3 newLocalScale = HealthPivot.localScale;
        newLocalScale.x = maxWidth * (1f - t);
        HealthPivot.localScale = newLocalScale;

        // Опционально: если достигли нуля, можно скрыть полоску
        // HealthLine.SetActive(t < 1f);
        if (HealthBar != null)
        {
            HealthBar.SetActive(t < 1f); // скрыть когда достигли полного
        }
    }

    protected virtual void EffectProvide()
    {
        if (effectPrefab != null)
            Instantiate(effectPrefab, transform.position, transform.rotation);
    }
    protected virtual void Destroy()
    {
        // Перед базовой реализацией вызываем эффект уничтожения (при наличии)

        ParentDestroyChecker(); // Если родитель пуст, то уничтожаем его
        Destroy(gameObject);

    }

}
