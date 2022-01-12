using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsReset : MonoBehaviour
{
    void Start()
    {
        PlayerPrefs.DeleteAll();
    }
}
