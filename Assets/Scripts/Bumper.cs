using UnityEngine;

public class Bumper : MonoBehaviour
{
    public float forceStrength = 10f; // сила отталкивания

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D rb = collision.rigidbody;
        if (rb != null)
        {
            // Расчет направления от бампера к объекту
            Vector2 direction = collision.transform.position - transform.position;
            direction.Normalize();

            // Применение силы к объекту
            rb.AddForce(direction * forceStrength, ForceMode2D.Impulse);
        }
    }
}