using UnityEngine;

public class Bumper : MonoBehaviour
{
    public float forceStrength = 10f; // ���� ������������

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D rb = collision.rigidbody;
        if (rb != null)
        {
            // ������ ����������� �� ������� � �������
            Vector2 direction = collision.transform.position - transform.position;
            direction.Normalize();

            // ���������� ���� � �������
            rb.AddForce(direction * forceStrength, ForceMode2D.Impulse);
        }
    }
}