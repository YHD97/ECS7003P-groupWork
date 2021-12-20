using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Experimental.Rendering.Universal;

public class SettingsController : MonoBehaviour
{
    // Sound Settings
    public Slider masterAudioSlider;
    public Slider musicSlider;
    public Slider effectsSlider;

    // Gameplay Settings
    public Light2D globalLight;
    public Toggle countdownOnStart;

    public void saveSettings()
    {
        // Save Sound Settings
        GameSettings.MainVolume = masterAudioSlider.value;
        GameSettings.MusicVolume = musicSlider.value;
        GameSettings.EffectsVolume = effectsSlider.value;

        // Save Gameplay Settings
        GameSettings.Gamma = globalLight.intensity;
        GameSettings.ShowCountdownOnLevelStart = countdownOnStart.isOn;
    }

    void Start()
    {
        loadSettings();
    }

    public void loadSettings()
    {
        // Save Sound Settings
        masterAudioSlider.value = GameSettings.MainVolume;
        musicSlider.value = GameSettings.MusicVolume;
        effectsSlider.value = GameSettings.EffectsVolume;

        // Save Gameplay Settings
        globalLight.intensity = GameSettings.Gamma;
        countdownOnStart.isOn = GameSettings.ShowCountdownOnLevelStart;
    }

}
