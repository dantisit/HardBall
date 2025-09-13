using UnityEngine;
using UnityEngine.UI;

public class HeartsUI_Auto : MonoBehaviour
{
    public PlayerHealth playerHealth;   
    public GameObject heartPrefab;      
    public Sprite fullHeart;            
    public Sprite emptyHeart;           

    private Image[] hearts;             

    void Start()
    {
        hearts = new Image[(int)playerHealth.MaxHealth];

        for (int i = 0; i < playerHealth.MaxHealth; i++)
        {
            GameObject heart = Instantiate(heartPrefab, transform);

            Image heartImage = heart.GetComponent<Image>();
            hearts[i] = heartImage;
        }
    }

    void Update()
    {
        bool isDead = playerHealth.DeathMenu.activeSelf;

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < Mathf.FloorToInt(playerHealth.CurrentHealth) && !isDead)
                hearts[i].sprite = fullHeart;
            else
                hearts[i].sprite = emptyHeart;
        }
    }
}
