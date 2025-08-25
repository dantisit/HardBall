using UnityEngine;

public class CameraLoop : MonoBehaviour
{
    public string targetTag = "Player"; // ��� ������� ������
    public Transform targetObject; // ������, � �������� ��������� �����������
    public float approachDistance = 3f; // ���������� ��� �����������
    public float minZoom = 5f;          // ����������� ������ ������
    public float maxZoom = 10f;         // ������������ ������ ������
    public float smoothSpeed = 2f;      // �������� ������� ��������
    public float slowTimeScale = 0.2f;  // �������� ���������� ��� ������������ ���������

    private Transform playerTransform;
    private Camera cam;
    private Vector3 initialPosition; // �������� ������� ������

    void Start()
    {
        cam = Camera.main;
        initialPosition = transform.position;
        FindPlayer();
        if (targetObject == null)
        {
            Debug.LogWarning("�� �������� ������� ������ ��� �������� ����������");
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
            Debug.LogWarning("������ � ����� " + targetTag + " �� ������");
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

        // ���������� ������� ������� ������:
        Vector3 targetCameraPosition;

        if (distanceToTarget <= approachDistance)
        {
            // ������������ � ������� ������
            targetCameraPosition = new Vector3(playerTransform.position.x, playerTransform.position.y, transform.position.z);
        }
        else
        {
            // ������������ � �������� �������
            targetCameraPosition = initialPosition;
        }

        // ������� ����������� ������
        transform.position = Vector3.Lerp(transform.position, targetCameraPosition, smoothSpeed * Time.deltaTime);

        // ���������� zoom (�������� orthographicSize)
        float targetSize;

        if (distanceToTarget <= approachDistance)
        {
            float t = Mathf.InverseLerp(approachDistance, 0f, distanceToTarget);
            targetSize = Mathf.Lerp(minZoom, maxZoom, t);

            // ��������� ����� �� ���� �����������
            Time.timeScale = Mathf.Lerp(1f, slowTimeScale, t);
            Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, slowTimeScale);
        }
        else
        {
            targetSize = maxZoom;

            // ��������������� ���������� �����
            Time.timeScale = Mathf.Lerp(Time.timeScale, 1f, smoothSpeed * Time.deltaTime);
            Time.timeScale = Mathf.Clamp(Time.timeScale, 0.1f, 1f); // ����� �� ���� �������������� ��� ������� ���������� ��������
        }

        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetSize, smoothSpeed * Time.deltaTime);
    }
}