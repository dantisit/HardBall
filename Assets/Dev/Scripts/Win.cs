using UnityEngine;

public class Win : MonoBehaviour
{
    public GameConrroller Game;
    public GameObject WinMenu;
    [Tooltip("������, ������� ���������� ���������� ��� ������")] public GameObject WinObject;
    public void Update()
    {
        if (WinObject != null) return;

        win();
    }
    public void win() 
    { 
       WinMenu.SetActive(true);
       
       Game.StopGame();
    }
}
