using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class WInZone : MonoBehaviour
{
    public GameObject WinMenu;
    public GameConrroller System;
    public int SceneIndex;

    public bool WinMenuOnSwitch = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;

        if (!WinMenuOnSwitch)
            SceneManager.LoadScene(SceneIndex); // Переключаем сцену если не предусмотрено отображение винменю

        System.StopGame();
        WinMenu.SetActive(true);
    }
}
