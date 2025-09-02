using UnityEngine;

public class Rotata : MonoBehaviour
{
    // Минимальный и максимальный угол наклона по Z
    public float minAngle = -30f;
    public float maxAngle = 30f;

    // Время полного цикла (подъем и опускание)
    public float cycleTime = 2f;

    private float timer = 0f;

    void Update()
    {
        // Обновляем таймер
        timer += Time.deltaTime;

        // Вычисляем значение синуса для плавного колебания
        float t = (Mathf.Sin((timer / cycleTime) * Mathf.PI * 2) + 1) / 2; // от 0 до 1

        // Интерполируем между min и max
        float angleZ = Mathf.Lerp(minAngle, maxAngle, t);

        // Применяем наклон к объекту
        Vector3 rotation = transform.localEulerAngles;
        rotation.z = angleZ;
        transform.localEulerAngles = rotation;
    }
}
