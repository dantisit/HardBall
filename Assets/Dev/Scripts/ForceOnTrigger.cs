using UnityEngine;
using UnityEngine.UI; // для работы со UI

public class ForceOnTrigger : MonoBehaviour
{
    public float chargeSpeed = 10f; // скорость накопления силы
    public float maxForce = 20f;    // максимальная сила
    public Slider forceSlider;      // ссылка на UI Slider

    private Rigidbody2D playerRigidbody;
    private float currentForce = 0f;
    private bool isCharging = false;

    void Start()
    {
        if (forceSlider != null)
        {
            forceSlider.gameObject.SetActive(false); // скрываем слайдер по умолчанию
            forceSlider.minValue = 0;
            forceSlider.maxValue = maxForce;
            forceSlider.value = 0;
        }
        else
        {
            Debug.LogWarning("Force Slider не назначен!");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerRigidbody = other.GetComponent<Rigidbody2D>();
            if (forceSlider != null)
                forceSlider.gameObject.SetActive(true); // показываем слайдер
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerRigidbody = null;
            if (forceSlider != null)
                forceSlider.gameObject.SetActive(false); // скрываем слайдер
            currentForce = 0f; // сбрасываем заряд
            isCharging = false;
        }
    }

    void Update()
    {
        if (playerRigidbody != null)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isCharging = true;
                currentForce = 0f;
            }

            if (Input.GetKey(KeyCode.Space) && isCharging)
            {
                currentForce += chargeSpeed * Time.deltaTime;
                if (currentForce > maxForce)
                    currentForce = maxForce;

                // обновляем значение слайдера
                if (forceSlider != null)
                    forceSlider.value = currentForce;
            }

            if (Input.GetKeyUp(KeyCode.Space) && isCharging)
            {
                Vector2 forceDirection = Vector2.up; // направление силы
                playerRigidbody.AddForce(forceDirection * currentForce, ForceMode2D.Impulse);
                isCharging = false;

                // сбрасываем значение слайдера после применения силы
                if (forceSlider != null)
                    forceSlider.value = 0;
            }
        }
    }
}