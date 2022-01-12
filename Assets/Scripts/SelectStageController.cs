using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectStageController : MonoBehaviour
{
    [SerializeField] GameObject[] stageButtons;
    LevelLoader levelLoader;
    int stagesUnlocked;
    void Start()
    {
        levelLoader = FindObjectOfType<LevelLoader>();
        stagesUnlocked = PlayerPrefsController.GetReachedStage();
        for (int i = 0; i < stagesUnlocked; i++)
        {
            stageButtons[i].SetActive(true);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            levelLoader.LoadStartScreen();
        }
    }
}
