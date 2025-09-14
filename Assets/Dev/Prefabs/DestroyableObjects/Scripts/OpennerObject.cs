using UnityEngine;

public class OpennerObject : DestroyableObjects
{
    [SerializeField] private GameObject OpenChestPrefab;
    [SerializeField][Tooltip("������ � ������� ����� ��������� �������� �������")] 

    protected override void DestroyObject()
    {
        EffectProvide(); // ������ ������ �������� �������
        OpenChest(); // ������ ������ ��������� �������
        base.DestroyObject();
        Debug.Log("destroy");
    }

    private void OpenChest() 
    {
        Instantiate(OpenChestPrefab, transform.position, transform.rotation);
    }
}
