using UnityEngine;

public class ParentDestroyer : MonoBehaviour
{
    public void CheckChildren () 
    {

        if (transform.childCount != 1) return;

        Destroy(gameObject);
    }
}
