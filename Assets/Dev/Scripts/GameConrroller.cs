using System;
using System.Net;
using UnityEngine;

public class GameConrroller : MonoBehaviour
{
    [HideInInspector] public bool isStopped = true; // В будущем желательно запретить назначать эту переменную при помощи геттеров и сеттеров

    public void Start()
    {
        ContinueGame();
    }

    public void StopGame() 
    { 
        Time.timeScale = 0;
        isStopped = true;
    }

    public void ContinueGame() 
    {
        Time.timeScale = 1.0f;
        isStopped = false;
    }

    // Ну ещё возможно сюда нужно добавить первичный запуск игры и манипуляции со временем, звуком.
}
