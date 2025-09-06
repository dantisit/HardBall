using UnityEngine;

public class UpDownCamera : MonoBehaviour
{
    public Transform target;      // Объект, за которым следим
    public float minY = -10f;     // Нижняя граница по Y
    public float maxY = 10f;      // Верхняя граница по Y

    private float initialX;       // Фиксированная позиция камеры по X
    private float initialZ;       // Фиксированная позиция камеры по Z

    void Start()
    {
        if (target == null)
        {
            Debug.LogError("CameraFollowY: target не назначен!");
            enabled = false;
            return;
        }

        // Запоминаем начальные координаты камеры по X и Z
        initialX = transform.position.x;
        initialZ = transform.position.z;
    }

    void LateUpdate()
    {
        // Получаем позицию цели
        float targetY = target.position.y;

        // Ограничиваем позицию по Y в заданных пределах
        float clampedY = Mathf.Clamp(targetY, minY, maxY);

        // Обновляем позицию камеры: X и Z фиксированы, Y — по цели с ограничением
        transform.position = new Vector3(initialX, clampedY, initialZ);
    }
}