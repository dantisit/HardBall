using Lean.Pool;
using UnityEngine;
using UnityEngine.UIElements;

public class ObjectLiveCounter : MonoBehaviour
{
    [SerializeField] private LeanGameObjectPool EffectPool;
    [SerializeField] private Transform HealthLineTransform;
    [SerializeField] private GameObject HealthLine;
    [SerializeField] private GameObject OpenChest;
    [SerializeField] private GameObject OpenChests;

    public float maxHits = 5f; // ���������� ��������� �� �����������
    private float currentHits = 0f; // ������� ���������

    private float maxWidth; // ������������ ������ ������� ��������

    private void Start()
    {
        if (HealthLineTransform != null)
        {
            maxWidth = HealthLineTransform.localScale.x;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision == null || collision.gameObject == null) return;
        if (!collision.gameObject.CompareTag("Player")) return;

        currentHits++;
        UpdateFill();

        if (currentHits < maxHits) return;

        // ������ ��� �����������
        if (EffectPool != null)
        {
            EffectPool.Spawn(transform.position);
        }

        // �������� �������
        if (OpenChest != null) 
        {
            // ������ �������� ������ � ����������� ��� � ���������
            GameObject newOpenChest = Instantiate(OpenChest, transform);
            newOpenChest.transform.SetParent(OpenChests.transform, worldPositionStays: true);
            newOpenChest.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        } 
         

        // ����� ����� �������� ��������� �������� � �.�.
        transform.parent?.GetComponent<ParentDestroyer>()?.CheckChildren();

        Destroy(gameObject);
    }

    private void UpdateFill()
    {
        if (HealthLine == null || HealthLineTransform == null) return;

        // ���������: ��� ������ ���������, ��� ������ �������
        float t = Mathf.Clamp01(currentHits / maxHits); // 0..1

        // ��������� ������ ���������������
        Vector3 newLocalScale = HealthLineTransform.localScale;
        newLocalScale.x = maxWidth * (1f - t);
        HealthLineTransform.localScale = newLocalScale;

        // �����������: ���� �������� ����, ����� ������ �������
        // HealthLine.SetActive(t < 1f);
        if (HealthLine != null)
        {
            HealthLine.SetActive(t < 1f); // ������ ����� �������� �������
        }
    }
}