using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : Singleton
{
    [SerializeField] AudioSource audioSource;

    void Update()
    {
        audioSource.volume = PlayerPrefsController.GetMasterVolume();
    }
}
