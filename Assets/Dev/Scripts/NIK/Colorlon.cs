using UnityEngine;

public class FillSpriteOnHold : MonoBehaviour
{
    public SpriteRenderer targetSpriteRenderer; // ������ �� ��������
    public Color fillColor = Color.red;         // ����, ������� ����������� ������
    public float fillSpeed = 1f;                // �������� ����������

    private Color originalColor;

    void Start()
    {
        if (targetSpriteRenderer != null)
        {
            originalColor = targetSpriteRenderer.color;
        }
    }

    void Update()
    {
        if (targetSpriteRenderer == null)
            return;

        if (Input.GetKey(KeyCode.Space))
        {
            // ���������� ����������� ������������ ����� ��� ������ ���-�� �������
            targetSpriteRenderer.color = Color.Lerp(targetSpriteRenderer.color, fillColor, fillSpeed * Time.deltaTime);
        }
        else
        {
            // ���������� � ��������� �����, ���� ������ �� ������������
            targetSpriteRenderer.color = Color.Lerp(targetSpriteRenderer.color, originalColor, fillSpeed * Time.deltaTime);
        }
    }
}