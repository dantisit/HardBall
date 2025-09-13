using UnityEngine;
using UnityEngine.UI;
using TMPro; // Добавляем

public class SettingsManager : MonoBehaviour
{
    public TMP_Dropdown resolutionDropdown;
    public Toggle fullscreenToggle;
    public TMP_Dropdown graphicsDropdown;

    private Resolution[] resolutions;

    void Start()
    {
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();
        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            resolutionDropdown.options.Add(new TMP_Dropdown.OptionData(option));

            if (Screen.width == resolutions[i].width && Screen.height == resolutions[i].height)
                currentResolutionIndex = i;
        }

        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        fullscreenToggle.isOn = PlayerPrefs.GetInt("Fullscreen", 1) == 1;
        graphicsDropdown.value = PlayerPrefs.GetInt("GraphicsQuality", 2);
    }

    public void ApplySettings()
    {
        int resIndex = resolutionDropdown.value;
        Resolution res = resolutions[resIndex];
        Screen.SetResolution(res.width, res.height, fullscreenToggle.isOn);

        Screen.fullScreen = fullscreenToggle.isOn;

        QualitySettings.SetQualityLevel(graphicsDropdown.value);

        PlayerPrefs.SetInt("ResolutionIndex", resIndex);
        PlayerPrefs.SetInt("Fullscreen", fullscreenToggle.isOn ? 1 : 0);
        PlayerPrefs.SetInt("GraphicsQuality", graphicsDropdown.value);
        PlayerPrefs.Save();
    }
}