using Lean.Pool;
using UnityEngine;

public class ObjectLiveCounter : MonoBehaviour
{
    public LeanGameObjectPool EffectPool;
    public int maxHits = 5; // ���������� ��������� �� �����������
    private int currentHits = 0; // ������� ���������
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;
        
            currentHits++;

        if ( !(currentHits >= maxHits) ) return;

            if (EffectPool != null) 
            {
                EffectPool.Spawn(transform.position); 
            }

            // ���� ������ ���� ����� �������� ��������� �������� �� �������
            
            transform.parent.GetComponent<ParentDestroyer>()?.CheckChildren(); // ��������� �������� �� �������� ������� � �������������, ���� ��� - ���������� ������������ ��
            Destroy(gameObject);
    }
}