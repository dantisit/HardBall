using UnityEngine;

public class ChestOpenner : DestroyableObjects
{
    [SerializeField] private GameObject OpenChestPrefab;
    [SerializeField][Tooltip("Объект в котором будут храниться открытые сундуки")] 
    private GameObject OpenChestFolder;

    protected override void Destroy()
    {
        EffectProvide(); // Создаём эффект открытия сундука
        OpenChest(); // Создаём префаб открытого сундука
        base.Destroy();

    }

    private void OpenChest() 
    {
        GameObject newOpenChest = Instantiate(OpenChestPrefab, transform);
        newOpenChest.transform.SetParent(OpenChestFolder.transform, worldPositionStays: true);
        newOpenChest.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }
}
