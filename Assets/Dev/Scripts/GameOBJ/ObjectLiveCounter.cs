using Lean.Pool;
using UnityEngine;

public class ObjectLiveCounter : MonoBehaviour
{
    public LeanGameObjectPool EffectPool;
    public int maxHits = 5; // количество попаданий до уничтожения
    private int currentHits = 0; // текущие попадания
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;
        
            currentHits++;

        if ( !(currentHits >= maxHits) ) return;

            if (EffectPool != null) 
            {
                EffectPool.Spawn(transform.position); 
            }

            // Куда нибудь сюда можно вставить выпадение ресурсов из сундука
            
            transform.parent.GetComponent<ParentDestroyer>()?.CheckChildren(); // Проверяем остались ли дочерние объекты у родительского, если нет - уничтожаем родительский об
            Destroy(gameObject);
    }
}