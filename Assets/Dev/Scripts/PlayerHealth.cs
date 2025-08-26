using UnityEngine;
using UnityEngine.Rendering;

public class PlayerHealth : MonoBehaviour
{
    public GameObject DeathMenu;
    public GameConrroller Game;

    public float MaxHealth;
    [HideInInspector] public float CurrentHealth;

    private Vector3 StartTransform;
    [SerializeField] private GameObject playerTransform;
    public void Damage(float damage) 
    {

        if (CurrentHealth <= 1) 
        {
            Death();
            return;
        }

        CurrentHealth -= damage;

        playerTransform.transform.position = StartTransform;
        
    }

    public void Death() 
    { 
        DeathMenu.SetActive(true);
        Game.StopGame();
    }
    public void Start()
    {
        StartTransform = playerTransform.transform.position;
    }
}
