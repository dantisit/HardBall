using UnityEngine;

public class IsWalk : MonoBehaviour
{
    public Animator animator;
    public float speed = 5f;

    void FidexUpdate()
    {
        float move = Input.GetAxis("Horizontal"); // или Vertical, в зависимости от управления

        // Движение персонажа
        transform.Translate(Vector3.right * move * speed * Time.fixedDeltaTime);

        // Установка параметра анимации
        if (Mathf.Abs(move) > 0.1f)
        {
            animator.SetBool("isWalk", true);
        }
        else
        {
            animator.SetBool("isWalk", false);
        }
    }
}