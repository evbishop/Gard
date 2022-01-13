using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    [SerializeField] Slider volumeSlider, soundSlider, difficultySlider;
    [SerializeField] float defaultVolume = 0.4f, defaultSound = 0.5f;
    [SerializeField] int defaultDifficulty = 2;

    void Start()
    {
        volumeSlider.value = PlayerPrefsController.GetMasterVolume();
        soundSlider.value = PlayerPrefsController.GetSoundVolume();
        difficultySlider.value = PlayerPrefsController.GetDifficulty();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) SaveAndExit();
    }

    public void SaveAndExit()
    {
        PlayerPrefsController.SetMasterVolume(volumeSlider.value);
        PlayerPrefsController.SetSoundVolume(soundSlider.value);
        PlayerPrefsController.SetDifficulty(Mathf.RoundToInt(difficultySlider.value));
        FindObjectOfType<LevelLoader>().LoadStartScreen();
    }

    public void SetDefaults()
    {
        volumeSlider.value = defaultVolume;
        soundSlider.value = defaultSound;
        difficultySlider.value = defaultDifficulty;
    }
}
