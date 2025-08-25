using UnityEngine;

public class Partokl : MonoBehaviour
{
    public GameObject targetObject;     // Объект, за которым следим
    public GameObject particleObject;   // Объект с партиклами
    
    private bool targetDestroyed = false;

    void FixedUpdate()
    {
        if (targetObject == null && !targetDestroyed)
        {
            // Когда targetObject уничтожен
            targetDestroyed = true;
            ActivateParticles();
        }
    }

    private void ActivateParticles()
    {
        if (particleObject != null)
        {
            particleObject.SetActive(true);
        }
    }
}