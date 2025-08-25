using UnityEngine;

public class HitCounter : MonoBehaviour
{
    public int maxHits = 5; // ���������� ��������� �� �����������
    private int currentHits = 0; // ������� ���������

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            currentHits++;

            if (currentHits >= maxHits)
            {
                Destroy(gameObject);
            }
        }
    }
}