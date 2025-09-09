using UnityEngine;

public class Bumper : MonoBehaviour
{
    public float ForceOfKnockback = 10f; // сила отталкивания

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D rb = collision.rigidbody;
        if (rb == null) return;

        Vector2 direction = collision.transform.position - transform.position;
        direction.Normalize();

        rb.AddForce(direction * ForceOfKnockback, ForceMode2D.Impulse);
    }
}