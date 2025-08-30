using Lean.Pool;
using UnityEngine;
using UnityEngine.UIElements;

public class ObjectLiveCounter : MonoBehaviour
{
    [SerializeField] private LeanGameObjectPool EffectPool;
    [SerializeField] private Transform HealthLineTransform;
    [SerializeField] private GameObject HealthLine;
    [SerializeField] private GameObject OpenChest;
    [SerializeField] private GameObject OpenChests;

    public float maxHits = 5f; // количество попаданий до уничтожения
    private float currentHits = 0f; // текущие попадания

    private float maxWidth; // Максимальная ширина полоски здоровья

    private void Start()
    {
        if (HealthLineTransform != null)
        {
            maxWidth = HealthLineTransform.localScale.x;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision == null || collision.gameObject == null) return;
        if (!collision.gameObject.CompareTag("Player")) return;

        currentHits++;
        UpdateFill();

        if (currentHits < maxHits) return;

        // Эффект при уничтожении
        if (EffectPool != null)
        {
            EffectPool.Spawn(transform.position);
        }

        // Открытие сундука
        if (OpenChest != null) 
        {
            // Создаём открытый сундук и привязываем его к остальным
            GameObject newOpenChest = Instantiate(OpenChest, transform);
            newOpenChest.transform.SetParent(OpenChests.transform, worldPositionStays: true);
            newOpenChest.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        } 
         

        // Здесь можно вставить выпадение ресурсов и т.д.
        transform.parent?.GetComponent<ParentDestroyer>()?.CheckChildren();

        Destroy(gameObject);
    }

    private void UpdateFill()
    {
        if (HealthLine == null || HealthLineTransform == null) return;

        // Визуально: чем больше попаданий, тем меньше полоска
        float t = Mathf.Clamp01(currentHits / maxHits); // 0..1

        // Уменьшаем ширину пропорционально
        Vector3 newLocalScale = HealthLineTransform.localScale;
        newLocalScale.x = maxWidth * (1f - t);
        HealthLineTransform.localScale = newLocalScale;

        // Опционально: если достигли нуля, можно скрыть полоску
        // HealthLine.SetActive(t < 1f);
        if (HealthLine != null)
        {
            HealthLine.SetActive(t < 1f); // скрыть когда достигли полного
        }
    }
}