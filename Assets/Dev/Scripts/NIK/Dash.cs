using UnityEngine;

public class Dash : MonoBehaviour
{
    public float forceAmount = 500f;  // Сила толчка
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("На объекте нет Rigidbody2D!");
        }
    }

    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))  // Левая кнопка мыши
        {
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPos.z = 0f;  // Обнуляем Z, так как 2D

            Vector2 direction = (mouseWorldPos - transform.position).normalized;
            rb.AddForce(direction * forceAmount);
        }
    }
}