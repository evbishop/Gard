using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsController : MonoBehaviour
{
    const string MASTER_VOLUME_KEY = "master volume";
    const string SOUND_VOLUME_KEY = "sound volume";
    const string DIFFICULTY_KEY = "difficulty";
    const string REACHED_STAGE = "stage";

    const float MIN_VOLUME = 0f;
    const float MAX_VOLUME = 1f;

    const int MIN_DIFFICULTY = 0;
    const int MAX_DIFFICULTY = 4;

    void Start()
    {
        if (GetMasterVolume() == 0f
            && GetSoundVolume() == 0f
            && GetDifficulty() == 0
            && GetReachedStage() == 0)
        {
            SetMasterVolume(0.4f);
            SetSoundVolume(0.5f);
            SetDifficulty(2);
            SetReachedStage(1);
        }
    }

    public static void SetMasterVolume(float volume)
    {
        if (volume >= MIN_VOLUME && volume <= MAX_VOLUME)
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        else
            Debug.LogError("Master volume is out of range");
    }

    public static float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }

    public static void SetSoundVolume(float volume)
    {
        if (volume >= MIN_VOLUME && volume <= MAX_VOLUME)
            PlayerPrefs.SetFloat(SOUND_VOLUME_KEY, volume);
        else
            Debug.LogError("Sound volume is out of range");
    }

    public static float GetSoundVolume()
    {
        return PlayerPrefs.GetFloat(SOUND_VOLUME_KEY);
    }

    public static int GetReachedStage()
    {
        return PlayerPrefs.GetInt(REACHED_STAGE);
    }

    public static void SetReachedStage(int stage)
    {
        PlayerPrefs.SetInt(REACHED_STAGE, stage);
    }

    public static void SetDifficulty(int difficulty)
    {
        if (difficulty >= MIN_DIFFICULTY && difficulty <= MAX_DIFFICULTY)
            PlayerPrefs.SetInt(DIFFICULTY_KEY, difficulty);
        else
            Debug.LogError("Difficulty setting is out of range");
    }

    public static int GetDifficulty()
    {
        return PlayerPrefs.GetInt(DIFFICULTY_KEY);
    }
}
