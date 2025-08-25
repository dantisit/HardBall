using System.Net;
using UnityEngine;

public class GameConrroller : MonoBehaviour
{
    [HideInInspector] public bool isStopped = true; // � ������� ���������� ��������� ��������� ��� ���������� ��� ������ �������� � ��������

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

    // �� ��� �������� ���� ����� �������� ��������� ������ ���� � ����������� �� ��������, ������.
}
