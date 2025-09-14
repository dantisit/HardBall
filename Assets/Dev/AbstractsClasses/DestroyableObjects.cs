using System;
using System.ComponentModel;
using UnityEditor.Timeline;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class DestroyableObjects : MonoBehaviour
{
    [SerializeField] private GameObject HealthBar;
    [SerializeField] private Transform HealthPivot;

    [SerializeField] private GameObject effectPrefab;

    public float maxHits; // количество попаданий до уничтожения

    protected float currentHits; // текущие попадания
    protected float maxWidth; // Максимальная ширина полоски здоровья

    public bool IsIndestructible = false;

    private ContainObject Container;

    protected void Awake ()
    {
        // Определяем ширину полоски здоровья

        if (HealthPivot != null)
        {
            maxWidth = HealthPivot.localScale.x;
        }

        // Считаем объект, если он находится в контейнере
        Container = transform?.parent.GetComponent<ContainObject>();

        if (Container != null)
            Container.ChildrenCount++;

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other == null || other.gameObject == null) return;
        if (!other.gameObject.CompareTag("Player")) return;
        if (IsIndestructible) return; // Проверяем объект на наличие неуязвимости

        currentHits++;
        UpdateFill(); // Обновляем заполнение на полоске ХП

        if (currentHits >= maxHits) // Проверяем кол-во                             
            DestroyObject(); // Уничтожаем объект
    }
    protected void ParentDestroyChecker()
    {
        transform.parent?.GetComponent<ParentDestroyer>()?.CheckChildren();
    }

    protected void UpdateFill()
    {
        if (HealthBar == null || HealthPivot == null) return;

        float t = Mathf.Clamp01(currentHits / maxHits); 

        // Уменьшаем ширину пропорционально
        Vector3 newLocalScale = HealthPivot.localScale;
        newLocalScale.x = maxWidth * (1f - t);
        HealthPivot.localScale = newLocalScale;

        if (HealthBar != null)
        {
            HealthBar.SetActive(t > 0); // скрыть когда достигли полного
        }
    }

    protected virtual void EffectProvide()
    {
        if (effectPrefab != null)
            Instantiate(effectPrefab, transform.position, transform.rotation);
    }
    protected virtual void DestroyObject()
    {
        // Перед базовой реализацией вызываем эффект уничтожения (при наличии)

        if (Container != null) 
            Container.ChildDestroy(gameObject);
        else Destroy(gameObject);
    }

    public virtual void ResetObject() 
    { 
        currentHits = 0;
        UpdateFill();
    }
}
