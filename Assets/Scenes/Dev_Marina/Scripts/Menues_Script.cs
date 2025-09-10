using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menues_Script : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject PauseMenuUI;
    public GameObject SettingsUI;
    public GameObject MainMenu;

    private enum SettingsOrigin { None, PauseMenu, MainMenu }
    private SettingsOrigin settingsOrigin = SettingsOrigin.None;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && (MainMenu == null || !MainMenu.activeSelf))
        {
            if (GameIsPaused)
                Resume();
            else
                Pause();
        }
    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void OpenSettingsFromPause()
    {
        PauseMenuUI.SetActive(false);
        SettingsUI.SetActive(true);
        settingsOrigin = SettingsOrigin.PauseMenu;
    }

    public void OpenSettingsFromMainMenu()
    {
        MainMenu.SetActive(false);
        SettingsUI.SetActive(true);
        settingsOrigin = SettingsOrigin.MainMenu;
    }

    public void BackFromSettings()
    {
        SettingsUI.SetActive(false);

        if (settingsOrigin == SettingsOrigin.PauseMenu)
            PauseMenuUI.SetActive(true);
        else if (settingsOrigin == SettingsOrigin.MainMenu)
            MainMenu.SetActive(true);

        settingsOrigin = SettingsOrigin.None;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        GameIsPaused = false;
        SceneManager.LoadScene(0);
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f;
        GameIsPaused = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
