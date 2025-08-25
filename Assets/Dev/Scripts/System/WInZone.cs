using UnityEngine;
using UnityEngine.SceneManagement;

public class WInZone : MonoBehaviour
{
    public GameObject WinMenu;
    public GameConrroller Controller;
    public int SceneIndex;

    public bool WinMenuOnSwitch = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;

        if (!WinMenuOnSwitch)
            SceneManager.LoadScene(SceneIndex);

        Controller.StopGame();
        WinMenu.SetActive(true);
    }
}
