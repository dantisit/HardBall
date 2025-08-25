using UnityEngine;

public class CameraLoop : MonoBehaviour
{
    public string targetTag = "Player"; // Тег объекта игрока
    public Transform targetObject; // Объект, к которому проверяем приближение
    public float approachDistance = 3f; // Расстояние для приближения
    public float minZoom = 5f;          // Минимальный размер камеры
    public float maxZoom = 10f;         // Максимальный размер камеры
    public float smoothSpeed = 2f;      // Скорость плавных движений
    public float slowTimeScale = 0.2f;  // Значение таймскейла при максимальном сближении

    private Transform playerTransform;
    private Camera cam;
    private Vector3 initialPosition; // Исходная позиция камеры

    void Start()
    {
        cam = Camera.main;
        initialPosition = transform.position;
        FindPlayer();
        if (targetObject == null)
        {
            Debug.LogWarning("Не назначен целевой объект для проверки расстояния");
        }
    }

    void FindPlayer()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag(targetTag);
        if (playerObj != null)
        {
            playerTransform = playerObj.transform;
        }
        else
        {
            Debug.LogWarning("Объект с тегом " + targetTag + " не найден");
        }
    }

    void Update()
    {
        if (playerTransform == null || targetObject == null)
        {
            FindPlayer();
            return;
        }

        float distanceToTarget = Vector3.Distance(playerTransform.position, targetObject.position);

        // Определяем целевую позицию камеры:
        Vector3 targetCameraPosition;

        if (distanceToTarget <= approachDistance)
        {
            // Приближаемся к позиции игрока
            targetCameraPosition = new Vector3(playerTransform.position.x, playerTransform.position.y, transform.position.z);
        }
        else
        {
            // Возвращаемся к исходной позиции
            targetCameraPosition = initialPosition;
        }

        // Плавное перемещение камеры
        transform.position = Vector3.Lerp(transform.position, targetCameraPosition, smoothSpeed * Time.deltaTime);

        // Управление zoom (размером orthographicSize)
        float targetSize;

        if (distanceToTarget <= approachDistance)
        {
            float t = Mathf.InverseLerp(approachDistance, 0f, distanceToTarget);
            targetSize = Mathf.Lerp(minZoom, maxZoom, t);

            // Замедляем время по мере приближения
            Time.timeScale = Mathf.Lerp(1f, slowTimeScale, t);
            Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, slowTimeScale);
        }
        else
        {
            targetSize = maxZoom;

            // Восстанавливаем нормальное время
            Time.timeScale = Mathf.Lerp(Time.timeScale, 1f, smoothSpeed * Time.deltaTime);
            Time.timeScale = Mathf.Clamp(Time.timeScale, 0.1f, 1f); // чтобы не было отрицательного или слишком маленького значения
        }

        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetSize, smoothSpeed * Time.deltaTime);
    }
}