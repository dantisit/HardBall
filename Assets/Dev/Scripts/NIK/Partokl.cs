using UnityEngine;

public class Partokl : MonoBehaviour
{
    public GameObject targetObject;     // ������, �� ������� ������
    public GameObject particleObject;   // ������ � ����������
    
    private bool targetDestroyed = false;

    void FixedUpdate()
    {
        if (targetObject == null && !targetDestroyed)
        {
            // ����� targetObject ���������
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