using UnityEngine;

public class ObjectLiveCounter : MonoBehaviour
{
    public GameObject Effect;
    public int maxHits = 5; // количество попаданий до уничтожения
    private int currentHits = 0; // текущие попадания
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;
        
            currentHits++;

        if ( !(currentHits >= maxHits) ) return;

            Effect.GetComponent<ChestDestroyEffect>()?.Effect();
            transform.parent.GetComponent<ParentDestroyer>()?.CheckChildren();
            Destroy(gameObject);
    }
}