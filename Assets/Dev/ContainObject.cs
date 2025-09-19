using System.Collections;
using System.Security;
using UnityEngine;

public class ContainObject : MonoBehaviour
{
    [Tooltip("Нужно ли уничтожать контейнер, когда он становится пуст")] 
    public bool DestroyEmptyContainer;
    
    [Tooltip("Нужно ли повторно спавнить дочерние объекты, когда они были уничтожены")] 
    public bool ReloadChild;
    [HideInInspector] public int ChildrenCount;
    private int StartChildrenCount;

    private GameObject child;

    public void Start()
    {
        StartChildrenCount = ChildrenCount;
    }
    private void ChildrenEnable() 
    {
        for (int i = 0; i < StartChildrenCount; i++) 
        {
            child = transform.GetChild(i).gameObject;

            child.SetActive(true);
            child.GetComponent<DestroyableObjects>().ResetObject();
            StartCoroutine(TimelyIndestructible()); // Включаем новому объекту временную неуязвимость

            ChildrenCount = StartChildrenCount;
        }
    }
    public void ChildDestroy(GameObject child) // функция используется внутри ребёнка
    {
        ChildrenCount--;

        if (ChildrenCount == 0 && DestroyEmptyContainer)
            Destroy(gameObject);

        if (ReloadChild == true) 
        {
            child.SetActive(false);
            
            if (ChildrenCount == 0)
                ChildrenEnable();
        } 
        else Destroy(child);
    }

    private IEnumerator TimelyIndestructible()
    {
        child.GetComponent<DestroyableObjects>().IsIndestructible = true;
        yield return new WaitForSeconds(0.1f);
        for (int i = 0; i < StartChildrenCount; i++)
        {
            child = transform.GetChild(i).gameObject;
            child.GetComponent<DestroyableObjects>().IsIndestructible = false;
        }
    }
}
