using UnityEngine;
using UnityEngine.UI; 

public class ForceOnTrigger : MonoBehaviour
{
    public float chargeSpeed = 10f; 
    public float maxForce = 20f;    
    public Slider forceSlider;      

    private Rigidbody2D playerRigidbody;
    private float currentForce = 0f;
    private bool isCharging = false;

    void Start()
    {
        if (forceSlider != null)
        {
            forceSlider.gameObject.SetActive(false); 
            forceSlider.minValue = 0;
            forceSlider.maxValue = maxForce;
            forceSlider.value = 0;
        }
        else
        {
            Debug.LogWarning("Force Slider �� ��������!");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerRigidbody = other.GetComponent<Rigidbody2D>();
            if (forceSlider != null)
                forceSlider.gameObject.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerRigidbody = null;
            if (forceSlider != null)
                forceSlider.gameObject.SetActive(false); 
            currentForce = 0f; 
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

                if (forceSlider != null)
                    forceSlider.value = currentForce;
            }

            if (Input.GetKeyUp(KeyCode.Space) && isCharging)
            {
                Vector2 forceDirection = Vector2.up; 
                playerRigidbody.AddForce(forceDirection * currentForce, ForceMode2D.Impulse);
                isCharging = false;

                if (forceSlider != null)
                    forceSlider.value = 0;
            }
        }
    }
}