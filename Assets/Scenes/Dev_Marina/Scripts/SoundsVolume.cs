using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundsVolume : MonoBehaviour
{
    public Slider musicSlider;
    public Slider sfxSlider;

    public AudioMixer audioMixer;

    private void Start()
    {
   
        float musicVolume = PlayerPrefs.GetFloat("MusicVolume", 0f);
        float sfxVolume = PlayerPrefs.GetFloat("SFXVolume", 0f);

        SetMusicVolume(musicVolume);
        SetSFXVolume(sfxVolume);

        musicSlider.value = Mathf.Pow(10, musicVolume / 20f); 
        sfxSlider.value = Mathf.Pow(10, sfxVolume / 20f);

        musicSlider.onValueChanged.AddListener(OnMusicSliderChanged);
        sfxSlider.onValueChanged.AddListener(OnSFXSliderChanged);
    }

    private void OnMusicSliderChanged(float value)
    {
        float volume = Mathf.Log10(value) * 20; 
        SetMusicVolume(volume);
    }

    private void OnSFXSliderChanged(float value)
    {
        float volume = Mathf.Log10(value) * 20;
        SetSFXVolume(volume);
    }

    public void SetMusicVolume(float value)
    {
        audioMixer.SetFloat("MusicVolume", value);
        PlayerPrefs.SetFloat("MusicVolume", value);
        PlayerPrefs.Save();
    }

    public void SetSFXVolume(float value)
    {
        audioMixer.SetFloat("SFXVolume", value);
        PlayerPrefs.SetFloat("SFXVolume", value);
        PlayerPrefs.Save();
    }
}
