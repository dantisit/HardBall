using UnityEngine;

public class IsWalk : MonoBehaviour
{
    public Animator animator;
    private Vector3 lastPosition;

    void Start()
    {
        lastPosition = transform.position;
    }

    void FixedUpdate()
    {
        // Проверяем изменение позиции
        float distanceMoved = Vector3.Distance(transform.position, lastPosition);

        if (distanceMoved > 0.001f)
        {
            animator.SetBool("isWalk", true);
        }
        else
        {
            animator.SetBool("isWalk", false);
        }

        lastPosition = transform.position;
    }
}