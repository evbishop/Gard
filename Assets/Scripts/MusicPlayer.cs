using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : Singleton
{
    [SerializeField] AudioSource audioSource;

    void Start()
    {
        audioSource.volume = PlayerPrefsController.GetMasterVolume();
    }

    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }
}
